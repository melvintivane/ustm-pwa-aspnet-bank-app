# Gestor de Contas Bancárias

## Resumo
O projeto parteII_pwa_teste é uma aplicação web desenvolvida em ASP.NET Core que gerencia contas bancárias. Ele permite a criação, edição e exclusão de contas bancárias, bem como a exibição de uma lista de todas as contas disponíveis. O projeto utiliza o Entity Framework Core para interagir com o banco de dados, que contém informações sobre as contas bancárias.

## Getting Started
```shell
   1. Clone este repositório
   2. dotnet tool install --global dotnet-ef
   3. dotnet ef migrations add InitialMigration
   4. dotnet ef database update
   5. dotnet run
```

## Estrutura do Projeto
O projeto é organizado da seguinte forma:

Controllers: Esta pasta contém os controladores da aplicação. O ContaController gerencia as operações relacionadas às contas bancárias, como adição, edição, exclusão e listagem.

Data: Aqui estão os arquivos relacionados ao contexto do banco de dados. O ContaDBContext é responsável por configurar a conexão com o banco de dados e definir as entidades (tabelas) que serão usadas na aplicação.

Models: Nesta pasta, encontram-se os modelos de dados utilizados na aplicação. Os modelos Conta, AddConta, e UpdateConta representam as informações das contas bancárias e são usados para validação e manipulação dos dados.

## Controlador ContaController
O ContaController é responsável por lidar com as operações relacionadas às contas bancárias, incluindo:

- List(): Retorna uma lista de todas as contas bancárias cadastradas.
- Add(): Exibe o formulário para adicionar uma nova conta bancária.
- Add(AddConta addContaRequest): Processa o formulário de adição de conta bancária e a insere no banco de dados.
- Edit(Guid id): Exibe o formulário de edição de uma conta bancária com base em seu ID.
- Edit(UpdateConta model): Processa o formulário de edição de conta bancária e atualiza os dados no banco de dados.
- Delete(UpdateConta model): Remove uma conta bancária com base no ID especificado.

## Fluxo de Funcionamento
1. O usuário acessa a página inicial da aplicação.
2. A página inicial exibe uma lista de contas bancárias cadastradas no banco de dados.
3. O usuário pode optar por adicionar uma nova conta bancária, editar uma conta existente ou excluí-la.
4. Para adicionar uma nova conta, o usuário preenche um formulário com informações do titular e do e-mail. Um número de conta aleatório é gerado automaticamente.
5. Para editar uma conta, o usuário seleciona a opção de edição na lista e modifica os dados no formulário correspondente.
6. Para excluir uma conta, o usuário seleciona a opção de exclusão na lista.
7. Após cada operação, o usuário é redirecionado de volta à lista de contas bancárias.

## Banco de Dados
O projeto utiliza o Entity Framework Core para se conectar a um banco de dados. O banco de dados é configurado no ContaDBContext e possui uma única tabela chamada Contas, que armazena informações sobre as contas bancárias, incluindo ID, número da conta, titular e e-mail.

## Considerações Finais
Este projeto fornece uma estrutura básica para gerenciar contas bancárias em uma aplicação web ASP.NET Core. É importante notar que a aplicação não inclui autenticação de usuário ou medidas de segurança avançadas, portanto, deve ser usada apenas para fins educacionais ou como ponto de partida para um sistema mais robusto.

Para melhorar a aplicação, você pode considerar adicionar autenticação de usuário, autorização, validações de entrada mais rigorosas e medidas de segurança adicionais, dependendo das necessidades do seu projeto.

## Licença
Este projeto está licenciado sob a Licença MIT - consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.

