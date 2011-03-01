using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class NoteInfoList
    {
        internal static NoteInfoList FetchNoteInfoList(NoteCriteria criteria)
        {
            return Csla.DataPortal.Fetch<NoteInfoList>(criteria);
        }
    }
}
