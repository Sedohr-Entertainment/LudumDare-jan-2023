using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.DevMenu.Commands;
using TMPro;

namespace Ru1t3rl.DevMenu.Behaviours
{
    public class DevMenu : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

        private List<Command<string[]>> actions;
        public List<Command<string[]>> Actions => actions ??= CommandsLibrary.Instance.commands;

        private List<Command<string[]>> filteredActions = new List<Command<string[]>>();
        public List<Command<string[]>> FilteredActions => filteredActions;

        public UnityEvent<List<Command<string[]>>> onFilteredChanged = new UnityEvent<List<Command<string[]>>>();

        private void Awake()
        {
            inputField.onValueChanged.AddListener(Filter);
            inputField.onSubmit.AddListener(Perform);            
        }

        private void OnDestroy()
        {
            inputField.onValueChanged.RemoveListener(Filter);
            inputField.onSubmit.RemoveListener(Perform);
        }

        private void Perform(string value)
        {
            for (int i = filteredActions.Count; i-- > 0;)
            {
                if (filteredActions[i].IsMatch(value, true))
                {
                    filteredActions[i].Invoke(value.Split(' '));
                    inputField.text = "";
                    break;
                }
            }
        }

        public void Filter(string input)
        {
            filteredActions.Clear();
            for (int i = actions.Count; i-- > 0;)
            {
                if (actions[i].IsMatch(input))
                {
                    filteredActions.Add(actions[i]);
                }
            }

            OrderFiltered();

            onFilteredChanged?.Invoke(filteredActions);
        }

        private void OrderFiltered()
        {
            filteredActions = filteredActions.OrderBy(action => action.id).ToList();
        }
    }
}