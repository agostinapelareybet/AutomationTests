public class EnvironmentVariables
{
    public static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL") ?? "Default";

    public static string ProductsUrl => Environment.GetEnvironmentVariable("PRODUCTS_URL") ?? "Default";

    public static string Password => Environment.GetEnvironmentVariable("PASSWORD") ?? "";

    public static string GetValidUserName()
    {
        string userNames = Environment.GetEnvironmentVariable("USER_NAMES") ?? "";

        var userNameList = userNames.Split(',').ToList();
        Random random = new Random();
        int index = random.Next(userNameList.Count);
        return userNameList[index].Trim();
    }
}

