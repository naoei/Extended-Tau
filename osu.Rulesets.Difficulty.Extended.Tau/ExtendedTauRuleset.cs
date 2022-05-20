using osu.Framework.IO.Stores;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Tau;
using osu.Game.Rulesets.UI;
using osu.Rulesets.Difficulty.Extended.Tau.Difficulty;
using osu.Rulesets.Difficulty.Extended.Tau.Performance;
using osu.Rulesets.Difficulty.Statistics.Rulesets;
using osu.Rulesets.Difficulty.Statistics.Rulesets.Difficulty;
using osu.Rulesets.Difficulty.Statistics.Rulesets.Performance;

namespace osu.Rulesets.Difficulty.Extended.Tau;

public class ExtendedTauRuleset : TauRuleset, IExtendedRuleset
{
    public IExtendedDifficultyCalculator CreateExtendedDifficultyCalculator(WorkingBeatmap beatmap)
        => new ExtendedTauDifficultyCalculator(RulesetInfo, beatmap);

    public IExtendedPerformanceCalculator CreateExtendedPerformanceCalculator()
        => new ExtendedTauPerformanceCalculator();

    public DrawableRuleset CreateDebuggerRuleset(IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
        => new DebuggerDrawableTauRuleset(this, beatmap, mods);

    public override IResourceStore<byte[]> CreateResourceStore() => new NamespacedResourceStore<byte[]>(new DllResourceStore(typeof(TauRuleset).Assembly), @"Resources");
}