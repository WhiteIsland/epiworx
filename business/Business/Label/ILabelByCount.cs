using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface ILabelByCount
    {
        string Name { get; }
        int Quantity { get; }
    }
}
