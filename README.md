### Crear Base de Datos en SQL Server Express con nombre "DBPRUEBAS" para que coincida con el archivo connectionStrings dentro del Web.config

```		
<connectionStrings>
	<add name="DefaultConnection"
		connectionString="Data Source=localhost\SQLEXPRESS; Initial Catalog=DBPRUEBAS; Integrated Security=True"
		providerName="System.Data.SqlClient"/>	
</connectionStrings>
		
```

### En la consola del Administrador de Paquetes pon el comando "Update-Database" para crear la tabla de Employee