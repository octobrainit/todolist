FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN apt-get update && apt-get install -y clang libc++-dev libc++abi-dev

COPY ["./src/1 - presentation/TaskList.Api/TaskList.Api.csproj", "./src/1 - presentation/TaskList.Api/"]
RUN dotnet restore "./src/1 - presentation/TaskList.Api/"

COPY ["./src/2 -business/TaskList.Business/TaskList.Business.csproj", "./src/2 -business/TaskList.Business/"]
RUN dotnet restore "./src/2 -business/TaskList.Business/"

COPY ["./src/2 -business/TaskList.Domain/TaskList.Domain.csproj", "./src/2 -business/TaskList.Domain/"]
RUN dotnet restore "./src/2 -business/TaskList.Domain/"

COPY ["./src/3 - infraestructure/TaskList.Data/TaskList.Data.csproj", "./src/3 - infraestructure/TaskList.Data/"]
RUN dotnet restore "./src/3 - infraestructure/TaskList.Data/"

COPY ["./src/4 - tests/TaskList.Domain.UnitTest/TaskList.Domain.UnitTest.csproj", "./src/4 - infraestructure/TaskList.Domain.UnitTest/"]
RUN dotnet restore "./src/4 - infraestructure/TaskList.Domain.UnitTest/"

COPY . ./
RUN dotnet publish -c Release -o /app -r linux-x64 --self-contained=true /p:PublishTrimmed=false /p:TrimMode=link

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS runtime
WORKDIR /app

COPY --from=build /app ./

EXPOSE 8080

ENTRYPOINT ["./TaskList.Api"]
