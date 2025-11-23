using System;
using Application.Dtos;

namespace Application.Abstractions.Service;

public interface IActorService
{
    IEnumerable<ActorDto> GetAll();
    Task<ActorDto>? GetByIdAsync(int id);
    ActorDto Create(CreateActorDto dto);
}
