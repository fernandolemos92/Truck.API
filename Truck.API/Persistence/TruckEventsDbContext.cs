using Truck.API.Entities;

namespace Truck.API.Persistence
{
    public class TruckEventsDbContext
    {
        public List<TruckEvent> TruckEvents { get; set; }

        public TruckEventsDbContext()
        {
            TruckEvents = new List<TruckEvent>();
        }
    }
}
