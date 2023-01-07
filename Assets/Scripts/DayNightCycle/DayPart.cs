using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.DayNightCycle.Addons;

namespace Ru1t3rl.DayNightCycle
{
    public class DayPart : MonoBehaviour
    {
        [SerializeField] private new string name;
        [SerializeField] private float duration;
        [SerializeField] private float dailyRotationFrom = 0;
        [SerializeField] private float dailyRotationTo = 0;
        private List<BaseAddon> addons = new List<BaseAddon>();

        protected DayNightManager manager;
        public DayNightManager Manager => manager ??= GetComponent<DayNightManager>() ?? GetComponentInParent<DayNightManager>();

        public string Name => name;
        public float Duration => duration;
        public float DailyRotationFrom => dailyRotationFrom;
        public float DailyRotationTo => dailyRotationTo;

        private bool first = true;
        public UnityEvent OnDayPartStart = new UnityEvent();
        public UnityEvent OnDayPartEnd = new UnityEvent();


        private void OnEnable()
        {
            Manager?.AddDayPart(this);
        }

        private void OnDisable()
        {
            Manager?.RemoveDayPart(this);
        }

        public void UpdateDayPart(float time)
        {
            if (first)
            {
                OnDayPartStart?.Invoke();
                first = false;
            }

            UpdateAddons(time);
        }

        public void AddAddon(BaseAddon addon)
        {
            addons.Add(addon);
        }

        public void RemoveAddon(BaseAddon addon)
        {
            addons.Remove(addon);
        }

        public void UpdateAddons(float time)
        {
            for (int iAddon = 0; iAddon < addons.Count; iAddon++)
            {
                addons[iAddon].UpdateAddon(time / duration);
            }
        }

        public void Deactivate()
        {
            for (int iAddon = 0; iAddon < addons.Count; iAddon++)
            {
                addons[iAddon].Deactivate();
            }

            OnDayPartEnd?.Invoke();
            first = true;
        }
    }
}