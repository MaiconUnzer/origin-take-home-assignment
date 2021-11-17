using Origin.Take.Home.Assignment.Enums;
using Origin.Take.Home.Assignment.Models;
using Origin.Take.Home.Assignment.Requests;
using System;
using Xunit;

namespace Origin.Take.Home.Assignment.Tests.Models
{
    public class AutoInsuranceTest
    {
        [Fact]
        public void GivenAutoInsurance_WhenCustomerVehicleNull_ThenLifeInsuranceStatusInelegible()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 20;
            var customerIncome = 20000;
            Vehicle customerVehicle = null;
            var autoInsurance = new AutoInsurance(baseScore, customerAge, customerIncome, customerVehicle);

            //Act
            autoInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(LifeInsuranceStatus.Inelegible, autoInsurance.LifeInsuranceStatus);
        }

        [Fact]
        public void GivenAutoInsurance_WhenCustomerAgeBelow30_AndBaseScore2_AndSalaryBelow200k_AndVehicleLessThanFiveYearsOld_ThenTotalScoreEqualOne()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 20;
            var customerIncome = 300;
            var customerVehicle = new Vehicle
            {
                Year = DateTime.Now.AddYears(-3).Year
            };
            var autoInsurance = new AutoInsurance(baseScore, customerAge, customerIncome, customerVehicle);

            //Act
            autoInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(1, autoInsurance.TotalScore);
        }

        [Fact]
        public void GivenAutoInsurance_WhenCustomerAgeBelow30_AndBaseScore2_AndSalaryAbove200k_AndVehicleLessThanFiveYearsOld_ThenTotalScoreEqualZero()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 20;
            var customerIncome = 200000;
            var customerVehicle = new Vehicle
            {
                Year = DateTime.Now.AddYears(-3).Year
            };
            var autoInsurance = new AutoInsurance(baseScore, customerAge, customerIncome, customerVehicle);

            //Act
            autoInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(0, autoInsurance.TotalScore);
        }

        [Fact]
        public void GivenAutoInsurance_WhenCustomerAgeBelow30_AndBaseScore2_AndSalaryAbove200k_AndVehicleIsMoreThanFiveYearsOld_ThenTotalScoreEqualNegativeOne()
        {
            //Arrange
            var baseScore = 2;
            var customerAge = 20;
            var customerIncome = 200000;
            var customerVehicle = new Vehicle
            {
                Year = DateTime.Now.AddYears(-6).Year
            };
            var autoInsurance = new AutoInsurance(baseScore, customerAge, customerIncome, customerVehicle);

            //Act
            autoInsurance.CalculateInsurance();

            //Assert
            Assert.Equal(-1, autoInsurance.TotalScore);
        }
    }
}
