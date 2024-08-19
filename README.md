# Offense Detector 🔍

Welcome to the **Offense Detector**! Our API is the perfect tool for identifying offensive language in texts. We use string similarity algorithms to analyze and flag words that may be considered offensive.

**Curious about how it works?** [Find out here!](Algorithm/README.md)

<br>

# Choose Your Language 🌐

<table border=1>
  <tr>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README.md">English</a></td>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README_pt.md">Português</a></td>
    <td><a href="https://github.com/JaymeFernandes/Offense_Detector/blob/master/README_es.md">Español</a></td>
  </tr>
</table>

<br>

# Performance Improvement ⚡️

We’re excited to share a major performance improvement for our API! Previously, it took 20 seconds to analyze 32,681 characters. Now, it completes the same task in just 2 seconds! 🚀

This was made possible by using parallel iterations with `Parallel.ForEach`. The magic? We split the task across processors, allowing each core to work simultaneously. The result? A much faster performance!

<br>

# Feature 🚀
- **Highly sensitive to offenses, even with character substitutions:**
  ```
    V4c@ = cow
    t4r4d0 = idiot
    |!x0 = trash
  ```

<br>

# Installation 💻

To get started with the API, follow these steps:

1. **Restore the dependency packages:**
   ```bash
   dotnet restore ./src/Offense_Detector.Api/Offense_Detector.Api.csproj
   dotnet restore ./src/Offense_Detector.Domain/Offense_Detector.Domain.csproj
   ```

2. **Configure the `appsettings.Development.json` or `appsettings.json` file:**
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

3. **Start the Project:**
   ```bash
   cd src/Offense_Detector.Api/
   dotnet run
   ```

<br>

# Contributing 🤝

If you encounter any issues or have suggestions for improvements, we’d love to hear from you! Feel free to open an issue or submit a pull request. Contributions are always welcome!

<br>

# License 📝

This project is licensed under the [MIT License](LICENSE). Feel free to use and adapt it to suit your needs!
