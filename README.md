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
├── Connected Services/
├── Dependências/
├── Properties/
├── wwwroot/
├── Application/
│   ├── Dtos/
│   ├── Interfaces/
│   └── Services/
├── Controllers/
├── Domain/
│   ├── Entities/
│   └── Interfaces/
├── Infrastructure/
│   └── Data/
│       ├── AppData/
│       ├── Migrations/
│       └── Repositories/
├── Models/
├── Views/
│   ├── Abrigo/
│   ├── Home/
│   ├── Localizacao/
│   ├── Ocupante/
│   ├── Recurso/
│   └── Shared/
```

---

## 📘 Documentação do Projeto
## 📊 Diagramas
O projeto inclui os seguintes diagramas para facilitar o entendimento da arquitetura e estrutura do sistema:

- Diagrama Entidade-Relacionamento (DER): Representa o modelo lógico do banco de dados.
- Modelo de Dados (MER): Reflete o modelo físico do banco de dados com atributos, tipos e chaves.
- Diagrama de Classes (caso haja aplicação .NET ou orientada a objetos): Exibe os relacionamentos entre as classes do sistema.
- Fluxograma ou Diagrama de Casos de Uso (se aplicável): Ilustra os fluxos de interação do usuário com o sistema.

Os diagramas estão disponíveis na pasta ```/docs/diagramas```.

---

## 🚧 Desenvolvimento
- O projeto foi desenvolvido utilizando as tecnologias:

   - .NET 8 com ASP.NET Razor Pages (MVC ou API)
   - Entity Framework Core com Migrations
   - Banco de Dados Relacional (SQL Server, Oracle ou H2)
   - Repositórios com Injeção de Dependência
   - Swagger (para APIs)
   - Bootstrap ou Tailwind (para frontend, se aplicável)

---

## 🧪 Testes
Os testes foram realizados para validar:

   - Funcionalidades CRUD: Teste de criação, leitura, atualização e exclusão de registros.
   - Regras de negócio: Exemplo, não permitir o cadastro de abrigos sem capacidade.
   - Validações em formulário: Campos obrigatórios, tamanhos e formatos.
   - Respostas da API (se aplicável): Status HTTP esperados (200, 400, 404, etc.)

Testes manuais foram feitos por meio do Swagger, Postman e uso direto da aplicação via navegador.

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

## 📌 Exemplos de Testes
- Criar um abrigo via Swagger/Postman (API)

   ```json
   {
     "nome": "Abrigo Central",
     "capacidade": 150,
     "localizacao": "Zona Leste"
   }
   ```

- Verificar lista de abrigos
   ```GET /api/abrigos```

- Erro esperado
   - Tentar criar abrigo com capacidade = 0 → retorna erro 400 com mensagem de validação.

---

## 📘 Documentação da API
A documentação da API está disponível através do Swagger:

🔗 ```https://localhost:XXXX/swagger```

Através dela, é possível visualizar e testar todos os endpoints disponíveis das entidades Abrigo, Localização, Ocupante e Recurso.

---

## 📎 Observações
- O projeto está preparado para ser facilmente adaptado a outros bancos relacionais suportados pelo EF Core.

- As páginas CSHTML utilizam os TagHelpers padrão do ASP.NET Core com suporte a validações automáticas.
