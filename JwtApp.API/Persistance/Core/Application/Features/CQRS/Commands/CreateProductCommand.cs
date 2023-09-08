using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands
{
    public class CreateProductCommand:IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
