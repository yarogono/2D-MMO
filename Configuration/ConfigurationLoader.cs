using System.Text.Json;

namespace ChatServer.Configuration;

internal class ConfigurationLoader
{
    private const string ConfigurationFileName = "configuration.json";

    public ChatServerConfiguration GetMangosConfiguration()
    {
        var configuration = ReadConfigurationAsync();
        var chatServerConfiguration = JsonSerializer.Deserialize<ChatServerConfiguration>(configuration);
        if (chatServerConfiguration == null)
        {
            throw new Exception($"Unable to deserialzie {ConfigurationFileName}");
        }
        return chatServerConfiguration;
    }

    private string ReadConfigurationAsync()
    {
        if (!File.Exists(ConfigurationFileName))
        {
            throw new Exception($"Unable to locate {ConfigurationFileName}");
        }
        return File.ReadAllText(ConfigurationFileName);
    }
}
