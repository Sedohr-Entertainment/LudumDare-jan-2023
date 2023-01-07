using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.DayNightCycle.Addons
{
    public class FogAddon : BaseAddon
    {
        [SerializeField] private Gradient color;
        [SerializeField] private AnimationCurve density;

        public override void UpdateAddon(float time)
        {
            RenderSettings.fogColor = color.Evaluate(time);
            RenderSettings.fogDensity = density.Evaluate(time);
        }
    }
}