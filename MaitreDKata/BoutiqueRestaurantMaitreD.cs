using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class BoutiqueRestaurantMaitreD : IMaitreD
    {
        public bool Accept(IReservation[] reservations, IReservation candidate, 
                           ITable[] tables, TimeSpan seatingDuration)
        {
            var sameDayReservations = new SameDayReservationFilter()
                                            .Filter(reservations, candidate,
                                                    seatingDuration);
                                        
            int total = sameDayReservations
                            .Sum(r => r.Quantity);

            return candidate
                    .CanFit(new RectangularTable(tables.Sum(t => t.Size) - total));
        }
    }
}
