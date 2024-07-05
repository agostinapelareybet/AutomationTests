using System;

public static class EnvironmentVariables
{
    // M�todo est�tico para obtener la base URL
    public static string BaseUrl
    {
        get
        {
            // Aqu� obtienes la variable de entorno desde el sistema operativo o desde un archivo de configuraci�n
            return Environment.GetEnvironmentVariable("BASE_URL");
        }
    }

    public static string UserName
    {
        get
        {
            // Aqu� obtienes la variable de entorno desde el sistema operativo o desde un archivo de configuraci�n
            return Environment.GetEnvironmentVariable("USER_NAME");
        }
    }

    public static string Password
    {
        get
        {
            // Aqu� obtienes la variable de entorno desde el sistema operativo o desde un archivo de configuraci�n
            return Environment.GetEnvironmentVariable("PASSWORD");
        }
    }
}
