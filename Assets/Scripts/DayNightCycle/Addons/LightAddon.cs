using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.DayNightCycle.Addons
{
    public class LightAddon : BaseAddon
    {
        [SerializeField] private new Light light;
        [SerializeField] private Gradient color;
        [SerializeField] private AnimationCurve intensity;

        public override void UpdateAddon(float time)
        {
            light.enabled = true;

            light.color = color.Evaluate(time);
            light.intensity = intensity.Evaluate(time);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            light.enabled = false;
        }
    }
}