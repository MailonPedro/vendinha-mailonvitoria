# Vendinha Mavi

Sistema desktop desenvolvido em C# com Windows Forms e SQLite para controle de clientes e dívidas.

## Funcionalidades

- Cadastro de clientes
- Edição de clientes
- Exclusão de clientes
- Busca de clientes
- Controle de dívidas
- Registro de pagamentos

## Tecnologias

- C#
- .NET
- Windows Forms
- SQLite

## Como executar

1. Abrir no Visual Studio
2. Executar a aplicação
3. O banco será criado automaticamente

## Regras de negócio

- CPF não pode ser duplicado
- Cliente só pode ter uma dívida pendente
- Dívidas podem ser marcadas como pagas

## Funcionalidade

- Na tela FormBuscar.cs, para excluir um cliente deve-se clicar na linha do mesmo
  a mesma coisa para poder editar.
- Na tela de registrar divida, ao procurar um nome, aparece a lista de clientes
  deve-se dar um duplo click na linha, assim selecionando-o.
- Para marcar a divida com paga, basta selecionar a linha do cliente e clicar no botao marcar como paga
- 