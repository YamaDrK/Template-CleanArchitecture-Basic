namespace Application.Common.Exceptions
{
    public class DataNotFoundException(string entityName, int id) 
        : Exception($"Entity {entityName} ({id}) was not found!");
}
