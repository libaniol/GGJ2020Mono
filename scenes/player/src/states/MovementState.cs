using Godot;

public class MovementState : State
{
    public override void Update(Player player, float delta)
    {
        ChangeState(player);
        Vector3 movement = new Vector3();
        if (Input.IsActionPressed("move_fw"))
        {
            movement.z -= 1.0f;
        }
        if (Input.IsActionPressed("move_bw"))
        {
            movement.z += 1.0f;
        }
        if (Input.IsActionPressed("move_lf"))
        {
            movement.x -= 1.0f;
        }
        if (Input.IsActionPressed("move_rt"))
        {
            movement.x += 1.0f;
        }

        player.Movement = movement.Normalized();
        float rot = Mathf.Atan2(-player.Movement.x, -player.Movement.z);
        Vector3 rotation = player.Rotation;
        rotation.y = rot;
        player.Rotation = rotation;

        player.Velocity = new Vector3(player.Movement.x * player.MoveSpeed,
                    player.Velocity.y,
                    player.Movement.z * player.MoveSpeed);

        PerformGravity(player, delta);
    }

    public override void EnterState(Player player)
    {

    }

    public override void ExitState(Player player)
    {

    }

    private void ChangeState(Player player)
    {
        if (!(Input.IsActionPressed("move_fw") || Input.IsActionPressed("move_bw") ||
                Input.IsActionPressed("move_lf") || Input.IsActionPressed("move_rt")))
        {
            player.ChangeState(new IdleState());
            return;
        }
        if (Input.IsActionJustPressed("jump"))
        {
            player.ChangeState(new JumpState());
            return;
        }
        if (player.Velocity.y < 0.0f && !player.IsOnFloor())
        {
            player.ChangeState(new FallState());
            return;
        }
    }
}