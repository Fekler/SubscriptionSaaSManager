# SubscriptionSaaSManager

**SubscriptionSaaSManager** é uma API para gerenciamento de assinaturas e controle multi-tenant, construída com foco em escalabilidade, segurança e modularidade.
Este projeto está atualmente publicado em uma VM Oracle ARM64 utilizando NGINX como proxy reverso com SSL configurado.
Acesse a API publicada: [SaaS Manager API](https://saasmanager.fekler.tec.br/swagger/index.html)


## Tecnologias Utilizadas
- **.NET 8**
- **Entity Framework Core**
- **JWT Authentication**
- **Docker** (com suporte multiplataforma)
- **GitHub Actions** (para CI/CD)
- **DotNetEnv** (para variáveis de ambiente)
- **xUnit** (para TDD)
- **NGINX** (proxy reverso com SSL)
- **Oracle Cloud**
- **PostgresSQL**

## Padrões e Princípios Adotados
- Clean Architecture com organização modular baseada em camadas.
- Repository Pattern para abstração de acesso aos dados.
- Princípios SOLID, garantindo manutenibilidade e modularidade.
- N-Tier Layer Architecture, com camadas independentes de responsabilidades bem definidas.

## Arquitetura do Projeto
O projeto adota a **Clean Architecture** com a seguinte divisão de camadas:
1. **API**: Exposição de endpoints RESTful.
2. **Application**: Lógica de negócios.
3. **Domain**: Entidades e regras de domínio.
4. **InfraData**: Comunicação com o banco de dados e repositórios.
5. **IOC**: Configuração de injeção de dependências.
6. **Common**: Utilitários e classes compartilhadas.
7. **Test**: Testes unitários usando xUnit.


### Benefícios da Clean Architecture
- **Manutenibilidade**: Facilita alterações no sistema sem impacto significativo nas demais camadas.
- **Testabilidade**: Isola o núcleo do domínio para facilitar a escrita de testes unitários.
- **Escalabilidade**: Modularidade permite expandir funcionalidades de forma controlada.
- **Independência**: O domínio não depende de frameworks, bancos de dados ou tecnologias externas.
  
## Configuração e Execução
### Requisitos
- .NET 8 SDK
- Docker (opcional para execução via contêiner)
- SQL Server

### Executando o Projeto
1. Clone o repositório:
   ```git clone https://github.com/Fekler/SubscriptionSaaSManager.git ```
2. Instale as dependências e configure o ambiente:
Defina as variáveis de ambiente no arquivo .env:
```ConnectionStrings__DefaultConnection=<sua-string-de-conexao>```
``` TOKEN_JWT_SECRET=<seu-segredo-jwt> ```
3. Execute as migrações para configurar o banco de dados:
```dotnet ef database update --project SubscriptionSaaSManager.InfraData```
4. Inicie a aplicação:
```dotnet run --project SubscriptionSaaSManager.API```

## Executando com Docker
1. Construa a imagem:
```docker build -t subscriptionsaasmanager .```
2. Execute o contêiner:
```docker run -d -p 5000:80 --env-file .env subscriptionsaasmanager```
## Contribuição
Contribuições são bem-vindas! Faça um fork do repositório, crie um branch para sua feature, e envie um pull request.

## Licença
Este projeto está licenciado sob a MIT License.
