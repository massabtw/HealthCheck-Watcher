# Fiscal de monitoramento de sistemas

Um projeto simples e funcional, que a cada dois minutos faz o checkup no sistema para detectar erros.

## 🛠️ Tecnologias Utilizadas
* C#
* ASP.NET
* Azure Functions (Timer Trigger)

## 🏗️ Arquitetura do Projeto

O projeto foi estruturado seguindo boas práticas de divisão de responsabilidades:

### 1. Monitoramento.Core
Módulo central que guarda as regras de negócio e definições globais do sistema.
* **Interfaces (`IHealthChecker`):** Onde criamos o contrato que define as regras obrigatórias que todo fiscal de equipamento deve seguir.
* **Models (`SystemStatus`):** Onde definimos a estrutura do relatório, ou seja, como queremos que as informações de análise (Nome do sistema, Status Online e Mensagem de Erro) sejam entregues.

### 2. Monitoramento.Infrastructure
Módulo responsável pela comunicação externa e integrações (localizado na pasta `APIs`).
* **`PdvHealthChecker`:** Responsável pela fiscalização do Ponto de Venda (Caixa). O PDV é o coração operacional do sistema; se ele falhar, a empresa enfrenta problemas críticos, como a interrupção da invasão de notas fiscais e paralisação do balcão.
* **`TotemHealthChecker`:** Responsável pela fiscalização do Totem de autoatendimento que fica no salão. Se o totem falhar, a operação perde vazão de pedidos, gerando insatisfação e perda imediata de faturamento.

## 🚀 Como Executar e Testar

Para colocar o fiscal para rodar e visualizar os comportamentos de sucesso e falha, siga os passos abaixo:

1. Abra a solução no seu ambiente de desenvolvimento (**Visual Studio** ou **VS Code**).
2. Defina o projeto `Monitoramento.Functions` como o projeto de inicialização.
3. Execute o projeto (pressionando `F5` ou rodando `dotnet run` no terminal).

### 🧪 Cenários de Teste Configurados
O projeto já vem preparado com duas URLs distintas para simular a realidade de uma operação:
* **Totem Autoatendimento:** Configurado com a URL do Google para simular a **normalidade do sistema** (Retorno esperado: `True`).
* **Sistema PDV (Caixa):** Configurado com uma URL de teste de erro para simular uma **queda de rede ou falha crítica** (Retorno esperado: `False` + Mensagem de erro capturada pelo `catch`).

### 🖥️ O que esperar no Terminal
A cada dois minutos, a Azure Function será disparada de forma autônoma. O que você verá na tela preta do console é o resultado bruto que o método `GetAsync` puxa da rede, exibindo de forma clara se o equipamento está online ou se deu erro, centralizado nas linhas de log customizadas.

## 🧠 Por que escolhi essa Arquitetura?

A decisão de separar o projeto nessas camadas não foi por acaso. O foco aqui foi criar um código **limpo, escalável e blindado contra falhas**:

* **Escalabilidade (Injeção de Dependência):** Graças à interface `IHealthChecker`, o sistema é altamente flexível. Se amanhã a operação adicionar uma nova máquina na rede (como um painel KDS na cozinha), basta criar um novo arquivo para ela. O motor central do sistema testará o novo equipamento automaticamente, sem necessidade de alterar o código principal.
* **O conceito do "Termômetro Padrão":** O software interno de um PDV é infinitamente mais complexo do que o de um Totem, lidando com notas fiscais e gavetas de dinheiro. Porém, para fins de monitoramento, isolamos essa complexidade. O código atua apenas como um "termômetro", tratando as máquinas da mesma forma e testando apenas a conectividade de rede de maneira padronizada e leve.
* **Isolamento de Falhas:** Como cada máquina possui seu próprio "fiscal" (um arquivo dedicado em `Infrastructure`), a manutenção se torna cirúrgica. Se a infraestrutura mudar a rota de rede apenas do PDV, eu ajusto exclusivamente o arquivo `PdvHealthChecker`. O monitoramento do Totem continua seguro, intacto e rodando sem interrupções.