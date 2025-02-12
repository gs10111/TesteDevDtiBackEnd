# TesteDevDtiBackEnd
# Sistema de Notas Escolar

## 📌 Sobre o Projeto
Aplicação desenvolvida em **.NET** para gerenciar alunos, disciplinas e notas. O objetivo do sistema é facilitar o acompanhamento do desempenho acadêmico, permitindo o cadastro, atualização e consulta de informações relacionadas aos alunos e suas notas.

## 🚀 Tecnologias Utilizadas
- **.NET** (versão 8)
- **MongoDB** para armazenamento de dados
- **MongoDB.Driver** para comunicação com o banco de dados
- **MongoDB Compass** (para consulta dos dados)
- **ASP.NET Core** para a API
- **React** para o frontend 
- **Swagger** para documentação da API

## ⚙️ Funcionalidades
- 📌 Cadastro de alunos
- 📌 Registro de notas dos alunos
- 📌 Consulta de notas e médias

## 🎯 Como Executar o Projeto
### Pré-requisitos
Antes de executar o projeto, certifique-se de ter instalado:
- **.NET SDK** (versão compatível com o projeto)
- **MongoDB** (local )
- **Visual Studio** 

### Passos para rodar a aplicação
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/sistema-de-notas.git
   ```
2. Acesse a pasta do projeto:
   ```bash
   cd sistema-de-notas
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Configure a string de conexão com o MongoDB no arquivo de configurações `appsettings.json`:
   ```json
   "MongoDbSettings": {
     "ConnectionString": "mongodb://localhost:{Sua connection String} ",
     "DatabaseName": "SistemaNotasFrequenciaDB"
   }
   ```
5. Inicie a aplicação:
   ```bash
   dotnet run
   ```

A API estará disponível em `http://localhost:5000` (ou outra porta configurada).

## 📖 Documentação da API
A documentação da API pode ser acessada via **Swagger** em:
```
http://localhost:5000/swagger
```
