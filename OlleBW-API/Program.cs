WebApplication app = WebApplication.Create();

app.Urls.Add("https://localhost:3000");
app.Urls.Add("https://*:3000");


List<Enemy> Enemies = new();

Enemies.Add(new() { Name = "FireDragon", Atk = 200, HP = 500 });

Enemies.Add(new() { Name = "Clown", Atk = 25, HP = 100 });

Enemies.Add(new() { Name = "Rat", Atk = 5, HP = 25 });

Enemies.Add(new() { Name = "Goblin", Atk = 25, HP = 50 });



app.MapGet("/", Answer);

app.MapGet("/Enemies/", () =>
{
    return Enemies;
});

app.MapGet("/Enemies/{num}", (int num) =>
{
    if (num >= 0 && num < Enemies.Count)
    {
        return Results.Ok(Enemies[num]);
    }
    return Results.NotFound();
});

app.MapPost("/Enemies", () =>
{
    Console.WriteLine("POST!");
});

app.Run();

static string Answer()
{
    return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque augue justo, blandit eu porttitor eleifend, elementum sit amet mi. Vestibulum eu odio nulla. Vivamus eget risus vel risus eleifend dignissim. Mauris libero orci, egestas a velit nec, commodo commodo magna. Curabitur diam augue, facilisis nec malesuada in, lobortis rutrum ipsum. Phasellus aliquet varius arcu, vel lacinia ligula dapibus ac. Nulla facilisi. Fusce mollis fermentum orci nec malesuada. Integer vel hendrerit nunc. Nullam convallis enim et dolor pellentesque placerat. Donec facilisis sodales iaculis. Nullam mollis faucibus feugiat. Maecenas quis neque nec nunc hendrerit porta. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Praesent semper diam vestibulum, dignissim nulla et, eleifend nunc.";
}