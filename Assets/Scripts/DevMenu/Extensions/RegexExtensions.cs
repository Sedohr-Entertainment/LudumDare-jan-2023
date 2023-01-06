using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public static class RegexExtensions
{
    public static bool IsPartialMatch(this Regex regex, string input)
    {
        List<string> groups = new List<string>();
        Regex tempRegex;

        #region create groups
        string group = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (group != "" && input[i] == ' ')
            {
                groups.Add(group);
                group = "";
                continue;
            }

            if (group != "" && input[i] == '(')
            {
                groups.Add(group);
                group = "";
            }

            if (input[i] == '^' && input[i + 1] == '(')
            {
                groups.Add(group);
                group = "";
                group += input[i];
                i++;
            }

            group += input[i];

            if (input[i] == ')')
            {
                groups.Add(group);
                group = "";
            }
        }
        #endregion

        for (int i = 0; i < groups.Count; i++)
        {
            tempRegex = new Regex(groups[i]);
            if (tempRegex.IsMatch(input))
            {
                return true;
            }
        }

        return false;
    }
}
