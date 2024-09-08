namespace Cashing.Bl.Interfaces
{
    public interface IMemoryCahService
    {
        public T GetFromCash<T>(string key);
        public T SettoCash<T>(string key, T value);
        public void RemoveFromCash(string key);
    }
}
