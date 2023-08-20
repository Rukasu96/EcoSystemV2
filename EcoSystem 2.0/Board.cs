using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Board
    {
        private int widthSize;
        private int heightSize;

        public int WidthSize { get => widthSize; }
        public int HeightSize { get => heightSize; }

        public Board()
        {
            do
            {
                Console.WriteLine("Pole musi być minimum 100");

                widthSize = SetSize("Podaj szerokość planszy");
                heightSize = SetSize("Podaj długość planszy");

            } while (!CheckSize());
            

            EntityManager.Instance.SetArraySize(widthSize, heightSize);
            Draw();
        }

        private void Draw()
        {
            Console.Clear();

            for (int i = 0; i < widthSize; i++)
            {
                for (int j = 0; j < heightSize; j++)
                {
                    Console.SetCursorPosition(i, j);
                }
            }
        }

        private int SetSize(string sentence)
        {
            int value = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.WriteLine(sentence);

                string input;
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Niewłaściwa wartość");
                }
            }

            return value;
        }

        private bool CheckSize()
        {
            return widthSize*heightSize >= 100 ? true : false;
        }
    }
}
