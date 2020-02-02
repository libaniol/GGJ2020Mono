using Godot;

public class DuckState : State
{
    public override void Update(Player player, float delta)
    {

    }

    public override void EnterState(Player player)
    {
        GD.Print("DUCK");
    }

    public override void ExitState(Player player)
    {

    }
}