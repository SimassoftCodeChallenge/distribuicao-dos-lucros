FROM microsoft/dotnet:2.1.500-sdk-alpine AS builder

WORKDIR /source

COPY . .

#faz o build
RUN dotnet publish Solution.sln --output /app/ --configuration Release

FROM microsoft/dotnet:2.1.500-sdk-alpine
WORKDIR /root
EXPOSE 5100

# Copia o codigo compilado do primeiro container para o segundo
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "Simasoft.Challenge.Lucro.Api.dll"]

#docker build -t simasoft-participacao-lucros-rest .
#docker run --name simasoft-participacao-lucros-api -p 8000:80 simasoft-participacao-lucros-rest
#http://localhost:8000/phonogram-service/swagger
