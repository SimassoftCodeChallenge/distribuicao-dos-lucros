# distribuicao-dos-lucros
Sistema de Calculo de Distribuição dos Lucros da Empresa ACME

# Instruções de execução
a) Local
1) efetuar o Clone;
2) Executar os seguintes comandos .net core:
2.1) dotnet clean
2.2) dotnet build
2.3) dotnet run
3) Para acessar o Swagger: http://endereco:porta/swagger

b) Container Docker
1) docker build -t simasoft-participacao-lucros-rest .
2) docker run --name simasoft-participacao-lucros-api -p 8000:80 simasoft-participacao-lucros-rest
3) http://localhost:8000/phonogram-service/swagger