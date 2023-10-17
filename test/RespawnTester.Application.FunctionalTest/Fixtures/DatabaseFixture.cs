using Microsoft.EntityFrameworkCore;
using Respawn;
using Respawn.Graph;
using RespawnTestes.Infrastructure.Data;
using System.Data.Common;

namespace RespawnTester.Application.FunctionalTests.Fixtures;

public class DatabaseFixture
    : IAsyncLifetime
{
    private Respawner? respawner;
    private DbConnection? connection;

    public DataContext DataContext { get; private set; } = new DataContext();

    public async Task InitializeAsync()
    {
        connection = DataContext.Database.GetDbConnection();

        await connection.OpenAsync();

        respawner = await Respawner.CreateAsync(connection, new RespawnerOptions
        {
            TablesToIgnore = new Table[]
            {
                "sysdiagrams",
                "tblUser",
                "tblObjectType",
                new Table("dbo", "__EFMigrationsHistory")
            },
            SchemasToExclude = new[]
            {
                "cfg"
            },
            DbAdapter = DbAdapter.SqlServer
        });
    }

    public async Task ResetDatabase()
    {
        await respawner!.ResetAsync(connection!);
    }

    public async Task DisposeAsync()
    {
        await ResetDatabase();
        await connection!.CloseAsync();
    }


}
