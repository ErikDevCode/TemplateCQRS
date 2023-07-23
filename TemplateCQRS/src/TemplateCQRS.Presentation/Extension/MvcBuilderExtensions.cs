namespace TemplateCQRS.Presentation.Extension
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddJsonCamelCase(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            });
            return mvcBuilder;
        }
    }
}

