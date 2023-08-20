using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Fox : Animal
    {
        public Fox(int posX, int posY) : base()
        {
            coords.X = posX;
            coords.Y = posY;
            model = 'F';
            color = ConsoleColor.Yellow;
            Power = 6;
            _Initiative = 10;
            _Age = 3;
            Spawn(posX, posY);
        }
        public override void CreateNewEntity(int posX, int posY)
        {
            Fox fox = new Fox(posX, posY);
        }
        public override void SpecialAbility()
        {
            int[] FreePosXY = EntityManager.Instance.ReturnFreeNeighbourPositions(coords.X, coords.Y);

            if(FreePosXY == null)
            {
                return;
            }

            EntityManager.Instance.RemoveEntity(coords.X, coords.Y);
            FinishMove(FreePosXY[0], FreePosXY[1]);

        }

    }
}
