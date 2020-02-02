using Godot;

public class JumpState : State
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
        float y = player.Velocity.y;
        Vector3 velocity = movement * player.MoveSpeed;
        velocity.y = y;
        player.Velocity = velocity;
        PerformGravity(player, delta);
    }

    public override void EnterState(Player player)
    {
        GD.Print("JUMP");
        Vector3 movement = player.Velocity;
        float y = player.JumpStrength;
        movement.y = y;
        player.Velocity = movement;
    }

    public override void ExitState(Player player)
    {

    }

    private void ChangeState(Player player)
    {
        if (player.Velocity.y < 0.0f)
        {
            player.ChangeState(new FallState());
            return;
        }
    }
}