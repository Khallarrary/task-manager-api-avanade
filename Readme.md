# Task Manager – Full Stack (Angular + .NET)

Aplicação web full stack para gerenciamento de tarefas, desenvolvida com **Angular no front-end** e **ASP.NET Core Web API no back-end**, utilizando **SQL Server** como banco de dados.

---

##  Funcionalidades

* ✔ Criar tarefas
* ✔ Listar tarefas
* ✔ Atualizar status (Pendente / Concluída)
* ✔ Deletar tarefas individuais
* ✔ Deletar todas as tarefas
* ✔ Filtrar tarefas por status
* ✔ Validação de formulário no front-end

---

## Tecnologias utilizadas

### 🔹 Front-end

* Angular
* TypeScript
* HTML + CSS

### 🔹 Back-end

* ASP.NET Core Web API (.NET)
* Entity Framework Core

### 🔹 Banco de Dados

* SQL Server

---

## Estrutura do projeto

TaskManager.API
TaskManager.Application
TaskManager.Domain
TaskManager.Infrastructure
task-manager-frontend

---

## Como executar o projeto

### 🔹 1. Clonar o repositório

git clone https://github.com/Khallarrary/task-manager-api-avanade

---

### 🔹 2. Configurar o Back-end

* Abrir a solução no Visual Studio ou VS Code
* Configurar a string de conexão no `appsettings.json`

Exemplo:

"ConnectionStrings": {
"DefaultConnection": "Server=SEU_SERVIDOR;Database=TaskDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

---

### 🔹 3. Rodar as migrations

dotnet ef database update

---

### 🔹 4. Executar a API

dotnet run

API disponível em:

https://localhost:5001

Swagger:

https://localhost:5001/swagger

---

### 🔹 5. Executar o Front-end

cd task-manager-frontend
npm install
ng serve

Aplicação disponível em:

http://localhost:4200

---

## Endpoints principais

* GET /api/tasks → Listar tarefas
* GET /api/tasks/{id} → Buscar por ID
* POST /api/tasks → Criar tarefa
* PUT /api/tasks/{id} → Atualizar tarefa
* DELETE /api/tasks/{id} → Deletar tarefa
* DELETE /api/tasks/all → Deletar todas

---

## Decisões técnicas

* Uso de **arquitetura em camadas** (Domain, Application, Infrastructure)
* Separação de responsabilidades com **Repository Pattern**
* Uso de **DTOs** para comunicação com a API
* Consumo da API via **HttpClient no Angular**
* Gerenciamento de estado simples no front-end

---

## Melhorias futuras

* Autenticação e autorização
* Paginação de tarefas
* Notificações (toasts)
* Testes automatizados
* Deploy em nuvem

---

## Autor

Desenvolvido por José Aparecido Fernandes Junior

---

## Observações

Este projeto foi desenvolvido como desafio técnico com foco em boas práticas de desenvolvimento full stack.
