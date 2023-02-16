using Dotnetstore.Core.Interfaces;

namespace Dotnetstore.Core.Services;

public class PathService : IPathService
{
    string IPathService.ApplicationData => ApplicationData;
    string IPathService.ApplicationFolder => ApplicationFolder;
    string IPathService.DatabaseFileFolder => DatabaseFileFolder;
    string IPathService.LocalApplicationData => LocalApplicationData;

    private string ApplicationData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    private string ApplicationFolder => Path.Combine(ApplicationData, "DotnetstoreIntranet");
    private string DatabaseFileFolder => Path.Combine(ApplicationFolder, "Database");
    private string LocalApplicationData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
}