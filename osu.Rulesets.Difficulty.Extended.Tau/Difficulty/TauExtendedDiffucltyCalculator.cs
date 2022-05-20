using osu.Game.Beatmaps;
using osu.Game.Rulesets;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Difficulty.Skills;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Tau.Difficulty;
using osu.Rulesets.Difficulty.Statistics.Rulesets.Difficulty;

namespace osu.Rulesets.Difficulty.Extended.Tau.Difficulty;

public class ExtendedTauDifficultyCalculator : TauDifficultyCalculator, IExtendedDifficultyCalculator
{
    public ExtendedTauDifficultyCalculator(IRulesetInfo ruleset, WorkingBeatmap beatmap) 
        : base(ruleset, beatmap)
    {
    }

    public Skill[] GetSkills(IBeatmap beatmap, Mod[] mods, double clockRate)
        => CreateSkills(beatmap, mods, clockRate);

    public DifficultyAttributes GetDifficultyAttributes(IBeatmap beatmap, Mod[] mods, Skill[] skills, double clockRate)
        => CreateDifficultyAttributes(beatmap, mods, skills, clockRate);
}