using System;
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
    public delegate void RefreshUIHandle();
    // 连接结果回调
    public delegate void ConnectResultBlock();
    //关闭窗体回调
    public delegate void CloseFormHandle();
    //关闭窗体回调

    /// <summary>
    /// 页书改变处理
    /// </summary>
    /// <param name="current">当前的页数</param>
    /// <param name="pageSize">页显示个数</param>
    public delegate void PageChangedHandle(int current);

    #endregion
}
