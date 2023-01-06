using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Ru1t3rl.Events;
using Ru1t3rl.DevMenu.Commands;
using DeveloperMenu = Ru1t3rl.DevMenu.Behaviours.DevMenu;

namespace Ru1t3rl.DevMenu.UI
{
    [RequireComponent(typeof(DeveloperMenu))]
    public class DevMenuUI : MonoBehaviour
    {
        private List<BaseActionUI> actions = new List<BaseActionUI>();
        [SerializeField] private GameObject actionUIPrefab;
        [SerializeField] private Transform actionUIParent;
        [SerializeField] private GameObject hintUI;

        private void Awake()
        {
            DeveloperMenu devMenu = GetComponent<DeveloperMenu>();
            for (int iAction = 0; iAction < devMenu.Actions.Count; iAction++)
            {
                GameObject actionUI = Instantiate(actionUIPrefab, actionUIParent);
                BaseActionUI actionUIComponent = actionUI.GetComponent<BaseActionUI>();
                actionUIComponent.SetAction(devMenu.Actions[iAction]);
                actions.Add(actionUIComponent);
            }

            devMenu.onFilteredChanged.AddListener(OnFilteredChanged);
            EventManager.Instance.AddListener("devMenu", Toggle);

            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            EventManager.Instance.RemoveListener("devMenu", Toggle);
        }

        private void OnFilteredChanged(List<Command<string[]>> filteredActions)
        {
            #region Disable all
            for (int i = 0; i < actions.Count; i++)
            {
                if (filteredActions.Contains(actions[i].Command))
                {
                    actions[i].Show();
                }
                else
                {
                    actions[i].Hide();
                }
            }
            #endregion

            #region Check if more are needed
            for (int i = actions.Count; i < filteredActions.Count; i++)
            {
                GameObject actionUI = Instantiate(actionUIPrefab, actionUIParent);
                BaseActionUI actionUIComponent = actionUI.GetComponent<BaseActionUI>();
                actions.Add(actionUIComponent);
            }
            #endregion

            #region Link to filtered actions
            for (int i = 0; i < filteredActions.Count; i++)
            {
                actions[i].SetAction(filteredActions[i]);
                actions[i].Show();
            }
            #endregion
        }

        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ShowHint()
        {

        }
    }
}