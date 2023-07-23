namespace TemplateCQRS.Shared.Extensions
{
    public static class DictionaryExtension
    {
        public static T GetValueOrDefault<T>(this IDictionary<string, string> metaData, string keyName, T defaultValue)
        {
            return metaData.TryGetValue(keyName, out var metaDataValue) ? (T)Convert.ChangeType(metaDataValue, typeof(T)) : defaultValue;
        }
    }
}

