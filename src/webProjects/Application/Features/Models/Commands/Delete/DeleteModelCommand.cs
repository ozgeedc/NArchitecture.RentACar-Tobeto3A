using Application.Features.Models.Dtos;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

internal class DeleteModelCommand: IRequest<DeletedModelResponses>
{
    public int Id { get; set; }
}
