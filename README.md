# 🍔 GoodBurguer API

> **Projeto desenvolvido como parte de um Desafio Técnico para a vaga de Desenvolvedor C#.**


API desenvolvida para o gerenciamento de pedidos e cardápio de uma hamburgueria. O objetivo deste projeto foi demonstrar conhecimentos em arquitetura moderna, padrões de projeto e qualidade de código em um ecossistema .NET.

## 🏗️ Arquitetura e Padrões
O projeto foi construído seguindo as melhores práticas de desenvolvimento backend para garantir testabilidade e baixa manutenção:
- **Clean Architecture**: Separação clara de responsabilidades entre as camadas.
- **Domain-Driven Design (DDD)**: Lógica de negócio protegida e centralizada no domínio.
- **CQRS**: Utilização do **MediatR** para desacoplamento entre comandos e consultas.
- **Design Patterns**: Aplicação do padrão **Strategy** para descontos e **Repository/Unit of Work**.

---

## 📌 Funcionalidades
- [x] Criar, atualizar e deletar pedidos.
- [x] Buscar pedido por ID.
- [x] Listar pedidos com paginação.
- [x] Consultar cardápio completo.
- [x] Validação rigorosa de regras de negócio e aplicação de descontos.

## 🧠 Regras de Negócio (Domínio)
O domínio garante que um pedido seja válido apenas se:
- ✔️ Contiver **exatamente 1** sanduíche.
- ✔️ Contiver no **máximo 1** bebida.
- ✔️ Contiver no **máximo 1** acompanhamento.

## 💸 Regras de Desconto
Para o cálculo de descontos, utilizei o padrão **Strategy**. Isso permite que novas regras de promoção sejam adicionadas sem afetar o fluxo principal de criação de pedidos, respeitando o princípio *Open/Closed* (SOLID).

---

## 📂 Estrutura do Projeto
- **GoodBurguer.API**: Camada de entrada, controllers e documentação.
- **GoodBurguer.Application**: Casos de uso, handlers do MediatR e DTOs.
- **GoodBurguer.Domain**: Coração da aplicação (Entidades, Regras de Negócio e Interfaces).
- **GoodBurguer.Infrastructure**: Implementação de dados (EF Core) e integrações externas.

---

## 🚀 Tecnologias Utilizadas
- **Runtime**: .NET 8
- **Banco de Dados**: SQL Server
- **ORM**: Entity Framework Core
- **Comunicação**: MediatR (In-process)
- **Testes**: xUnit

## 🧪 Testes
O foco dos testes foi garantir que as regras de negócio críticas (como a composição do pedido e os descontos) funcionem conforme o esperado.
```bash
dotnet test
```

---

## ⚙️ Como executar o projeto

### 🛠️ Passo a passo
1. **Clonar o repositório:**
   ```bash
   git clone https://github.com
   ```
2. **Configurar o banco:**
   Ajuste a `ConnectionStrings` no `appsettings.json`.
3. **Migrações:**
   ```bash
   dotnet ef database update
   ```
4. **Executar:**
   ```bash
   dotnet run --project GoodBurguer.API
   ```

---

## 👨‍💻 Autor

**Marcos Robles**  
[![Linkedin Badge](https://shields.io)](https://linkedin.com)
