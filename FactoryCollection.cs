using System;
using System.Collections.Generic;
using System.Text;

namespace GhostInTheCell
{
    public class FactoryCollection
    {
        public FactoryCollection(List<Factory> factories)
        {
            Factories = factories;
        }

        public List<Factory> Factories { get; set; }

        public void AttackClosestFactories(List<Factory> enemyFactories, List<Link> links)
        {
            foreach (Factory myFactory in Factories)
            {
                myFactory.AttackClosestFactory(enemyFactories, links);
            }
        }

        public void AttackNeutralFactories(List<Factory> neutralFactories, List<Link> links)
        {
            foreach (Factory myFactory in Factories)
            {
                myFactory.AttackNeutralFactory(neutralFactories, links);
            }
        }

        public static List<Factory> GetMyFactories(List<Factory> allFactories)
        {
            List<Factory> myFactories = new List<Factory>();
            foreach (Factory factory in allFactories)
            {
                if (factory.Owner == 1) myFactories.Add(factory);
            }
            return myFactories;
        }

        public static List<Factory> GetEnemyFactories(List<Factory> allFactories)
        {
            List<Factory> enemyFactories = new List<Factory>();
            foreach (Factory factory in allFactories)
            {
                if (factory.Owner == -1) enemyFactories.Add(factory);
            }
            return enemyFactories;
        }

        public static List<Factory> GetNeutralFactories(List<Factory> allFactories)
        {
            List<Factory> neutralFactories = new List<Factory>();
            foreach (Factory factory in allFactories)
            {
                if (factory.Owner == 0) neutralFactories.Add(factory);
            }
            return neutralFactories;
        }
    }
}
