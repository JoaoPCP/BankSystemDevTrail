🏦 BankDevTrail — Sistema de Banco Digital
📝 Breve descrição da aplicação

BankDevTrail é um sistema de simulação de banco digital desenvolvido em .NET com foco em Programação Orientada a Objetos e boas práticas arquiteturais.
A aplicação permite gerenciar Clientes, Contas e Transações, garantindo integridade, histórico imutável e operações financeiras seguras.

O sistema implementa funcionalidades essenciais de um banco digital, incluindo abertura de contas, depósitos, saques, transferências atômicas e consulta detalhada de extratos. Toda operação financeira gera uma transação no Ledger, garantindo auditoria completa.

🚀 Como rodar o projeto
1. Subir serviços com Docker Compose

docker compose up -d

2. Restaurar os pacotes do .NET
dotnet restore

3. Buildar a aplicação
dotnet build

4. Rodar a aplicação
dotnet run


A API será iniciada e a documentação estará disponível via Swagger.

📦 Funcionalidades Principais
👤 Cliente

Cadastro de cliente 

Consulta de contas de um cliente

🧾 Contas

Abertura de conta

Suporte a diferentes tipos de conta

💸 Transações

Todas as operações geram transações imutáveis no Ledger

Depósito

Saque 

Transferência 

📊 Consulta de Dados

Extrato completo de uma conta.

Histórico de transações 
