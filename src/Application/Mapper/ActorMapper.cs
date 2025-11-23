using System;
using Application.Abstractions.Mapper;
using Application.Dtos;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mapper;

[Mapper]
public partial class ActorMapper : IActorMapper
{
    public partial ActorDto ToActorDto(Actor actor);

    public partial Actor ToActor(CreateActorDto dto);

    [MapProperty(nameof(Actor.FirstName), nameof(ActorDto.FullName))]
    [MapProperty(nameof(Actor.LastName), nameof(ActorDto.FullName))]
    private static string CombineName(string first, string last) => $"{first} {last}";
}
