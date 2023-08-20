using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Grass : Plant
    {
        public Grass(int posX, int posY) : base()
        {
            model = 'I';
            color = ConsoleColor.DarkGreen;
            Power = 0;
            _Initiative = 9;
            _Age = 10;
            Spawn(posX,posY);
        }
        public override void CreateNewEntity(int posX, int posY)
        {
            Grass grass = new Grass(posX, posY);
        }
        


    }
}
