using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class UserInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static UserInfo FetchUserInfo(Data.User data)
        {
            var result = new UserInfo();
            result.Fetch(data);
            return result;
        }
    }
}
