using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class GameMenu
    {
        Dictionary<ConsoleKey, string> OverlandMenu { get; set; }
        Dictionary<ConsoleKey, string> BattleMenu { get; set; }

        public GameMenu()
        {
            BuildOverlandMenu();
            BuildBattleMenu();
        }

        public void Render(GameMenuType menuType)
        {
            Dictionary<ConsoleKey, string> menuToRender = null;

            switch(menuType)
            {
                case GameMenuType.Overland:
                    menuToRender = OverlandMenu;
                    break;

                case GameMenuType.Battle:
                    menuToRender = BattleMenu;
                    break;
            }

            int initialLeft = Console.CursorLeft;

            foreach(string value in menuToRender.Values)
            {
                Console.Write(value);
                Console.SetCursorPosition(initialLeft, Console.CursorTop + 1);
            }
        }

        public bool IsValidInput(ConsoleKey input, GameMenuType menuType)
        {
            Dictionary<ConsoleKey, string> validationMenu = null;

            switch (menuType)
            {
                case GameMenuType.Battle:
                    validationMenu = BattleMenu;
                    break;

                case GameMenuType.Overland:
                    validationMenu = OverlandMenu;
                    break;
            }

            return validationMenu.ContainsKey(input);
        }

        private void BuildOverlandMenu()
        {
            OverlandMenu = new Dictionary<ConsoleKey, string>();
            OverlandMenu.Add(ConsoleKey.UpArrow, " ↑ North");
            OverlandMenu.Add(ConsoleKey.DownArrow, " ↓ South");
            OverlandMenu.Add(ConsoleKey.LeftArrow, " ← West");
            OverlandMenu.Add(ConsoleKey.RightArrow, " → East");
        }

        private void BuildBattleMenu()
        {
            BattleMenu = new Dictionary<ConsoleKey, string>();
            BattleMenu.Add(ConsoleKey.A, " A Attack");
            BattleMenu.Add(ConsoleKey.R, " R Retreat");
        }
    }

    public enum GameMenuType
    {
        Overland = 1,
        Battle = 2
    }
}
