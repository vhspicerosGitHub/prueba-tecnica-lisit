# Lisit prueba tecnica
API con .NET Core 6

## Base de datos
Se creo la base de datos con SqlLite para no tener que ejecutar la base de datos en un contedor con docker y para que facilidad en la revision. 

* El Archivo de base de datos y el script de creacion se encuentran al interior de la carpeta "Database"

* A continuacion se muestra el modelo de base de datos

![alt text](https://github.com/vhspicerosGitHub/prueba-tecnica-lisit/blob/main/docs/Database%20Model.png?raw=true)

## Dependencias Generales

* **Sqlite**: Conector para SqlLite.
* **Dapper**: Para el acceso a datos. 
* **SeriLog**: Para el Log de la aplicacion (Por configuracion un log diario).
* **JWT**: Para generacion de Token. 
* **Swaggger**: para autodocumentacion de la API (adicional con Xmldoc).
* **Nunit**: Pruebas unitarias. 
* **Moq**: Simulación de objeros. 


## Como usar
### Instalacion
```
git clone https://github.com/vhspicerosGitHub/net-core-demo-api.git
```

### Compilar
```
dotnet build
```

### Correr los test
```
dotnet test
```

### Ejecutar el proyecto
```
 dotnet run --project  .\Lisit.Api\Lisit.Api.csproj
```