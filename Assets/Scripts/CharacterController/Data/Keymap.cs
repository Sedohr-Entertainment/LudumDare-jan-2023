using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Keymap", menuName = "CharacterController/Keymap", order = 0)]
public class Keymap : ScriptableObject
{
    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode crouch = KeyCode.LeftControl;
    public KeyCode sprint = KeyCode.LeftShift;
    public KeyCode interact = KeyCode.E;
    public KeyCode devMenu = KeyCode.Tab;
}
