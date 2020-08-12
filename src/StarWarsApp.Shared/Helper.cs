using Jil;
using StarWarsApp.Shared.Interfaces;
using System.Text.Json;

namespace StarWarsApp.Shared
{
    public class Helper : IHelper
    {
        public T Deserialize<T>(string obj)
        {
            return JSON.Deserialize<T>(obj);
        }
    }
}
