using SimpleAnalyzerWSourceGen.Internal;
using YGOHandAnalysisFramework;
using YGOHandAnalysisFramework.Data;
using YGOHandAnalysisFramework.Features.Analysis;
using CardSourceGenerator;
using YGOHandAnalysisFramework.Features.Combinations;
using YGOHandAnalysisFramework.Data.Operations;

string analyzerName = "Simple Analyzer With Source Generation";
int deckSize = 40;
int handSize = 5;

// Step 1. Create a List<> of cards that will be in the deck. A name and the quantity need to be specified.
// Step 2. Create a CardList.
// Step 3. Create a HandAnalyzer<>. This has all possible hands that the deck can produce.
// Step 4. Create filters that determine which hands we want to see.
// Step 5. Calculate probability using the HandAnalyzer<> and each filter.
// Step 6. Output to console.

// Step 1. Create a List<> of cards that will be in the deck. A name and the quantity need to be specified.
// You will have to add card data to the ../CardData/ folder (the content of that folder are not shown in the editor).
// You can read the readme.md provided in the CardSourceGenerator package.
// Or visit: https://github.com/mlivernoche/CardSourceGenerator
// A generic one is provided (genericdata.json), and it can be freely deleted.

var cardBuildArgs = new List<InternalCardGroup>()
{
    // Add your cards here.
    new()
    {
        Name = YGOCards.C_GenericDarkDragonofDarkness,
        Size = 3,
    },
    new()
    {
        Name = YGOCards.C_AmazingBrickofBrickiness,
        Size = 1,
    }
};

// Step 2. Create a CardList.
// Create a CardList and fill any empty space with a generic card group.
var cardList = CardList
    .Create(new CardGroupCollection<InternalCardGroup, YGOCards.YGOCardName>(cardBuildArgs))
    .Fill(deckSize, static size => new InternalCardGroup()
    {
        Name = new("Miscellaneous"),
        Size = size,
    });

// Step 3. Create a HandAnalyzer<>. This has all possible hands that the deck can produce.
var handAnalyzer = cardList
    .CreateHandAnalyzerBuildArgs(analyzerName, handSize)
    .CreateHandAnalyzer();

// Step 4. Create filters that determine which hands we want to see.
// You can use these lambdas to filter cards.

// The probability with this filter should be 33.76%.
var filterHandWithStarter = static (HandCombination<YGOCards.YGOCardName> hand) =>
{
    // We want hands with the good card.
    return hand.HasThisCard(YGOCards.C_GenericDarkDragonofDarkness);
};

// The probability with this filter should be 30.21%.
var filterHandWithStarterButNoBricks = static (HandCombination<YGOCards.YGOCardName> hand) =>
{
    // Skip hands with the brick.
    if (hand.HasThisCard(YGOCards.C_AmazingBrickofBrickiness))
    {
        return false;
    }

    // We want hands with the good card.
    return hand.HasThisCard(YGOCards.C_GenericDarkDragonofDarkness);
};

// Step 5. Calculate probability using the HandAnalyzer<> and each filter.
// Calculate the probability of drawing hands which match the requirements of the filter.
var probOfStarter = handAnalyzer.CalculateProbability(filterHandWithStarter);
var probOfStarterWithNoBrick = handAnalyzer.CalculateProbability(filterHandWithStarterButNoBricks);

// Step 6. Output to console.
Console.WriteLine($"Analyzer Name: {analyzerName}.");
Console.WriteLine($"Deck Size: {deckSize:N0}.");
Console.WriteLine($"Hand Size: {handSize:N0}.");
Console.WriteLine($"Probability Of Drawing Starter: {probOfStarter:P2}.");
Console.WriteLine($"Probability Of Drawing Starter WITHOUT Brick: {probOfStarterWithNoBrick:P2}.");
Console.WriteLine();

// This loop is freely removable.
foreach (var (key, cardGroup) in handAnalyzer.CardGroups)
{
    Console.WriteLine($"{cardGroup.Name.Name}: {cardGroup.Size:N0}.");
    Console.WriteLine($"Minimum: {cardGroup.Minimum:N0}.");
    Console.WriteLine($"Maximum: {cardGroup.Maximum:N0}.");
    Console.WriteLine();
}

// The output should be:
/*
 * Analyzer Name: Simple Analyzer With Source Generation.
 * Deck Size: 40.
 * Hand Size: 5.
 * Probability Of Drawing Starter: 33.76%.
 * Probability Of Drawing Starter WITHOUT Brick: 30.21%.
 * 
 * Generic Dark Dragon of Darkness: 3.
 * Minimum: 0.
 * Maximum: 3.
 * 
 * Amazing Brick of Brickiness: 1.
 * Minimum: 0.
 * Maximum: 1.
 * 
 * Miscellaneous: 36.
 * Minimum: 0.
 * Maximum: 36.
 */
