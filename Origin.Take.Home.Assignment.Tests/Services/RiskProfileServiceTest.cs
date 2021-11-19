using Origin.Take.Home.Assignment.Enums;
using Origin.Take.Home.Assignment.Requests;
using Origin.Take.Home.Assignment.Services;
using Xunit;

namespace Origin.Take.Home.Assignment.Tests.Services
{
    public class RiskProfileServiceTest
    {
        [Fact]
        public void GivenRiskProfileRequest_WhenAge35_AndDependents2_AndHouseOwned_AndIncomeZero_AndMaritalStatusMarried_AndVehicleYear2018_ThenReturnLifeInsuranceStatusAutoRegular_AndDisabilityInelegible_AndHomeEconomic_AndLifeRegular()
        {
            //Arrange
            var riskProfileService = new RiskProfileService();
            var riskProfileRequest = new RiskProfileRequest
            {
                Age = 35,
                Dependents = 2,
                House = new House
                {
                    OwnershipStatus = OwnershipStatus.Owned
                },
                Income = 0,
                MaritalStatus = MaritalStatus.Married,
                RiskQuestions = new int[] { 0, 1, 0 },
                Vehicle = new Vehicle
                {
                    Year = 2018
                }
            };

            //Act
            var riskProfileResponse = riskProfileService.GetRiskProfile(riskProfileRequest);

            //Assert
            Assert.Equal(LifeInsuranceStatus.Regular, riskProfileResponse.Auto);
            Assert.Equal(LifeInsuranceStatus.Inelegible, riskProfileResponse.Disability);
            Assert.Equal(LifeInsuranceStatus.Economic, riskProfileResponse.Home);
            Assert.Equal(LifeInsuranceStatus.Regular, riskProfileResponse.Life);
        }
    }
}
