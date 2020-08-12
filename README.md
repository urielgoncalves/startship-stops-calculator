# Star Wars Starship Stops Calculator

This is a .NET Core console application which consumes the Start Wars API (https://swapi.dev) to calculate how many stops for resupply are required in a given distance.

### Features
- Show starships and how many stops for resupply are required until the end of the travel.
- If any starship doesn't have required information for calculation, the result will be -1.

### Output
Ship Name: Y-wing | Stops for resupply: 74

### Usage
- Download or clone the repository;
- Open the solution using Visual Studio IDE's and run the console application;
- Or access the source code directory via terminal and run **dotnet run** command. The output is placed in bin/Debug/netcoreapp3.1;
- When the application starts, input the travel distance in MGLT(Megalithts);
- The results are paginated. In the botton of the list is shown the navigation options. Press 1 to go to the previous page, 2 to go to the next page and 0 to quit the application.


### Technologies
- .NET Core 3.1
- xUnit 2.4

<iframe src="https://drive.google.com/file/d/1Ebf0bl1k_Th1Tj2xzW8-2olnmlbHOaDZ/preview" width="640" height="480"></iframe>
