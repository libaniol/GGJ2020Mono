using Godot;

public interface IState
{
    void Update(Player player, float delta);
    void EnterState(Player player);
    void ExitState(Player player);
}

public class State : IState
{
    public virtual void Update(Player player, float delta)
    {
        GD.Print("Update");
    }
    public virtual void EnterState(Player player)
    {
        GD.Print("EnterState");
    }
    public virtual void ExitState(Player player)
    {
        GD.Print("ExitState");
    }

    protected void PerformGravity(Player player, float delta)
    {
        Vector3 movement = player.Velocity;
        float y = movement.y;
        y += player.Gravity * delta;
        movement.y = y;
        player.Velocity = movement;
    }
}