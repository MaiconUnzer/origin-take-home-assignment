using Origin.Take.Home.Assignment.Enums;

namespace Origin.Take.Home.Assignment.Responses
{
    public class RiskProfileResponse
    {
        public LifeInsuranceStatus Auto { get; set; }
        public LifeInsuranceStatus Life { get; set; }
        public LifeInsuranceStatus Disability { get; set; }
        public LifeInsuranceStatus Home { get; set; }
    }
}
