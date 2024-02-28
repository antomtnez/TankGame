public interface ITank 
{
    public int GetMaxHealth();
    public int GetHealth();
    public void InitializeTank(IMovable movable, IAttackable attackable);
    public void Move();
    public bool HasArrivedToDestination();
    public void Attack();
    public bool IsDead();
}
