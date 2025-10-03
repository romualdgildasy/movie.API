using movie.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<MovieDto> movies =
[
    new(1,"Inception","Christopher Nolan", new DateOnly(2010,7,16)),
    new(2,"Matrix","Toukof Lerusse", new DateOnly(1993,3,31)),
    new(3,"Le Parrain","Francis Ford", new DateOnly(1972,3,24)),
];

//route pour nos film
app.MapGet("/movies", () => movies);

app.MapGet("/movies{id}", (int id) => movies.Find(movie => movie.Id == id));

app.Run();
