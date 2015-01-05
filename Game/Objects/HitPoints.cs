using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class HitPoints
    {
        public int CurrentHitPoints { get; private set; }

        public HitPoints(int startingHitPoints)
        {
            CurrentHitPoints = startingHitPoints;
        }

        public void TakeDamage(int amount)
        {
            CurrentHitPoints -= amount;
        }

        public void HealDamage(int amount)
        {
            CurrentHitPoints += amount;
        }

        public bool IsDead()
        {
            return CurrentHitPoints <= 0;
        }
    }
}
