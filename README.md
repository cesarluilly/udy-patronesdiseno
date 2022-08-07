# udy-patronesdiseno-console

Aplicacion de consola realizadas por el curso Patrones de diseño en C# Aplicados en ASP .Net

https://www.udemy.com/course/aprender-patrones-de-disenos-aplicados-en-asp-net/

![curso](./imgReadme/curso.jpg)


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