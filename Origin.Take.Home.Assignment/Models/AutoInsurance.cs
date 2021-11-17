using Origin.Take.Home.Assignment.Requests;
using System;

namespace Origin.Take.Home.Assignment.Models
{
    public class AutoInsurance : Insurance
    {
        public AutoInsurance(int baseScore, int customerAge, int customerIncome, Vehicle customerVehicle) : base(baseScore, customerAge, customerIncome)
        {
            CustomerVehicle = customerVehicle;
        }

        public Vehicle CustomerVehicle { get; }

        public override void CalculateInsurance()
        {
            if (CustomerVehicle == null)
                SetTotalScoreInelegible();

            CalculateTotalScore();

            var fiveYearsAgo = DateTime.Now.AddYears(-5).Year;
            if (CustomerVehicle.Year >= fiveYearsAgo)
                IncrementTotalScore(1);
        }
    }
}
