using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Core
{
    public class NameValueItemCollection : List<NameValueItem>
    {
        public NameValueItem this[object value]
        {
            get { return this.FirstOrDefault(child => child.Value.Equals(value)); }
        }

        public NameValueItemCollection()
        {

        }

        public NameValueItemCollection(IEnumerable list, string displayMember, string valueMember)
        {
            foreach (var item in list)
            {
                object text = item.GetType().GetProperty(displayMember).GetValue(item, null);
                object value = item.GetType().GetProperty(valueMember).GetValue(item, null);

                if (!this.Contains(value))
                {
                    this.Add(new NameValueItem(text.ToString(), value));
                }
            }
        }

        public NameValueItem Add(object value, string text)
        {
            var child = new NameValueItem
            {
                Value = value,
                Name = text
            };

            this.Add(child);

            return child;
        }

        public bool Contains(object value)
        {
            return this.Any(child => child.Value.Equals(value));
        }

        public void Remove(object obj)
        {
            foreach (var child in this)
            {
                if (obj.GetType() == typeof(NameValueItem))
                {
                    if (child.Equals((NameValueItem)obj))
                    {
                        base.Remove(child);
                        break;
                    }
                }
                else
                {
                    if (child.Equals(obj))
                    {
                        base.Remove(child);
                        break;
                    }
                }
            }
        }
    }
}
