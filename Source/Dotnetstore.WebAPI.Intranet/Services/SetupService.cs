using Dotnetstore.Core.Abstracts;
using Dotnetstore.Core.Interfaces;
using Dotnetstore.WebAPI.Intranet.Interfaces;
using Microsoft.Data.Sqlite;

namespace Dotnetstore.WebAPI.Intranet.Services;

public class SetupService : Disposable, ISetupService
{
    private IConfiguration? _configuration;
    private IPathService? _pathService;

    public SetupService(
        IConfiguration configuration,
        IPathService pathService)
    {
        _configuration = configuration;
        _pathService = pathService;
    }

    void ISetupService.AddFolders()
    {
        AddApplicationFolder();
        AddDatabaseFolder();
        AddSQLiteDatabaseFile();
    }

    private void AddApplicationFolder()
    {
        if (_pathService is null)
            return;

        if (!Directory.Exists(_pathService.ApplicationFolder))
            Directory.CreateDirectory(_pathService.ApplicationFolder);
    }

    private void AddDatabaseFolder()
    {
        if (_pathService is null)
            return;

        if (!Directory.Exists(_pathService.DatabaseFileFolder))
            Directory.CreateDirectory(_pathService.DatabaseFileFolder);
    }

    private void AddSQLiteDatabaseFile()
    {
        if (_pathService is null ||
            _configuration is null)
            return;

        if (!File.Exists(Path.Combine(_pathService.DatabaseFileFolder, "DotnetstoreIntranet.db")))
        {
            var connectionString = "Data Source=" +
                                   Path.Combine(_pathService.DatabaseFileFolder,
                                       _configuration.GetSection("Databases:SQLite:ConnectionString").Value);
            using var sqLiteConnection = new SqliteConnection(connectionString);
            sqLiteConnection.Open();
            sqLiteConnection.Close();
        }
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _configuration = null;
            _pathService = null;
        }

        base.DisposeManaged();
    }
}