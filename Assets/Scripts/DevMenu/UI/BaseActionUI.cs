using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ru1t3rl.DevMenu.Commands;

namespace Ru1t3rl.DevMenu.UI
{
    public class BaseActionUI : MonoBehaviour
    {
        private Command<string[]> command;
        public Command<string[]> Command => command;

        [SerializeField] private TextMeshProUGUI nameText;

        public void SetAction(Command<string[]> command)
        {
            this.command = command;
            nameText.text = command.syntax;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
