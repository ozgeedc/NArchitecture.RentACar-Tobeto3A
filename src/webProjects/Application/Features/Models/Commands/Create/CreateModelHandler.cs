using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
{
    ///  Bu alan, model verilerini depolamak ve yönetmek için kullanılacak bir IModelRepository nesnesini temsil eder.
    private readonly IModelRepository _modelRepository;
    /// Bu alan, nesneler arasında veri eşleme (mapping) işlemlerini gerçekleştirmek için kullanılacak bir IMapper nesnesini temsil eder.
    private readonly IMapper _mapper;

    public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;  ///nesnesine eşleme işlemi gerçekleştiriliyor. _mapper nesnesi, bu işlemi sağlar.
    }

    public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        Model model = _mapper.Map<Model>(request);
        Model createdModel = await _modelRepository.AddAsync(model);
        CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(createdModel);
        return response;
    }
}
//Bu kod, CreateModelCommand isteğini işleyen bir sınıfı temsil eder ve veritabanına yeni bir model eklerken veri eşleme işlemlerini kullanır.