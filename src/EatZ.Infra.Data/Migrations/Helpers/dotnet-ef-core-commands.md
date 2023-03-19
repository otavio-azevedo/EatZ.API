# Add new migration
dotnet ef migrations add <<MIGRATION_NAME>> --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\

# Update database
dotnet ef database update --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\

# Generate script
dotnet ef migrations script <<MIGRATION_BEFORE_DESIRED_SCRIPT>> -o script.sql --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\