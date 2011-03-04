using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class AttachmentInfoList
    {
        internal static AttachmentInfoList FetchAttachmentInfoList(AttachmentCriteria criteria)
        {
            return Csla.DataPortal.Fetch<AttachmentInfoList>(criteria);
        }
    }
}
