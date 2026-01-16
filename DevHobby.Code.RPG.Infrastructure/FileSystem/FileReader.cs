using DevHobby.Code.RPG.Infrastructure.Interfaces;

namespace DevHobby.Code.RPG.Infrastructure.FileSystem;

public class FileReader : IFileReader
{
    public string ReadAllText(string path) => File.ReadAllText(path);
}
