using Godot;

public class IdleState : State
{
    public override void Update(Player player, float delta)
    {
        ChangeState(player);
        PerformGravity(player, delta);
    }

    public override void EnterState(Player player)
    {
        GD.Print("IDLE");
        player.Movement = new Vector3();
        player.Velocity = new Vector3();
    }

    public override void ExitState(Player player)
    {

    }

    private void ChangeState(Player player)
    {
        if (Input.IsActionPressed("move_fw") || Input.IsActionPressed("move_bw") ||
                Input.IsActionPressed("move_lf") || Input.IsActionPressed("move_rt"))
        {
            player.ChangeState(new MovementState());
            return;
        }
        if (Input.IsActionPressed("jump"))
        {
            player.ChangeState(new JumpState());
            return;
        }
    }
}