using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class NoteInfo
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Body);
    }

        internal static NoteInfo FetchNoteInfo(Data.Note data)
        {
            var result = new NoteInfo();
            result.Fetch(data);
            return result;
        }
    }
}
