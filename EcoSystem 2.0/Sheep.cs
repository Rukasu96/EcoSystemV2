using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Sheep : Animal
    {
        public Sheep(int posX, int posY) : base()
        {
            coords.X = posX;
            coords.Y = posY;
            model = 'S';
            color = ConsoleColor.Blue;
            Power = 5;
            _Initiative = 5;
            _Age = 6;
            Spawn(posX, posY);
        }
        public override void CreateNewEntity(int posX, int posY)
        {
            Sheep sheep = new Sheep(posX, posY);
        }
    }
}
