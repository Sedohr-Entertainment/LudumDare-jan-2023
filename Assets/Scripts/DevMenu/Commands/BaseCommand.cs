using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Ru1t3rl.DevMenu.Commands
{
    public class BaseCommand
    {
        public readonly string id;
        public readonly string description;
        public readonly string syntax;
        public readonly Regex regex;

        public BaseCommand(string id, string description, string syntax, Regex regex)
        {
            this.id = id;
            this.description = description;
            this.syntax = syntax;
            this.regex = regex;
        }

        public bool IsMatch(string input, bool full = false)
        {
            if ((id.Contains(input) || description.Contains(input) || syntax.Contains(input)) || regex.IsPartialMatch(input) && !full)
            {
                return true;
            }

            if (regex.IsMatch(input))
            {
                return true;
            }

            return false;
        }
    }
}