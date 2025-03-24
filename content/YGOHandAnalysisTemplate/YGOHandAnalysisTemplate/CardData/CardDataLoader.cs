using CardSourceGenerator;

namespace YGOHandAnalysisTemplate.CardData;

internal static class CardDataLoader
{
    public static IEnumerable<YGOCards.IYGOCard> LoadCardData()
    {
        var path = Path.Combine(Environment.CurrentDirectory, "CardData");
        var files = Directory.GetFiles(path, "*.json");
        return YGOCards
            .LoadAllCardDataFromYgoPro(files)
            .Values;
    }
}
