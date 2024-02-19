# Soccer Simulator

Built for the Miniclip code assignment.  

To run the application, clone the repository on the `main` branch and run `build_and_run.sh` to build a **Docker** image and run a container. The application will be available on `localhost:8080`.  

Alternatively, build the solution in **Visual Studio(2022)** and run it from there.  

Team data can be retrieved from either a JSON file or an in memory SQL database, this is determined in `Startup.cs:13`. 

Packages used:
* AutoMapper
* Dapper
* Microsoft.Data.Sqlite
* Newtonsoft.Json
