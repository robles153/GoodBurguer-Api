# GoodBurguer API

API desenvolvida em **.NET 8** para gerenciamento de pedidos e cardápio de uma hamburgueria.

O projeto foi construído seguindo boas práticas de desenvolvimento backend, utilizando **Clean Architecture**, **DDD** e **CQRS com MediatR**.

---

## 📌 Funcionalidades

- Criar pedido  
- Atualizar pedido  
- Deletar pedido  
- Buscar pedido por ID  
- Listar pedidos com paginação  
- Consultar cardápio  
- Aplicação de regras de negócio  
- Aplicação de descontos  

---

##  Regras de negócio

Um pedido deve obrigatoriamente seguir:

- ✔️ Deve conter **exatamente 1 sanduíche**
- ✔️ Pode conter **no máximo 1 bebida**
- ✔️ Pode conter **no máximo 1 acompanhamento**

### Exemplos inválidos:

- ❌ Dois sanduíches  
- ❌ Duas bebidas  
- ❌ Dois acompanhamentos  
- ❌ Pedido sem sanduíche  

---

##  Regras de desconto

A aplicação utiliza o padrão **Strategy** para aplicar descontos.

Cada regra de desconto é isolada, permitindo fácil manutenção e extensão.

---

## 🏗️ Arquitetura

O projeto foi estruturado seguindo **Clean Architecture**:

GoodBurguer.API
GoodBurguer.Application
GoodBurguer.Domain
GoodBurguer.Infrastructure


### Camadas

- **API** → Controllers e configuração  
- **Application** → Handlers, Requests, Responses, DTOs  
- **Domain** → Entidades, regras de negócio e exceções  
- **Infrastructure** → Repositórios e acesso a dados  

---

##  Tecnologias utilizadas

- .NET 8  
- ASP.NET Core  
- Entity Framework Core  
- SQL Server  
- MediatR  
- Swagger  
- xUnit (testes unitários)  

---

Padrões utilizados
Clean Architecture
Domain-Driven Design (DDD)
Repository Pattern
Unit of Work
Strategy Pattern

Decisões de arquitetura
Utilização de Clean Architecture para separação de responsabilidades
Uso de CQRS com MediatR para desacoplamento entre camadas
Regras de negócio centralizadas na camada Domain
Aplicação do padrão Strategy para cálculo de descontos
Uso de Repository Pattern e Unit of Work
DTOs localizados na camada Application, evitando acoplamento com a API

Testes

O projeto possui:

 Testes unitários das regras de negócio

 ## Como rodar
1. Atualizar connection string
2. Rodar migrations
3. Executar projeto

