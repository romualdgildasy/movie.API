using System;
using System.ComponentModel.DataAnnotations;

namespace movie.API.Dtos;

public record class CreateMovieDto
(
    [Required] string Title,
    [Required] string Director,
    DateOnly ReleaseDate
);