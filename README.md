# enable dotnet-ef cmd for using the below cmd

dotnet tool install --global dotnet-ef

# for cmd cli using these cmd one

# this cmd cli only work for current path stand at src folder

dotnet ef -s ./FutureComputer.API migrations add InitialCreate -p ./FutureComputer.Infrastructure -c FutureComputerDbContext -v

dotnet ef database update -s ./FutureComputer.API -p ./FutureComputer.Infrastructure -c FutureComputerDbContext -v

# for Pakage Manager Console, using this one when stand at API project

add-migration InitialCreate -p FutureComputer.Infrastructure -c FutureComputerDbContext -v

update-database -p FutureComputer.Infrastructure -c FutureComputerDbContext -v
