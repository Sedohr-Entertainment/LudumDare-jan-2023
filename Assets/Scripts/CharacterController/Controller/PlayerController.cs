using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ru1t3rl.Events;
using Ru1t3rl.Events.Args;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterControlerBase controller;
    private Vector2 input = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterControlerBase>();
    }

    public void OnEnable()
    {
        EventManager.Instance.AddListener("move", OnMove);
        EventManager.Instance.AddListener("jump", OnJump);
    }

    public void OnMove(System.EventArgs args)
    {
        input = (Vector2)(args as Vector2InputArgs);
        controller.ApplyMovement(input);
    }

    public void OnJump()
    {
        controller.Jump();
    }
}
