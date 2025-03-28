using CardSourceGenerator;
using YGOHandAnalysisFramework.Data;

namespace SimpleAnalyzerWSourceGen.Internal;

internal record InternalCardGroup : ICardGroup<YGOCards.YGOCardName>
{
    public required int Size { get; init; }
    public int Minimum => 0;
    public int Maximum => Size;
    public required YGOCards.YGOCardName Name { get; init; }
}
