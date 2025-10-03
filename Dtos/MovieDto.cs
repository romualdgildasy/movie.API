using System;

namespace movie.API.Dtos;

public record MovieDto
(
    int Id,
    string Title,
    string Director,
    DateOnly ReleaseDate
);
