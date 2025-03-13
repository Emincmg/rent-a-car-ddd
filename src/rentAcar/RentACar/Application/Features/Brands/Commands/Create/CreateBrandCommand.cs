using MediatR;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand: IRequest<CreatedBrandResponse>
{
    public string Name { get; set; }
    
    public class CreatedBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        public Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = request.Name;
            createdBrandResponse.Id = Guid.NewGuid();
            return null;
        }
    }
}