﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{
    #region Delegate
    // 接受服务器数据回调代理
    public delegate void DataResultBlock(ResultModel result);
    //UI回调代理
    public delegate void UIHandleBlock();
    // 连接结果回调
    public delegate void ConnectResultBlock();
    //关闭窗体回调
    public delegate void CloseFormHandle();


    #endregion
}