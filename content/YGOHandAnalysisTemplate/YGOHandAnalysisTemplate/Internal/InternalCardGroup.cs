using CardSourceGenerator;
using CommunityToolkit.Diagnostics;
using YGOHandAnalysisFramework.Data;

namespace YGOHandAnalysisTemplate.Internal;

internal class InternalCardGroup : ICardGroup<YGOCards.YGOCardName>, ICardBuildArgs
{
    public int Size { get; }
    public int Minimum { get; }
    public int Maximum { get; }
    public YGOCards.YGOCardName Name { get; }

    public InternalCardGroup(ICardGroup<YGOCards.YGOCardName> cardGroup, ICardBuildArgs cardBuildArgs)
    {
        Guard.IsEqualTo(cardGroup.Name, cardBuildArgs.Name);

        Size = cardGroup.Size;
        Minimum = cardGroup.Minimum;
        Maximum = cardGroup.Maximum;
        Name = cardGroup.Name;
    }

    public InternalCardGroup(YGOCards.YGOCardName card, int size)
    {
        Size = size;
        Minimum = 0;
        Maximum = size;
        Name = card;
    }
}
