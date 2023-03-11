// ef commands templates for the Rider's terminal

cd ZaylandShop.ProductCatalog.Storage
dotnet restore
dotnet ef -h
dotnet ef migrations add Initial --verbose --project ../ZaylandShop.ProductCatalog.Storage --startup-project ../ZaylandShop.ProductCatalog.Web
dotnet ef database update --verbose --project ../ZaylandShop.ProductCatalog.Storage --startup-project ../ZaylandShop.ProductCatalog.Web