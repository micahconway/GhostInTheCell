using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GhostInTheCell
{
    class Player
    {
        public static bool[] neutralFactoriesAttacked = new bool[30];
        static void Main(string[] args)
        {
            string[] inputs;
            int factoryCount = int.Parse(Console.ReadLine()); // the number of factories
            int linkCount = int.Parse(Console.ReadLine()); // the number of links between factories

            List<Link> links = new List<Link>();

            for (int i = 0; i < linkCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int factory1 = int.Parse(inputs[0]);
                int factory2 = int.Parse(inputs[1]);
                int distance = int.Parse(inputs[2]);
                Link newLink = new Link(factory1, factory2, distance);
                links.Add(newLink);
            }

            // game loop
            while (true)
            {
                int entityCount = int.Parse(Console.ReadLine()); // the number of entities (e.g. factories and troops)
                List<Factory> allFactories = new List<Factory>();

                for (int i = 0; i < entityCount; i++)
                {
                    inputs = Console.ReadLine().Split(' ');
                    int entityId = int.Parse(inputs[0]);
                    string entityType = inputs[1];
                    int arg1 = int.Parse(inputs[2]);
                    int arg2 = int.Parse(inputs[3]);
                    int arg3 = int.Parse(inputs[4]);
                    int arg4 = int.Parse(inputs[5]);
                    int arg5 = int.Parse(inputs[6]);

                    if (entityType.Equals("FACTORY"))
                    {
                        allFactories.Add(new Factory(entityId, arg1, arg2, arg3));
                    }
                }

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                List<Factory> myFactories = new List<Factory>(FactoryCollection.GetMyFactories(allFactories));

                //var juiciestNeutralFactory = NeutralFactoryHelper.JuiciestNeutralFactoryId(allFactories);

                myFactories.ForEach(x => x.AttackNeutralFactory(NeutralFactoryHelper.GetAllNeutralFactories(allFactories), links));

                myFactories.ForEach(x => x.AttackClosestFactory(FactoryCollection.GetEnemyFactories(allFactories), links));

                // Any valid action, such as "WAIT" or "MOVE source destination cyborgs"

                /*Console.WriteLine("MOVE 1 3 3");
                 Console.WriteLine("MOVE 1 5 3");
                 Console.WriteLine("MOVE 1 0 3");
                 Console.WriteLine("MOVE 1 2 2");
                 Console.WriteLine("MOVE 1 4 2");*/
            }
        }
    }
}
    
    

