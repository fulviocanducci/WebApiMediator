using MediatR;
using System.Collections.Generic;

namespace WebApiMediatR.Commands
{
    public class PeopleGetCommand: IRequest<IEnumerable<PeopleResult>>
    {

    }
}
