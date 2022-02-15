# project-perfiltic.com
.NET Core

# Pasos para ejecutar la API
La api esta desarrollada con .NET Core 5 y para ser usada en SQL Server, en el siguiente manual explicaré como utilizar la api

1. Primero se debe ajustar el string de conexión ubicado en el archivo appsettings.json para en la seccion ConnectionStrings, en mi caso utilice una conexion con autenticación de windows usando sql server, sin embargo esta instalado el paque de pgsql para adaptar el string de conexión
2. Se debe ejecutar la migración a la base de datos por las entidades que existen en el proyecto según la logica presentada, a continuación los siguientes comandos a ejecutarse
2.1 -> add-migration my-migration
2.2 -> update-database

3. Una ves ejecutado los comandos anteriores y cargada la base de datos, se procede a hacer el llenado de la tabla user de manera manual para efectos de prueba, sin embargo cuenta con un metodo post para hacer el registro del usaurio en cuestion
4. todos los metodos deben llevar autenticación generada 
