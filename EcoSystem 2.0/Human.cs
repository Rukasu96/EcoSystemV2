using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Human : Animal
    {

        public Human() : base()
        {
            model = 'H';
            color = ConsoleColor.Green;
            Power = 4;
            TurnController.Instance.RemoveFromList(this);
        }

        public override void Move()
        {
            Console.SetCursorPosition(coords.X, coords.Y);
            Console.ForegroundColor = color;
            Console.WriteLine(model);
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    if (EntityManager.Instance.IsInBounds(coords.X, coords.Y - 1))
                    {
                        MakeMove(Direction.Up);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (EntityManager.Instance.IsInBounds(coords.X, coords.Y + 1))
                    {
                        MakeMove(Direction.Down);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (EntityManager.Instance.IsInBounds(coords.X - 1, coords.Y))
                    {
                        MakeMove(Direction.Left);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (EntityManager.Instance.IsInBounds(coords.X + 1, coords.Y))
                    {
                        MakeMove(Direction.Right);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
