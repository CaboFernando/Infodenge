### Explicação Geral da Aplicação

A aplicação **Infodengue** foi desenvolvida com o objetivo de gerenciar dados relacionados a **solicitantes** e **relatórios** sobre arboviroses (como dengue, zika e chikungunya). A arquitetura foi baseada no padrão **DDD (Domain-Driven Design)**, utilizando **.NET 6** para a implementação dos serviços e **Entity Framework Core** (EF Core) para o acesso ao banco de dados relacional SQL Server.

A aplicação é composta pelos seguintes componentes principais:

1. **Controllers**:

   * **RelatorioController**: Responsável por gerenciar as requisições relacionadas aos relatórios. Ele permite que os usuários solicitem relatórios, obtenham relatórios por código IBGE, e obtenham totais por arbovirose, entre outras funcionalidades.
   * **SolicitanteController**: Gerencia as requisições relacionadas aos solicitantes, como a criação e consulta de dados de solicitantes.

2. **Services**:

   * **RelatorioService**: Contém a lógica de negócios para adicionar e listar relatórios. Ele interage com o repositório de relatórios para persistir e recuperar dados do banco.
   * **SolicitanteService**: Realiza a lógica de negócios relacionada a solicitantes, interagindo com o repositório de solicitantes.

3. **Repositories**:

   * **RelatorioRepository**: Responsável por persistir e consultar dados de relatórios no banco de dados.
   * **SolicitanteRepository**: Responsável por persistir e consultar dados de solicitantes no banco de dados.

4. **Entities**:

   * **Solicitante**: Representa um solicitante do relatório, com campos como `Cpf`, `Nome` e um relacionamento com os relatórios.
   * **Relatorio**: Representa um relatório sobre arboviroses, contendo informações como `Arbovirose`, `CodigoIbge`, `SemanaInicio`, `SemanaFim`, entre outros.

### Funcionalidades Implementadas:

* **Cadastro de Solicitante**: Permite registrar dados de solicitantes, incluindo o nome e o CPF.
* **Cadastro de Relatório**: Relacionado a um solicitante, é possível criar relatórios com informações sobre arboviroses, como a cidade (via código IBGE), o período de semanas e a arbovirose.
* **Consultas de Relatórios**:

  * **Por Código IBGE**: Filtra os relatórios com base no código IBGE de uma cidade.
  * **Totais por Arbovirose**: Obtém os totais de relatórios por tipo de arbovirose.
  * **Todos os Relatórios**: Lista todos os relatórios cadastrados no banco de dados.

Além disso, foi implementado o suporte à autenticação e ao uso de **Swagger** para documentar a API, facilitando testes e visualização dos endpoints.

### Como Usar Migrations para Gerar o Banco de Dados

Quando for necessário gerar o banco de dados ou atualizar a estrutura de dados (como após modificações nos modelos de dados), você deve usar o **EF Core Migrations** para realizar o processo de criação ou atualização do banco de dados. Aqui está um passo a passo de como usar **migrations** para gerar um banco de dados novo ou aplicar alterações no banco de dados existente:

#### Passos para Criar a Primeira Migration (Banco de Dados Novo)

1. **Verifique a Conexão com o Banco de Dados**:
   No arquivo `appsettings.json`, verifique se a string de conexão do banco de dados está configurada corretamente. Exemplo:

   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "Server=localhost;Database=InfodengueDB;Trusted_Connection=True;TrustServerCertificate=True;"
       }
   }
   ```

   Isso deve ser configurado corretamente para o banco de dados que você está utilizando (SQL Server, por exemplo).

2. **Abra o Package Manager Console**:
   No Visual Studio, vá em **Tools > NuGet Package Manager > Package Manager Console**.

3. **Adicionar a Migration**:
   No **Package Manager Console**, execute o comando para criar uma nova migration, que criará os scripts para o banco de dados com base nas entidades definidas:

   ```bash
   Add-Migration InitialCreate -Project Infodengue.Infrastructure -StartupProject Infodengue.API
   ```

   Onde:

   * `InitialCreate` é o nome da migration.
   * `-Project Infodengue.Infrastructure` indica o projeto onde o DbContext (a camada de acesso ao banco) está localizado.
   * `-StartupProject Infodengue.API` indica o projeto que é responsável pela execução da aplicação (o projeto que contém a configuração da API).

   Após rodar o comando, o EF Core criará a migration no diretório `Migrations` dentro do seu projeto de infraestrutura.

4. **Aplicar a Migration (Criar o Banco de Dados)**:
   Para aplicar a migration e criar o banco de dados no SQL Server (ou outro banco de dados configurado), execute o seguinte comando no **Package Manager Console**:

   ```bash
   Update-Database -Project Infodengue.Infrastructure -StartupProject Infodengue.API
   ```

   Esse comando aplica a migration e cria as tabelas do banco de dados conforme definidas nas entidades do seu código.

#### Passos para Atualizar o Banco de Dados com Novas Migrations

1. **Adicionar uma Nova Migration**:
   Quando você fizer alterações nos seus modelos (como adicionar novos campos ou modificar a estrutura de uma tabela), você pode gerar uma nova migration com o comando:

   ```bash
   Add-Migration NomeDaAlteracao -Project Infodengue.Infrastructure -StartupProject Infodengue.API
   ```

2. **Aplicar a Nova Migration**:
   Após gerar a migration, aplique-a ao banco de dados com o comando:

   ```bash
   Update-Database -Project Infodengue.Infrastructure -StartupProject Infodengue.API
   ```

   Isso atualizará o banco de dados com as mudanças feitas nas entidades.

### Considerações Finais

* **Backup do Banco de Dados**: Sempre faça backups do banco de dados antes de aplicar migrações, especialmente em ambientes de produção.
* **Ambientes de Teste**: Utilize um banco de dados de teste ao fazer alterações durante o desenvolvimento para evitar perder dados importantes.
* **Execução de Migrations em Produção**: Evite rodar migrations diretamente em produção sem um processo adequado de revisão de alterações e testes em ambientes controlados.

Com isso, você pode garantir que o banco de dados esteja sempre atualizado com a estrutura do modelo de dados da sua aplicação.
