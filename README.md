# TripSupp

## TripSupp.WebAPI 
```sh
    dotnet ef migrations add InitialCreate
    dotnet ef database drop
    dotnet ef database update

    dotnet run seeddata
    dotnet run build
```


```sh
cd .\TripSupp.WebAPI\
docker build -t docker-tripsupp-api -f Dockerfile .
cd .\TripSupp.WebApp\
docker build -t docker-tripsupp-webapp -f Dockerfile .
cd ..
docker compose up --build
```