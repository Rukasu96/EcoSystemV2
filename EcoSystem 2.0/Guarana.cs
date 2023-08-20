using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Guarana : Plant
    {
        public Guarana(int posX, int posY) : base()
        {
            model = 'G';
            color = ConsoleColor.Magenta;
            Power = 0;
            _Initiative = 5;
            _Age = 8;
            Spawn(posX, posY);
        }

        public override void CreateNewEntity(int posX, int posY)
        {
            Guarana guarana = new Guarana(posX, posY);
        }
    }
}
