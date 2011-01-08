using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    [Serializable]
    public partial class Category : Csla.BusinessBase<Category>, ICategory
    {
        private Category()
        {
        }
    }
}
