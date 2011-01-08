using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core.Messenger;

namespace Epiworx.Tests.Helpers
{
    public class EmptyMessenger : IMessenger
    {
        public string Message { get; set; }

        public bool Send()
        {
            return true;
        }

        public EmptyMessenger()
        {
            this.Message = string.Empty;
        }
    }
}
