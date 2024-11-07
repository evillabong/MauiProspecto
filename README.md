# Consideraciones 

1. Crear la base de datos MauiProspecto
2. Ejecutar script para la creación de base de datos /Scripts/Database.sql
3. Configurar en proyecto WebApi cadena de conexión de la base de datos en appsettings.json la clave ConnectionStrings:SqlServerConnectionString
4. Configurar en MauiProgram la URL del api en el servicio ApiService
5. De requerir copiar y ejecutar el comando /Scripts/Scaffold.txt en la consola de paquetes nuget para reestructurar la DB siempre y cuando haya cambiado la estructura de la DB y cambiar la cadena de conexión 


# Notas:
1. Para la ejecución en maguina virtual se debe establecer como proyecto de inicio MauiProspecto y WebApi
2. Para la ejecución en emulador Android es necesario publicar el WebApi en un servidor web de preferencia puede ser IIS LOCAL y apuntar el URL según el paso 3. CONSIDERACIONES
