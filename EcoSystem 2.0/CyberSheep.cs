using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class CyberSheep : Animal
    {
        private Hogweed chasingHogweed;
        public CyberSheep(int posX, int posY) : base()
        {
            coords.X = posX;
            coords.Y = posY;
            model = 'C';
            color = ConsoleColor.DarkBlue;
            Power = 5;
            _Initiative = 6;
            _Age = 2;
            Spawn(posX, posY);
        }

        public override void Move()
        {
            FindNearestHogweed();
            if(chasingHogweed == null || !chasingHogweed.isAlive)
            {
                base.Move();
            }
            else
            {
                if(coords.X < chasingHogweed.Coords.X)
                {
                    MakeMove(Direction.Right);
                }else if(coords.X > chasingHogweed.Coords.X)
                {
                    MakeMove(Direction.Left);
                }else if(coords.Y < chasingHogweed.Coords.Y)
                {
                    MakeMove(Direction.Down);
                }else if(coords.Y > chasingHogweed.Coords.Y)
                {
                    MakeMove(Direction.Up);
                }
            }
        }

        public override void CreateNewEntity(int posX, int posY)
        {
            CyberSheep CyberSheep = new CyberSheep(posX, posY);
        }

        private void FindNearestHogweed()
        {
            int lowestDeficitResult = 0;
            List<Hogweed> hogweeds = EntityManager.Instance.Hogweeds;

            if( hogweeds.Count == 1)
            {
                chasingHogweed = hogweeds[0];
            }
            else if( hogweeds.Count > 1)
            {
                for (int i = 0; i < hogweeds.Count; i++)
                {
                    int oldDeficitResult = lowestDeficitResult;

                    int deficitPosX = Math.Abs(hogweeds[i].Coords.X - coords.X);
                    int deficitPosY = Math.Abs(hogweeds[i].Coords.Y - coords.Y);

                    lowestDeficitResult = deficitPosX + deficitPosY;

                    if(lowestDeficitResult < oldDeficitResult || oldDeficitResult == 0)
                    {
                        chasingHogweed = hogweeds[i];
                    }
                }
            }

        }
    }
}
