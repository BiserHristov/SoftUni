using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main()
        {
            Queue<int> effectQueue = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> casingStack = new Stack<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;
            bool pouchDone = false;

            while (effectQueue.Count > 0 && casingStack.Count > 0)
            {
                int currentBombEffect = effectQueue.Peek();
                int currentCasing = casingStack.Peek();
                int sum = currentBombEffect + currentCasing;

                if (sum == 40)
                {
                    daturaBombs++;
                    effectQueue.Dequeue();
                    casingStack.Pop();
                }
                else if (sum == 60)
                {
                    cherryBombs++;
                    effectQueue.Dequeue();
                    casingStack.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoyBombs++;
                    effectQueue.Dequeue();
                    casingStack.Pop();
                }
                else
                {
                    currentCasing -= 5;
                    casingStack.Pop();
                    casingStack.Push(currentCasing);

                }

                if (daturaBombs >= 3 &&
                    cherryBombs >= 3 &&
                    smokeDecoyBombs >= 3)
                {
                    pouchDone = true;
                    break;

                }

            }

            if (pouchDone)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.WriteLine("Bomb Effects: " + (effectQueue.Count == 0 ? "empty" : string.Join(", ", effectQueue)));
            Console.WriteLine("Bomb Casings: " + (casingStack.Count == 0 ? "empty" : string.Join(", ", casingStack)));
            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
