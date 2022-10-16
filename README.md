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

# Seccion 3 Singleton

## Video 5 Explicacion

Este patron nos va a servir para crear objetos, y aseguraremos que si o si solo se cree un objeto y esto puede ser por performance, 
algun tercero que requiere que solo haya una unica instancia.

![singletonLogCode](./imgReadme/singletonLogCode.jpg)

Program
![programSingletonLog](./imgReadme/programSingletonLog.jpg)

Despues de la corrida
![singletonLog](./imgReadme/singletonLog.jpg)

## Video 6 Implementacion en Asp

Un controlador es el que recibe la solicitud de un cliente la 
trata, la maneja junto con el modelo, y si es adecuado regresar 
una vista siendo la vista contenido HTML, te regresa la vista.

> Nota. sealed ("Sellado") de `public sealed class Log` decimos
que la clase Log no se va a poder heredar.

Creamos el proyecto Tools en donde alojamos la clase Singleton
de Log y ademas agregamos referencias a nuestro proyecto 
de aspnet 
![video6Referencia](./imgReadme/video6Referencia.jpg)

> * **Implementacion 1**

![SingletonLogimplementacion1asp](./imgReadme/SingletonLogimplementacion1asp.jpg)

Corrida 
![CorridaAspLog](./imgReadme/CorridaAspLog.jpg)

![corridaLogAsp](./imgReadme/corridaLogAsp.jpg)

> * **Implementacion 2**

Agregamos configuracion de Path en appsettings.
![video6AppSettingAdd](./imgReadme/video6AppSettingAdd.jpg)

Agregamos una clase que va a ser como la representacion de
lo que agregamos en MyConfig

![video7ConfigurationClass](./imgReadme/video7ConfigurationClass.jpg)

Hacemos una Inyeccion de dependencia de MyConfiguracin en
Programa para versiones Net 6 y para Net 5 Inferior en Startup.

![Video7InyeccionConfiguracion](./imgReadme/Video7InyeccionConfiguracion.jpg)

Recibimos lo que se inyecto en el controlador
![video7InyeccionDeDependecia](./imgReadme/video7InyeccionDeDependecia.jpg)

Hacemos uso de la variable que recibe la inyeccion
![video7ObjInyectadoUtilizado](./imgReadme/video7ObjInyectadoUtilizado.jpg)

> **Nota** De esta manera si en un futuro decidimos guardar en
otra ruta los Logs, lo podremos cambiar facilmente.

Ahora si nosotros estamos trabajando con hilos podemos hacer un 
truco ya que podria suceder que dos hilos entren en el mismo 
instante y por lo cual van a crear 2 instancias diferentes
pero se tendra al final la ultima creada lo cual no es correcto.

> Hay una propiedad en .Net que se llama `lock` que lo que
va a hacer es que mientras esta un hilo trabajando con este
atributo no puede trabajar otro hilo, entonces con la siguiente
instruccion o truco, decimos que nos proteja la variable 
`_protect` y mientras se esta protegindo el otro hilo va a estar
en espera y de esta manera estamos protegiendolo para cuando 
estamos trabajando con hilos.

![video7ProtegiendoDeHilos](./imgReadme/video7ProtegiendoDeHilos.jpg)

# Seccion 4: Factory Method
## Video 7 Explicacion

Imagina que tienes una fabrica, esta fabrica hace productos,
estos productos pueden ser de distinto tipo, entonces tu puedes
tener un conjunto de fabricas.

Ahora bien, factory method es una fabrica creadora de objetos.

![video7FactoryMethodDiagram](./imgReadme/video7FactoryMethodDiagram.jpg)

La practica nos indica que debemos de tener una clase abstracta
llamada **creator**(creador) y vamos a tener clases que hereden de
Creator llamada **ConcreteCreator**(creadores concretos) y
estas van a ser la fabricas que van a crear productos.

