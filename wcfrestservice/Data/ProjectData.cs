using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Epiworx.Data;

namespace Epiworx.WcfRestService
{
    public class ProjectData
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public UserData CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<NoteData> Notes { get; set; }

        public ProjectData()
        {
            this.Notes = new List<NoteData>();
        }

        public ProjectData(Project project)
            : this()
        {
            if (project == null)
            {
                return;
            }

            this.ProjectId = project.ProjectId;
            this.Name = project.Name;
            this.Description = project.Description;
            this.IsActive = project.IsActive;
            this.CreatedBy = new UserData(project.CreatedByUser);
            this.CreatedDate = project.CreatedDate;
        }
    }
}
