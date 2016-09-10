namespace WebsitePerformance.Contracts.Validator
{
    public interface IValidator<CoreType>
    {
        string[] Results { get; }
        bool IsValid(CoreType value);
        bool IsExist(int id);
    }
}