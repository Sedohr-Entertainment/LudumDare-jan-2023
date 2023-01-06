using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ru1t3rl.Extensions
{
    public static class KeyCodeExtensions
    {
        /// <summary> Is the key held down? </summary>
        /// <param name="key"> The key to check </param>
        public static bool IsPressed(this KeyCode key) => Input.GetKey(key);

        /// <summary> Is the key released this frame? Only true for the first frame </summary>
        /// <param name="key"> The key to check </param>
        public static bool IsReleased(this KeyCode key) => Input.GetKeyUp(key);

        /// <summary> Is the key down this frame? Only true for the first frame </summary>
        /// <param name="key"> The key to check </param>
        public static bool IsDown(this KeyCode key) => Input.GetKeyDown(key);
    }
}
