using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Office.Models
{
    public class EnumModel
    { 
        public enum Salutations
        {
            [StringValue("Mr")]
            Mr = 1,
            [StringValue("Mrs")]
            Mrs = 2,
            [StringValue("Miss")]
            Miss = 3
        }

        public enum Gender
        {
            [StringValue("Male")]
            Male = 1,
            [StringValue("Female")]
            Female = 2
        }

        public enum Action
        {
            [StringValue("Close")]
            Close = 1,
            [StringValue("Forward")]
            Forward = 2,
            [StringValue("Reply")]
            Reply = 3
        }

        public enum Priority
        {
            [StringValue("High")]
            High = 1,
            [StringValue("Low")]
            Low = 2,
            [StringValue("Medium")]
            Medium = 3,
            [StringValue("Extremely Urgent")]
            ExtremelyUrgent = 4
        }

        public class StringValueAttribute : System.Attribute
        {

            private string _value;

            public StringValueAttribute(string value)
            {
                _value = value;
            }

            public string Value
            {
                get { return _value; }
            }

        }
    }
}