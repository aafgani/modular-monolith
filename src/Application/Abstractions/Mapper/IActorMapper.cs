using System;
using Application.Dtos;
using Domain.Entities;

namespace Application.Abstractions.Mapper;

public interface IActorMapper
{
    public ActorDto ToActorDto(Actor actor);

    public Actor ToActor(CreateActorDto dto);
}
