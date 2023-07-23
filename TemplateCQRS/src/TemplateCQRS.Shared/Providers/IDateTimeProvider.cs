namespace TemplateCQRS.Shared.Providers
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}

