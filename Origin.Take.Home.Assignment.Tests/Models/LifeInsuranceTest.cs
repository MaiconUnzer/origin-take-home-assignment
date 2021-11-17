using Origin.Take.Home.Assignment.Enums;
using Origin.Take.Home.Assignment.Models;
using Origin.Take.Home.Assignment.Requests;
using Xunit;

namespace Origin.Take.Home.Assignment.Tests.Models
{
    public class LifeInsuranceTest
    {
        [Fact]
        public void GivenLifeInsurance_WhenCustomerAgeAbove60_ThenLifeInsuranceStatusInelegible()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 61;
            var customerIncome = 0;
            var customerDependents = 0;
            var customerMaritalStatus = MaritalStatus.Married;
            var lifeInsurance = new LifeInsurance(baseScore, customerAge, customerIncome, customerDependents, customerMaritalStatus);

            //Act
            lifeInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(LifeInsuranceStatus.Inelegible, lifeInsurance.LifeInsuranceStatus);
        }

        [Fact]
        public void GivenLifeInsurance_WhenCustomerAgeBelow30_AndIncomeAbove200k_AndCustomerHasDependents_AndMaritalStatusMarried_ThenTotalScoreEqual1()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 29;
            var customerIncome = 200000;
            var customerDependents = 1;
            var customerMaritalStatus = MaritalStatus.Married;
            var lifeInsurance = new LifeInsurance(baseScore, customerAge, customerIncome, customerDependents, customerMaritalStatus);

            //Act
            lifeInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(1, lifeInsurance.TotalScore);
        }

        [Fact]
        public void GivenLifeInsurance_WhenCustomerAgeBelow30_AndIncomeBelow200k_AndCustomerHasDependents_AndMaritalStatusMarried_ThenTotalScoreEqual2()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 29;
            var customerIncome = 20000;
            var customerDependents = 1;
            var customerMaritalStatus = MaritalStatus.Married;
            var lifeInsurance = new LifeInsurance(baseScore, customerAge, customerIncome, customerDependents, customerMaritalStatus);

            //Act
            lifeInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(2, lifeInsurance.TotalScore);
        }
    }
}
