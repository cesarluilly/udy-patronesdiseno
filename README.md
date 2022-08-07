# udy-patronesdiseno-console

Aplicacion de consola realizadas por el curso Patrones de diseño en C# Aplicados en ASP .Net

https://www.udemy.com/course/aprender-patrones-de-disenos-aplicados-en-asp-net/

![curso](./imgReadme/curso.jpg)

## Preparando el Ambiente
- Creamos un proyecto de **consola**
- Creamos un proyecto en la misma solucion de **ASP.NET Core Web 
App (Model-View-Controller)**
- Creamos proyecto en la misma solucion de **Library Class**

Namas como introduccion. 

* Un controlador es el que recibe la solicitu de un cliente, 
la trata, la maneja junto con el modelo y si es necesario 
regresar una vista siendo la vista contenido HTML, va
a regresar una vista.

* Y la herramienta de biblioteca nos sirve para tener mis
herramientas separadas y pueda utilizarla en otros proyectos 
sin tener que volverlos a programar.


# Seccion 6: Repository

## 11. Entity Framework

Aqui vamos a hacer uso de ORM de Entity Framework, y el ORM
es basicamente el Mapeo de una base de datos para que puedas
utilizarla con programacion orientada a Objetos.

- Ahora vamos a crear una la siguiente base de
datos

```sql
CREATE DATABASE DesignPattern;
USE DesignPattern;


CREATE TABLE Beer
(
    Pk int IDENTITY (1, 1) not null,
    CONSTRAINT Pk_Beer PRIMARY KEY (Pk),
    
    Name NVARCHAR(50) NOT NULL,
    Style NVARCHAR(50) NOT NULL
);
GO

insert into Beer (Name, Style) values ('Corona', 'Blanca')
insert into Beer (Name, Style) values ('Minerva', 'Negra')

```

- Vamos a agregar Paquetes Nuggets
![nugget](./imgReadme/nugget.jpg)

Instalamos los siguientes paquetes

    - > Microsoft.EntityFrameworkCore.SqlServer
    - > Microsoft.EntityFrameworkCore.Tools

Ahora abrimos una consola de Paqutetes Nugget y ejecutamos el
siguiente comando

`Scaffold-DbContext "Server=DESKTOP-ANEEUI8;Database=DesignPattern;User=DBUser;Password=DBUser2019" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`

![scafold](./imgReadme/scafold.jpg)


Agregamos el codigo y corremos

![run1](./imgReadme/run1.jpg)

## 12 Explicacion 

Imaginemos que tenemos que tenemos diferentes fuentes de datos
tal como Dapper, EntityFramework o un Api, entonces el 
patro repository es un intermediario para esta informacion.

Lo que hace el patron Repository es darte una manera de que 
accedas a esos datos sin que la aplicacion se preocupe de que 
es lo que esta pasando en repository, y este es un 
patron de diseño escructural.

Y esto es con la finalidad de que la aplicacion no tiene que 
enterarse si cuando vas por la tabla usuario vas a un API o 
cuando vas por cerveza vas a entity framework, entonces 
por lo tanto para la aplicacion tiene que ser invisible, 
entonces lo unico que debe de hacer la aplicacion es invocar
un metodo sin importarle que es lo que esta pasando por detras.


![dfRepository](./imgReadme/dfRepository.jpg)

### Por ahorita vamos a hacer una implementacion sencilla y despues la volvermos mas compleja.

- Agregamos la interface con los contratos dados y la clase repository

![ibeer](./imgReadme/InclRepository.jpg)

Hacemos uso del repositorio y corremos la aplicacion

![video12corrida](./imgReadme/video12corrida.jpg)

## 13 Repository con Generics

Ahora agregaos una nueva tabla 

```sql

USE DesignPattern;

CREATE TABLE Brand
(
    Pk int IDENTITY (1, 1) not null,
    CONSTRAINT Pk_Brand PRIMARY KEY (Pk),
    
    Name NVARCHAR(50) NOT NULL,
);
GO
```

Ahora vamos a generar nuestro modelo a traves de scafold abriendo
una consola de nugget y tecleando el siguiente comando

> `Scaffold-DbContext "Server=DESKTOP-ANEEUI8;Database=DesignPattern;User=DBUser;Password=DBUser2019" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force`

