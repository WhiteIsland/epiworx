using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IUser
    {
        int UserId { get; }
        string FirstName { get; }
        string LastName { get; }
        string Name { get; }
        string Salt { get; }
        string Password { get; }
        string Email { get; }
        Role Role { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        string Notes { get; }
        int ModifiedBy { get; }
        string ModifiedByName { get; }
        DateTime ModifiedDate { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
