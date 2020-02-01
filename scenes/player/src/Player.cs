using Godot;
using System;

public class Player : KinematicBody
{
    [Export]
    private float moveSpeed = 0.0f;
    [Export]
    private float gravity = 0.0f;
    [Export]
    private float jumpStrength = 0.0f;

    private Vector3 movement = new Vector3();
    private Vector3 velocity = new Vector3();

    private State currentState = new IdleState();

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float Gravity { get => gravity; set => gravity = value; }
    public float JumpStrength { get => jumpStrength; set => jumpStrength = value; }
    public Vector3 Movement { get => movement; set => movement = value; }
    public Vector3 Velocity { get => velocity; set => velocity = value; }

    //GODOT CALLBACKS
    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        currentState.Update(this, delta);
    }

    public override void _PhysicsProcess(float delta)
    {
        Velocity = MoveAndSlide(Velocity, Vector3.Up);
    }

    public void ChangeState(State state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }
}
