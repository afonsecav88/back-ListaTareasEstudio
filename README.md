# Backend app de CRUD tareas (Api de Asp.net Core)

## Api de Asp.net Core, con los endpoints para hacer CRUD de tareas

### Módulo de Crud de tareas
- Crear un tareas.
- Modificar un tarea.
- Listar tareas.
- Eliminar tareas.

### Nota: esta api usa base de datos mssqlserver. 

1. Dependencias a instalar:  
```dotnet add package Microsoft.EntityFrameworkCore.SqlServer``` , 
```dotnet add package Microsoft.EntityFrameworkCore.Design```

2. Intalar tools entity framework: ```dotnet tool install --global dotnet-ef```

3. Crear una migracion de la BD: ```dotnet ef migrations add InitialCreate```

4. Actualizar Base de Datos: ```dotnet ef database update```

5. .Levantar un contenedor de docker con mssqlserver user este comando:
```docker run -v BackendTareas:/var/opt/mssql/data -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=PasswordDBAqui" -u 0:0 -p 3306:1433 -d mcr.microsoft.com/mssql/server:2019-latest```

6. Para levantar el server de desarrollo ```dotnet run```  
