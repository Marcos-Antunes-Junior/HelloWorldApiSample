var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Endpoint responsible for returning the "Hello World" message.
app.MapPost("/helloWorld", (Person person) =>
{
    if (string.IsNullOrEmpty(person.Name) || string.IsNullOrWhiteSpace(person.Name))
    {
        return Results.BadRequest("Name cannot be empty.");
    }
    
    var message = $"Hello World!\nName: {person.Name}\nDate: {DateTime.Now}";
    return Results.Text(message);


});

app.Run();

record Person(string Name);


