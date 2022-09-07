
# TodoProject
Projeto teste de API backend, implementação de API REST com integração de uma API gRPC.

## Iniciando
.Para iniciar as APIs e o banco como serviços execute o comando:
```
docker-compose up -d
```

.Caso queira executar as APIs separadas do compose execute o comando:
```
docker-compose -f docker-compose_db.yml up -d
```

## Considerações
Foi adicionado os serviços do pgadmin4 e mongo-express no compose para facilitar a consulta dos dados no banco caso necessário.

### Configurando Pgadmin4
Acesse: http://localhost:16543 e realize login com as credenciais informadas no compose.
![Alt text](img/pg_admin_1.png?raw=true "Passo 1")

Clique em "Adicionar Novo Servidor", configure o servidor conforme informações no compose:
	Senha: LeandroPostgres2021*
![Alt text](img/pg_admin_2.png?raw=true "Passo 2")

### Configurando Mongo-Express
Acesse: http://localhost:8081



## Dependências
.NET 6
.AutoMapper 11.0.1
.AutoMapper.Extensions.Microsoft.DependencyInjection 11.0.0
.MediatR 10.0.1
.MediatR.Extensions.Microsoft.DependencyInjection 10.0.1
.Npgsql.EntityFrameworkCore.PostgreSQL 6.0.6
.MongoDB.Driver 2.17.1
