using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommand : IRequest<UpdatedCarResponse>
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ModelYear { get; set; }
        public string Plate { get; set; }
        public int State { get; set; }  
        public double DailyPrice { get; set; }
    }
}