using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Subscription
    {
        public double DiscountOnTrip { get; }
        public double BonusPercentage { get; }

        public Subscription(double discountOnTrip, double bonusPercentage)
        {
            this.DiscountOnTrip = discountOnTrip;
            this.BonusPercentage = bonusPercentage;
        }
    }
}
