# TesteDevDtiBackEnd
# Sistema de Notas Escolar

## 📌 Sobre o Projeto
Aplicação desenvolvida em **.NET** para gerenciar alunos, disciplinas e notas. O objetivo do sistema é facilitar o acompanhamento do desempenho acadêmico, permitindo o cadastro, atualização e consulta de informações relacionadas aos alunos e suas notas.

## 🚀 Tecnologias Utilizadas
- **.NET** (versão 8.0)
- **MongoDB** para armazenamento de dados
- **MongoDB.Driver** para comunicação com o banco de dados
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
É possível apenas abrir a solução no Visual Studio, fazer a alteração da connection string e rodar a aplicação.
1. Clone o repositório:
   ```bash
   https://github.com/gs10111/TesteDevDtiBackEnd.git
   ```
2. Acesse a pasta do projeto:
   ```bash
   cd SistemaNotasFrequencia
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

## 🎯 Como Executar os testes

Para a execução dos testes unitários, é necessário o download das seguintes bibliotecas.

**xUnit**

**xUnit.runner.visualstudio**

**Moq**

Após instaladas, basta apenas executar todos os testes. Pressione Ctrl + R, A para executar todos os testes de uma vez na solução de teste.

