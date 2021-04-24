# Tickets 

# API to implemente MongoDb Crud.

## Instructions

NOTE: As a premise, you should have install Docker in your machine, else you should follow the next link
https://docs.docker.com/docker-for-windows/install/

1) This project is implementing db mongodb with Docker, to run I suggest to follow the steps.

Docker setup

Install Docker client in you machine, 

Linux
 sudo apt install mongo-clients

Windows
 -Download https://www.mongodb.com/try/download/community and Install
 
 -Add the execution path MongoDB to envviroment variables.
 -Seek for Edition enviroment variables.
 -In the tab advance options, looking for Enviroment Varables
 -In path row we will add a new variable, in my personal case C:\Program Files\MongoDB\Server\4.4\bin
 *Accept all the changes


*Download Mongo docker (this)
In your terminal you can 
docker pull mongo

*Mongo instance exec.

type and run the command:
docker run -p 27018:27017 --name mongoTickets mongo

*Validation Docker connection 

In a new terminal run the code
mongo localhost:27018
to check please type,  show dbs, this should show you 3 main dbs.

---Those steps are no necesary , just if you need to stop and continue working after, you can do implement that.

Please check that you replace the conten inside and delete quotes  

*Stop Docker
docker stop "containerId"

*Run old content

docker container start mongoTickets


Note
*You could connect by terminal or by  mongoBDcompas client for working with whole data. 



C# Configuration

to working with sensitive variables I use "user-secrets"

in .net project the connection string was init by 
dotnet user-secrets init -p Tickets.Api

and saved by
dotnet user-secrets set "CONNECTION_STRING" "mongodb://localhost:27018/test?compressors=disabled&gssapiServiceName=mongodb" -p Tickets.Api

you can check the conection string typing 
dotnet user-secrets list -p Tickets.Api

*Connection string
mongodb://localhost:27018/test?compressors=disabled&gssapiServiceName=mongodb


