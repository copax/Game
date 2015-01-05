using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class Attribute
    {
        public int AttributeValue { get; set; }
        public AttributeType AttributeName { get; set; }

        public int Bonus()
        {
            return 0;
        }
    }

    public enum AttributeType
    {
        Strength = 1
    };
}
