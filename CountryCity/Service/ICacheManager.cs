namespace CountryCity.Service
{
    public interface ICacheManager
    {
        void Set<T>(string cacheKey, T model);

        Task<bool> Clear();

        T Get<T>(string cacheKey);

        bool Contains(object key);

        void Remove(object key);

    }
}
