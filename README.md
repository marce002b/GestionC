# GestionC

Challenge Técnico - Gestión Compartida

Para llevar el control actualizado de todos los días festivos por país, del año 2022; se necesita
construir una aplicación REST Web API que exponga los siguientes “EndPoints”:
➢ Un “EndPoint” llamado “festivos” que sea llamado con el código del país cómo
parámetro. Ejemplo: https://localhost:8081/MyRestWebAPI/festivos/CODIGOPAIS
donde “CODIGOPAIS” puede ser “AR”, “MX”, “CO”, “CL” y “BR”.
o Para los parámetros “MX” y “BR”, hacer que el “EndPoint” de una respuesta
http: 401 unauthorized.
o Para los parámetros “AR”, “CO” y “CL”, el “EndPoint” deberá consumir la
información de los festivos del país desde el servicio externo:
https://date.nager.at/api/v3/PublicHolidays/2022/AR
o Este “EndPoint” deberá devolver el objeto como se obtiene del servicio
externo, pero solo incluir los campos: “date”, “localName”, “name”,
“countryCode” y “fixed”.

➢ Un segundo “EndPoint” denominado “usuarios” que devuelva todos los usuarios de
una tabla “Usuario” que contenga los siguientes campos: Id, Nombre, Apellido, Email
y Password. Crear la Base de Datos, la tabla y llenarla de datos con un Script.
➢ Crear además los “EndPoint” necesarios para realizar el ABM de Usuarios.
Utilizar para la confección de esta aplicación .Net Framework 4.8 o .Net Core 3.1 en adelante.
Bonus Points:
❖ Usar código limpio y ordenado; así como separación de responsabilidades.
❖ Uso de patrones de diseño y explicación del uso de los mismos.
❖ Creación de Unit Tests.
Notas:
❖ Proveer el código fuente subiendo la solución a un repositorio de Github, Gitlab u otro.
❖ Proveer el Script para generar la Base de Datos y “popularla” con datos de prueba.
❖ Proveer las instrucciones necesarias para la ejecución de la aplicación.


Database: ChallengeGC

ConString: "Server=(localdb)\\mssqllocaldb;Database=ChallengeGC;Trusted_Connection=True;MultipleActiveResultSets=true"

script creacion: Usuarios.sql

script de llenado datos: dbo.Usuario.data.sql





