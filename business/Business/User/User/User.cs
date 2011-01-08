using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class User : Csla.BusinessBase<User>, IUser
    {
        private User()
        {
        }
    }
}
