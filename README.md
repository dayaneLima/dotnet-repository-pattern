# 📦 RepositoryPattern

Este projeto demonstra uma aplicação backend modular e organizada utilizando o **padrão Repository com Specification Pattern**, arquitetura em camadas e o padrão **CQRS com Mediator** — ideal para APIs REST robustas e escaláveis.

---

## ✨ Tecnologias e Conceitos

- ✅ **.NET 8**
- ✅ **Entity Framework Core + PostgreSQL**
- ✅ **Arquitetura em camadas (Application / Domain / Infrastructure)**
- ✅ **CQRS com Mediator (customizado)**
- ✅ **Specification Pattern**
- ✅ **Minimal APIs**
- ✅ **Directory.Packages.props (gerenciamento centralizado de pacotes)**

---

## 🧱 Camadas do Projeto

| Camada        | Responsabilidade |
|---------------|------------------|
| `Application` | Casos de uso (Commands e Queries), validações e DTOs |
| `Domain`      | Entidades de negócio, regras de domínio e Specifications |
| `Infrastructure` | Implementações de repositórios, contexto EF e injeção de dependências |

---

## 📌 Exemplos de Endpoints

### 🔍 Obter produto por ID

```
GET /v1/products/{id}
```

### ➕ Criar novo produto

```
POST /v1/products
Content-Type: application/json

{
  "title": "Notebook Core i7"
}
```

---

## 🧠 Entidade de Domínio

```csharp
public class Product : Entity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
}
```

---

## 🧠 Padrão Specification

```csharp
public class GetProductByIdSpecification(Guid id) : Specification<Product>
{
    public override Expression<Func<Product, bool>> ToExpression()
        => product => product.Id == id;
}
```

---

## 🛠️ Migrations

### Criar uma migration

```bash
dotnet ef migrations add InitialCreate --project RepositoryPattern.Infrastructure --startup-project RepositoryPattern.API
```

### Atualizar o banco

```bash
dotnet ef database update --project RepositoryPattern.Infrastructure --startup-project RepositoryPattern.API
```

---

## 📁 Directory.Packages.props

Este projeto utiliza `Directory.Packages.props` para centralizar as versões dos pacotes NuGet. Isso melhora a consistência e facilita o upgrade de dependências em soluções maiores.

---


## 📜 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
