using CardSourceGenerator;
using YGOHandAnalysisFramework.Features.Analysis;
using YGOHandAnalysisFramework.Features.Comparison.Calculator;
using YGOHandAnalysisFramework.Features.Configuration;
using YGOHandAnalysisFramework.Projects;
using YGOHandAnalysisTemplate.Internal;

namespace YGOHandAnalysisTemplate.Projects;

internal abstract class InternalProject : IProject<InternalCardGroup, YGOCards.YGOCardName>
{
    public string ProjectName { get; }

    protected InternalProject(string projectName)
    {
        ProjectName = projectName ?? throw new ArgumentNullException(nameof(projectName));
    }

    public abstract void Run(ICalculatorWrapperCollection<HandAnalyzer<InternalCardGroup, YGOCards.YGOCardName>> calculators, IConfiguration<YGOCards.YGOCardName> configuration);
}
