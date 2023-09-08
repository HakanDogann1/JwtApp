using JwtApp.API.Persistance.Core.Application.Interfaces;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string Definition { get; set; }

    }
}
