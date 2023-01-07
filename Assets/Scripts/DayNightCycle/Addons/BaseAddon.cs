using UnityEngine;

namespace Ru1t3rl.DayNightCycle.Addons
{
    public abstract class BaseAddon : MonoBehaviour
    {
        protected DayPart manager;
        public DayPart dayPart => manager ??= GetComponent<DayPart>();

        protected virtual void OnEnable()
        {
            dayPart?.AddAddon(this);
        }

        protected virtual void OnDisable()
        {
            dayPart?.RemoveAddon(this);
        }


        /// <summary>Update the addons</summary>
        /// <param name="time">The time of the day part on a scale from 0 to 1</param>
        public abstract void UpdateAddon(float time);

        public virtual void Deactivate()
        {
            
        }
    }
}