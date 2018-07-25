public static class PlayerStats
{
    private static int avatar;
    private static string username = "Anonymous";

    public static int Avatar
    {
        get
        {
            return avatar;
        }
        set
        {
            avatar = value;
        }
    }

    public static string Username
    {
        get
        {
            return username;
        }
        set
        {
            username = value;
        }
    }
}