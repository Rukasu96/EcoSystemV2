using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Milt : Plant
    {
        public Milt(int posX, int posY) : base()
        {
            model = 'M';
            color = ConsoleColor.Yellow;
            Power = 0;
            _Initiative = 11;
            _Age = 9;
            Spawn(posX, posY);
        }

        public override void Move()
        {
            base.Move();
            base.Move();
        }

        public override void CreateNewEntity(int posX, int posY)
        {
            Milt milt = new Milt(posX, posY);
        }
    }
}
