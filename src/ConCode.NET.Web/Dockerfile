FROM microsoft/dotnet:latest

COPY . /app

WORKDIR /app/ConCode.NET.Web

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

EXPOSE 8080/tcp

ENTRYPOINT ["dotnet", "run", "http://0.0.0.0:8080"]