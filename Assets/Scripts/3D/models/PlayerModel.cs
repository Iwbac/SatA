public static class PlayerModel
{
    public static float MoveSpeed { get; set; }
    public static int AttackPower { get; set; }
    public static int Health { get { return health; } }
    private static int health = 100;

    public static int TakeDamage(int damage)
    {
        return health -= damage;
    }
}
