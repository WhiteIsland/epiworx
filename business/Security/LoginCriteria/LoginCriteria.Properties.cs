using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;

namespace Epiworx.Security
{
    public partial class LoginCriteria
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsGuest { get; set; }
    }
}
