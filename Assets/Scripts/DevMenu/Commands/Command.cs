using System;
using System.Text.RegularExpressions;

namespace Ru1t3rl.DevMenu.Commands
{
    public class Command : BaseCommand
    {
        private Action command;

        public Command(string id, string description, string syntax, Regex regex, Action command) : base(id, description, syntax, regex)
        {
            this.command = command;
        }

        public void Invoke()
        {
            command?.Invoke();
        }
    }

    public class Command<T1> : BaseCommand
    {
        private Action<T1> command;

        public Command(string id, string description, string syntax, Regex regex, Action<T1> command) : base(id, description, syntax, regex)
        {
            this.command = command;
        }

        public void Invoke(T1 arg1)
        {
            command?.Invoke(arg1);
        }
    }
}