📝 Passo 1: Criar o Arquivo
No VS Code, clique na pasta raiz Projeto Eventos (a pasta mãe de todas).

Crie um novo arquivo chamado README.md (tem que ser maiúsculo e terminar com .md).

Copie o código abaixo e cole dentro desse arquivo:

```Markdown
# 🚀 EventManager

Sistema completo para gerenciamento de eventos (CRUD), desenvolvido com arquitetura moderna Full Stack.

## 🛠️ Tecnologias Utilizadas

**Front-end:**
* **Angular 19** (Standalone Components, Signals, Services)
* **Bootstrap 5** (Design Responsivo e UI moderna)
* **TypeScript**

**Back-end:**
* **C# / .NET 8+** (Minimal APIs)
* **Entity Framework Core**
* **SQLite** (Banco de dados)

## ✨ Funcionalidades

* ✅ **Criar:** Cadastro de novos eventos com data, local e descrição.
* ✅ **Listar:** Visualização de todos os eventos em cards interativos.
* ✅ **Editar:** Atualização de informações de eventos existentes.
* ✅ **Excluir:** Remoção de eventos do banco de dados.

## ⚙️ Como rodar o projeto

### Pré-requisitos
* Node.js e Angular CLI instalados.
* .NET SDK instalado.

### 1. Rodando a API (Back-end)
```bash
cd EventManager.API
dotnet run
A API rodará em: http://localhost:5058 (ou porta similar)

2. Rodando o Front-end
```bash
cd EventManager.Web
npm install
ng serve
Acesse o projeto em: http://localhost:4200

Desenvolvido por Rafael Souza 💻