Ahora vamos a tener una interfaz llamada Product(Producto) que
va a ser la que va a categorizar a los productos que vamos a
crear, por ejemplo, podemos tener una fabrica que cree productos, 
por ejemplo un producto en una tienda ya sea papitas, cerveza, 
etc, pero tambien un producto podria ser un Kit de productos, 
un combo de productos, una promocion, al fina de todo va 
a tener una iteracion de ser una venta.

Ahora, tu puedes crear una fabrica para crear productos, para 
crear clases, para crear objetos de clases que van a implementar
la interfaz producto. 

Que ventajas tenemos?

Tenemos que la responsabilidad de crear va a estar en la fabrica, 
es decir, si tu estos objetos los utilizas en muchisimos lados, 
tu vas a tener la responsabilidad solamente en un lado  para 
crear el objeto. 

Tu Objeto podria tener muchisimos parametros para su creacion
y esos parametros de su creacion tu no vas a tener la 
responsabilidad mas que un solo lado .

Otras de las ventajas es que podemos tener objetos que son muy
parecidos, los cuales vamos a categorizar con una interfaz
**product** y si necesitamos crear otro objeto que es parecido, 
podemos tener esta misma jeraquizacion sin tener que reinventar
la rueda para crear este nuevo producto que a lo mejor tiene
otros atributos o metodos.

Y este es otra de las ventajas, la flexibilidad que te da para
no recrear la rueda.

### Codigo implementacion

![video7CreatorClass](./imgReadme/video7CreatorClass.jpg)

![video7ConcreteCreator](./imgReadme/video7ConcreteCreator.jpg)

![video7ConcreteCreatorClassInternet](./imgReadme/video7ConcreteCreatorClassInternet.jpg)

![video7ConcreteProductReal](./imgReadme/video7ConcreteProductReal.jpg)

![video7InterfaceISale](./imgReadme/video7InterfaceISale.jpg)

![video7Programa](./imgReadme/video7Programa.jpg)

![vido7Corrida](./imgReadme/vido7Corrida.jpg)

## Video 8 Implementacion en ASP

En este proyecto lo que vamos a hacer es manejas las 
ganancias sobre algo que pueden tener muchas reglas que 
pueden ser engorrosas, y estas reglas a veses tienen distintos
factores de entrada.
Por ejemplo, tu puedes vender algo, y este algo puede tener 
ciertas ganancias porque es local, es decir no estas 
vendiendo al publico extranjero, ahora este mismo algo
lo puedes vender al publico extranjero y entonces tendrias
otro conjunto de reglas que van a alterar la ganancia.

La ganancias de un producto seria eso que tu estas ganando extra
a lo que te costo el producto.

**Factory method ayuda** bastante cuando tu no sabes aun cuales 
son esos factores externos, a veses estas apenas programando
y el cliente se le ocurre agregar nuevos factores.

Estos factores son elementos que sirber para construir el objeto.

Entonces las ganancias pueden ser representadas como un objeto, 
el cual va a tener un metodo que va a calcular la ganancia
dependiendo si es un producto en venta local, o publico
extranjero y de repente podra tener otro, por ejemplo, 
venta por internet, etc. entonces aqui vamos a representar 
este tipo de ganancias.

Hay 2 cuestiones que debemos de tener muy en claro en 
**Factory Method**, hay 2 instancias generales
* Una Fabrica o Creador 
* Y un producto a Crear.

Ademas que tenemos 2 interfaces que nos sirven solamente para
dar orden
* Una que nos va a servir para dar una orden de los productos
creados 

* Y otra para categorizar la fabrica de sus productos.

### Ahora vamos al Codigo.

Creamos la carpeta earn y ahi es donde vamos a poner toda
la logistica de nuestras fabricas ya que vamos a tener
varias fabricas.
Y las fabricas van a representar la creacion de un
objeto y en este caso este objeto va a tener la funcionalidad
de calcular las ganancias.

