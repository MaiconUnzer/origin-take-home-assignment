using Origin.Take.Home.Assignment.Enums;
using Origin.Take.Home.Assignment.Models;
using Origin.Take.Home.Assignment.Requests;
using Xunit;

namespace Origin.Take.Home.Assignment.Tests.Models
{
    public class DisabilityInsuranceTest
    {
        [Fact]
        public void GivenDisabilityInsurance_WhenIncomeEqualZero_ThenLifeInsuranceStatusInelegible()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 20;
            var customerIncome = 0;
            House customerHouse = null;
            var customerDependents = 0;
            var customerMaritalStatus = MaritalStatus.Married;
            var disabilityInsurance = new DisabilityInsurance(baseScore, customerAge, customerIncome, customerHouse, customerDependents, customerMaritalStatus);

            //Act
            disabilityInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(LifeInsuranceStatus.Inelegible, disabilityInsurance.LifeInsuranceStatus);
        }

        [Fact]
        public void GivenDisabilityInsurance_WhenCustomerAgeAbove60_ThenLifeInsuranceStatusInelegible()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 61;
            var customerIncome = 0;
            House customerHouse = null;
            var customerDependents = 0;
            var customerMaritalStatus = MaritalStatus.Married;
            var disabilityInsurance = new DisabilityInsurance(baseScore, customerAge, customerIncome, customerHouse, customerDependents, customerMaritalStatus);

            //Act
            disabilityInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(LifeInsuranceStatus.Inelegible, disabilityInsurance.LifeInsuranceStatus);
        }

        [Fact]
        public void GivenDisabilityInsurance_WhenCustomerAge40_AndOwnershipStatusMortgaged_AndCustomerHasDependents_AndMaritalStatusEqualMarried_ThenTotalScoreEqual2()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 40;
            var customerIncome = 20000;
            var customerHouse = new House
            {
                OwnershipStatus = OwnershipStatus.Mortgaged
            };
            var customerDependents = 1;
            var customerMaritalStatus = MaritalStatus.Married;
            var disabilityInsurance = new DisabilityInsurance(baseScore, customerAge, customerIncome, customerHouse, customerDependents, customerMaritalStatus);

            //Act
            disabilityInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(2, disabilityInsurance.TotalScore);
        }
    }
}
