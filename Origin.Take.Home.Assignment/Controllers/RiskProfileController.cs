using Microsoft.AspNetCore.Mvc;
using Origin.Take.Home.Assignment.Models;
using Origin.Take.Home.Assignment.Requests;
using Origin.Take.Home.Assignment.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Take.Home.Assignment.Controllers
{
    [ApiController]
    [Route("risk-profile")]
    public class RiskProfileController : Controller
    {
        [HttpPost]
        public ActionResult<RiskProfileResponse> GetRiskProfile([FromBody] RiskProfileRequest riskProfileRequest)
        {
            var baseScore = riskProfileRequest.RiskQuestions.Count(x => x == true);

            Insurance homeInsurance = new HomeInsurance(baseScore, riskProfileRequest.Age, riskProfileRequest.Income, riskProfileRequest.House);
            Insurance autoInsurance = new AutoInsurance(baseScore, riskProfileRequest.Age, riskProfileRequest.Income, riskProfileRequest.Vehicle);
            Insurance lifeInsurance = new LifeInsurance(baseScore, riskProfileRequest.Age, riskProfileRequest.Income, riskProfileRequest.Dependents, riskProfileRequest.MaritalStatus);
            Insurance disabilityInsurance = new DisabilityInsurance(baseScore, riskProfileRequest.Age, riskProfileRequest.Income, riskProfileRequest.House, riskProfileRequest.Dependents, riskProfileRequest.MaritalStatus);

            List<Insurance> insurances = new()
            {
                homeInsurance,
                autoInsurance,
                lifeInsurance,
                disabilityInsurance
            };

            Parallel.ForEach(insurances, (insurance) =>
            {
                insurance.CalculateInsurance();
            });

            var riskProfileResponse = new RiskProfileResponse
            {
                Auto = autoInsurance.LifeInsuranceStatus,
                Disability = disabilityInsurance.LifeInsuranceStatus,
                Home = homeInsurance.LifeInsuranceStatus,
                Life = lifeInsurance.LifeInsuranceStatus
            };

            return Ok(riskProfileResponse);
        }
    }
}
