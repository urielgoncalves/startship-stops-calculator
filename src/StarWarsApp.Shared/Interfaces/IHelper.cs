namespace StarWarsApp.Shared.Interfaces
{
    public interface IHelper
    {
        T Deserialize<T>(string obj);
    }
}
