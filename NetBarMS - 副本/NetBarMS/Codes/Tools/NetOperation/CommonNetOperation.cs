using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.NetOperation
{
    /// <summary>
    /// 公用操作类
    /// </summary>
    class CommonNetOperation
    {
        #region 获取员工评价列表
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="resultBlock">反馈结果</param>
        /// <param name="name">图片名称</param>
        /// <param name="data">图片数据</param>
        public static void UploadPicture(DataResultBlock resultBlock,string name, string data)
        {

            CSUploadPicture.Builder picture = new CSUploadPicture.Builder();
            picture.Name = name;
            picture.Data = data;  
                                
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsUpload = picture.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_UPLOAD_PICTURE,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

    }
}
