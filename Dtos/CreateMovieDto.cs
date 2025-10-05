using System;

namespace movie.API.Dtos;

public record class CreateMovieDto
(
    string Title,
    string Director,
    DateOnly ReleaseDate
);