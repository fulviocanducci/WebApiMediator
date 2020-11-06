using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediatR.Repositories;

namespace WebApiMediatR.Commands
{
    public class PeopleGetByIdCommandHandler : IRequestHandler<PeopleGetByIdCommand, PeopleResult>
    {
        private readonly IRepositoryPeople Repository;

        public PeopleGetByIdCommandHandler(IRepositoryPeople repository)
        {
            Repository = repository;
        }
        public async Task<PeopleResult> Handle(PeopleGetByIdCommand request, CancellationToken cancellationToken)
        {
            return await Repository.FindAsync(w => w.Id == request.Id, s => new PeopleResult(s.Id, s.Name));
        }
    }
}
