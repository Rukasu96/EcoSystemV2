using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Antelope : Animal
    {
        public Antelope(int posX, int posY) : base()
        {
            coords.X = posX;
            coords.Y = posY;
            model = 'A';
            color = ConsoleColor.Cyan;
            Power = 5;
            _Initiative = 8;
            _Age = 4;
            Spawn(posX, posY);
        }
        public override void CreateNewEntity(int posX, int posY)
        {
            Antelope antelope = new Antelope(posX, posY);
        }
        public override void Move()
        {
            base.Move();
            Thread.Sleep(200);
            base.Move();
        }
    }
}
