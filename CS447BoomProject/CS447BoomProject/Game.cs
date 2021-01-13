using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS447BoomProject
{
    class Game
    {
        Random r = new Random();

        public int[] BombLocate()
        {
            int[] bombArray = new int[25];
            List<int> randomNumberList = new List<int>();
            int number = 0;

            while (randomNumberList.Count < 5)
            {
                number = r.Next(1, 25);

                if (!randomNumberList.Contains(number))
                {
                    randomNumberList.Add(number);
                }
            }

            int bomb1 = (int)randomNumberList[0];
            int bomb2 = (int)randomNumberList[1];
            int bomb3 = (int)randomNumberList[2];
            int bomb4 = (int)randomNumberList[3];
            int bomb5 = (int)randomNumberList[4];

            for (int i = 0; i < bombArray.Length; i++)
            {
                bombArray[i] = 0;
            }

            bombArray[bomb1] = 1;
            bombArray[bomb2] = 1;
            bombArray[bomb3] = 1;
            bombArray[bomb4] = 1;
            bombArray[bomb5] = 1;

            return bombArray;
        }

       /* public Boolean GameFinished(Player pla)
        {
            Boolean isFinished = false;
            if (pla.bombPoint == 3)
            {
                isFinished = true;
            }
            return isFinished;
        }*/
    }
}
