using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserInfoList
    {
        internal static UserInfoList FetchUserInfoList(UserCriteria criteria)
        {
            return Csla.DataPortal.Fetch<UserInfoList>(criteria);
        }
    }
}
