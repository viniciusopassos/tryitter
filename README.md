# tryitter

### Evidência de funcionamento: https://1drv.ms/u/s!AnRiLk1UjnTwiDxs2-yoNLVlz3B4?e=RAeLgo

## Descrição
Esse Projeto busca simular a API de uma rede social(twitter), totalmente baseada em texto. O objetivo é proporcionar um ambiente em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.

## Tecnologias Usadas

> Desenvolvida utilizando: C#, .Net, Entity Framework Core, Docker-Compose, SQLServer, xUnity. Utilizando o Modelo MVC.

## Orientações

### Docker-Compose

<details>
  <summary><strong>Usando Docker</strong></summary><br />
 
  > Rode o serviço `SQLServer`: entra na pasta com o comando: `cd src/` e inicialize o Contêiner com o comando: `docker-compose up -d`.
</details>

### Comando para subir o Banco

<details>
  <summary><strong>Você precisa ter o `dotnet ef` instalado.</strong></summary><br />

  Para instalar globalmente use

  > `dotnet tool install --global dotnet-ef`
  
  Para atualizar o Banco de dados use
  
  > `dotnet ef database update`
</details>

## Iniciando a aplicação

Comandos para acessar a aplicação:

Clone o projeto:

`git clone git@github.com:viniciusopassos/tryitter.git`

Acesse a pasta do Projeto:

`cd tryitter`

Acesse a raiz do projeto:

`cd src/`<br>
`cd tryitter`

Atualize o banco de dados:

`dotnet ef database update`

Inicialize a aplicação:

`dotnet run`
