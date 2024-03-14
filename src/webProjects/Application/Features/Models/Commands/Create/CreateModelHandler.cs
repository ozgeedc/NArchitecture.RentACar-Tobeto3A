using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelHandler : IRequestHandler<CreateModelCommand, CreatedModelResponses>
{
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

    public CreateModelHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public Task<CreatedModelResponses> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        _modelRepository.AddAsync(request);
    }
}
         


