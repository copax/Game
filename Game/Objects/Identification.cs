using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class Identification
    {
        public Guid UniqueID { get; set; }

        public Identification()
        {
            UniqueID = Guid.NewGuid();
        }
    }
}