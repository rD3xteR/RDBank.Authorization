### Add migration
```powershell
dotnet ef migrations add %MigrationName% --startup-project ./src/Api/Api.csproj --context AuthDbContext --output-dir Migrations --project ./src/Core/Core.csproj 
```

### Remove migration
```powershell
dotnet ef migrations remove --startup-project ./src/Api/Api.csproj --context AuthDbContext --project ./src/Core/Core.csproj
```
