using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApiMediatR.Commands
{
    public class PeopleCreateCommand : IRequest<PeopleResult>
    {
        [Required(ErrorMessage = "Digite o Nome")]
        public string Name { get; set; }
    }
}
