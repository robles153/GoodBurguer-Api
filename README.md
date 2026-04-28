markdown
# 🍔 GoodBurguer API

![.NET](https://shields.io)
![SQL Server](https://shields.io)

API desenvolvida para o gerenciamento de pedidos e cardápio de uma hamburgueria, focada em escalabilidade e organização.

## 🏗️ Arquitetura e Padrões
O projeto foi construído seguindo as melhores práticas de desenvolvimento backend:
- **Clean Architecture**: Separação clara de responsabilidades.
- **Domain-Driven Design (DDD)**: Foco nas regras de negócio e domínio.
- **CQRS**: Utilização do **MediatR** para desacoplamento entre comandos e consultas.
- **Design Patterns**: Aplicação do padrão **Strategy** para descontos e **Repository/Unit of Work**.

---

## 📌 Funcionalidades
- [x] Criar, atualizar e deletar pedidos.
- [x] Buscar pedido por ID.
- [x] Listar pedidos com paginação.
- [x] Consultar cardápio completo.
- [x] Aplicação automática de regras de negócio e descontos.

## 🧠 Regras de Negócio
Para garantir a integridade dos pedidos, as seguintes regras são validadas:
- ✔️ Deve conter **exatamente 1** sanduíche.
- ✔️ Pode conter no **máximo 1** bebida.
- ✔️ Pode conter no **máximo 1** acompanhamento.

*Exemplos inválidos:* `Dois sanduíches`, `Pedido sem sanduíche`, `Duas bebidas`.

## 💸 Regras de Desconto
A aplicação utiliza o padrão **Strategy**. Cada regra de desconto é isolada em sua própria classe, facilitando a manutenção e a criação de novas promoções sem alterar o código existente.

---

## 📂 Estrutura do Projeto
- **GoodBurguer.API**: Controllers e configurações de entrada.
- **GoodBurguer.Application**: Handlers, Requests, Responses e DTOs.
- **GoodBurguer.Domain**: Entidades, interfaces de repositório, exceções e regras de negócio.
- **GoodBurguer.Infrastructure**: Repositórios, acesso a dados (EF Core) e persistência.

---

## 🚀 Tecnologias Utilizadas
- **Runtime**: .NET 8 / ASP.NET Core
- **ORM**: Entity Framework Core
- **Banco de Dados**: SQL Server
- **Comunicação**: MediatR
- **Documentação**: Swagger (OpenAPI)
- **Testes**: xUnit

## 🧪 Testes
O projeto possui testes unitários focados nas regras de negócio e domínio.
Para executar os testes:
```bash
dotnet test
```

---

## ⚙️ Como executar o projeto

### 🔧 Pré-requisitos
- [.NET 8 SDK](https://microsoft.com)
- SQL Server (ou LocalDB)

### 🛠️ Passo a passo
1. **Clonar o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/goodburguer.git
   cd goodburguer
   ```

2. **Configurar o Banco de Dados:**
   No arquivo `appsettings.json`, atualize a sua `ConnectionStrings`.

3. **Rodar as Migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Executar a aplicação:**
   ```bash
   dotnet run --project GoodBurguer.API
   ```
   Acesse o Swagger em: `https://localhost:7002/swagger`

---

## 👨‍💻 Autor
**Marcos Robles**  
Desenvolvedor Backend .NET
