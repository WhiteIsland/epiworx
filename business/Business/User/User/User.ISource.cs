using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class User : ISource
    {
        public SourceType SourceType
        {
            get { return Business.SourceType.User; }
        }

        public int SourceId
        {
            get { return this.UserId; }
        }
    }
}
