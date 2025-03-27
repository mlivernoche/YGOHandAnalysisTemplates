using CommunityToolkit.Diagnostics;
using YGOHandAnalysisFramework.Data;

namespace SimpleAnalyzer.Internal;

internal record InternalCardGroup : ICardGroup<string>
{
    public required int Size { get; init; }
    public int Minimum { get; init; }
    public int Maximum { get; init; }
    public required string Name { get; init; }
}
