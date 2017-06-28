using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{

    //当前管理员的管理
    class CurrentStaffManage
    {
        private static CurrentStaffManage _manage;
        private SCAccountInfo staffInfo;

        public static CurrentStaffManage Manage()
        {
            if(_manage == null)
            {
                _manage = new CurrentStaffManage();
            }
            return _manage;
        }
        public void UpdateStaffInfo(SCAccountInfo info)
        {
            this.staffInfo = new SCAccountInfo.Builder(info).Build();
        }
        public Int32 GetCurrentStaffId()
        {
            if(this.staffInfo == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(this.staffInfo.Role.Roleid);
            }
        }

    }
}
