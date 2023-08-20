using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Plant : Entity
    {

        public override void Move()
        {
            TryToReproduce();
        }

    }
}
