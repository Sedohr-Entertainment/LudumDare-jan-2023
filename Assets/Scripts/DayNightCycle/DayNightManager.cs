using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.DayNightCycle
{
    public class DayNightManager : MonoBehaviour
    {
        [SerializeField] private Transform seasonalRotation;
        [SerializeField] private Transform dailyRotation;

        [Range(0f, 1f)]
        [SerializeField] private float timePercentage = 0f;
        [SerializeField] private bool pause = false;

        [Range(0f, 2f)]
        [SerializeField] private float timeSpeed = 1;

        private List<DayPart> dayParts = new List<DayPart>();
        private float dayLength = 0;

        private float time = 0;

        int currentDayPart = 0;
        float partTime = 0f;
        int prevCurrentDayPart = 0;

        private void Update()
        {
            if (pause)
            {
                time = timePercentage * dayLength;
                UpdateDayParts(time);
                return;
            }

            if (time / dayLength != timePercentage)
            {
                time = timePercentage * dayLength;
            }

            time += (Time.deltaTime / 10f) * timeSpeed;

            if (time >= dayLength)
            {
                time = 0;
            }

            timePercentage = time / dayLength;

            UpdateDayParts(time);
        }

        public void AddDayPart(DayPart dayPart)
        {
            dayParts.Add(dayPart);

            dayLength += dayPart.Duration;
        }

        public void RemoveDayPart(DayPart dayPart)
        {
            dayParts.Remove(dayPart);

            dayLength -= dayPart.Duration;
        }

        private void UpdateDayParts(float time)
        {
            currentDayPart = Mathf.FloorToInt(time / dayLength * dayParts.Count);
            partTime = time;

            for (int i = 0; i < currentDayPart; i++)
            {
                partTime -= dayParts[i].Duration;
            }

            if (prevCurrentDayPart != currentDayPart)
            {
                dayParts[prevCurrentDayPart].Deactivate();
            }

            dayParts[currentDayPart].UpdateDayPart(partTime);

            dailyRotation.localRotation = Quaternion.Lerp(
                dailyRotation.transform.localRotation,
                Quaternion.Euler(
                    (dayParts[currentDayPart].DailyRotationFrom + ((dayParts[currentDayPart].DailyRotationTo - dayParts[currentDayPart].DailyRotationFrom) * (partTime / dayParts[currentDayPart].Duration))) * 360,
                    0,
                    0),
                Time.deltaTime
            );

            prevCurrentDayPart = currentDayPart;
        }
    }
}