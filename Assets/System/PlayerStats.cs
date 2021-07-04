public static class PlayerStats
{

    public static int score { get; set; }
    public static int money { get; set; }
    public static Jobs.Career currentJob { get; set; }

    public static float fireRate { get; set; }
    public static float interviewChn { get; set; }
    public static int shotCount { get; set; }
    public static int maxHealth { get; set; }

    // Edits score by a set amount (positive or negative)
    public static void changeScore(int val)
    {
        score += val;
    }

    // Edits money by a set amount (positive or negative)
    public static void changeMoney(int val)
    {
        money += val;
    }

    // Increases money by a set amount depending on the input job
    public static void changeMoney(Jobs.Career job)
    {
        changeMoney(Jobs.getMoney(job));
    }

}