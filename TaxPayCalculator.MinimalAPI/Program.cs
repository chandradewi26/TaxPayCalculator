
using TaxPayCalculator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adding taxpay calculator as service ?
builder.Services.AddSingleton<ICalculator, TaxPayCalculator.TaxPayCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/sum", (int? n1, int? n2) => n1 + n2);

//https://www.youtube.com/watch?v=lSlPMDqVhFk
app.MapGet("/calculate", (decimal taxableIncome, ICalculator TaxPayCalculator) =>
{
    var resident = new Resident(taxableIncome);
    return TaxPayCalculator.Calculate(resident);
});

app.Run();
