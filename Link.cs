using System;
using System.Collections.Generic;
using System.Text;

namespace GhostInTheCell
{
    public class Link
    {
        public Link(int sourceFactoryId, int destinationFactoryId, int distance)
        {
            SourceFactoryId = sourceFactoryId;
            DestinationFactoryId = destinationFactoryId;
            Distance = distance;
        }

        public int SourceFactoryId { get; set; }
        public int DestinationFactoryId { get; set; }
        public int Distance { get; set; }
    }
}
