using Origin.Take.Home.Assignment.Enums;

namespace Origin.Take.Home.Assignment.Models
{
    public abstract class Insurance
    {
        protected Insurance(int baseScore, int customerAge, int customerIncome)
        {
            BaseScore = baseScore;
            CustomerAge = customerAge;
            CustomerIncome = customerIncome;
            TotalScore = baseScore;
        }

        public int BaseScore { get; }
        public int? TotalScore { get; private set; }
        public int CustomerAge { get; }
        public int CustomerIncome { get; }
        public LifeInsuranceStatus LifeInsuranceStatus => GetLifeInsuranceStatus();

        protected LifeInsuranceStatus GetLifeInsuranceStatus()
        {
            if (!TotalScore.HasValue)
                return LifeInsuranceStatus.Inelegible;
            else if (TotalScore >= 3)
                return LifeInsuranceStatus.Responsible;
            else if (TotalScore >= 1)
                return LifeInsuranceStatus.Regular;
            else
                return LifeInsuranceStatus.Economic;
        }

        protected void CalculateTotalScore()
        {
            if (CustomerAge < 30)
                DecrementTotalScore(2);
            else if (CustomerAge <= 40)
                DecrementTotalScore(1);

            if (CustomerIncome >= 200000)
                DecrementTotalScore(1);
        }

        protected void IncrementTotalScore(int value)
        {
            if (!TotalScore.HasValue)
                return;
            TotalScore += value;
        }

        protected void DecrementTotalScore(int value)
        {
            if (!TotalScore.HasValue)
                return;
            TotalScore -= value;
        }

        protected void SetTotalScoreInelegible() => TotalScore = null;

        public abstract void CalculateInsurance();
    }
}
