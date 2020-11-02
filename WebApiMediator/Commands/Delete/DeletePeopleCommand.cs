using SimpleSoft.Mediator;
using WebApiMediator.Models;

namespace WebApiMediator.Commands.Delete
{
    public class DeletePeopleCommand : Command<bool>
    {
        public int PeopleId { get; set; }
    }
}
