using MediatR;

namespace WebApiMediatR.Commands
{
    public class PeopleGetByIdCommand : IRequest<PeopleResult>
    {
        public PeopleGetByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
