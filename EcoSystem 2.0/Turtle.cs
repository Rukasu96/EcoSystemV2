using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Turtle : Animal
    {
        public Turtle(int posX, int posY) : base()
        {
            coords.X = posX;
            coords.Y = posY;
            model = 'T';
            color = ConsoleColor.DarkGreen;
            Power = 4;
            _Initiative = 3;
            _Age = 10;
            Spawn(posX, posY);
        }
        public override void CreateNewEntity(int posX, int posY)
        {
            Turtle turtle = new Turtle(posX, posY);
        }

        public override void Move()
        {
            int result = RandomNumber.GenerateNumber(0, 4);

            if(result == 0)
            {
                base.Move();
            }

        }
    }
}
