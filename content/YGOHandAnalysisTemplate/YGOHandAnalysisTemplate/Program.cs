using CardSourceGenerator;
using YGOHandAnalysisFramework.Features.Console;
using YGOHandAnalysisFramework.Projects;
using YGOHandAnalysisTemplate.Internal;

namespace YGOHandAnalysisTemplate;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        await ConsoleConfiguration.Execute(args, YGOCards.AllCardNames, static name => name.Name, new InternalConsoleAnalyzerComponents(GetCardGroupBuildArgs(), GetProjects()));
    }

    private static IEnumerable<InternalCardGroupBuildArgs> GetCardGroupBuildArgs()
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<IProject<InternalCardGroup, YGOCards.YGOCardName>> GetProjects()
    {
        throw new NotImplementedException();
    }
}
