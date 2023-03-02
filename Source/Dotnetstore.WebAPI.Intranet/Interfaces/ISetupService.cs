namespace Dotnetstore.WebAPI.Intranet.Interfaces;

public interface ISetupService
{
    void AddFolders();

    Task RunSetupAsync();
}