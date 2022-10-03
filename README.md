# TestIntComex
Las siguientes indicaciones son ayudas en caso de que se presente algun error con la base de datos a la hora de ejecutar el proyecto.

1. La base de datos utilizada es una LocalDB creada para la presentación del test. Si va a usar una local DB favor seguir los siquientes pasos. <br>
  1.1. Vaya a su CMD y digite "sqllocaldb info": esto debera darle el nombre de la intancia localdb.<br>
  1.2. Ejecute el comando "SqlLocalDB.exe info MSSQLLocalDB" y el CMD le mostrata los datos de us LocalDB. <br>
  1.3. En caso de que con el comando le salga "The automatic instance "MSSQLLocalDB" is not created". Debera ejecutar el comando "SqlLocalDB.exe start MSSQLLocalDB"<br>
  1.4 Ejecute el comando "SqlLocalDB.exe info MSSQLLocalDB" nuevamente y tome el dato "Intance pipeline name" <br>
  1.5 Cambie el valor del punto anterior en el archivo appsettings.json de la aplicacion en el valor "DefaultConnection" en la pripiedad server.<br>

2. Si no desea relaizar todos los pasos del punto 1, tome una intancia de base de datos SQL server y Cambie el valor del punto anterior en el archivo appsettings.json 
de la aplicacion en el valor "DefaultConnection" en la pripiedad server.<br>

3. En esta aplicación se uso EF Code First, y tiene las migraciones activas, pero no automaticas, para generar la base de datos debe usar el comando "Update-database" en
el tablero de comandos de Visual Studio.<br>
Nota: En caso de que no funcione el comando dicho, primero ejecute "Add-Migrations" y luego  "Update-database".



