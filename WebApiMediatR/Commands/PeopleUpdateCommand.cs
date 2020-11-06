using MediatR;
using System.ComponentModel.DataAnnotations;

namespace WebApiMediatR.Commands
{
    public class PeopleUpdateCommand : IRequest<bool>
    {        

        [Required(ErrorMessage = "Digite o Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        public string Name { get; set; }
    }
}
