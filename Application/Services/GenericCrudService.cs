using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Entities;
using AutoMapper;

namespace Application.Services;

public class GenericCrudService<T, Repository> : IGenericCrudService
    where T : EntityBase
    where Repository : IRepository<T>
{

    private Repository _repository;
    private IMapper _mapper;

    public GenericCrudService(Repository repository, IMapper mapper) 
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async virtual Task<OutputDto> GetById<InputDto, OutputDto>(InputDto inputDto)
    {
        var getEntity = _mapper.Map<T>(inputDto);

        var foundEntity = await _repository.GetById(getEntity);

        var foundDto = _mapper.Map<OutputDto>(foundEntity);

        return foundDto;
    }

    public async virtual Task<IEnumerable<OutputDto>> List<InputDto, OutputDto>(InputDto inputDto)
    {
        var listEntity = _mapper.Map<T>(inputDto);

        var listedEntities = await _repository.List(listEntity);

        var listedDtos = _mapper.Map<IEnumerable<OutputDto>>(listedEntities);

        return listedDtos;
    }

}
