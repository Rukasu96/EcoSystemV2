using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Slot
    {
        private Coords _Cords;
        private Animal animal;
        private char model;

        public bool IsEmpty;
        public Coords Cords { get => _Cords; }
        public Animal Animal { get => animal; }
        public Slot(int x, int y)
        {
            model = 'X';
            _Cords = new Coords(x, y);
            SlotManager.Instance.AddSlot(x, y, this);
            IsEmpty = true;
        }

        public bool ChangeEmpty()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(_Cords.X, _Cords.Y);
            Console.WriteLine(model); // Zamienić na model
            return IsEmpty = !IsEmpty;
        }

        public void AssignAnimal(Animal animal)
        {
            this.animal = animal;
            ChangeEmpty();
        }

        public void RemoveAnimal()
        {
            animal = null;
            ChangeEmpty();
        }
    }
}
