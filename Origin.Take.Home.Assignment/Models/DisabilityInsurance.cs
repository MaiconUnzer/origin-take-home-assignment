using Origin.Take.Home.Assignment.Requests;

namespace Origin.Take.Home.Assignment.Models
{
    public class DisabilityInsurance : Insurance
    {
        public DisabilityInsurance(int baseScore, int customerAge, int customerIncome, House customerHouse, int customerDependents, MaritalStatus customerMaritalStatus) : base(baseScore, customerAge, customerIncome)
        {
            CustomerHouse = customerHouse;
            CustomerDependents = customerDependents;
            CustomerMaritalStatus = customerMaritalStatus;
        }

        public House CustomerHouse { get; }
        public int CustomerDependents { get; }
        public MaritalStatus CustomerMaritalStatus { get; }

        public override void CalculateInsurance()
        {
            if (CustomerIncome <= 0 || CustomerAge > 60)
                SetTotalScoreInelegible();

            CalculateTotalScore();

            if (CustomerHouse?.OwnershipStatus == OwnershipStatus.Mortgaged)
                IncrementTotalScore(1);

            if (CustomerDependents > 0)
                IncrementTotalScore(1);

            if (CustomerMaritalStatus == MaritalStatus.Married)
                DecrementTotalScore(1);
        }
    }
}
