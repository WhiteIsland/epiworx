using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Core.Messenger
{
    public interface IMessenger
    {
        string Message { get; set; }
        bool Send();
    }
}
