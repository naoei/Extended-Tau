using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Tau;
using osu.Game.Rulesets.Tau.UI;
using osu.Game.Rulesets.UI;
using osuTK;

namespace osu.Rulesets.Difficulty.Extended.Tau;

public class DebuggerDrawableTauRuleset : TauDrawableRuleset
{
    public DebuggerDrawableTauRuleset(TauRuleset ruleset, IBeatmap beatmap, IReadOnlyList<Mod> mods = null)
        : base(ruleset, beatmap, mods)
    {
    }

    protected override Playfield CreatePlayfield() => new TauDebuggerPlayfield();

    public override PlayfieldAdjustmentContainer CreatePlayfieldAdjustmentContainer()
        => new TauDebuggerPlayfieldAdjustmentContainer(0.9f);

    private class TauDebuggerPlayfield : TauPlayfield
    {
        protected override GameplayCursorContainer CreateCursor() => new InvisibleTauCursor();

        private class InvisibleTauCursor : TauCursor
        {
            public InvisibleTauCursor()
            {
                Alpha = 0;
                AlwaysPresent = true;
            }
        }
    }
    
    private class TauDebuggerPlayfieldAdjustmentContainer : PlayfieldAdjustmentContainer
    {
        protected override Container<Drawable> Content => content;
        private readonly Container content;

        public TauDebuggerPlayfieldAdjustmentContainer(float scale = 0.6f)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = new Vector2(scale);
            FillMode = FillMode.Fit;
            FillAspectRatio = 1;

            InternalChild = content = new ScalingContainer { RelativeSizeAxes = Axes.Both };
        }

        /// <summary>
        /// A <see cref="Container"/> which scales its content relative to a target width.
        /// </summary>
        private class ScalingContainer : Container
        {
            protected override void Update()
            {
                base.Update();

                Scale = new Vector2(Parent.ChildSize.X / TauPlayfield.BaseSize.X);
                Size = Vector2.Divide(Vector2.One, Scale);
            }
        }
    }
}