using System;

public class EnvironmentVariables
{
    public static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL") ?? "Default";

    public static string? UserName => Environment.GetEnvironmentVariable("USER_NAME");

    public static string? Password => Environment.GetEnvironmentVariable("PASSWORD");
}
    