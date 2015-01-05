using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game.Objects
{
    public class GameEngine
    {
        private static int BoardHeight = 15;
        private static int BoardWidth = 50;
        private static int MenuWidth = 15;
        private static string DividerRow = string.Format("+{0}+", new string('-', BoardWidth + MenuWidth + 1));
        private static string FieldRow = string.Format("|{0}|{1}|", new string(' ', BoardWidth), new string(' ', MenuWidth));

        private GameMenuType MenuType { get; set; }
        private GameMenu Menu { get; set; }
        private GameMap Map { get; set; }
        private Creature TheGuy { get; set; }
        private Creature Monster { get; set; }

        public GameEngine()
        {
            Initialize();
        }

        public void Initialize()
        {
            Console.SetWindowSize(100, 30);
            Map = new GameMap(BoardHeight, BoardWidth, "Map.txt");
            Menu = new GameMenu();
            MenuType = GameMenuType.Overland;
            TheGuy = new Creature(10, "The Guy", SizeType.Medium, '☺');
            TheGuy.MyScreenPosition = new Point(BoardWidth / 2, BoardHeight / 2);
            TheGuy.MyWorldPosition = new Point(Map.MapArray[0].Length / 2, (Map.MapArray.Count() / 2) - 5);
            Map.CurrentCenter = TheGuy.MyWorldPosition;

            Monster = new Creature(5, "Monster", SizeType.Medium, '☿');

            Random rand = new Random();
            int leftPos = rand.Next(1, BoardWidth);
            int topPos = rand.Next(1, BoardHeight);
            Monster.MyScreenPosition = new Point(leftPos, topPos);
        }

        public void Run()
        {
            ConsoleKey input = ConsoleKey.X;

            while (true)
            {
                Render();

                do
                {
                    input = ReadInput();
                } while (!Menu.IsValidInput(input, MenuType) && (input != ConsoleKey.Q));

                if (input == ConsoleKey.Q)
                {
                    return;
                }

                ProcessInput(input);
            }
        }

        private ConsoleKey ReadInput()
        {
            Console.SetCursorPosition(9, BoardHeight + 2);
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            return keyPressed.Key;
        }

        private void ProcessInput(ConsoleKey input)
        {
            Point newPosition;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    newPosition = new Point(TheGuy.MyWorldPosition.X, TheGuy.MyWorldPosition.Y - 1);
                    if (Map.IsValidMove(newPosition))
                    {
                        TheGuy.MyWorldPosition = newPosition;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    newPosition = new Point(TheGuy.MyWorldPosition.X, TheGuy.MyWorldPosition.Y + 1);
                    if (Map.IsValidMove(newPosition))
                    {
                        TheGuy.MyWorldPosition = newPosition;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    newPosition = new Point(TheGuy.MyWorldPosition.X + 1, TheGuy.MyWorldPosition.Y);
                    if (Map.IsValidMove(newPosition))
                    {
                        TheGuy.MyWorldPosition = newPosition;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    newPosition = new Point(TheGuy.MyWorldPosition.X - 1, TheGuy.MyWorldPosition.Y);
                    if (Map.IsValidMove(newPosition))
                    {
                        TheGuy.MyWorldPosition = newPosition;
                    }
                    break;
            }
        }

        private void Render()
        {
            Console.Clear();
            Console.WriteLine(DividerRow);
            for (int i = 0; i < BoardHeight; i++)
            {
                Console.WriteLine(FieldRow);
            }
            Console.WriteLine(DividerRow);

            Map.CurrentCenter = TheGuy.MyWorldPosition;
            Map.Render();
            TheGuy.Render();
            //Monster.Render();

            Console.SetCursorPosition(BoardWidth + 2, 1);
            Menu.Render(MenuType);
            Console.SetCursorPosition(0, BoardHeight + 2);
            Console.Write("Command: ");
            Console.WriteLine("The console encoding is {0} (code page {1})",
                              Console.OutputEncoding.EncodingName,
                              Console.OutputEncoding.CodePage);
        }
    }
}
