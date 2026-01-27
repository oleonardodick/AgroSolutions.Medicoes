# Agro Solutions

## Worker de medição

Um Worker criado em Dot Net Core 8 responsável pela avaliação das medições realizadas pelos sensores dos talhões.

Através deste Worker, serão disparados e-mails para os produtores tomarem as providências necessárias de acordo com cada leitura realizada.

Este Worker não realiza as leituras, ele apenas recebe os dados lidos via fila RabbitMQ e realiza os tratamentos necessários.

## Indice

- [Download](#download)
- [Configuração](#configuracao)
- [Banco de dados](#banco-de-dados)
- [RabbitMQ](#rabbitmq)
- [Grafana](#grafana)
- [Como rodar o projeto?](#como-rodar-o-projeto)
  - [Via Docker Compose](#via-docker-compose)
  - [Via Kind](#via-kind)
- [Uso](#uso)
- [Testes](#testes)
- [Contribuição](#contribuição)

## Download

Primeiramente, deve ser realizado o download (clone) deste repositório do GitHub. Este clone pode ser realizado através do seguinte comando:

```bash
  git clone https://github.com/oleonardodick/AgroSolutions.Medicoes.git
```

## Configuração

Junto a este projeto, existe o arquivo **.env.example**. Este arquivo mostra quais variáveis de ambiente devem ser configuradas.

Para realizar a configuração, deve ser criado um arquivo **.env**, informando os valores das variáveis de ambiente. É extremamente importante que os nomes das variáveis sejam mantidos conforme o arquivo de exemplo.

## Banco de dados

Este projeto utiliza o PostgreSQL como banco de dados principal.

Esse projeto trabalha com Migrations para garantir o estado do banco de dados. É importante que, antes de rodar o projeto, o banco de dados esteja UP, aceitando conexões.

## Rabbit MQ

Para receber os cadastros de talhão, propriedades, proprietário e as medições, este projeto fica escutando uma fila do RabbitMQ.

Toda vez que uma mensagem for postada na fila, o projeto pegará esta mensagem, realizará os tratamentos necessários e adicionará no banco de dados, para que os dashboards possam consumir esses dados.

## Grafana

Os dashboards disponbilizados por esta aplicação serão acessados e visualizados pelo Grafana. Esses dashboards serão automaticamente disponibilizados ao rodar o container, sem a necessidade de criar eles manualmente.

## Como rodar o projeto?

### Via Docker Compose

Foi disponibilizado neste repositório um arquivo docker-compose.yml para que seja possível rodar a aplicação, já apontando para as variáveis de ambiente e imagens necessárias.

Após configurar o .env, pode ser rodado o seguinte comando na raiz do projeto:

```bash
docker compose up -d
```
**Importante**
É necessário que a imagem da aplicação já esteja criada para rodar este comando docker compose. Para criar a imagem, basta rodar um docker build.

```bash
docker build -t agro-solutions-medicoes:latest . 
```

### Via Kind

Kind é uma ferramenta que permite rodar kubernetes através de containers docker. Para realizar a instalação, basta seguir o guia de instalação disponível no site da ferramenta: [Kind instalation](https://kind.sigs.k8s.io/docs/user/quick-start/#installation)

Também é necessário realizar a instalação do kubernetes. Para isso, basta seguir o guia disponível no site oficial: [Kubernetes instalation](https://kubernetes.io/docs/tasks/tools/).

Com todas as ferramentas instaladas, basta rodar o script de deploy disponibilizado na pasta **./scripts/**.

Este script:
1. Cria o cluster Kubernetes com 1 Control plane e 1 worker. Esta configuração pode ser alterada através do arquivo de [configuracao](./k8s//kind/config.yaml).
2. Builda automaticamente a imagem da aplicação.
3. Envia esta imagem para o Kind, para que não seja necessário enviar para algum registry.
4. Cria o namespace da aplicação.
5. Cria os secrets da aplicação.
6. Cria o configmap da aplicação.
7. Cria os configmaps do grafana, para já configurar os datasources e dashboards.
8. Realiza o deploy do restante dos arquivos kubernetes através do comando kubectl apply.

Alternativamente este processo pode ser realizado manualmente, porém a sequencia citada acima deve ser respeitada para o correto deploy.

**Importante**
Será necessário adicionar permissão para rodar os scripts, para isso, devem ser executados os comandos:

```bash
chmod +x scripts/create-secrets.sh

chmod +x scripts/deploy-configmap.sh   

chmod +x scripts/dev-deploy.sh   
```

## Logs

Esta aplicação utiliza o Serilog para gerar os logs. Sua configuração está dentro do proprio projeto, no arquivo program.cs.

## Uso

Por se tratar de um Worker App, esta aplicação rodará automaticamente, sem a necessidade de executar nenhum outro comando.

Também não será disponibilizado nenhum endpoint para uso.

## Testes

Ao clonar o repositório desta API, dois projetos de testes serão baixados também. Nestes projetos ficarão todos os testes automatizados da aplicação, que poderão ser configurados para executar em uma pipeline.

## Contribuição

Este projeto foi desenvolvido por
- [Leonardo Dick Bernardes](http://github.com/oleonardodick)
