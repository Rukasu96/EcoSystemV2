using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class TurnController
    {
        private List<Entity> entitiesTurnList;

        private static TurnController? instance = null;
        public static TurnController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TurnController();
                }
                return instance;
            }
        }

        public TurnController()
        {
            entitiesTurnList = new List<Entity>();
        }

        public void AddToList(Entity entity)
        {
            entitiesTurnList.Add(entity);
        }

        public void RemoveFromList(Entity entity)
        {
            entitiesTurnList.Remove(entity);
        }

        public void StartTurn()
        {
            var turnList = entitiesTurnList.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Age).ToList();

            foreach (Entity entity in turnList)
            {
                if(entity.isAlive)
                {
                    entity.Move();
                    //Thread.Sleep(200);
                }
            }


        }
    }
}
