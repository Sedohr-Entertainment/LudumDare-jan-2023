using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs = System.EventArgs;

namespace Ru1t3rl.Events.Args
{
    public class Vector2InputArgs : EventArgs
    {

        public readonly Vector2 input;

        public Vector2InputArgs(Vector2 input)
        {
            this.input = input;
        }

        public Vector2InputArgs(float x, float y)
        {
            this.input = new Vector2(x, y);
        }

        public static implicit operator Vector2(Vector2InputArgs e) => e.input;
        public static implicit operator Vector2InputArgs(Vector2 v) => new Vector2InputArgs(v);
        //public static implicit operator Vector2InputArgs(float x, float y) => new Vector2InputArgs(x, y);
    }
}
