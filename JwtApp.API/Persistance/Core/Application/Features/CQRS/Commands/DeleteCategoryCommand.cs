using MediatR;

namespace JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