> * Agregamos la interfaz IEarn
![video8IEarn](./imgReadme/video8IEarn.jpg)

> * Creamos la clase Local Earn con implementacion de IEarn
![video8LocalEarn](./imgReadme/video8LocalEarn.jpg)

> * Creamos EarnFactory o fabrica
![video8EarnFactory](./imgReadme/video8EarnFactory.jpg)

> * Creamos la categoria de Fabrica que es LocalEarnFactory
![LocalEarnFactory](./imgReadme/LocalEarnFactory.jpg)

> * Agregamos controlador ProductDetails y la vista a nuestro nuevo controlador
![Video8AgregandoVista](./imgReadme/Video8AgregandoVista.jpg)

> * Hacemos instancia de la fabrica y creamos nuestro objeto
ganancia local.
![video8ProducController](./imgReadme/video8ProducController.jpg)

> * Agregamos codigo a nuestra vista
![video8View](./imgReadme/video8View.jpg)

> * Corrida 1
![video8corrida1](./imgReadme/video8corrida1.jpg)


**Pero despues llega mi cliente y dise que quiere tener otras reglas para
un total de publico extranjero y pues entonces factory method
siempre se va a acoplar cuando falten requerimientos.**

> * Agregamos ForeingEarn
![video8ForeingEarn](./imgReadme/video8ForeingEarn.jpg)

> * Agregamos ForeingFactory
![video8ForeingFactory](./imgReadme/video8ForeingFactory.jpg)

> * Instanciamos la fabrica y creamos el objeto en el Controller
![video8AddcodeController](./imgReadme/video8AddcodeController.jpg)

> * Agregamos codigo a la vista
![video8AddCodeToView](./imgReadme/video8AddCodeToView.jpg)

> * Corrida 2
![video8Corrida2](./imgReadme/video8Corrida2.jpg)


Entonces cuando hay un nuevo requerimiento o cambia un 
requirimiento, factory method te permite crecer de manera
lineal si afectar a otras funcionalidades y esta es la magia.

> **NOTA** Factory method tiene otra representacion que es como
un swich case, pero en este caso esta representacion es 
la que nos gusta mas ya que es mas flexible y ademas es mejor
deacuerdo a la experiencia, solo es como nota ya que
existen diferentes implementaciones de Factory Method. 

# Seccion 5: Dependency Injection
## Video 9 Explicacion de Inyeccion de Dependencia
Inyeccion de dependencia es uno de los mas utilizados, y
de echo si estas utilizando Frameworks de los mas 
modernos, estaremos seguros que estamos utilizando 
inyeccion de dependencia.

La inyeccion de dependencia trata sobre quitar la 
responsabilidad de una clase de crear objetos a partir de
otras clases, es decir, estas clases no tienen porque saber
como crear ciertos objetos, pueden tener objetos hijos, 
pero no tienen que saber como crearlos, lo que tienen que hacer
es que tu tengas que inyectarle el objeto una ves creado.

Es bien sencillo, como ejemplo, tu eres una persona que le gusta
la cerveza, pero tu no sabes como se hace la cerveza, 
simplemente te la dan ya echa, esto es la inyeccion de
dependencia, si usted quiere tomar cerveza, no tiene
que saber como se hace una cerveza y simplemente ya te lo dan
creado, esto es un ejemplo practico de inyeccion de 
dependencia en la vida real, ya que hay objetos
que tienen otros objetos, pero no tendriamos que
tener la responsabilidad internamente en nuestra clase
de crearlos, si no que los vamos a inyectar.

Las maneras de inyectarlo pueden ser en un metodo o en su
constructor, regularmente en los proyectos de .Net o 
ASP la inyeccion va a ser en el contructor de los 
controladores.

Ahora vamos a ver un ejemplo de porque es importante la inyeccion 
de dependencia

