using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArgs = System.EventArgs;

namespace Ru1t3rl.Events.Args
{
    public class FloatInputArgs : EventArgs
    {

        public readonly float input;

        public FloatInputArgs(float input)
        {
            this.input = input;
        }

        public static implicit operator float(FloatInputArgs e) => e.input;
        public static implicit operator FloatInputArgs(float f) => new FloatInputArgs(f);
    }
}
