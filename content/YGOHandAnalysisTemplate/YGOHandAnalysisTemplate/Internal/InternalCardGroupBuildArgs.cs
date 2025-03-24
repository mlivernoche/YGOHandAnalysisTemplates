using CardSourceGenerator;

namespace YGOHandAnalysisTemplate.Internal;

internal record InternalCardGroupBuildArgs : ICardBuildArgs
{
    public required YGOCards.YGOCardName Name { get; init; }
}
