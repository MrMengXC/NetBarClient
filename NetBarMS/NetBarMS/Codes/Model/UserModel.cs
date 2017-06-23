using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Model
{
    class UserModel
    {

        public string name;         //姓名
        public string cdcard;       //身份证
        public string money;        //Money
        public string r_date;       //注册日期

        /// <summary>
        /// 获取id
        /// </summary>
        public void GetId()
        {

        }
    }
    /// <summary>
    /// 会员用户 model
    /// </summary>
    class MemberUserModel
    {

        public string lev;  //等级



    }
    /// <summary>
    /// 临时用户 model
    /// </summary>
    class TemUserModel
    {



    }

}
