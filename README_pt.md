# Detector de Ofensas 🔍

Bem-vindo ao **Detector de Ofensas**! Nossa API é a ferramenta perfeita para identificar linguagem ofensiva em textos. Usamos algoritmos de similaridade de strings para analisar e flagrar palavras que podem ser consideradas ofensivas.

**Quer saber como tudo isso funciona?** [Descubra aqui!](Algorithm/README_pt.md)

<br>

# Escolha o Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README_es.md">Español</a></td>
  </tr>
</table>

<br>

# Melhoria de Desempenho ⚡️

Estamos empolgados em compartilhar uma grande melhoria no desempenho da nossa API! Antes, levávamos 20 segundos para analisar 32.681 caracteres. Agora, concluímos a mesma tarefa em apenas 2 segundos! 🚀

Isso foi possível graças ao uso de iterações em paralelo com `Parallel.ForEach`. A mágica? Dividimos a tarefa entre os processadores, permitindo que cada núcleo trabalhe ao mesmo tempo. O resultado é um desempenho muito mais ágil!

<br>

# Funcionalidade 🚀
- **Extremamente sensível a ofensas, mesmo com caracteres trocados:**
  ```
    V4c@ = vaca
    t4r4d0 = tarado
    |!x0 = lixo
  ```

<br>

# Instalação 💻

Para começar a usar a API, siga estes passos:

1. **Restaure os pacotes de dependência:**
   ```bash
   dotnet restore ./src/Offense_Detector.Api/Offense_Detector.Api.csproj
   dotnet restore ./src/Offense_Detector.Domain/Offense_Detector.Domain.csproj
   ```

2. **Configure o arquivo `appsettings.Development.json` ou `appsettings.json`:**
   ```json
   {
     "ConnectionStrings": {
       "MySQLConnect": "Server=localhost;Database=Offense_Detector;Uid=root;Pwd=yourPassword;"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }
   ```

3. **Inicie o Projeto:**
   ```bash
   cd src/Offense_Detector.Api/
   dotnet run
   ```

<br>

# Contribuindo 🤝

Se você encontrou um bug ou tem uma ideia para melhorar o projeto, adoramos receber contribuições! Sinta-se à vontade para abrir uma issue ou enviar um pull request. Sua ajuda é sempre bem-vinda!

<br>

# Licença 📝

Este projeto está licenciado sob a [Licença MIT](LICENSE). Sinta-se à vontade para usá-lo e adaptá-lo conforme suas necessidades!
