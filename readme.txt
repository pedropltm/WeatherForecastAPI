Recomended configuration:

  * Git Extensions or Source Tree (for a easy git administration);
  * Visual Studio Code (for build and execute the application);
  * Insomnia (for testing);

Getting Started:

  1. Clone the repository;
  2. Using VS Code, open the project folder;
  3. Press CTRL+F5 to execute;
  4. Open Insomnia;
    4.1 Create a new folder ".Net Core API"
    4.2 Create a new request, inside this new folder:
      4.2.1 Name: WeatherForecast
      4.2.2 URL: Get https://localhost:7203/api/weatherforecast
      4.2.3 Body: No body
      4.2.4 Auth: No Authentication
      4.2.5 Query: https://localhost:7203/api/weatherforecast
      4.2.6 Header: Content-Type, Value: application/json
      4.2.7 Docs: empty
    4.3 Create another new request, inside the ".Net Core API" folder:
      4.3.1 Name: WeatherForecastItems
      4.3.2 URL: Post https://localhost:7203/api/weatherforecastitems
      4.3.3 Body: { "name":"walk dog", "isComplete":true }
      4.3.4 Auth: No Authentication
      4.3.5 Query: https://localhost:7203/api/weatherforecastitems
      4.3.6 Header: Content-Type, Value: application/json
      4.3.7 Docs: empty
    4.4 Create another new request, inside the ".Net Core API" folder:
      4.4.1 Name: WeatherForecastItems
      4.4.2 URL: Get https://localhost:7203/api/weatherforecastitems
      4.4.3 Body: No body
      4.4.4 Auth: No Authentication
      4.4.5 Query: https://localhost:7203/api/weatherforecastitems
      4.4.6 Header: Content-Type, Value: application/json
      4.4.7 Docs: empty
            
Project References:

  Microsoft
  Tutorial: Create a web API with ASP.NET CoreMicrosoft
  https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio-code
  Tip: Do not read this article in pt_br language. It will cause a lot of undestanding dificulties.
  
  StackOverFlow
  Issue: Why can't I call the UseInMemoryDatabase method on DbContextOptionsBuilder?
  https://stackoverflow.com/questions/48061096/why-cant-i-call-the-useinmemorydatabase-method-on-dbcontextoptionsbuilder/48062124
  Tip: I found this article that helped me to fix this problem. But, if you are with this problem and you are using VS Code without Nuget, use this command instead:
  dotnet add package Microsoft.EntityFrameworkCore.InMemory
  
  StackOverFlow
  Issue: SSL peer certificate or SSH remote key was not OK
  https://stackoverflow.com/questions/14192837/ssl-peer-certificate-or-ssh-remote-key-was-not-ok
  Tip: Disable SSL verification.