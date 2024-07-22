namespace TestProject.support
{
    public class EnvironmentVariables
    {
        public static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL") ?? "Default";

        public static string ProductsUrl => Environment.GetEnvironmentVariable("PRODUCTS_URL") ?? "Default";

        public static string Password => Environment.GetEnvironmentVariable("PASSWORD") ?? "";

        public static string GetValidUserName()
        {
            var userNames = Environment.GetEnvironmentVariable("USER_NAMES") ?? "";

            var userNameList = userNames.Split(',').ToList();
            var random = new Random();
            var index = random.Next(userNameList.Count);
            return userNameList[index].Trim();
        }
    }

}