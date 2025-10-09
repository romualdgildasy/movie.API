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
app.MapGet("movies", () => movies);

app.MapGet("movies{id}", (int id) =>
{
    MovieDto ? movie = movies.Find(movie => movie.Id == id);
    return (movie is null) ? Results.NotFound() : Results.Ok(movie);
}).WithName("GetMovie");
//creation de la route de post
app.MapPost("movies", (CreateMovieDto newMovie) =>
{
    MovieDto movie = new
        (
        Id: movies.Count + 1,
        Title: newMovie.Title,
        Director: newMovie.Director,
        ReleaseDate: newMovie.ReleaseDate
        );
    movies.Add(movie);

    return Results.CreatedAtRoute("GetMovie", new { id = movie.Id }, movie);
});

//creatio de la methgo PUT  pour modifier les films
app.MapPut("movies/{id}", (int id, UpdateMovieDto updateMovie) =>
    {
        var index = movies.FindIndex(movie => movie.Id == id);
        movies[index] = new MovieDto
        (
            id,
             updateMovie.Title,
             updateMovie.Director,
             updateMovie.ReleaseDate
        );
        return Results.NoContent();
    }
);

//creation de la methode de suppression
app.MapDelete("movies/{id}", (int id) =>
{
    movies.RemoveAll(movie => movie.Id == id);
    return Results.NoContent();
});

app.Run();
