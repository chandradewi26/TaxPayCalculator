using Microsoft.AspNetCore.Mvc.Testing;

namespace TaxPayCalculator.APITests
{
    [TestClass]
    public class Tests
    {
        private HttpClient _httpClient;

        public Tests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        [DataRow(15000, 0)]
        [DataRow(37000, 2937)]
        [DataRow(40000, 3467)]
        [DataRow(45000, 4392)]
        [DataRow(55000, 7767)]
        [DataRow(70000, 13117)]
        [DataRow(92000, 20767)]
        [DataRow(120000, 31267)]
        [DataRow(150000, 43567)]
        [DataRow(180000, 55267)]
        [DataRow(200000, 64667)]
        public async Task GivenIncome_ReturnCorrectTaxAmount(int taxableIncome, int taxAmount)
        {
            decimal decimalTaxableIncome = taxableIncome;
            decimal decimalTaxAmount = taxAmount;

            var response = await _httpClient.GetAsync($"/TaxPayCalculator?income={decimalTaxableIncome}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var decimalResult = decimal.Parse(stringResult);

            Assert.AreEqual(decimalTaxAmount, decimalResult);
        }

    }
}