using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace EcoSystem_2._0
{
    internal class EntityManager
    {
        private Entity[,] entities;
        private List<Hogweed> hogweeds = new List<Hogweed>();
        public Entity[,] Entities { get => entities; }
        public List<Hogweed> Hogweeds { get => hogweeds; }
        private static EntityManager? instance = null;
        public static EntityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntityManager();
                }
                return instance;
            }
        }

        public void SetArraySize(int width, int height)
        {
            entities = new Entity[width,height];
        }

        public void AddEntity(int posX, int posY, Entity entity)
        {
            entities[posX,posY] = entity;
        }

        public void RemoveEntity(int posX, int posY)
        {
            Console.SetCursorPosition(posX,posY);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(' ');
            entities[posX, posY] = null;
        }
        public void AddHogweed(Hogweed hogweed)
        {
            hogweeds.Add(hogweed);
        }

        public void RemoveHogweed(Hogweed hogweed)
        {
            hogweeds.Remove(hogweed);
        }

        public Entity ReturnEntity(int posX, int posY)
        {
            return entities[posX,posY];
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < entities.GetLength(0) && y >= 0 && y < entities.GetLength(1);
        }

        public int[] ReturnFreeNeighbourPositions(int EntityPosX, int EntityPosY)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (IsInBounds(EntityPosX + i, EntityPosY + j) == true)
                    {
                        if (ReturnEntity(EntityPosX + i, EntityPosY + j) == null)
                        {
                            return new int[] { EntityPosX + i, EntityPosY + j };
                        }
                    }

                    if (IsInBounds(EntityPosX - i, EntityPosY + j) == true)
                    {
                        if (ReturnEntity(EntityPosX - i, EntityPosY + j) == null)
                        {
                            return new int[] { EntityPosX - i, EntityPosY + j };
                        }
                    }

                    if (IsInBounds(EntityPosX + i, EntityPosY - j) == true)
                    {
                        if (ReturnEntity(EntityPosX + i, EntityPosY - j) == null)
                        {
                            return new int[] { EntityPosX + i, EntityPosY - j };
                        }
                    }

                    if (IsInBounds(EntityPosX - i, EntityPosY - j) == true)
                    {
                        if (ReturnEntity(EntityPosX - i, EntityPosY - j) == null)
                        {
                            return new int[] { EntityPosX - i, EntityPosY - j };
                        }
                    }
                }

            }

            return null;
        }
        
        
    }
}
