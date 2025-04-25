namespace Application.Commons.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(Type entityType, int id) 
            : base($"Entity {entityType.Name} ({id}) was not found!") { }

        public DataNotFoundException(string? message) : base(message) { }
    }
}
