using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GhostInTheCell
{
    public static class NeutralFactoryHelper
    {

        public static int JuiciestNeutralFactoryId(List<Factory> allFactories)
        {
            var neutralFactories = GetAllNeutralFactories(allFactories);
            return neutralFactories.Where(x => x.FactoryProduction > 0).Select(x => x.Id).First();
        }

        public static List<Factory> GetAllNeutralFactories(List<Factory> allFactories)
        {
            var neutralFactories = new List<Factory>();
            foreach (var factory in allFactories)
            {
                if (factory.Owner == 0) neutralFactories.Add(factory);
            }
            return neutralFactories;
        }
    }
}
