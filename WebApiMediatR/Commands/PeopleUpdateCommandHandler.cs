using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediatR.Models;
using WebApiMediatR.Repositories;

namespace WebApiMediatR.Commands
{
    public class PeopleUpdateCommandHandler : IRequestHandler<PeopleUpdateCommand, bool>
    {
        private readonly IRepositoryPeople Repository;

        public PeopleUpdateCommandHandler(IRepositoryPeople repository)
        {
            Repository = repository;
        }
        public async Task<bool> Handle(PeopleUpdateCommand request, CancellationToken cancellationToken)
        {
            People people = new People
            {
                Id = request.Id,
                Name = request.Name
            };
            return await Repository.UpdateAsync(people);
        }
    }
}
