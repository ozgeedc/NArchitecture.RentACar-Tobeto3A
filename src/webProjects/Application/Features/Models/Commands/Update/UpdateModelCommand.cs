using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Update
{
   public class UpdateModelCommand:IRequest<UpdateModelCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandId {  get; set; }
    }
}
