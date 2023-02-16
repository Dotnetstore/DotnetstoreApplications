namespace Dotnetstore.Core.Interfaces;

public interface IPathService
{
    string LocalApplicationData { get; }

    string ApplicationData { get; }

    string DatabaseFileFolder { get; }

    string ApplicationFolder { get; }
}