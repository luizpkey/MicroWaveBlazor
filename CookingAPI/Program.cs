using CookingAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var database = new InMemoryDatabase();

app.MapGet("/recipes", () =>
    {
        return database.GetCulinaryItems();
    })
    .WithName("GetCulinaryItems")
    .WithOpenApi();

app.MapGet("/recipe/{id}", (int id) =>
    {
        var item = database.GetCulinaryItemById(id);
        if (item == null)
        {
            return Results.NotFound(new { Message = "Receita não encontrada" });
        }
        return Results.Ok(item);

    })
    .WithName("GetCulinaryItemById")
    .WithOpenApi();

    app.MapPut("/my_recipe",
        (MyCulinaryItemDTO recipe) => { var updatedItem = database.AlterCulinaryItem(recipe);
            if (updatedItem == null)
            {
                return Results.NotFound();
                
            } return Results.Ok(updatedItem); })
        .WithName("MyRecipe: Update")
        .WithSummary("Atualiza meu jeito")
        .WithDescription("Atualiza receita personalizada")
        .Produces<CulinaryItem>();


app.Run();