> **La inyeccion de dependencia vienen a resolver
unos de los principios Solid, que es el principio de 
la inversion de la independecia y es practicamente que
no se debe depender de implementaciones pero si de abstraccion,
es decir, tu clase no deberia de depender de como crear las cosas
y simplemente recibir las cosas ya hechas**


> * ![viode9implentatcion](./imgReadme/viode9implentatcion.jpg)


> * ![drinWatherGobernador](./imgReadme/drinWatherGobernador.jpg)

> * ![video9Program](./imgReadme/video9Program.jpg)

> * ![video9Corrida](./imgReadme/video9Corrida.jpg)

## Video 10 Implementacion en ASP de Inyeccion de Dependencia

Cuando icimos el patron de diseño de Factory Method (Ver
session anterior), dijimos que ibamos a mejorarlo con inyeccion 
de dependencia.

Codigo Actual a mejorar.
![video10CodeCurrent](./imgReadme/video10CodeCurrent.jpg)

Ahora bien, si vemos  el controlador es una clase y vemos
que adentro esta construyendo varios objetos, 
Nota, pero el patron de inyeccion de dependecia dise que
los objetos no deberian de construirse ahi, ya que es mucha
responsabilidad para crearse ahi, ya que por ejemplo, 
si llegara a cambiar la fabrica `LocalEarnFactory` significa
que tendriamos que ir a todos los controladores donde 
se tenga esa creacion para cambiarla, lo cual no se hace
mantenible.

Bien, ahora en ASP.Net tenemos un mecanismo como en otros
muchos otros frameworks para tener la inyeccion de 
dependencia, es decir, no vamos a reinventar la inyeccion 
de dependencia ya eso ya existe y lo vamos a encontrar en 
archivo Startup.cs.

Ahora lo que yo quiero es inyectar mi fabrica para que este 
disponible en todos mis controladores en su constructor, 
es decir, yo no quiero dar la dependencia al controlador
para que cree esos objetos que a lo mejor voy a estar 
utilizando bastante.

Entonces lo que vamos a hacer es inyectarlo con una
biblioteca que ya tiene ASP llamada dependency injection
`Using Microsoft.AspNetCore.DependecyInjection`.

Bien, hay 3 formas de inyectar los objetos.
* **Singleton** .- Vas a tener un objeto para toda tu aplicacion.
* **Transitorio o Transient** .- Y esto va a hacer un objeto para
cada servicio, cada solicitud para cada controlador, es decir
el objeto de un controlador no va a ser el mismo que se este 
utilizando en otro constructor de otro controlador.
* **Scope** Va a ser el mismo objeto en la solicitud.

Ahora vamos a inyectar un objeto con ese mecanismo, 

> * Agregamos unas configuraciones al appSettings 
![video10aspsettings](./imgReadme/video10aspsettings.jpg)

> * Inyectamos las fabricas 
![video10inyeccionDeFabricas](./imgReadme/video10inyeccionDeFabricas.jpg)

> * Recibimos el objeto inyectado en el controlador
![video10ContructorController](./imgReadme/video10ContructorController.jpg)

> * Utilizamos las variables inyectadas
![video10UtilizaVAriablePrivada](./imgReadme/video10UtilizaVAriablePrivada.jpg)

> * Corrida y vemos que todo sigue funcionando igual
![video10Corrida](./imgReadme/video10Corrida.jpg)



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


# Video 17 Guardando en 2 tablas

Imaginemos que tenemos que agregar una cerveza, pero 
esa cerceza podria ser de una nueva marca que no tenemos
en nuestra base de datos, entonces el problema radica
que tenemos que ir a las 2 tablas.

El patron UnitOfWork nos va ayudar con este tema.

A continuacion vamos a agregar un nuevo ViewModel clase con 
el nombre `FormBeerViewModel` con se muestra en la siguiente 
imagen

![video17ForBeerViewModel](./imgReadme/video17ForBeerViewModel.jpg)

Despues vamos a BeerController y agregamos 2 metodos

