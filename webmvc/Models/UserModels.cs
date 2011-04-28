using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Epiworx.Business;
using Epiworx.Core;

namespace Epiworx.WebMvc.Models
{
    public class UserIndexModel : UserListModel
    {
    }

    public class UserListModel : ModelBase
    {
        public IQueryable<INote> Notes { get; set; }
        public IQueryable<IUser> Users { get; set; }
    }

    public class UserFormModel : ModelBusinessBase
    {
        public int UserId { get; set; }

        [DisplayName("Name:")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("First name:")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [DisplayName("Last name:")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [DisplayName("Email:")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DisplayName("Role:")]
        [IntegerRequired(ErrorMessage = "Role is required")]
        public int Role { get; set; }

        [DisplayName("Enter password:")]
        public string Password { get; set; }

        [DisplayName("Enter the password again:")]
        public string PasswordConfirmation { get; set; }

        [DisplayName("This user is active")]
        public bool IsActive { get; set; }

        [DisplayName("This user is archived")]
        public bool IsArchived { get; set; }

        public IEnumerable<NameValueItem> Roles { get; set; }
        public NoteListModel NoteListModel { get; set; }
    }
}