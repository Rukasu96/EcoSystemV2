using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Entity
    {
        protected int _Initiative;
        protected int _Age;

        protected Coords coords;
        protected char model;
        protected ConsoleColor color;

        public int Power;
        public bool isAlive;
        public int Initiative { get => _Initiative; }
        public Coords Coords { get => coords; }
        public char Model { get => model; }
        public int Age { get => _Age; }

        public Entity()
        {
            coords = new Coords();
            isAlive = true;
        }

        public virtual void Move() { }
        public virtual void CreateNewEntity(int posX, int posY) { }
        public virtual void SpecialAbility() { }
        protected virtual void TryToReproduce(Entity entity) { }
        protected virtual void TryToReproduce() 
        {
            int[] FreePosXY = EntityManager.Instance.ReturnFreeNeighbourPositions(coords.X, coords.Y);

            if (FreePosXY == null)
            {
                return;
            }

            CreateNewEntity(FreePosXY[0], FreePosXY[1]);
        }

        protected void Spawn(int posX, int posY)
        {
            coords.X = posX;
            coords.Y = posY;

            EntityManager.Instance.AddEntity(coords.X, coords.Y, this);
            TurnController.Instance.AddToList(this);

            Console.SetCursorPosition(coords.X,coords.Y);
            Console.ForegroundColor = color;
            Console.WriteLine(model);
        }

        protected void MeetingWithEntity(Entity entity)
        {
            if (entity is Belladonna || entity is Hogweed)
            {
                if (this is CyberSheep && entity is Hogweed)
                {
                    entity.Die();
                }
                else
                {
                    entity.Die();
                    Die();
                }
            }
            else if (entity is Guarana)
            {
                entity.Die();
                Power = +3;
            }
            else
            {
                Fight(entity);
            }
        }

        protected void Fight(Entity opponent)
        {
            if (Power > opponent.Power || Power == opponent.Power)
            {
                opponent.Die();
            }
            else
            {
                Die();
            }
        }
        protected void FinishMove(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.WriteLine(model);
            coords.X = posX;
            coords.Y = posY;
            EntityManager.Instance.AddEntity(posX, posY, this);
        }

        public virtual void Die()
        {
            TurnController.Instance.RemoveFromList(this);
            EntityManager.Instance.RemoveEntity(coords.X, coords.Y);
            isAlive = false;
        }
    }
}
