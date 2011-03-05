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
    public class AttachmentIndexModel : AttachmentListModel
    {
    }

    public class AttachmentListModel : ModelListBase
    {
        public ISource Source { get; set; }
        public IQueryable<IAttachment> Attachments { get; set; }
    }

    public class AttachmentFormModel : ModelBusinessBase
    {
        public int AttachmentId { get; set; }
        public SourceType SourceType { get; set; }
        public int SourceId { get; set; }

        [DisplayName("Name:")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DisplayName("File Type:")]
        [Required(ErrorMessage = "FileType is required")]
        public string FileType { get; set; }

        [DisplayName("File Data:")]
        [Required(ErrorMessage = "FileData is required")]
        public HttpPostedFileBase FileData { get; set; }

        public string CreatedByName { get; set; }
        public string CreatedByEmail { get; set; }
        public DateTime CreatedDate { get; set; }

        public AttachmentFormModel()
        {
        }

        public AttachmentFormModel(IAttachment note)
        {
            Csla.Data.DataMapper.Map(note, this, true);
        }
    }
}