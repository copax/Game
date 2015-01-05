using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class Size
    {
        public SizeType MySizeType { get; private set; }

        public Size(SizeType newSizeType)
        {
            MySizeType = newSizeType;
        }
    }

    public enum SizeType
    {
        Medium = 1
    };
}
