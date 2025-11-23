using System;

namespace Application.Dtos;

public class CreateActorDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public int Age { get; set; }
}
