namespace IdentifiersService.Abstraction
{
    public interface IIdentifiersRepository
    {
        dynamic GenerateIdentifiers();
        string GenerateResourceNames(string key);
    }
}