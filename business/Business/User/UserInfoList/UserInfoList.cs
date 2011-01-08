using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class UserInfoList : Csla.ReadOnlyListBase<UserInfoList, UserInfo>
    {
        private UserInfoList()
        {
        }
    }
}
