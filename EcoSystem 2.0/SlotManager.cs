using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class SlotManager
    {
        private Slot[,] slots;

        public Slot[,] Slots { get => slots; }

        private static SlotManager? instance = null;
        public static SlotManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SlotManager();
                }
                return instance;
            }
        }

        public void SetArraySize(int width, int height)
        {
            slots = new Slot[width, height];
        }

        public void AddSlot(int posX, int posY, Slot slot)
        {
            slots[posX, posY] = slot;
        }

        public bool IsInBoard(int x, int y)
        {
            return x >= 0 && x < slots.GetLength(0) && y >= 0 && y < slots.GetLength(1);
        }

        public Slot ReturnSlot(int x, int y)
        {
            return slots[x, y];
        }
    }
}
