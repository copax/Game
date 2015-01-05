using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class Name
    {
        public string GivenName { get; private set; }

        public Name(string newName)
        {
            GivenName = newName;
        }
    }
}
