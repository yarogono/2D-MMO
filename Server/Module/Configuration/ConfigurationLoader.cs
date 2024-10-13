using System.Text.Json;

namespace Server.Configuration;

public class ConfigurationLoader
{
    private const string ConfigurationFileFullPathName = "../../../../Module/Configuration/configuration.json";

    public ServerConfiguration GetServerConfiguration()
    {
        var configuration = ReadConfigurationAsync();
        var chatServerConfiguration = JsonSerializer.Deserialize<ServerConfiguration>(configuration);
        if (chatServerConfiguration == null)
        {
            throw new Exception($"Unable to deserialzie {ConfigurationFileFullPathName}");
        }
        return chatServerConfiguration;
    }

    private string ReadConfigurationAsync()
    {
        if (!File.Exists(ConfigurationFileFullPathName))
        {
            throw new Exception($"Unable to locate {ConfigurationFileFullPathName}");
        }
        return File.ReadAllText(ConfigurationFileFullPathName);
    }
}