Nota. Aqui al final agregamos **force** para que me agregue la 
el nuevo modelo de la nueva tabla.

Generic en este caso lo vamos a utilizar para que una clase se 
comporte igual para distintos fuentes de modelo.

Entonces las ventajas de utilizar un repositorio Generico es que
para cada nueva tabla no vamos a crear nueva interfaz, 
si no que con la clase generica nos ahorramos todo eso.

![irepogeneric](./imgReadme/irepogeneric.jpg)

Nota. Vamos a utilizar el potencial de DbSet ya que esto te 
permite convertir esas tablas en clases para poder trabajar
con programacion orientada a objetos. DbSet

- Creamos nuestra clase Repository

![video13RepositoryClass](./imgReadme/video13RepositoryClass.jpg)

- Agregamos codigo de corrida 
![video13CodigoProgram](./imgReadme/video13CodigoProgram.jpg)

- Corrida
![video13Corrida](./imgReadme/video13Corrida.jpg)

## Video 14 Implementacion en ASP

Creamos proyecto de bibliotecas de clases en la misma solucion y
eliminamos la clase por defecto que crea.

![video14LibraryClass](./imgReadme/video14LibraryClass.jpg)

> - DesignPatterns.Models

Agregamos las dependecias nugget a la biblioteca de Clases

Instalamos los siguientes paquetes

    - > Microsoft.EntityFrameworkCore.SqlServer
    - > Microsoft.EntityFrameworkCore.Tools

![video14nugget](./imgReadme/video14nugget.jpg)

Creamos proyectos de bibliotecas de clases en la misma solucion y
eliminamos la clase por defecto que crea.

> - DesignPatterns.Repository

Ahora vamos a establecer el Startup Project al **DesignPatterns.Models**

> **NOTA** Esto es importante ya que de lo contrario no podemos
hacer scafold

![video14startupProject](./imgReadme/video14startupProject.jpg)

Ahora abrimos una consola de Paqutetes Nugget y ejecutamos el
siguiente comando 

> **Asegurarnos que estamos en el proyecto DesignPatterns.Models**

`Scaffold-DbContext "Server=DESKTOP-ANEEUI8;Database=DesignPattern;User=DBUser;Password=DBUser2019" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data`

![video14Scafold](./imgReadme/video14Scafold.jpg)

Ahora vamos al proyecto de DesignPatterns.Repository y agregamos
referencias de proyecto de **DesignPatterns.Models**

![video14referenceProject](./imgReadme/video14referenceProject.jpg)

![video14AddRef](./imgReadme/video14AddRef.jpg)

Ahora en el proyecto DesignPatterns.Repository vamos a agregar 
la interfaz **IRepository** y la clase **Repository** 
y despues vamos a copiar el codigo que habiamos echo en el 
video anterior.


![video14ClassInterfaceRepository](./imgReadme/video14ClassInterfaceRepository.jpg)


Ahora lo que necesitamos es ver como implementarlo en el 
proyecto de DesignPatternsAsp

Agregamos las dependecias de proyecto a el proyecto de 
DesignPatternsAsp

![video14DependencesAsp](./imgReadme/video14DependencesAsp.jpg)

Ahora vamos a ir a Startup(Version .Net 5  o inferior) o a
Program.vs (caso de .Net 6 pero tambien podemos crear el 
Startup.cs y personalizarlo)

A continuacion vamos a ver los alcances de las inyecciones
de dependencia en .Net Core

* **services.AddScoped** .- Es a nivel de solicitud, es decir 
va a ser objetos diferentes por solicitud.

* **services.AddTransient** .- Solo es recomendable en funciones, 
es decir cuando se procesa algo y la funcion devuelve algo.

* **services.AddSingleton** .-  Se crean la primera vez que se solicitan (o cuando se ejecuta ConfigureServices si especifica una instancia allí) y luego cada solicitud posterior utilizará la misma instancia.

y para eso necesitamos agregar la cadena de coneccion al 
appsetting.json para despues hacer una inyeccion de 
dependencia.

![video14AppSettingsStringCon](./imgReadme/video14AppSettingsStringCon.jpg)

Agrego la inyeccion de dependecia en Program.cs ya que estamos
en .Net 6

![video14Inyeccion](./imgReadme/video14Inyeccion.jpg)

