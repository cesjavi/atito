using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float danceStepSpeed = 6f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private int comboBufferSize = 6;

    public event Action<string> ComboPerformed;

    private CharacterController _controller;
    private Vector3 _velocity;
    private readonly List<char> _inputBuffer = new();

    private readonly Dictionary<string, string> _comboMap = new()
    {
        { "UDLR", "Windmill" },
        { "LLRR", "Toprock" },
        { "DULR", "Headspin" }
    };

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        ApplyGravity();
        ReadDanceInput();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        float speed = _inputBuffer.Count > 0 ? danceStepSpeed : walkSpeed;
        _controller.Move(move * speed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_controller.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void ReadDanceInput()
    {
        RegisterKey(KeyCode.UpArrow, 'U');
        RegisterKey(KeyCode.DownArrow, 'D');
        RegisterKey(KeyCode.LeftArrow, 'L');
        RegisterKey(KeyCode.RightArrow, 'R');
    }

    private void RegisterKey(KeyCode key, char token)
    {
        if (!Input.GetKeyDown(key))
        {
            return;
        }

        _inputBuffer.Add(token);
        if (_inputBuffer.Count > comboBufferSize)
        {
            _inputBuffer.RemoveAt(0);
        }

        string currentSequence = new string(_inputBuffer.ToArray());
        foreach (var combo in _comboMap)
        {
            if (!currentSequence.EndsWith(combo.Key, StringComparison.Ordinal))
            {
                continue;
            }

            ComboPerformed?.Invoke(combo.Value);
            _inputBuffer.Clear();
            return;
        }
    }
}
