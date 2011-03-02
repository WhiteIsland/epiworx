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
    public class NoteIndexModel : NoteListModel
    {
    }

    public class NoteListModel : ModelListBase
    {
        public ISource Source { get; set; }
        public IQueryable<INote> Notes { get; set; }
    }

    public class NoteFormModel : ModelBusinessBase
    {
        public int NoteId { get; set; }
        public SourceType SourceType { get; set; }
        public int SourceId { get; set; }

        [DisplayName("Body:")]
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        public string CreatedByName { get; set; }
        public string CreatedByEmail { get; set; }
        public DateTime CreatedDate { get; set; }

        public NoteFormModel()
        {
        }

        public NoteFormModel(INote note)
        {
            Csla.Data.DataMapper.Map(note, this, true);
        }
    }
}