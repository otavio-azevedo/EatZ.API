# Add new migration
dotnet ef migrations add AddIdentityTables --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\

# Update database
dotnet ef database update --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\