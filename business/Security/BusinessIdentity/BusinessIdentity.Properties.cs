using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Security;
using Epiworx.Business;

namespace Epiworx.Security
{
    public partial class BusinessIdentity
    {
        public int UserId { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Email { get; internal set; }
        public bool IsGuest { get; internal set; }
    }
}
