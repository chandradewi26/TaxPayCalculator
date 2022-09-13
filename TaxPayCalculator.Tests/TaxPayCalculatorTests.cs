namespace TaxPayCalculator.Tests;

/*Calculate tax + offset + medicare*/
public class TaxPayCalculatorTests
{
    private readonly ICalculator? _calculator;

    public TaxPayCalculatorTests()
    {
        _calculator = new TaxPayCalculator();
    }

    private Resident CreateResident(decimal taxableincome)
    {
        return new Resident(taxableincome);
    }

    private void TestCalculation(decimal input, decimal expectedOuput)
    {
        var resident = CreateResident(input);
        var result = _calculator.Calculate(resident);
        Assert.Equal(expectedOuput, result);
    }

    [Fact(DisplayName = "Given income of $15,000 - $0 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome15000_0AmountOfTaxWillBeApplied()
    {
        TestCalculation(15000, 0);
    }

    [Fact(DisplayName = "Given income of $37,000 - $2,937 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome37000_2937AmountOfTaxWillBeApplied()
    {
        TestCalculation(37000, 2937);
    }

    [Fact(DisplayName = "Given income of $40,000 - $3,467 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome40000_3467AmountOfTaxWillBeApplied()
    {
        TestCalculation(40000, 3467);
    }

    [Fact(DisplayName = "Given income of $45,000 - $4,392 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome45000_4392AmountOfTaxWillBeApplied()
    {
        TestCalculation(45000, 4392);
    }

    [Fact(DisplayName = "Given income of $55,000 - $7,767 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome55000_7767AmountOfTaxWillBeApplied()
    {
        TestCalculation(55000, 7767);
    }

    [Fact(DisplayName = "Given income of $70,000 - $13,117 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome70000_13117AmountOfTaxWillBeApplied()
    {
        TestCalculation(70000, 13117);
    }

    [Fact(DisplayName = "Given income of $92,000 - $20,767 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome92000_20767AmountOfTaxWillBeApplied()
    {
        TestCalculation(92000, 20767);
    }

    [Fact(DisplayName = "Given income of $120,000 - $31,267 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome120000_31267AmountOfTaxWillBeApplied()
    {
        TestCalculation(120000, 31267);
    }

    [Fact(DisplayName = "Given income of $150,000 - $43,567 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome150000_43567AmountOfTaxWillBeApplied()
    {
        TestCalculation(150000, 43567);
    }

    [Fact(DisplayName = "Given income of $180,000 - $55,267 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome180000_55267AmountOfTaxWillBeApplied()
    {
        TestCalculation(180000, 55267);
    }

    [Fact(DisplayName = "Given income of $200,000 - $64,667 tax will be applied")]
    public void TestTaxPayCalculator_GivenIncome200000_64667AmountOfTaxWillBeApplied()
    {
        TestCalculation(200000, 64667);
    }
}

/*
[Fact(DisplayName = "Given income of $15,000 - $0 tax will be applied")]
[Fact(DisplayName = "Given income of $37,000 - $2,937 tax will be applied")]
[Fact(DisplayName = "Given income of $40,000 - $3,467 tax will be applied")]
[Fact(DisplayName = "Given income of $45,000 - $4,392 tax will be applied")]
[Fact(DisplayName = "Given income of $55,000 - $7,767 tax will be applied")]
[Fact(DisplayName = "Given income of $70,000 - $13,117 tax will be applied")]
[Fact(DisplayName = "Given income of $92,000 - $20,767 tax will be applied")]
[Fact(DisplayName = "Given income of $120,000 - $31,267 tax will be applied")]
[Fact(DisplayName = "Given income of $150,000 - $43,567 tax will be applied")]
[Fact(DisplayName = "Given income of $180,000 - $55,267 tax will be applied")]
[Fact(DisplayName = "Given income of $200,000 - $64,667 tax will be applied")]
*/