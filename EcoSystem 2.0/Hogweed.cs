using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Hogweed : Plant
    {
        public Hogweed(int posX, int posY) : base()
        {
            model = 'D';
            color = ConsoleColor.Red;
            Power = 0;
            _Initiative = 1;
            _Age = 1;
            Spawn(posX, posY);
            EntityManager.Instance.AddHogweed(this);
        }

        public override void Move()
        {
            int result = RandomNumber.GenerateNumber(0, 8);
            if(result == 0)
            {
                base.Move();
            }
            SpecialAbility();
        }

        public override void SpecialAbility()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (EntityManager.Instance.IsInBounds(coords.X + i, coords.Y + j) == true)
                    {
                        Entity animal = EntityManager.Instance.ReturnEntity(coords.X + i, coords.Y + j);
                        
                        if(animal is Animal)
                        {
                            if(animal is CyberSheep)
                            {
                                continue;
                            }
                            else
                            {
                                animal.Die();
                            }
                        }
                    }
                }
            }
        }

        public override void CreateNewEntity(int posX, int posY)
        {
            Hogweed hogweed = new Hogweed(posX, posY);
        }

        public override void Die()
        {
            base.Die();
            EntityManager.Instance.RemoveHogweed(this);
        }
    }
}
