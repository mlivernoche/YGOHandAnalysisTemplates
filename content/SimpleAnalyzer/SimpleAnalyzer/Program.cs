using SimpleAnalyzer.Internal;
using YGOHandAnalysisFramework;
using YGOHandAnalysisFramework.Data;
using YGOHandAnalysisFramework.Features.Analysis;

string analyzerName = "Simple Analyzer";
int deckSize = 40;
int handSize = 5;

var cardBuildArgs = new CardGroupCollection<InternalCardGroup, string>()
    .Add(new InternalCardGroup()
    {
        Name = "Starters",
        Size = 14,
        Minimum = 1,
        Maximum = 5
    })
    .Add(new InternalCardGroup()
    {
        Name = "Hand Traps",
        Size = 20,
        Minimum = 2,
        Maximum = 5
    });

var cardList = CardList
    .Create(cardBuildArgs)
    .Fill(deckSize, static size => new InternalCardGroup()
    {
        Name = "Miscellaneous",
        Size = size,
        Minimum = 0,
        Maximum = size,
    });

var analyzerBuildArgs = HandAnalyzerBuildArguments.Create(analyzerName, handSize, cardList);
var handAnalyzer = HandAnalyzer.Create(analyzerBuildArgs);

var prob = handAnalyzer.CalculateProbability();
Console.WriteLine($"Analyzer Name: {analyzerName}.");
Console.WriteLine($"Deck Size: {deckSize:N0}.");
Console.WriteLine($"Hand Size: {handSize:N0}.");
Console.WriteLine($"Probability: {prob:P2}.");
Console.WriteLine();

foreach(var (key, cardGroup) in handAnalyzer.CardGroups)
{
    Console.WriteLine($"{cardGroup.Name}: {cardGroup.Size:N0}.");
    Console.WriteLine($"Minimum: {cardGroup.Minimum:N0}.");
    Console.WriteLine($"Maximum: {cardGroup.Maximum:N0}.");
    Console.WriteLine();
}
