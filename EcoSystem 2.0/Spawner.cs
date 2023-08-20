using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem_2._0
{
    internal class Spawner
    {
        int width;
        int height;
        int randomPosX;
        int randomPosY;
        bool slotIsFree;

        public Spawner(int width, int height)
        {
            this.width = width;
            this.height = height;
            SpawnAllEntities(width, height);
        }

        private void SpawnAllEntities(int width, int height)
        {
            int size = width * height;

            int grassSize = (size*40)/100; // 40%
            int miltSize = (size*10)/100; // 10%
            int bellaSize = (size*3)/100; // 3%
            int hogweedSize = (size*2)/100; // 2%
            int guaranaSize = (size*5)/100; // 5%
            int wolfSize = (size*10)/100; // 10%
            int sheepSize = (size*15)/100; // 15%
            int antelopeSize = (size*5)/100; // 5%
            int turtleSize = (size*3)/100; // 3%
            int foxSize = (size*5)/100; // 5%
            int cybersheepSize = size - grassSize - miltSize - bellaSize - hogweedSize - guaranaSize 
                - wolfSize - turtleSize - foxSize - sheepSize - antelopeSize;

            for (int i = 0; i < grassSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Grass grass = new Grass(randomPosX, randomPosY);
            }

            for (int i = 0; i < miltSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Milt milt = new Milt(randomPosX, randomPosY);
            }

            for (int i = 0; i < bellaSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Belladonna bella = new Belladonna(randomPosX, randomPosY);
            }

            for (int i = 0; i < hogweedSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Hogweed hogweed = new Hogweed(randomPosX, randomPosY);
            }

            for (int i = 0; i < guaranaSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Guarana guarana = new Guarana(randomPosX, randomPosY);
            }

            for (int i = 0; i < wolfSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Wolf wolf = new Wolf(randomPosX, randomPosY);
            }

            for (int i = 0; i < sheepSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Sheep sheep = new Sheep(randomPosX, randomPosY);
            }

            for (int i = 0; i < antelopeSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Antelope antelope = new Antelope(randomPosX, randomPosY);
            }

            for (int i = 0; i < turtleSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Turtle turtle = new Turtle(randomPosX, randomPosY);
            }

            for (int i = 0; i < foxSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                Fox fox = new Fox(randomPosX, randomPosY);
            }

            for (int i = 0; i < cybersheepSize; i++)
            {
                do
                {

                    FindEmptySlot();

                } while (!slotIsFree);

                CyberSheep cyberSheep = new CyberSheep(randomPosX, randomPosY);
            }

        }

       private void FindEmptySlot()
        {
            slotIsFree = true;

            randomPosX = RandomNumber.GenerateNumber(0, width);
            randomPosY = RandomNumber.GenerateNumber(0, height);

            if (EntityManager.Instance.ReturnEntity(randomPosX, randomPosY) != null)
            {
                slotIsFree = false;
            }
        }

    }
}