![video17DosMetodosAdd](./imgReadme/video17DosMetodosAdd.jpg)

![video16AddPostRedefinido](./imgReadme/video16AddPostRedefinido.jpg)


Ahora vamos a agregar una vista vacia al primer metodo Add de tipo
[Get] que habiamos agregado

![video17AddViewToFirsAdd](./imgReadme/video17AddViewToFirsAdd.jpg)

Y agregamos el siguiente codigo.
```html
@model DesignPatternsAsp.Models.ViewModels.FormBeerViewModel

<form asp-controller="Beer" asp-action="Add" method="post">
    <div class="form-group">
        <label asp-for="Name"></label>
        <input class="form-control" asp-for="Name"/>
        <span asp-validation-for="Name" class="text-danger"></span>        
    </div>

    <div class="form-group">
        <label asp-for="Style"></label>
        <input class="form-control" asp-for="Style"/>
        <span asp-validation-for="Style" class="text-danger"></span>        
    </div>

    <div class="form-group">
        <label asp-for="BrandId"></label>
        <select class="form-control" asp-for="BrandId" asp-items="@ViewBag.Brands">
            <option value="">--- Selecciona marca ---</option>
        </select>
        <span asp-validation-for="BrandId" class="text-danger"></span>        
    </div>

    <div class="form-group">
        <label asp-for="OtherBrand"></label>
        <input class="form-control" asp-for="OtherBrand"/>
        <span asp-validation-for="OtherBrand" class="text-danger"></span>        
    </div>


    <div class="form-group">
        <button class="btn btn-primary" type="submit">Guardar</button>
    </div>
</form>


```

Un punto a recordar en .Net 6

![video17NoRequerid](./imgReadme/video17NoRequerid.jpg)

Corridas

![video17CorridaAdd](./imgReadme/video17CorridaAdd.jpg)

![corridaFinalGet](./imgReadme/corridaFinalGet.jpg)

# Seccion 8: Strategy
## Video 18 Explicacion de Strategy

Es un patron de comportamiento, es decir nos va a ayudar a 
realizar cierto comportamiento en nuestros objetos.

Ejemplos reales
* Nos va ayudar cuando tengamos un elemento que tiene que 
ser exportado a un determindado formato, como excel, pdf, doc, 
etc, y esto es una accion con distintas estrategias.
* Otro ejemplo es cuando estamos haciendo un sistema tipo 
photoshop en el cual vamos a hacer figuras y el dibujar
un cuadrado es una estrategia y el dibujar un circulo
es otra estrategia pero la accion dibujar tiene distinto
comportamiento.

Entonces con el patron strategy vamos a hacer que el manejo de
este tipo de acciones que se pueden categorizar tengan una
escalabilidad y un manejo muy practico aparte que una ves
que creamos el objeto podemos cambiar su comportamiento
de una manera dinamica.

Se compone de 
* Interfaz `IStrategy` y este va a tener por lo menos un metodo
que las clases que lo implementen tienen que cumplir.

* Clase concreta `ConcreteStrategyA`.

* Clase `Context` con la cual vamos a crear el objeto y va 
a tener un atributo por lo menos que sea del tipo `IStrategy`
y este va a tener alguna accion, y se va a tener un metodo
que lo va a hacer es poder cambiar la estrategia.

![strategypattern](./imgReadme/strategypattern.jpg)

Codificando
> * Interfaz IStrategy
![video18InterfazIStrategy](./imgReadme/video18InterfazIStrategy.jpg)

> * Clase CarStrategy que implementa de IStrategy
![video18CarStrategy](./imgReadme/video18CarStrategy.jpg)

> * Clase MotoStrategy que implementa de IStrategy
![video18MotoStrategy](./imgReadme/video18MotoStrategy.jpg)


> * Clase Context que tiene al menos un atributo IStrategy
![video18ContextStrategy](./imgReadme/video18ContextStrategy.jpg)

