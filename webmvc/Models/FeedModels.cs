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
    public class FeedIndexModel : FeedListModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserDisplayName { get; set; }
        public string Date { get; set; }
    }

    public class FeedListModel : ModelListBase
    {
        public IEnumerable<IFeed> Feeds { get; set; }
        public IEnumerable<IUser> Users { get; set; }
    }
}