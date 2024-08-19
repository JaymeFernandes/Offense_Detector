# Detector de Ofensas 🔍

¡Bienvenido al **Detector de Ofensas**! Nuestra API es la herramienta perfecta para identificar lenguaje ofensivo en textos. Utilizamos algoritmos de similitud de cadenas para analizar y marcar palabras que pueden considerarse ofensivas.

**¿Quieres saber cómo funciona todo esto?** [¡Descúbrelo aquí!](Algorithm/README_es.md)

<br>

# Elige el Idioma 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README_es.md">Español</a></td>
  </tr>
</table>

<br>

# Mejora de Desempeño ⚡️

¡Estamos emocionados de compartir una gran mejora en el rendimiento de nuestra API! Antes, tardábamos 20 segundos en analizar 32.681 caracteres. Ahora, ¡completamos la misma tarea en solo 2 segundos! 🚀

Esto fue posible gracias al uso de iteraciones en paralelo con `Parallel.ForEach`. ¿La magia? Dividimos la tarea entre los procesadores, permitiendo que cada núcleo trabaje al mismo tiempo. ¡El resultado es un rendimiento mucho más ágil!

<br>

# Funcionalidade 🚀
- **Extremadamente sensible a ofensas, incluso con caracteres sustituidos:**
  ```
    V4c@ = vaca
    t4r4d0 = tarado
    |!x0 = basura
  ```

<br>

# Instalación 💻

Para comenzar a usar la API, sigue estos pasos:

1. **Restaura los paquetes de dependencia:**
   ```bash
   dotnet restore ./src/Offense_Detector.Api/Offense_Detector.Api.csproj
   dotnet restore ./src/Offense_Detector.Domain/Offense_Detector.Domain.csproj
   ```

2. **Configura el archivo `appsettings.Development.json` o `appsettings.json`:**
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

3. **Inicia el Proyecto:**
   ```bash
   cd src/Offense_Detector.Api/
   dotnet run
   ```

<br>

# Contribuyendo 🤝

Si encuentras un problema o tienes una idea para mejorar el proyecto, ¡nos encantaría recibir tus aportes! No dudes en abrir un issue o enviar un pull request. ¡Tu ayuda siempre es bienvenida!

<br>

# Licencia 📝

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE). ¡Siéntete libre de usarlo y adaptarlo según tus necesidades!
