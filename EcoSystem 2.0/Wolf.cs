using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Wolf : Animal
    {
        public Wolf(int posX, int posY) : base()
        {
            coords.X = posX;
            coords.Y = posY;
            model = 'W';
            color = ConsoleColor.Red;
            Power = 7;
            _Initiative = 7;
            _Age = 8;
            Spawn(posX, posY);
        }

        public override void CreateNewEntity(int posX, int posY)
        {
            Wolf wolf = new Wolf(posX, posY);
        }

    }
}
