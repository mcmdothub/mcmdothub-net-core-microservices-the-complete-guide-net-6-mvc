# Deli.Services.ProductAPI

# Add NuGet Packages:
	- AutoMapper											(used to map DTO to entity)
	- AutoMapper.Extensions.Microsoft.DependencyInjection	(used to map DTO to entity)
	- Swashbuckle.AspNetCore.SwaggerUI						(used to display API documentation)
	- Swashbuckle.AspNetCore.Annotations					(used to display API documentation)
	- Microsoft.AspNetCore.Authentication.JwtBearer			( used for authentification)
	- Microsoft.EntityFrameworkCore.SqlServer				(used for database and migration's)
	- Microsoft.EntityFrameworkCore.Tools					(used for database and migration's)

# Configure DbContext for Product API

# Create tables for Product database
	- PackageManager console: 
		- Select Default project: "Services\Deli.Services.ProductAPI"
		- Check that in "Solution Explorer" startup project is: "Services\Deli.Services.ProductAPI"
		- Add-migration:
			PM> add-migration AddProductModelToDb

		- Push to database:
			PM> update-database

# Create DTO's inside Product API

# Product Repository Interface

# AutoMapper Configuration in Product API

# Product Repository implementation

# Product API controller HTTPGET