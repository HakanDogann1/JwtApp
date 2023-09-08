using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommand:IRequest
    {
        public string Definition { get; set; }
    }
}
