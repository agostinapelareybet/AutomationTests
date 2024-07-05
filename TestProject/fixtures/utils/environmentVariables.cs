using System;

public static class EnvironmentVariables
{
    public static string BaseUrl
    {
        get
        {
            return Environment.GetEnvironmentVariable("BASE_URL");
        }
    }

    public static string UserName
    {
        get
        {
            return Environment.GetEnvironmentVariable("USER_NAME");
        }
    }

    public static string Password
    {
        get
        {
            return Environment.GetEnvironmentVariable("PASSWORD");
        }
    }
}
