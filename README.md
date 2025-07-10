# 🧾 Minimal API com .NET 9, PostgreSQL e Vue — Sistema de Pedidos

Este projeto implementa uma API REST com .NET 9 (Minimal API), PostgreSQL como banco de dados relacional, validação robusta com FluentValidation e mapeamento de objetos via AutoMapper.  
A aplicação simula um sistema de gestão de pedidos com clientes e produtos, e é consumida por uma interface web desenvolvida com Vue.js.

> Este projeto foi idealizado como parte de meu portfólio profissional com foco em backend moderno, organizado e pronto para produção.

---

## 🔧 Tecnologias Utilizadas

### 🧠 Backend
- .NET 9 (Minimal API)
- Entity Framework Core
- PostgreSQL
- AutoMapper
- FluentValidation
- Scalar – documentação moderna OpenAPI

### 🎨 Frontend
- Vue 3 + Vite
- Axios (consumo da API)

---

## 📚 Funcionalidades

- ✅ Cadastro de clientes com validações e retorno de dados limpos
- ✅ Gerenciamento de produtos com preço e nome
- ✅ Criação de pedidos com múltiplos produtos (relação N:N)
- ✅ Listagem de pedidos com seus respectivos itens e cliente associado
- ✅ DTOs separados para entrada (Create/Update) e saída (Read)
- ✅ Validação robusta com mensagens amigáveis
- ✅ Configurações de modelo via Fluent API (`IEntityTypeConfiguration`)
- ✅ Interface interativa de documentação com Scalar

---

## 🧱 Estrutura do Projeto

```
/Backend
│
├── DTOs/                  # Objetos de transferência de dados
├── Endpoints/             # Rotas organizadas por entidade
├── Entities/              # Modelos de domínio
├── Configurations/        # Fluent API para modelagem do EF
├── Validators/            # Validações com FluentValidation
├── Data/                  # AppDbContext e acesso ao banco
├── MappingProfile.cs      # Mapeamento com AutoMapper
└── Program.cs             # Entrypoint principal
```

---

## ⚙️ Como Rodar o Projeto

### Pré-requisitos:

- .NET 9 SDK Preview
- PostgreSQL instalado
- Node.js 18+ com npm ou yarn (para o front)

---

### 🔄 Backend (.NET API)

```bash
cd Backend
dotnet ef database update
dotnet run
```

A API será executada em:  
`https://localhost:5001`

> A documentação estará disponível no Scalar: `http://localhost:5001/docs`

---

### 💻 Frontend (Vue)

```bash
cd Frontend
npm install
npm run dev
```

A interface estará disponível em:  
`http://localhost:5173`

---

## 📷 Screenshots

> (Adicione capturas de tela do Scalar, Vue e exemplos de payloads aqui)

---

## 🧠 Aprendizados e Objetivos

Este projeto teve como foco:

- Uso do EF Core com PostgreSQL em cenários reais
- Boas práticas com DTOs, validações e mapeamentos
- Modelagem de banco com relacionamentos complexos (muitos-para-muitos)
- Organização modular e sustentável com Minimal API
- Consumo da API com Vue.js e exibição dos dados na interface

---

## 🔄 Possíveis Expansões Futuras

- ✅ Autenticação com JWT e roles
- ✅ Paginação e filtros avançados
- 📦 Exportação de relatórios (PDF, Excel)
- ☁️ Deploy com CI/CD no Railway, Render ou Azure
- 🔐 Login/registro de usuários com identidade

---

## ✍️ Autor

**Rogerio Cardoso da Vitória**  
[LinkedIn](https://www.linkedin.com/in/rogeriodavcardoso/)  
Desenvolvedor C# com foco em APIs limpas, modernas e com boas práticas de mercado.

---

## 📄 Licença

Este projeto é de código aberto, para fins educacionais e profissionais.  
Atualizado em: 10/07/2025
