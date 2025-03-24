using CardSourceGenerator;
using YGOHandAnalysisFramework.Features.Caching;

namespace YGOHandAnalysisTemplate.Internal;

internal sealed class InternalHandAnalyzerLoader : HandAnalyzerLoader<InternalCardGroup, YGOCards.YGOCardName>
{
    public InternalHandAnalyzerLoader(string workingDirectory) : base(workingDirectory)
    {

    }

    protected override YGOCards.YGOCardName ConvertCardNameFromString(string cardName)
    {
        return new(cardName);
    }

    protected override string ConvertCardNameToString(YGOCards.YGOCardName cardName)
    {
        return cardName.Name;
    }
}
