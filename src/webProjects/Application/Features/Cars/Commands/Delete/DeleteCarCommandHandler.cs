using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        Car? car = await _carRepository.GetAsync(c => c.Id == request.Id, include: x => x.Include(x => x.Model));
        Car deletedCar = await _carRepository.DeleteAsync(car);
        DeleteCarResponse response = _mapper.Map<DeleteCarResponse>(deletedCar);
        return response;
    }
}