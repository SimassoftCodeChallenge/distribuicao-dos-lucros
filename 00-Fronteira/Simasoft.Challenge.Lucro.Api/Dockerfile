FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Simasoft.Challenge.Lucro.Api/Simasoft.Challenge.Lucro.Api.csproj", "Simasoft.Challenge.Lucro.Api/"]
RUN dotnet restore "Simasoft.Challenge.Lucro.Api/Simasoft.Challenge.Lucro.Api.csproj"
COPY . .
WORKDIR "/src/Simasoft.Challenge.Lucro.Api"
RUN dotnet build "Simasoft.Challenge.Lucro.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Simasoft.Challenge.Lucro.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Simasoft.Challenge.Lucro.Api.dll"]