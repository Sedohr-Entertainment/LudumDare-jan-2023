using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.DayNightCycle.Addons
{
    public class SkyAddon : BaseAddon
    {
        [SerializeField] private Material skybox;
        [SerializeField] private Gradient skyTint;
        [SerializeField] private Gradient groundTint;

        [SerializeField] private AnimationCurve atmosphereThickness;
        [SerializeField] private AnimationCurve sunSize;
        [SerializeField] private AnimationCurve sunConvergence;
        [SerializeField] private AnimationCurve exposure;

        public override void UpdateAddon(float time)
        {
            skybox.SetColor("_SkyTint", skyTint.Evaluate(time));
            skybox.SetColor("_GroundColor", groundTint.Evaluate(time));

            skybox.SetFloat("_AtmosphereThickness", atmosphereThickness.Evaluate(time));
            skybox.SetFloat("_SunSize", sunSize.Evaluate(time));
            skybox.SetFloat("_SunSizeConvergence", sunConvergence.Evaluate(time));
            skybox.SetFloat("_Exposure", exposure.Evaluate(time));
        }
    }
}