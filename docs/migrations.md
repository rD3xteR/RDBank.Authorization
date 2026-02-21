### Add migration
```powershell
dotnet ef migrations add %MigrationName% --startup-project ./Api/Api.csproj --context AuthDbContext --output-dir Migrations --project ./Core/Core.csproj 
```

### Remove migration
```powershell
dotnet ef migrations remove --startup-project ./Api/Api.csproj --context AuthDbContext --project ./Core/Core.csproj
```
