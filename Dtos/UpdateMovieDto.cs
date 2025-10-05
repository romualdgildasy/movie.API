using System;

namespace movie.API.Dtos;

public record class UpdateMovieDto
(
     string Title,
    string Director,
    DateOnly ReleaseDate
);
