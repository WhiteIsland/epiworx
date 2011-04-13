using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class UserData
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserData()
        {
        }

        public UserData(User user)
            : this()
        {
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.Email = user.Email;
        }
    }
}