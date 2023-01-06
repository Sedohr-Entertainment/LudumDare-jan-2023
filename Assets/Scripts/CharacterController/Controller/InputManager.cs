using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Ru1t3rl.Events;
using Ru1t3rl.Events.Args;
using Ru1t3rl.Extensions;
using EventArgs = System.EventArgs;

public class InputManager : MonoBehaviour
{
    public Keymap keymap;

    public UnityEvent<EventArgs> horizontal, vertical;
    public UnityEvent<EventArgs> move;
    public UnityEvent jump;

    private float horizontalValue = 0, verticalValue = 0;
    private Vector2 moveValue = Vector2.zero;

    private bool inDevMenu = false;

    private void Awake()
    {
        EventManager.Instance.AddEvent("horizontal", horizontal);
        EventManager.Instance.AddEvent("vertical", vertical);
        EventManager.Instance.AddEvent("move", move);
        EventManager.Instance.AddEvent("jump", jump);
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveEvent("horizontal");
        EventManager.Instance.RemoveEvent("vertical");
        EventManager.Instance.RemoveEvent("move");
        EventManager.Instance.RemoveEvent("jump");
    }

    public void Update()
    {
        if (keymap.devMenu.IsDown())
        {
            EventManager.Instance.Invoke("devMenu");
            inDevMenu = !inDevMenu;
        }

        if (inDevMenu)
            return;

        if (keymap.backward.IsPressed())
            verticalValue -= 1;
        if (keymap.forward.IsPressed())
            verticalValue += 1;

        if (keymap.left.IsPressed())
            horizontalValue -= 1;
        if (keymap.right.IsPressed())
            horizontalValue += 1;

        moveValue.x = horizontalValue;
        moveValue.y = verticalValue;
        moveValue.Normalize();

        #region Events
        if (keymap.jump.IsDown())
            EventManager.Instance.Invoke("jump");

        if (horizontalValue != 0)
        {
            EventManager.Instance.Invoke("horizontal", new FloatInputArgs(horizontalValue));
        }

        if (verticalValue != 0)
        {
            EventManager.Instance.Invoke("vertical", new FloatInputArgs(verticalValue));
        }

        if (horizontalValue != 0 || verticalValue != 0)
        {
            EventManager.Instance.Invoke("move", new Vector2InputArgs(moveValue));
        }
        #endregion
    }
}
