using Microsoft.AspNetCore.Builder;
using Tailwind;

namespace SharedUI;

public static class DependencyInjection
{
    public static void AddTailwindWatch(this IApplicationBuilder builder)
    {
        var srcDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent;

        var sharedUIDirectory = srcDirectory!.GetDirectories("common").First().GetDirectories("SharedUI").First();

        builder.RunTailwind("buildcss:watch", sharedUIDirectory.FullName);
    }
}