using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class AttachmentInfo
    {
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        internal static AttachmentInfo FetchAttachmentInfo(Data.Attachment data)
        {
            var result = new AttachmentInfo();
            result.Fetch(data);
            return result;
        }
    }
}
