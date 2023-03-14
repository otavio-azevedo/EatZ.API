# Add new migration
dotnet ef migrations add AddIdentityTables --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\

# Update database
dotnet ef database update --project .\src\EatZ.Infra.Data\ --startup-project .\src\EatZ.API\

// Seed roles
            migrationBuilder.Sql($"INSERT INTO \"AspNetRoles\" VALUES ('22154e1a-a87b-42af-abd2-7a50aafedad2','{Roles.Company}','{Roles.Company.ToUpper()}',NULL),('84479801-b4ca-4234-9f82-e932298af580','{Roles.Consumer}','{Roles.Consumer.ToUpper()}',NULL)");