Agregamos codigo al contexto para devolver las beers.

![video14HomeController](./imgReadme/video14HomeController.jpg)

Nos vamos a la vista para agregar codigo y probar.
![video14ViewHome](./imgReadme/video14ViewHome.jpg)


# Seccion 7 UnitOfWork

## Video 15 Explicacion

Es una forma para trabajarse en conjunto.
Por ejemplo

En la siguiente imagen vemos que hay 2 save(), y eso representa
que se van a hacer 2 conecciones a la base de datos.

![video14Save](./imgReadme/video14Save.jpg)

Entonces lo que nos propone el patron UnitOfWork es que 
si tenemos un conjunto de peticiones a la base de datos, podemos 
agruparlas y mandarlas juntas.

Entonces por lo tanto este es un extra al patron repository.

![video15Df](./imgReadme/video15Df.jpg)

UnitOfWork tambien tiene un comportamiento similar a singleton, 
es decir, si el objeto ha sido solicitado en un esquema de 
trabajo, es decir se crea el objeto, pero si alguien vuelve
a solicitar ese objeto, entonces te devuelvo el objeto
que ya habia creado sin necesida de tener que recrearlo.

Lo que hacemos con UnitOfwork es agrupar los repositorios
en una parte, en un grupo y ese grupo va a trabajar como uno
cuando se trabaje con la solicitud de la DB.

La razon de esto, es que se tienen que aislar estas partes, 
porque no todos los programadores trabajan en el mismo proyecto, 
si no que a lo mejor la capa de modelo lo trabajan otro
grupo de programadores, y la capa de negocio la trabaja
otro grupo de programadores, y es por eso que las capas
deber ser invisibles ya que ninguna capa tiene que saber
de como esta escructurado y los detalles de la otra capa.

![video15InterClass](./imgReadme/video15InterClass.jpg)

Vamos a program y guardamos 2 elementos diferentes

![video15UnitOfWork](./imgReadme/video15UnitOfWork.jpg)


## Video 16 Implementacion en ASP

Creamos la siguiente DB

```sql
DROP database DesignPattern;

CREATE DATABASE DesignPattern;
USE DesignPattern;


CREATE TABLE Brand
(
    Pk int IDENTITY (1, 1) not null,
    CONSTRAINT Pk_Brand PRIMARY KEY (Pk),
    
    Name NVARCHAR(50) NOT NULL,
);
GO

CREATE TABLE Beer
(
    Pk int IDENTITY (1, 1) not null,
    CONSTRAINT Pk_Beer PRIMARY KEY (Pk),
    
    Name NVARCHAR(50) NOT NULL,
    Style NVARCHAR(50) NOT NULL,

    PkBrand int null,
    CONSTRAINT FK_Beer_Brand_PkBrand FOREIGN KEY (PkBrand) REFERENCES Brand (Pk)
    
);
GO

INSERT into brand (Name) values ('cesBrand');
insert into beer values ('Corona', 'Style1',1)

```

Nos ubicamos en el proyecto de DesignPatterns.Models y ejecutamos
`Scaffold-DbContext "Server=DESKTOP-ANEEUI8;Database=DesignPattern;User=DBUser;Password=DBUser2019" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data`

para actualizar nuestros modelos.

Ahora vamos a crear nuestra interface y clase de UnitOfWork
en nuestro proyecto DesignPatterns.Repository y el codigo 
tiene que ser identico que lo que icimos en la seccion anterior.


![video16UnitOfWork](./imgReadme/video16UnitOfWork.jpg)

Ahora lo que vamos a hacer es inyectar la Interfaz
IUnitOfWork

![video16Inyeccion](./imgReadme/video16Inyeccion.jpg)

Ahora agregamos el controlador

![video16AddController](./imgReadme/video16AddController.jpg)


Agregamos el modelo y el codigo en el controlador

![video16ViewModelAddCode](./imgReadme/video16ViewModelAddCode.jpg)

Agregamos una vista vacia al index

![video16Addview](./imgReadme/video16Addview.jpg)


Agregamos el siguiente codigo a la vista.

![video16ViewIndexCode](./imgReadme/video16ViewIndexCode.jpg)

Corremos la applicacion 

![video16Corrida](./imgReadme/video16Corrida.jpg)



