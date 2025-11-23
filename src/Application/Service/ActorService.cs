using System;
using Application.Abstractions.Service;
using Application.Dtos;
using Application.Mapper;

namespace Application.Service;

public class ActorService : IActorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ActorMapper _mapper;

    public ActorService(IUnitOfWork unitOfWork, ActorMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<ActorDto> GetAll()
    {
        var actors = _unitOfWork.Actors.Get();
        return actors.Select(_mapper.ToActorDto);
    }
    public async Task<ActorDto?> GetByIdAsync(int id)
    {
        var actor = await _unitOfWork.Actors.GetByIdAsync(id);
        return actor is null ? null : _mapper.ToActorDto(actor);
    }

    public ActorDto Create(CreateActorDto dto)
    {
        var actor = _mapper.ToActor(dto);

        // Business rule example
        // if (actor.Age < 18)
        //     throw new Exception("Actor must be at least 18 years old.");

        if (string.IsNullOrEmpty(actor.FirstName))
            throw new Exception("Actor FirstName must not be empty.");

        _unitOfWork.Actors.Insert(actor);
        return _mapper.ToActorDto(actor);
    }
}
