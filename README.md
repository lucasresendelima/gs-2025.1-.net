# Gestão de Abrigos - ASP.NET Core WebApp

Este projeto é uma aplicação web ASP.NET Core voltada para a **gestão de abrigos e seus recursos** durante situações de emergência. A aplicação possibilita o **gerenciamento de abrigos, ocupantes, localizações e recursos** através de uma interface amigável em Razor Pages, além de disponibilizar uma API REST documentada com Swagger.

---

## 👨‍💻 Autores
Desenvolvido pelo grupo LTAKN:
- RM: 557937  –  Enzo Prado Soddano
- RM: 556564  –  Lucas Resende Lima
- RM: 559183  –  Vinicius Prates Altafini

---

## 🧩 Tecnologias Utilizadas

- ASP.NET Core 8.0
- Razor Pages (CSHTML)
- Entity Framework Core (com Migrations)
- Oracle Database
- Swagger para documentação da API
- Padrão de projeto: Camadas (Presentation, Application, Domain, Infrastructure)
- Validações com Data Annotations
- Injeção de Dependência
- Oracle.EntityFrameworkCore

---

## 📦 Funcionalidades

### 📁 Entidades Gerenciadas:
- **Abrigos**
- **Localizações**
- **Ocupantes**
- **Recursos**

### 🔧 Funcionalidades Implementadas:
- CRUD completo para todas as entidades
- Validação de formulários com Data Annotations
- Relacionamentos entre entidades:
  - Abrigo → Localização (N:1)
  - Abrigo → Ocupantes (1:N)
- Persistência com EF Core + Oracle
- Interface Razor Pages com suporte a:
  - Exibição de listas e detalhes
  - Formulários de criação, edição e exclusão
- Integração com Swagger para testes da API REST

---

## 🗂️ Organização em Camadas:

```GestaoAbrigos_WebApp/
├── Application/
│ ├── Dtos/
│ ├── Interfaces/
│ └── Services/
├── Domain/
│ ├── Entities/
│ └── Interfaces/
├── Infrastructure/
│ └── Data/
│ └── AppData/
├── Presentation/
│ └── Controllers/
├── Migrations/
└── Pages/
```

---

---

## 🚀 Como Executar o Projeto

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seu-usuario/GestaoAbrigos_WebApp.git
   cd GestaoAbrigos_WebApp
   ```

2. Configure a string de conexão no ```appsettings.json```

  ```json
  "ConnectionStrings": {
    "DefaultConnection": "User Id=...;Password=...;Data Source=..."
  }
  ```

3. Rode as migrations (opcional, se necessário recriar o banco)

  ```bash
  dotnet ef database update
  ```

4. Execute o projeto

  ```bash
  dotnet run
  ```

5. Acesse no navegador

- Interface Web: ```https://localhost:XXXX```

- Swagger (API REST): ```https://localhost:XXXX/swagger```

---

## 📘 Documentação da API
A documentação da API está disponível através do Swagger:

🔗 ```https://localhost:XXXX/swagger```

Através dela, é possível visualizar e testar todos os endpoints disponíveis das entidades Abrigo, Localização, Ocupante e Recurso.

---

## 📎 Observações
- O projeto está preparado para ser facilmente adaptado a outros bancos relacionais suportados pelo EF Core.

- As páginas CSHTML utilizam os TagHelpers padrão do ASP.NET Core com suporte a validações automáticas.
