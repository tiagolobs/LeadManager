# LeadManager

## Execução
Para executar a aplicação no visual studio basta abrir a solution do projeto e executar o projeto WebApi. O swagger será aberto no browser padrão.

## Observações

Foi utilizado o Sqlite (em memória) no lugar do SQLServer pra facilitar a execução local, ao executar a aplicação o banco em memória é inicializado com alguns dados padrão. Durante a execução, se o dado é alterado ele grava em memória as alterações, mas ao reiniciar a aplicação as alterações são perdidas e ele volta para o estado inicial.

Algumas classes de dominio estão com algumas propriedades (exemplo: id) com o set público para facilitar a criação dos testes unitários, mas em um contexto normal o set delas seria privado.

Algumas classes de dominio estão com construtores abertos para facilitar a criação dos testes unitários, mas em um contexto normal existiria apenas construtores com as regras de criação obrigátorias.