using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using Ru1t3rl.Utilities;

namespace Ru1t3rl.DevMenu.Commands
{
    public class CommandsLibrary : UnitySingleton<CommandsLibrary>
    {
        public List<Command<string[]>> commands = new List<Command<string[]>>();

        Command<string[]> MOVE = new Command<string[]>(
            "move",
            "Move object to position",
            "move <name> <x> <y> <z>",
            new Regex(@"^(move .*)( -?[0-9]+(\.[0-9]+)?){3}"), args =>
        {
            GameObject obj = GameObject.Find(args[1]);

            if (obj == null)
            {
                Debug.LogError($"Object {args[1]} not found");
                return;
            }

            Vector3 pos = new Vector3(float.Parse(args[2]), float.Parse(args[3]), float.Parse(args[4]));
            obj.transform.position = pos;
        });

        protected override void Awake()
        {
            base.Awake();

            commands.Add(MOVE);
        }
    }
}