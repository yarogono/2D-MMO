using System.Text.Json;

namespace ChatServer.Configuration;

internal class ConfigurationLoader
{
    private const string ConfigurationFileFullPathName = "../../../Module/Configuration/configuration.json";

    public ChatServerConfiguration GetChatServerConfiguration()
    {
        var configuration = ReadConfigurationAsync();
        var chatServerConfiguration = JsonSerializer.Deserialize<ChatServerConfiguration>(configuration);
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
