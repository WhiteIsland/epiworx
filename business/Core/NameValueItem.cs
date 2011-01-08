using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Core
{
    [Serializable]
    public class NameValueItem : IComparer<NameValueItem>, IComparable<NameValueItem>
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NameValueItem))
            {
                return base.Equals(obj);
            }

            return this.Value.Equals(obj);
        }

        public bool Equals(NameValueItem obj)
        {
            return this.Value.Equals(obj.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public NameValueItem()
        {
        }

        public NameValueItem(string text, object value)
        {
            this.Name = text;
            this.Value = value;
        }

        public int Compare(NameValueItem objA, NameValueItem objB)
        {
            if (objA == null & objB == null)
            {
                return 0;
            }

            if (objA == null)
            {
                return 1;
            }

            if (objB == null)
            {
                return 2;
            }

            return string.Compare(objA.Value.ToString(), objB.Value.ToString());
        }

        public int CompareTo(NameValueItem obj)
        {
            if (obj == null)
            {
                return 1;
            }

            return string.Compare(this.Value.ToString(), obj.Value.ToString());
        }
    }
}
