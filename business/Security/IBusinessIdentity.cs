using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Epiworx.Security
{
    public interface IBusinessIdentity : IIdentity
    {
        int UserId { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }
        bool IsGuest { get; }
    }
}
