namespace WebsitePerformance.Contracts.Services
{
    /// <summary>
    /// Base interface for all WebsitePerformance services
    /// </summary>
    /// <typeparam name="T">DTO type, which will received from Web API</typeparam>
    public interface IAddable<T>
    {
        /// <summary>
        /// Use for add new entity
        /// </summary>
        /// <param name="value">Entity for adding</param>
        void Add(T value);
    }
}