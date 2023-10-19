O repositório a seguir foi utilizado para o seguinte desafio:

Criação da API:
1. Desenvolver uma API com .NET (preferencialmente .NET 6).
2. Utilizar o Entity Framework como ORM (Object-Relational Mapping) para lidar com o banco de dados.
3. Preferencialmente, utilizar o PostgreSQL como banco de dados.

Entidades Boleto e Banco:

1. Criar a entidade "Boleto" com as seguintes propriedades obrigatórias:
  - Id
  - Nome do Pagador
  - CPF/CNPJ do Pagador
  - Nome do Beneficiário
  - CPF/CNPJ do Beneficiário
  - Valor
  - Data de Vencimento
  - Observação
  - BancoId (o Id do Banco será usado como referência)

2. Criar a entidade "Banco" com as seguintes propriedades obrigatórias:
  - Id
  - Nome do Banco
  - Código do Banco
  - Percentual de Juros

Endpoints da API:

1. Implementar dois endpoints para a entidade "Banco":
  - Um para buscar todos os registros de bancos.
  - Outro para buscar um único registro de banco passando o código do banco como filtro.
    
2. Implementar um endpoint para buscar um boleto pelo seu Id.

3. Se o boleto estiver sendo buscado após a data de vencimento, calcular o valor do boleto com os juros do banco em questão. O cálculo não precisa ser por dias, apenas o juro total após o vencimento.

Validações:

1. Implementar validações para garantir que os campos obrigatórios sejam preenchidos corretamente.

Outros Pontos de Interesse:

1. Se desejar, criar autenticação com token.
2. Utilizar Data Transfer Objects (DTOs) para mapear os dados da API.
3. Utilizar a biblioteca AutoMapper para mapear entre entidades e DTOs.
4. Organizar o código em camadas para manter uma estrutura limpa e organizada.
