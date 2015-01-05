using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Game.Interfaces;
using System.Drawing;

namespace Game.Objects
{
    public class GameMap : IDisplayable
    {
        public string[] MapArray { get; private set; }
        public Point CurrentCenter { get; set; }
        private int BoardHeight { get; set;}
        private int BoardWidth { get; set; }

        public GameMap(int boardHeight, int boardWidth, string mapFileName)
        {
            BoardHeight = boardHeight;
            BoardWidth = boardWidth;
            MapArray = LoadMap(mapFileName);
            MapArray = ExpandMap(boardHeight, boardWidth, MapArray);
        }

        public bool IsValidMove(Point newPosition)
        {
            string newLocCar = MapArray[newPosition.Y-1].Substring(newPosition.X-1, 1);
            return !"|\\/-".Contains(newLocCar);
        }

        public string[] LoadMap(string mapFileName)
        {
            return File.ReadAllLines("Objects\\" + mapFileName);   
        }

        public string[] ExpandMap(int boardHeight, int boardWidth, string[] mapLines)
        {
            int maxRowWidth = mapLines.Max<string, int>(x => x.Length);
            List<string> newMap = new List<string>();            

            for (int i = 0; i < mapLines.Count(); i++)
            {
                string paddedLine = mapLines[i].PadRight(maxRowWidth, ' ');
                mapLines[i] = string.Format("{0}{1}{0}", new string(' ', boardWidth), paddedLine);
            }

            for (int i = 0; i < boardHeight; i++)
            {
                newMap.Add(new string(' ', maxRowWidth + (boardWidth * 2)));
            }

            newMap.AddRange(mapLines);

            for (int i = 0; i < boardHeight; i++)
            {
                newMap.Add(new string(' ', maxRowWidth + (boardWidth * 2)));
            }

            return newMap.ToArray();
        }

        public void Render()
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            int topCounter = 1;

            for (int i = CurrentCenter.Y - (BoardHeight / 2); i < CurrentCenter.Y + (BoardHeight / 2); i++)
            {
                Console.SetCursorPosition(1, topCounter++);
                Console.Write(MapArray[i].Substring(CurrentCenter.X - (BoardWidth / 2), BoardWidth));
            }

            Console.SetCursorPosition(currentLeft, currentTop);
        }
    }
}
