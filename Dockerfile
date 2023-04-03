FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TodoListService.csproj", "./"]
RUN dotnet restore "TodoListService.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "TodoListService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoListService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoListService.dll"]
