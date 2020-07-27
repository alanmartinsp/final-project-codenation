Desafio final da Aceleração Dev de c# da Codenation, com apoio da Stone.

### Objetivo

Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.
A arquitetura do projeto é formada por:

### Backend - API

- criar endpoints para serem usados pelo frontend da aplicação
- criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
- a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

### Frontend

- deve implementar as funcionalidades apresentadas nos wireframes
- deve ser acessada adequadamente tanto por navegadores desktop quanto mobile
- deve consumir a API do produto
- desenvolvida na forma de uma Single Page Application

### Observações

- Se a aceleração tiver ênfase no backend (Java, Python, C#, Go, PHP, etc) a equipe deve obrigatoriamente implementar a API. A implementação do frontend é considerado um bônus importante
- Se a aceleração tiver ênfase em frontend (React, Vue, Angular, etc) a equipe deve obrigatoriamente implementar o frontend da aplicação e o backend pode ser substituido por uma aplicação mock. A implementação da API é considerado um bônus importante

## Endpoints
Após executar a aplicação, você pode acessar a documentação da API, contendo os endpoints implementados, no endereço http://localhost:51325/swagger.

## Deploy

Para fins de demonstração de funcionamento, foi feito o deploy da aplicação na plataforma [Heroku](https://www.heroku.com/).

| Serviço | Link |
| :--- | :--- |
| Front-end | [https://codenation-log-frontend.herokuapp.com/](Frontend)|
| Back-end | [https://codenation-log-api.herokuapp.com/swagger](Api) |
| Banco de Dados | *Sem acesso externo* |
