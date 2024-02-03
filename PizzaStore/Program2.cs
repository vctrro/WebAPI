using Microsoft.OpenApi.Models;
using PizzaStore.DB2;

internal class Program2
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
        });
        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
        });

        app.MapGet("/", () => "Hello World!");
        app.MapGet("/pizzas/{id}", (int id) => PizzaDB2.GetPizza(id));
        app.MapGet("/pizzas", () => PizzaDB2.GetPizzas());
        app.MapPost("/pizzas", (Pizza pizza) => PizzaDB2.CreatePizza(pizza));
        app.MapPut("/pizzas", (Pizza pizza) => PizzaDB2.UpdatePizza(pizza));
        app.MapDelete("/pizzas/{id}", (int id) => PizzaDB2.RemovePizza(id));

        app.Run();
    }
}