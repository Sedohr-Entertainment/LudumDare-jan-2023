using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs = System.EventArgs;

namespace Ru1t3rl.Events.Args
{
    public class MovementArgs : EventArgs
    {
        public readonly Vector3 movement;

        public MovementArgs(Vector3 movement)
        {
            this.movement = movement;
        }

        public static implicit operator Vector3(MovementArgs e) => e.movement;
        public static implicit operator MovementArgs(Vector3 v) => new MovementArgs(v);
    }
}
