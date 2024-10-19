using System.ComponentModel.Design;

namespace Question4
{
    //question - 04
    public class Program
    {
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true, 50),
                new Black(false, 10),
                new Gold(true, 30),
                new Black(true, 20),
                new Gold(false, 20),

            };
            var subscriptionPlans = new SubscribePlan(plans);

            var result = subscriptionPlans.GetSubscriptionPlan();
            foreach( var item in result)
            {
                Console.WriteLine($"{item.Item1},{item.Item2}");
            }

        }
        //interface with a member
        public interface IBroadbandPlan
        {
            public int GetBroadbandPlanAmount();
        }
        public class Black: IBroadbandPlan
        {
            private readonly bool _isSubscriptionValid;
            private readonly int _discountPercentage;
            private const int PlanAmount= 3000;

            //constructor
            public Black(bool isSubscriptionValid, int discountPercentage)
            {
                this._isSubscriptionValid = isSubscriptionValid;
                this._discountPercentage = discountPercentage;
                if(discountPercentage < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if(discountPercentage > 50)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            //method 
            public int GetBroadbandPlanAmount()
            {
                
                if(_isSubscriptionValid)
                {
                    return (PlanAmount - (PlanAmount * (_discountPercentage) / 100));
                }
                return PlanAmount;
            }
        }
        //class gold with specific member variables and functions
        public class Gold : IBroadbandPlan
        {
            private readonly bool _isSubscriptionValid;
            private readonly int _discountPercentage;
            private const int PlanAmount = 1500;

            public Gold(bool isSubscriptionValid, int discountPercentage)
            {
                this._isSubscriptionValid= isSubscriptionValid;
                this._discountPercentage = discountPercentage;
                if(discountPercentage < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (discountPercentage > 30)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            public int GetBroadbandPlanAmount()
            {
                if (_isSubscriptionValid)
                {
                    return (PlanAmount - (PlanAmount * (_discountPercentage) / 100));
                }
                return PlanAmount;
            }
  
        }
        public class SubscribePlan
        {
            private readonly IList<IBroadbandPlan> _broadbandPlans;
            public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
            {
                _broadbandPlans = broadbandPlans;   
                if(_broadbandPlans == null)
                {
                    throw new ArgumentNullException();
                }
            }
            public IList<Tuple<string, int>> GetSubscriptionPlan()
            {
                var res = new List<Tuple<string, int>>();
                foreach (var item in _broadbandPlans)
                {

                    string name = item.GetType().Name;
                    int amount = item.GetBroadbandPlanAmount();
                    res.Add(new Tuple<string, int>(name, amount));

                }
                return res;
            }
        }





    }
}
