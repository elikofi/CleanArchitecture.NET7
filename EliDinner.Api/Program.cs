using EliDinner.Api;
using EliDinner.Application;
using EliDinner.Infractructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DI
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration); //added services from DI class.




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseExceptionHandler("/error");//This is to be checked on
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

