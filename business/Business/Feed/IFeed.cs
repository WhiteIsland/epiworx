using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IFeed
    {
        int FeedId { get; }
        string Type { get; }
        string Data { get; }
        int CreatedBy { get; }
        string CreatedByName { get; }
        DateTime CreatedDate { get; }
    }
}
