# LeadManager

## Backend

### Execução
Para executar a aplicação no visual studio basta abrir a solution do projeto e executar o projeto WebApi. O swagger será aberto no browser padrão.

### Busca Leads
Para buscar os Leads foi criado um filtro na query de status: Invited = 0, Accepted = 1, Declined = 2, se não passar nenhum status retorna todos.

### Atualizar Leads
Para atualizar os Leads foi criado um patch que no body possui o campo "accepted", caso seja true executa as regras definidas para o caso de "accepted", se for false executa as regras para o caso de "declined".

### Observações

Foi utilizado o Sqlite (em memória) no lugar do SQLServer pra facilitar a execução local, ao executar a aplicação o banco em memória é inicializado com alguns dados padrão. Durante a execução, se o dado é alterado ele grava em memória as alterações, mas ao reiniciar a aplicação as alterações são perdidas e ele volta para o estado inicial.

Algumas classes de dominio estão com algumas propriedades (exemplo: id) com o set público para facilitar a criação dos testes unitários, mas em um contexto normal o set delas seria privado.

Algumas classes de dominio estão com construtores abertos para facilitar a criação dos testes unitários, mas em um contexto normal existiria apenas construtores com as regras de criação obrigátorias.

## Frontend

### Execução

Para executar a aplicação rodar os seguintes comandos

```bash
yarn install
```

```bash
yarn start
```