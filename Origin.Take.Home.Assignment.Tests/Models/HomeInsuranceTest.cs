using Origin.Take.Home.Assignment.Enums;
using Origin.Take.Home.Assignment.Models;
using Origin.Take.Home.Assignment.Requests;
using Xunit;

namespace Origin.Take.Home.Assignment.Tests.Models
{
    public class HomeInsuranceTest
    {
        [Fact]
        public void GivenHomeInsurance_WhenCustomerHouseNull_ThenLifeInsuranceStatusInelegible()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 20;
            var customerIncome = 0;
            House customerHouse = null;
            var disabilityInsurance = new HomeInsurance(baseScore, customerAge, customerIncome, customerHouse);

            //Act
            disabilityInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(LifeInsuranceStatus.Inelegible, disabilityInsurance.LifeInsuranceStatus);
        }

        [Fact]
        public void GivenHomeInsurance_WhenCustomerAge40_AndIncomeAbove200k_AndOwnershipStatusMortgaged_ThenTotalScoreEqual1()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 40;
            var customerIncome = 200000;
            var customerHouse = new House
            {
                OwnershipStatus = OwnershipStatus.Mortgaged
            };
            var disabilityInsurance = new HomeInsurance(baseScore, customerAge, customerIncome, customerHouse);

            //Act
            disabilityInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(1, disabilityInsurance.TotalScore);
        }

        [Fact]
        public void GivenHomeInsurance_WhenCustomerAge40_AndIncomeBelow200k_AndOwnershipStatusMortgaged_ThenTotalScoreEqual2()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 40;
            var customerIncome = 20000;
            var customerHouse = new House
            {
                OwnershipStatus = OwnershipStatus.Mortgaged
            };
            var disabilityInsurance = new HomeInsurance(baseScore, customerAge, customerIncome, customerHouse);

            //Act
            disabilityInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(2, disabilityInsurance.TotalScore);
        }
    }
}
