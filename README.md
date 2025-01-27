# OrganizaMed

[![Stack](https://skillicons.dev/icons?i=dotnet,cs,nodejs,typescript,angular,bootstrap,cypress&perline=8&theme=light)](https://skillicons.dev)

## Projeto

Trabalho de conclusão de curso para a [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Descrição

Uma clínica médica é um centro onde atividades, como cirurgias e consultas, são realizadas por profissionais médicos.
Os alunos da  [Academia do Programador](https://www.academiadoprogramador.net) 2024 foram contratados para criar um aplicativo web que mantenha e
organize o cronograma dessas atividades dentro da clínica.

---
## Funcionalidades

1. O cadastro do **Médicos** consiste de:
- Nome
- Data de nascimento
- Telefone
- CPF
- CRM

2. O cadastro do **Atendimento** consiste de:
- Tipo 
- Hora de inicio
- Hora de termino 
- Médico responsavel

### Demais funcionalidades
- Verificação de médico ja inserido
- Verificação de Horario inserido corretamente
- Não exclusão de médicos com atividades pendentes
- Cadastro de usuarios do sistema
- Sistema de login

### Futuras Funcionalidades
- Verificação de conflitos de horarios nas agendas dos médicos
- Medicos com mais horas de trabalho
---
## Requisitos para Execução do Projeto Completo

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto back-end.
- Node.js v20+
- Angular v18 

---
## Executando o Back-End 

Vá para a pasta do projeto da WebAPI:

```bash
cd server/organizamed.WebApi
```

Execute o projeto:

```bash
dotnet run
```

A API poderá ser acessada no endereço `https://localhost:8000/api`.

A documentação **OpenAPI** também estará disponível em: `https://localhost:8000/swagger`.

---
## Executando o Front-End 

Vá para a pasta do projeto Angular:

```bash
cd client
```

Instale as dependências:

```bash
npm install
```

Execute o projeto:

```bash
npm start
```

A aplicação Angular estárá disponível no endereço `http://localhost:4200`.
