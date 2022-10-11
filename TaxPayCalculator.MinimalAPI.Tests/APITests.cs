using Microsoft.AspNetCore.Mvc.Testing;

namespace TaxPayCalculator.MinimalAPI.Tests
{
    [TestClass]
    public class APITests
    {
        private HttpClient _httpClient;

        public APITests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task DefaultRoute_ReturnsHelloWorld()
        {
            var response = await _httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("Hello World!", stringResult);
        }

        [TestMethod]
        public async Task Sum_Returns16For10And6()
        {
            var response = await _httpClient.GetAsync("/sum?n1=10&n2=6");
            var stringResult = await response.Content.ReadAsStringAsync();
            var intResult = int.Parse(stringResult);

            Assert.AreEqual(16, intResult);
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

            var response = await _httpClient.GetAsync($"/calculate?taxableIncome={decimalTaxableIncome}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var decimalResult = decimal.Parse(stringResult);

            Assert.AreEqual(decimalTaxAmount, decimalResult);
        }
    }
}