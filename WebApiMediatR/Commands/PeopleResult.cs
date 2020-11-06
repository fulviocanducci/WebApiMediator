namespace WebApiMediatR.Commands
{
    public class PeopleResult
    {
        public PeopleResult(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get;  }        
        public string Name { get; }
    }
}
