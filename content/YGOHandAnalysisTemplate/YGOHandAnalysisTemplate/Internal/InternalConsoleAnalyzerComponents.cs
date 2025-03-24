using CardSourceGenerator;
using YGOHandAnalysisFramework;
using YGOHandAnalysisFramework.Data;
using YGOHandAnalysisFramework.Features.Caching;
using YGOHandAnalysisFramework.Features.Configuration;
using YGOHandAnalysisFramework.Features.Console;
using YGOHandAnalysisFramework.Projects;

namespace YGOHandAnalysisTemplate.Internal;

internal class InternalConsoleAnalyzerComponents : ConsoleAnalyzerComponents<InternalCardGroup, YGOCards.YGOCardName>
{
    private DictionaryWithGeneratedKeys<YGOCards.YGOCardName, InternalCardGroupBuildArgs> BuildArgs { get; }
    private List<IProject<InternalCardGroup, YGOCards.YGOCardName>> Projects { get; }

    public InternalConsoleAnalyzerComponents(IEnumerable<InternalCardGroupBuildArgs> buildArgs, IEnumerable<IProject<InternalCardGroup, YGOCards.YGOCardName>> projects)
    {
        BuildArgs = new DictionaryWithGeneratedKeys<YGOCards.YGOCardName, InternalCardGroupBuildArgs>(static staple => staple.Name, buildArgs);
        Projects = [.. projects];
    }

    public override HandAnalyzerLoader<InternalCardGroup, YGOCards.YGOCardName> CreateCacheLoader(IConfiguration<YGOCards.YGOCardName> configuration)
    {
        return new InternalHandAnalyzerLoader(configuration.CacheLocation);
    }

    public override InternalCardGroup CreateCardGroup(ICardGroup<YGOCards.YGOCardName> cardGroup)
    {
        if (BuildArgs.TryGetValue(cardGroup.Name, out var buildArgs))
        {
            return new InternalCardGroup(cardGroup, buildArgs);
        }

        return new InternalCardGroup(cardGroup, new InternalCardGroupBuildArgs() { Name = cardGroup.Name });
    }

    public override YGOCards.YGOCardName CreateCardGroupName(string name)
    {
        return new(name);
    }

    public override InternalCardGroup CreateMiscCardGroup(int size)
    {
        var name = CreateCardGroupName("misc");
        return new InternalCardGroup(name, size);
    }

    public override IEnumerable<IProject<InternalCardGroup, YGOCards.YGOCardName>> CreateProjects(IConfiguration<YGOCards.YGOCardName> configuration)
    {
        return Projects;
    }
}
