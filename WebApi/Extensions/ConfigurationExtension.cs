namespace WebApi.Extensions
{
    public static class ConfigurationExtension
    {
        public static int[] GetSizePagination(this IConfiguration configuration)
        {
            int[] size = Array.Empty<int>();
            configuration.Bind("Options:PaginationOption", size);
            return size;
        }
    }
}
