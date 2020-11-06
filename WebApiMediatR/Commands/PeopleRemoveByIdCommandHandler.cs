using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediatR.Repositories;

namespace WebApiMediatR.Commands
{
    public class PeopleRemoveByIdCommandHandler : IRequestHandler<PeopleRemoveByIdCommand, bool>
    {
        private readonly IRepositoryPeople Repository;

        public PeopleRemoveByIdCommandHandler(IRepositoryPeople repository)
        {
            Repository = repository;
        }
        public async Task<bool> Handle(PeopleRemoveByIdCommand request, CancellationToken cancellationToken)
        {
            return await Repository.DeleteAsync(request.Id);
        }
    }
}
