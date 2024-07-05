using System;

public static class EnvironmentVariables
{
    // Método estático para obtener la base URL
    public static string BaseUrl
    {
        get
        {
            // Aquí obtienes la variable de entorno desde el sistema operativo o desde un archivo de configuración
            return Environment.GetEnvironmentVariable("BASE_URL");
        }
    }

    public static string UserName
    {
        get
        {
            // Aquí obtienes la variable de entorno desde el sistema operativo o desde un archivo de configuración
            return Environment.GetEnvironmentVariable("USER_NAME");
        }
    }

    public static string Password
    {
        get
        {
            // Aquí obtienes la variable de entorno desde el sistema operativo o desde un archivo de configuración
            return Environment.GetEnvironmentVariable("PASSWORD");
        }
    }
}
