using System;
using System.Collections.Generic;
using System.Text;

namespace GhostInTheCell
{
    public class Factory
    {
        public int Id { get; set; }
        public int Owner { get; set; } // 1 for you, -1 for your opponent and 0 if neutral
        public int CyborgCount { get; set; }
        public int FactoryProduction { get; set; }

        public Factory(int id, int owner, int cyborgCount, int factoryproduction)
        {
            Id = id;
            Owner = owner;
            CyborgCount = cyborgCount;
            FactoryProduction = factoryproduction;
        }

        public Link GetLinkWithClosestEnemy(List<Factory> targetFactories, List<Link> links)
        {
            Link closestLink = null;
            for (int i = 0; i < targetFactories.Count; i++)
            {
                foreach (Link link in links)
                {
                    // If the link is the one between current and enemy factory
                    if ((Id == link.SourceFactoryId && targetFactories[i].Id == link.DestinationFactoryId)
                        || (Id == link.DestinationFactoryId && targetFactories[i].Id == link.SourceFactoryId))
                    {
                        if (closestLink != null)
                        {
                            if (link.Distance < closestLink.Distance)
                            {
                                closestLink = link;
                            }
                        }
                        else
                        {
                            closestLink = link;
                        }
                    }
                }
            }
            return closestLink;
        }

        public void AttackClosestFactory(List<Factory> targetFactories, List<Link> links)
        {
            Link closestTargetLink = GetLinkWithClosestEnemy(targetFactories, links);
            //Console.WriteLine(closestEnemyLink.SourceFactoryId + " " + closestEnemyLink.DestinationFactoryId);
            
            if (Id == closestTargetLink.SourceFactoryId){
                Console.WriteLine("MOVE " + Id + " " + closestTargetLink.DestinationFactoryId + " 15");
            }
            else
            {
                Console.WriteLine("MOVE " + Id + " " + closestTargetLink.SourceFactoryId + " 15");
            }
        }

        public void AttackNeutralFactory(List<Factory> neutralFactories, List<Link> links)
        {
            for (int i = 0; i < neutralFactories.Count; i++)
            {
                int thisNeutralFactoryId = neutralFactories[i].Id;
                if (!Player.neutralFactoriesAttacked[thisNeutralFactoryId])
                {
                    Console.WriteLine("MOVE " + Id + " " + neutralFactories[i].Id + " 1");
                    Player.neutralFactoriesAttacked[thisNeutralFactoryId] = true;
                    break;
                }
            }
        }

        #region Static methods

        public static string PrintAllFactoryIDs(List<Factory> factories)
        {
            string factoryIds = "";
            for (int i = 0; i < factories.Count; i++)
            {
                factoryIds = factories[i].Id + " ";
            }
            return factoryIds;
        }

        #endregion

    }
}
