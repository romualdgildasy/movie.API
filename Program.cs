using movie.API.endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapMoviesEndpoint();


app.Run();
