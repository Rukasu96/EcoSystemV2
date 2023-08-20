using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Belladonna : Plant
    {
        public Belladonna(int posX, int posY) : base()
        {
            model = 'B';
            color = ConsoleColor.DarkRed;
            Power = 0;
            _Initiative = 6;
            _Age = 6;
            Spawn(posX, posY);
        }

        public override void CreateNewEntity(int posX, int posY)
        {
            Belladonna bella = new Belladonna(posX, posY);
        }
    }
}
