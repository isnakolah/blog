namespace Common.Application.Common.Extensions;

internal static class SlugExtensions
{
    public static string CreateSlug(this string str)
    {
        var slug = string.Join("-", str.ToLower().Split(" ", StringSplitOptions.TrimEntries));

        return slug;
    }

    public static string RemakeStringFromSlug(this string slug)
    {
        var str = string.Join(" ", slug.Split("-"));

        return str;
    }
}