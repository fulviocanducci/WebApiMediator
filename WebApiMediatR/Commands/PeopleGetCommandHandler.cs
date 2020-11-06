using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediatR.Repositories;
namespace WebApiMediatR.Commands
{
    public class PeopleGetCommandHandler : IRequestHandler<PeopleGetCommand, IEnumerable<PeopleResult>>
    {
        private readonly IRepositoryPeople Repository;

        public PeopleGetCommandHandler(IRepositoryPeople repository)
        {
            Repository = repository;
        }
        public async Task<IEnumerable<PeopleResult>> Handle(PeopleGetCommand request, CancellationToken cancellationToken)
        {
            return await Repository.GetAsync(select => new PeopleResult(select.Id, select.Name));
        }
    }
}
