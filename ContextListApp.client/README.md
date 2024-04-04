# ContacttListApp

### Applying Migrations
To apply the latest migration to your database, run the following command:
```bash

dotnet ef migrations add Init --project ContactListApp.DAL --startup-project ContactListApp.API

dotnet ef migrations     update --project ContactListApp.DAL --startup-project ContactListApp.API
