using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiMediatR.Models;
using WebApiMediatR.Repositories;

namespace WebApiMediatR.Commands
{
    public class PeopleCreateCommandHandler : IRequestHandler<PeopleCreateCommand, PeopleResult>
    {
        private readonly IRepositoryPeople Repository;
        public PeopleCreateCommandHandler(IRepositoryPeople repository)
        {
            Repository = repository;
        }

        public async Task<PeopleResult> Handle(PeopleCreateCommand request, CancellationToken cancellationToken)
        {
            People people = new People
            {
                Name = request.Name
            };
            await Repository.AddAsync(people);
            return new PeopleResult(people.Id, people.Name);
        }
    }
}
