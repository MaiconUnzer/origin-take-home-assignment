using Microsoft.AspNetCore.Mvc;
using Origin.Take.Home.Assignment.Requests;
using Origin.Take.Home.Assignment.Responses;
using Origin.Take.Home.Assignment.Services;

namespace Origin.Take.Home.Assignment.Controllers
{
    [ApiController]
    [Route("risk-profile")]
    public class RiskProfileController : Controller
    {
        private readonly RiskProfileService _riskProfileService;

        public RiskProfileController(RiskProfileService riskProfileService)
        {
            _riskProfileService = riskProfileService;
        }

        [HttpPost]
        public ActionResult<RiskProfileResponse> GetRiskProfile([FromBody] RiskProfileRequest riskProfileRequest)
        {
            var riskProfileResponse = _riskProfileService.GetRiskProfile(riskProfileRequest);

            return Ok(riskProfileResponse);
        }
    }
}
