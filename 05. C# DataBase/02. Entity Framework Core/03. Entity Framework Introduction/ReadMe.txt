1. Create .Net Core Console app
2. Manage NuGet packages:
	2.1  ->    Microsoft.EntityFrameworkCore.SqlServer
	2.2  ->    Microsoft.EntityFrameworkCore.Design
			(Judge works with version 3.1.3)
3. Build (F5) the project in Visual Studio (to save the changes)
    //DB First:
4. In csprojfile directory enter in command prompt and enter: 
	4.1  ->    dotnet tool install --global dotnet-ef
	4.2  ->    dotnet ef dbcontext scaffold "Server=.;Integrated Security=true;Database=SoftUni" Microsoft.EntityFrameworkCore.SqlServer -o Models -f -d
			(-f oznachava da prezapishe daden klas ako veche e suzdaden
			 -d oznachava koqto informaciq e vyzmojno dai mi ia s atributi, koiato ne- s fluent API)

       dotnet ef migrations add InitialCreate
       dotnet ef database update


	// dotnet ef migrations remove 
	   dotnet build//