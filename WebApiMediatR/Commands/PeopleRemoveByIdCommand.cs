using MediatR;

namespace WebApiMediatR.Commands
{
    public class PeopleRemoveByIdCommand : IRequest<bool>
    {
        public PeopleRemoveByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
