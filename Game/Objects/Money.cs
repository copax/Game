using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class Money
    {
        public MoneyType MyType { get; set; }
        public int Amount { get; set; }
    }

    public enum MoneyType
    {
        Gold = 1
    };
}