> * Aqui vemos 2 practicas del principio SOLID.
>   * Principio de responsabilidad unica y eso es correr, 
        como vas a correr? no lo se, y simplemente 
        yo te doy la estrategia y tu te encargas de correr.
>    * Principio Open-Close, que es abierto a la extension pero
        cerrada a la modificacion, y como ejemplo es que me llegue
        de pronto un nuevo requerimiento, que sea trabajar con 
        otro tipo de vehiculo, pero si lo icieramos con Switch-Case a la antigua estaria violando este 
        principio ya que estaria modificando la clase,
        pero como estoy utilizando el patron strategy, 
        una nueva clase la estoy agregando una nueva clase
        sin tener que mover las otras clases, en este caso
        le llamo BicicleStategy y que implemente a IStrategy.

> * Clase BicycleStrategy que implementa de IStrategy
![video18BicycleStrategy](./imgReadme/video18BicycleStrategy.jpg)

> * Program Class
![video18program](./imgReadme/video18program.jpg)

> * Corrida
![video18corrida](./imgReadme/video18corrida.jpg)


## Video 19 Implementacion en ASP de Strategy

Vamos a ver la solucion del UnitOfWork, y lo que icimos en el
ultimo video de UnitOfWork, es que teniamos 2 formas de 
agregar a la base de datos.
* Una era agregar una Cerveza ya con su marca asignada
* La otra era agregar la marca y asignarla a la cerveza
y la guardabamos.


Entonces aqui hay 2 estrategias.
* Cerveza viene con marca existente
* Cerveza viene con nueva marca

Hacemos una refactorizacion de lo que ya se tenia para agregar 
los siguiente.

> * ![video19Refactorizacion](./imgReadme/video19Refactorizacion.jpg)

Empezamos con el Patron estrategia.

> * Interfaz IBeerStrategy
![video19IBeerStrategy](./imgReadme/video19IBeerStrategy.jpg)

> * Clase BeerStrategy 
![video19BeerStrategy](./imgReadme/video19BeerStrategy.jpg)

> * Clase BeerStrategyWithBrand
![video19BeerStrategyWithBrand](./imgReadme/video19BeerStrategyWithBrand.jpg)

> * ControllerBeer Add
![video19ControllerBeer](./imgReadme/video19ControllerBeer.jpg)

> * Corrida
![video19Corrida](./imgReadme/video19Corrida.jpg)


# Seccion 9: Builder
## Video 20 Explicacion de Builder

Patron creacional que nos va a permitir crear objetos complejos, 
este patron nos viene bien cuando la creacion de los objetos, 
implica tener un constructor enorme, y con el Patron Builde, 
nos va a permitir crear distintos objetos del mismo tipo 
de clase de una manera muy sencilla.

Se compone por
> * **Producto**.- El producto es el objeto complejo, y este puede ser
muchisimas cosas, este patron viene bien con el uso de la 
facturacion electronica, porque la factura en si es un objeto
complejo que tiene muchas cosas que pueden variar ya de dependiendo
el pais puede variar la facturacion, y es por eso que es complejo.


> * **ConcreteBuilder** .- Este es el encargado de crear el 
objeto es decir, nuestro producto final por medio de una serie
de pasos, un objeto complejo, puede estar echo por distintos
pasos. Por ejemplo, los pasos para construir un auto deportivo
a un camion, los pasos para construilos quizas son parecidos,
pero no iguales, y estos pasos pueden variar o incluso el orden
de estos pasos tambien pueden variar. Este va a tener la
implementacion de la interfaz IBuilder.

> * **IBuilder** .- Solo es para la organizacion ya que 
podemos tener distintos ConcreteBuilder que crean distintos
productos.

