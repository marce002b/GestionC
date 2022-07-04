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

# RESOLUCION INSTRUCCIONES BASICAS

En VS2022 se crea un proyecto tipo ASP NET CORE WEB API. Usara .NET 6.0 y DI con swagger para probar la API. Creamos una carpeta MODELOS donde iran nuestras clases basicas usuario y festivos. 



 public class Usuario
    {
    public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    
    
     public class Festivos
    {
        public string date { get; set; }
        public string localName { get; set; }
        public string name { get; set; }
        public string countryCode { get; set; }
        public bool @fixed { get; set; }
        //public bool global { get; set; }
        //public object counties { get; set; }
        //public int? launchYear { get; set; }
        //public List<string> types { get; set; }
    }
Dentro del IDE de VS podemos:

CREAR Database: ChallengeGC

script creacion tabla USUARIO: Usuarios.sql

script de llenado datos: dbo.Usuario.data.sql

finalmente nos queda en appsettings.json un ConString: "Server=(localdb)\\mssqllocaldb;Database=ChallengeGC;Trusted_Connection=True;MultipleActiveResultSets=true"

Creamos una clase Usuario.cs que nos represente cada entidad con Id , Nombre , etc

1) Agregamos un CONTROLLER API UsuariosController usando EFramework con CRUD, llamado UsuariosController que nos permitira generar las operaciones (rutas y metodos del controlador sobre la tabla dicha.) simplemente elegimos la clase origen que es usuario de nuestro modelo, el context que lo agregamos autonombrado y el nombre del controller. ya tendremos  las acciones get put post delete que soportan las operaciones CRUD, especificando parametro cuando requiera y tb un bool para saber si el usuario existe:

Usuarios


GET
​/api​/Usuarios

POST
​/api​/Usuarios

GET
​/api​/Usuarios​/{id}

PUT
​/api​/Usuarios​/{id}

DELETE
​/api​/Usuarios​/{id}


2) ENDPOINT FESTIVOS API MINIMAL  sin derivar de ControllerBase

Se crea una clase llamada Festivos con los datos provenientes del json de respuesta de la url provista. no se usara la clase completa sino 5 campos. se procede a anteponer @ ya q un campo se llama fixed palabra reservada. esta clase se usara para deserealizar los json de las respuestas GET del httpClient en una lista de festivos . 

se usa el metodo get del HttpMethod pq es un ejemplo de api minima sin :ControllerBase

En un primer controller FestivosEndpointsClass usamos API minimal para devolver los festivos por codigo de pais, solo para los permitidos  "AR", "CO", "CL" filtrados en una expresion lambda.

2) ENDPOINT FESTIVOS API NORMAL con controller 

En un segundo  controller  Festivos2Controller.cs con inyeccion de dependencias: patron q permite registrar clases en un container que inyectara las dependencias y no usara instancias dentro de la clase ademas permitiremos devolver un unautorized: Se mostrara un 401 no autorizado cuando no sea el pais adecuado, ej BR , para lo cual se simpplifica devolviendo return Unauthorized();

aqui debemos crear una Interface IServicioFestivos que nos obliga a implementar en la clase el metodo como hilo de ejecucion task  BuscarDataFestivosAPIExterna , este es el que verdaderamente llamara a la api externa con el codigo de pais elegido como parametro y deserealizara en una lista de festivos...
la registracion se hizo en program.cs mediante
builder.Services.AddTransient<IServicioFestivos, ServicioFestivos>();

PARA USAR DI de Net 6.0: cuando se pida una instancia de IServicioFestivos se debe crear una instancia de ServicioFestivos 
 registramos el servicio por ej tipo transient en el container q es la IServicioFestivos , este tipo es transitorio y crea una instancia por cada invocacion al controlador y sus metodos.

















