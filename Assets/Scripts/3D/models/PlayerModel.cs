public static class PlayerModel
{
    public static float MoveSpeed { get; set; }
    public static int AttackPower { get; set; }
    public static int Health { get; set; }

    public static int TakeDamage(int damage)
    {
        return Health -= damage;
    }
}
