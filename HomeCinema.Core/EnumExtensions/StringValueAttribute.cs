using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.EnumExtensions
{
    public class StringValueAttribute : System.Attribute
    {
        private string value;

        public StringValueAttribute(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }
    }
}