> * **Director** .- El director es el que se va a encargar de
decir, mira builder, vamos a ejecutar este metodo primero, 
despues este otro, etc. y es el que te va a dar la direccion
de como crear el objeto concreto y ConcreteBuilde nos va
a decir como crearlo y director nos va a decir cual
ejecutar primero, segundo, etc. 
Dependiendo el autor, tu vas a saber que regularmente
el director va a mandar los valores pero a veses lo va
a saber con el control Builder, las 2 son maneras de 
trabajar y va a ir bien.

![video20BuilderDiagrama](./imgReadme/video20BuilderDiagrama.jpg)

La manera de detectar para saber si necesitamos utiliza el 
patron Builder sera cuando identifiquemos que hay una
clase donde haya diferentes configuraciones en su constructor.

> * Creamos la clase PreparedDrink
![video20PreparedDrinkClass](./imgReadme/video20PreparedDrinkClass.jpg)

> * Creamos la Interfaz IBuilder
![video20InterfazIBuilder](./imgReadme/video20InterfazIBuilder.jpg)

> * Creamos la clase PreparedAlcoholicDrinkConcreteBuilder
![video20ConcreteClass1](./imgReadme/video20ConcreteClass1.jpg)
![video20ConcreteClass2](./imgReadme/video20ConcreteClass2.jpg)
![video20ConcreteClass3](./imgReadme/video20ConcreteClass3.jpg)

> * Creamos la clase BartmanDirector
![video20BarmanDirectorClass1](./imgReadme/video20BarmanDirectorClass1.jpg)
![video20BarmanDirectorClass2](./imgReadme/video20BarmanDirectorClass2.jpg)

> * Vamos a la Clase Program **(De esta forma creamos objetos
complejos sin necesidad de tantos constructores)**
![video20Program](./imgReadme/video20Program.jpg)

> * Corrida
![video20Corrida](./imgReadme/video20Corrida.jpg)

## Video 21 Patron Builder implementado en biblioteca a utilizar en ASP 

Imaginar que tenemos que crear 2 o varios distintos archivos, 
pero con una configuracion en especial, es decir algo caotico
con muchos parametros y quiero que el archivo se 
* Se genere en JSON
* Se genere con separacion de pipes
* Se Encripte
* Quiero que se genere a partir de una base de datos de alguna
tabla

y toda esta configuracion puede cambiar, como por ejemplo, 
que este en minuscula, mayuscula, etc.

Estas configuraciones van creando la necesidad de tener 
un objeto que tenga complejidad y todo esto se va a hacer en un 
constructor.

El patron de diseño builder nos va a ayudar con estas tareas, 
sobre todo si necesitamos nuevos tipos de archivos para 
generarlos. 

Esto es muy comun en los trabajos de generar archivos de
este tipo, sobre todo cuando compartimos con distintos 
tipos de fuente de datos.

Tambien el patron de diseño Builder se puede utilizar
para la facturacion electronica de tu pais ya que tambien
puede caer en este tipo de necesidades. 

Lo que vamos a tener al final es un objeto que va a representa
el producto, y este objeto va a generar dichos archivos ya
con la configuracion establecida, vamos a utilizar un director
el cual nos va a dar el tipo de archivo que vamos a necesitar 
como por ejemplo json, separado por pipes etc, y con 
ayuda del concrete builder vamos a crear estas tareas.

Vamos a separar las tareas de la configuracion paso por paso
y el director va a manipular esos pasos.

Vamos a Codificar.

* Creamos la interfaz IBuilderGenerator

![video21-Ibuilder](./imgReadme/video21-Ibuilder.jpg)

* Creamos la clase Generator.
![video21Generator](./imgReadme/video21Generator.jpg)

* Creamos la clase GeneratorConcreteBuilder
![video21GeneratorConcreteBuilder](./imgReadme/video21GeneratorConcreteBuilder.jpg)

* Creamos la clase GeneratorDirector
![video21GeneratorDirector](./imgReadme/video21GeneratorDirector.jpg)


En la siguiente video vamos a ver como implementar estas clases
creadas en ASP.Net 














































