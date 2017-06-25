﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Google.ProtocolBuffers;
using System.Windows.Forms;

namespace NetBarMS.Codes.Tools
{
    class NetMessageManage
    {


        private Socket clientSocket;
        private static NetMessageManage _instance;
        private const string ipString = "jorkenw.gnway.org";
        private const int port = 8465;

        #region
        // 接受回调代理
        public delegate void DataResultBlock(ResultModel result);
        public event DataResultBlock ResultBlockHandle;

        // 连接结果回调
        public delegate void ConnectResultBlock();
        public event ConnectResultBlock ConnectBlockHandle;
        
        //UI回调代理
        public delegate void UIHandleBlock();
        #endregion

        public static NetMessageManage Manager(ConnectResultBlock connect)
        {
            if (_instance == null)
            {
                _instance = new NetMessageManage();
                _instance.ConnectSever();
                _instance.ConnectBlockHandle += connect;
            }
            return _instance;
        }
        public static NetMessageManage Manager()
        {
            if(_instance == null)
            {
                _instance = new NetMessageManage();
                _instance.ConnectSever();
            }
            return _instance;
        }


        /// <summary>
        /// 连接服务器
        /// </summary>
        private void ConnectSever()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.BeginConnect(ipString, port, new AsyncCallback(ConnectCallback), clientSocket);
        }

        /// <summary>
        /// 连接服务器回调
        /// </summary>
        /// <param name="asyncConnect">Async connect.</param>
        private void ConnectCallback(IAsyncResult asyncConnect)
        {
            //这里做一个超时的监测，当连接超过5秒还没成功表示超时  
            bool success = asyncConnect.AsyncWaitHandle.WaitOne(100, true);
            if (!success)
            {
                //超时  
                //clientSocket.Close();
                Console.WriteLine("connect Time Out");
            }
            else
            {
                System.Console.WriteLine("Connect success");
                Thread thread = new Thread(ReceiveData);
                thread.Start();
                //发送连接成功回调
                if(this.ConnectBlockHandle!=null)
                {
                    this.ConnectBlockHandle();
                }
            }



        }


        //循环接收数据
        private void ReceiveData()
        {
            
            //不断接收服务器发来的数据
            while (true)
            {

                if (!clientSocket.Connected)
                {
                    Console.WriteLine("断开连接");
                    break;
                }

                //存储数据头的所有字节数 varint32:1419 1417
                byte[] recvBytesHead = new byte[1024];
                int len = clientSocket.Receive(recvBytesHead);

                if (len >0)
                {
                    try
                    {
                        CodedInputStream inputStream = CodedInputStream.CreateInstance(recvBytesHead);
                        int varint32 = (int)inputStream.ReadRawVarint32();
                        if (varint32 >= len)
                        {
                            byte[] newResult = new byte[varint32];
                            int newLen = clientSocket.Receive(newResult, 0, varint32, SocketFlags.None);
                            //System.Console.WriteLine("varint32:" + varint32);
                            byte[] resArr = new byte[varint32 + len];
                            recvBytesHead.CopyTo(resArr, 0);
                            newResult.CopyTo(resArr, recvBytesHead.Length);
                            ReceiveDataHandle(resArr);
                        }
                        else
                        {
                            ReceiveDataHandle(recvBytesHead);


                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("接收服务器数据出错");
                        System.Console.WriteLine("接收服务器数据出错");
                    }


                }


            }
        }

        //接收数据处理
        private void ReceiveDataHandle(byte[] result)
        {
            try
            {
                CodedInputStream inputStream = CodedInputStream.CreateInstance(result);
                int varint32 = (int)inputStream.ReadRawVarint32(); 
                byte[] body = inputStream.ReadRawBytes(varint32);
                MessagePack pack = MessagePack.ParseFrom(body);
                if (ResultBlockHandle != null)
                {
                    ResultBlockHandle(new ResultModel()
                    {
                        pack = pack,
                        error = 0,
                    });
                }

            }
            catch (Exception exp)
            {
                System.Console.WriteLine("ReceiveMessage Exception:" + exp.ToString());
            }

        }
     
        // 发送数据1
        private void SendMsg(IMessageLite value)
        {

            //		resultBlock = result;

            if (!IsConnected())
            {
                System.Console.WriteLine("服务器未连接");
                return;
            }
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    CodedOutputStream outputStream = CodedOutputStream.CreateInstance(stream);
                    //一定要去看它的代码实现，
                    outputStream.WriteMessageNoTag(value);
                    /**
                    * WriteMessageNoTag 等价于 WriteVarint32, WriteByte(byte[])
                    * 也就是：变长消息头 + 消息体
                    */
                    outputStream.Flush();

                    byte[] data = stream.ToArray();

                    if (!IsConnected())
                    {
                        //					clientSocket.Close();  
                        return;
                    }
                    //发送数据
                    clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);
                }

            }
            catch (Exception exp)
            {
                //Debug.Log("send message error" + exp.ToString());

            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="resultBlock">Result block.</param>
        public void SendMsg(IMessageLite value, DataResultBlock resultBlock)
        {
            ResultBlockHandle += resultBlock;
            SendMsg(value);
        }

        //发送数据结果回调
        private void SendCallback(IAsyncResult asyncConnect)
        {

            bool success = asyncConnect.AsyncWaitHandle.WaitOne(5000, true);
            if (!success)
            {
                //			clientSocket.Close ();  
                System.Console.WriteLine("Failed to SendMessage server.");
            }
            else
            {
                System.Console.WriteLine("SendSuccess");

            }
        }
        //是否连接中
        private bool IsConnected()
        {
            return clientSocket.Connected;
        }

        //再次连接服务器
        public void AgainConnect()
        {

        }

        /// <summary>
        /// 移除结果回调
        /// </summary>
        /// <param name="result"></param>
        public void RemoveResultBlock(DataResultBlock result)
        {
            this.ResultBlockHandle -= result;

        }



    }

    /// <summary>
    /// 结果Model
    /// </summary>
    public class ResultModel
    {
        public int error = 0;   // 0/1 无错误、有错误
        public MessagePack pack;
    }
}
