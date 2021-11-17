using Origin.Take.Home.Assignment.Requests;

namespace Origin.Take.Home.Assignment.Models
{
    public class LifeInsurance : Insurance
    {
        public LifeInsurance(int baseScore, int customerAge, int customerIncome, int customerDependents, MaritalStatus customerMaritalStatus) : base(baseScore, customerAge, customerIncome)
        {
            CustomerDependents = customerDependents;
            CustomerMaritalStatus = customerMaritalStatus;
        }

        public int CustomerDependents { get; }
        public MaritalStatus CustomerMaritalStatus { get; }

        public override void CalculateInsurance()
        {
            if (CustomerAge > 60)
                SetTotalScoreInelegible();

            CalculateTotalScore();

            if (CustomerDependents > 0)
                IncrementTotalScore(1);

            if (CustomerMaritalStatus == MaritalStatus.Married)
                IncrementTotalScore(1);
        }
    }
}
