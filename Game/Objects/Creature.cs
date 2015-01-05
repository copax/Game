using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Game.Interfaces;

namespace Game.Objects
{
    public class Creature : IDisplayable
    {
        public Identification MyID { get; set; }
        public Hand MyLeftHand { get; set; }
        public Hand MyRightHand { get; set; }
        public HitPoints MyHitPoints { get; set; }
        public Name MyName { get; set; }
        public Size MySize { get; set; }
        public Armor MyArmor { get; set; }
        public Purse MyPurse { get; set; }
        public Point MyScreenPosition { get; set; }
        public Point MyWorldPosition { get; set; }
        public char MyIcon { get; set; }

        public Creature(int CreatureHitPoints, string CreatureName, SizeType CreatureSize, char CreatureIcon)
        {
            Initialize();
            MyHitPoints = new HitPoints(CreatureHitPoints);
            MyName = new Name(CreatureName);
            MySize = new Size(CreatureSize);
            MyIcon = CreatureIcon;
        }

        private void Initialize()
        {
            MyID = new Identification();
            MyArmor = new Armor();
            MyPurse = new Purse();
            MyScreenPosition = new Point();
            MyWorldPosition = new Point();
            MyRightHand = new Hand();
            MyLeftHand = new Hand();
        }

        public void Render()
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.SetCursorPosition(MyScreenPosition.X, MyScreenPosition.Y);
            Console.Write(MyIcon);
            Console.SetCursorPosition(currentLeft, currentTop);
        }
    }
}
