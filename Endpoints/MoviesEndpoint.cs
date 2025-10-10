using movie.API.Dtos;

namespace movie.API.endpoints;

public static class MoviesEndpoint
{

    private static readonly List<MovieDto> movies =
    [
        new(1,"Inception","Christopher Nolan", new DateOnly(2010,7,16)),
        new(2,"Matrix","Toukof Lerusse", new DateOnly(1993,3,31)),
        new(3,"Le Parrain","Francis Ford", new DateOnly(1972,3,24)),
    ];
     public static RouteGroupBuilder MapMoviesEndpoint (this WebApplication app)
     {
        var group = app.MapGroup("/movies");
            //creation de la route de get
        group.MapGet("/", () => movies);    

                group.MapGet("/{id}", (int id) =>
                {
                    MovieDto ? movie = movies.Find(movie => movie.Id == id);
                    return (movie is null) ? Results.NotFound() : Results.Ok(movie);
                }).WithName("GetMovie");
            //creation de la route de post
                group.MapPost("/", (CreateMovieDto newMovie) =>
                {
                    if (string.IsNullOrEmpty(newMovie.Title))
                    {
                        return Results.BadRequest("Le titre du film est obligatoire.");
                    }
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
                group.MapPut("/{id}", (int id, UpdateMovieDto updateMovie) =>
                    {
                        var index = movies.FindIndex(movie => movie.Id == id);
                        if (index== -1)
                        {
                            return Results.NotFound();
                        }
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
                group.MapDelete("/{id}", (int id) =>
                {
                    movies.RemoveAll(movie => movie.Id == id);
                    return Results.NoContent();
                });
            return group;
    }
}
