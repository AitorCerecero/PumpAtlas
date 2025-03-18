Ruhrpumpen's Fire Systems Hydraulic Mapping Application (AKA Pump Atlas)

Remaining Tasks to Make Pump Atlas fully functional

Dear Developer

Reading this text means that due to lack of time and the fact I was the only one developing the app I ran out of time and im heading out of the company per personal circumstances, however ill let you know what is missing to make the app fully functional

The Pump Atlas Application current stage is on mid to final stage, there are some features of excel that due to lack of time and complexity of them were not completed, let me enlist what is missing and what I acomplished that may help to the final stage of the application

I want to make emphasis on a file, VP Jordi Bernal is the author of the file HSC-D-MX-Fire Pump Map, is the legacy file which the app is bases on, so all the future releases and methods created for the app should be based on the file and should be spoken with Jordi to either ask for clarification or authorization to make the changes

1. The code is hosted on GitHub in a Public repository, Ill leave the final commit in the following days with the final change of the application, cloning the repository will get you such version
2. There is a hardcoded connection string to the FireSystemsDB which is the dedicated Database on SQL Server for all Fire Systems app that rely on Databases
3. The version of SQL is lower than 2016, meaning that some of the new syntax for procedures higher than 2016 version will not work on the current one, mostly because is the version that RP's IT services provides for working
4. I coded some Stores Procedures that emulate the formulas that the Data-All Pumps worksheet of the workbook perform with the data so the only missing thing is to execute them once new data is stored with the Elevator data engine I built within the application
5. The following list is what is missing
	- Table to obtain prices based on the rated Head (the table should iterate over the whole table of pumps, considering as filter the Head and a Price percentage that is on the excel)
	- The table should contain a function that reads the current records for an specific head and retrieve the best price based on the Flow
	- compare the price returned from that table with the ones of the pump (pump prices are already showing on table but are hidden with a property of DevExpress but can still perfom some calculus)
	- use the color properties that DevExpress offers to color red when price is higher and green when price is either the same or lower
6. I already created the derrated function on the table, there is a table where all the process takes place and another one that serves as reference and the GUI of the app also contains a text box to introduce the derrated value

Overall, that is everything to consider the application done, remember to run the dotnet publish comand and set the state of the app from debug to release so the IDE returns a single EXE file to run in any Windows system 

The dotnet command that works is the following dotnet publish -r win-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true /p:PublishTrimmed=true --output "La carpeta de destino donde se guardara el exe"

