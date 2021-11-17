using Origin.Take.Home.Assignment.Requests;

namespace Origin.Take.Home.Assignment.Models
{
    public class HomeInsurance : Insurance
    {
        public HomeInsurance(int baseScore, int customerAge, int customerIncome, House customerHouse) : base(baseScore, customerAge, customerIncome)
        {
            CustomerHouse = customerHouse;
        }

        public House CustomerHouse { get; }
        public Vehicle CustomerVehicle { get; }

        public override void CalculateInsurance()
        {
            if (CustomerHouse == null)
                SetTotalScoreInelegible();

            CalculateTotalScore();

            if (CustomerHouse.OwnershipStatus == OwnershipStatus.Mortgaged)
                IncrementTotalScore(1);
        }
    }
}
