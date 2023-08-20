using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Animal : Entity
    {
        public Animal() : base()
        {

        }

        public override void Move()
        {
            Console.SetCursorPosition(coords.X, coords.Y);
            Console.ForegroundColor = color;
            Console.WriteLine(model);
            MakeMove(ChooseRandomDirection());
        }

        protected Direction ChooseRandomDirection()
        {
            bool IsMoveable = false;

            while (!IsMoveable)
            {
                int number = RandomNumber.GenerateNumber(0, 4);

                switch (number)
                {
                    case 0:
                        if (EntityManager.Instance.IsInBounds(coords.X, coords.Y - 1))
                        {
                            return Direction.Up;
                        }
                        break;
                    case 1:
                        if (EntityManager.Instance.IsInBounds(coords.X, coords.Y + 1))
                        {
                            return Direction.Down;
                        }
                        break;
                    case 2:
                        if (EntityManager.Instance.IsInBounds(coords.X - 1, coords.Y))
                        {
                            return Direction.Left;
                        }
                        break;
                    case 3:
                        if (EntityManager.Instance.IsInBounds(coords.X + 1, coords.Y))
                        {
                            return Direction.Right;
                        }
                        break;
                    default:
                        break;
                }
            }

            return 0;
        }

        protected void MakeMove(Direction dir)
        {
            int oldPosX = coords.X;
            int oldPosY = coords.Y;
            EntityManager.Instance.RemoveEntity(coords.X, coords.Y);

            switch (dir)
            {
                case Direction.Left:
                    coords.X--;
                    break;
                case Direction.Right:
                    coords.X++;
                    break;
                case Direction.Up:
                    coords.Y--;
                    break;
                case Direction.Down:
                    coords.Y++;
                    break;
                default:
                    break;
            }

            Entity entity = EntityManager.Instance.ReturnEntity(coords.X, coords.Y);

            if(entity != null)
            {
                if (this.model == entity.Model)
                {
                    TryToReproduce(entity);
                    FinishMove(oldPosX, oldPosY);
                    return;
                }
                else if (entity is Turtle)
                {
                    FightTurtle(entity, oldPosX, oldPosY);
                    return;
                }
                else if (entity is Fox)
                {
                    FightFox(entity);
                }
                else
                {
                    MeetingWithEntity(entity);
                }
            }
            
            if(isAlive)
            {
                FinishMove(coords.X, coords.Y);
            }

        }
        
        private void FightTurtle(Entity turtle, int oldPosX, int oldPosY)
        {
            if(Power > turtle.Power + 3)
            {
                turtle.Die();
                FinishMove(coords.X, coords.Y);
            }
            else
            {
                FinishMove(oldPosX, oldPosY);
            }
        }

        private void FightFox(Entity fox)
        {
            if(Power > fox.Power)
            {
                int result = RandomNumber.GenerateNumber(0, 2);
                
                if(result == 0)
                {
                    fox.SpecialAbility();
                }
                else
                {
                    Fight(fox);
                }
            }
        }

        protected override void TryToReproduce(Entity entity)
        {
            int[] FreePosXY = EntityManager.Instance.ReturnFreeNeighbourPositions(coords.X, coords.Y);

            if (FreePosXY == null)
            {
                FreePosXY = EntityManager.Instance.ReturnFreeNeighbourPositions(entity.Coords.X, entity.Coords.Y);
                
                if(FreePosXY == null)
                {
                    return;
                }
            }

            entity.CreateNewEntity(FreePosXY[0], FreePosXY[1]);
        }

       

        
    }
}
