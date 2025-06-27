# Prueba tecnica 

## Inciso 1 solucion 
    archivo SQLQuery.sql hallado en la raiz del repositorio


### Razonamiento de la solucion:

    - La base de datos se realizo con fidelidad al diagrama establecido en gitlabs
    intuiyendo los tipos de dato que seria cada columna para simplificar la prueba 
    lo mas posible, se agregaron indices a las llaves foraneas para que sea mucho 
    mas ligera la consulta, esto debido a que pasa de una busqueda profunda, o que
    revise todos los resultados de esa columna a una busqueda de arbol b.
    En la consulta se hace un inner join a las tres tablas para obtener la informacion debido
    a que incluye las tres tablas la informacion requerida.


    - Dada la ambigüedad del diagrama establecido en el gitlab (tipo de dato faltante, etc)
    ,para respetar las intrucciones dadas se realizo con esos campos y mantener el codigo 
    lo mas simplificado posible, esto para ganar tiempo debido a que usaria la misma para 
    el programa y mi falta de costumbre a C#, se realizo de dicha manera, pero estas desde mi 
    perspectiva deberia agregarse lo que seria una tabla catalogo  llamada estado con llave foranea
    en cada tabla ya existente de la base, esta para si desean eliminar algo de la base de datos 
    esta pueda solo cambiar el estado a inactivo, para llevar mejor control sin perdida de datos,
    asi como una tabla bitacora donde por medio de triggers esta guarde inserciones y actualizaciones 
    de cada tabla guardando informacion pertinente para llevar un monitoreo (o auditacion o control)
    en la base de datos, pero recalcando, que para mantener todo lo mas simple posible por el tiempo,
    que dichos cambios solo atrasarian el procedimiento, aumentarian en poca medida la dificultad del
    programa y que como esta base de datos no saldria a produccion, no se me hizo indispensable agregar
    dichos cambios a la base de datos, pero era necesario comentarlo debido a que aporta un gran valor 
    cuando las bases de datos son para produccion, y en mi perspectiva, son necesarias para evitar 
    incovenientes.

## Inciso 2 solucion

### Requerimientos:
Tener instalado sqlserver 2022 
Tener instalado entorno .net
Tener instalado dotnet ef
 para instalar ejecuta en terminal `dotnet tool install --global dotnet-ef`

### Pasos a seguir para poder levatar el proyecto en local:

**Clonar repositorio con `git clone https://github.com/pardo111/PruebaTecnica`**

1.  Ir al archivo ubicado en la raiz ./Program.cs y en la linea 9 la cadena que se le pasa como 
    argumento al metodo UseSqlServer poner la url de tu base de datos.

2.  Ejecutar en consola dentro del proyecto el siguiente comando:
    
    `dotnet ef migrations add Initial`

    Este comando crea la carpeta /Migrations la cual nos prepara todo para que este pueda realizar los cambios
    en la base de datos segun los modelos establecidos.

    Initial puede ser reemplazado por como desees llamar a este movimiento

3.  Ejecutar en consola dentro del proyecto el siguiente comando:

    `dotnet ef database update`

    Este comando crea todas las tablas dentro de la base de datos sino esta creada la base o tablas, 
    en caso contrario las actualiza.

3.  Ejecutar en consola dentro del proyecto el siguiente comando:

    `dotnet run`

    Este comando levanta la aplicacion puedes ver el resultado en 
    
    `http://localhost:5015/Venta`

    Esta url lo llevara a la pagina que solventa el inciso 2 de la prueba tecnica.



## datos a tomar en cuenta

Para que la ruta anteriormente especificada pueda verificarse que cumpla segun requisitos 
del inciso 2, la base de datos no debe estar vacia, en caso deseen llenar con campos de prueba, pueden 
consultar las rutas:

- `http://localhost:5015/Categoria/create`
- `http://localhost:5015/Producto/create`
- `http://localhost:5015/Venta/create`

Las cuales arrojaran formularios los cuales habria que llenar para insertar datos; tomar en cuenta que estos
form no son tolerantes a fallos (datos null, etc).

en las vistas:

- `http://localhost:5015/Categoria/`
- `http://localhost:5015/Producto/`

Podra ver listado lo que son los totales sin filtros de estas tablas.

Siguiendo con fidelidad lo solicitado en el inciso 2:

*_Realizar una página web que muestre el listado de los nombres de productos vendidos. Esta página web tendrá un filtro por categoría, este filtro debe ser una lista de valores del campo Nombre de la tabla Categoria y solo debe mostrar las categorías que tuvieron ventas en el año 2019._*

la vista en la url:
    `http://localhost:5015/Venta`

Solo arroja el nombre del producto, solo pudiendo filtrar la categoria, pero el año ya viene definido en el controlador como 2019.


# observaciones personales 

## no obligatorias, solamente observaciones personales

- En el presente trabajo existen rutas no solicitadas como:

    - `http://localhost:5015/Categoria/`
    - `http://localhost:5015/Producto/`
    - `http://localhost:5015/Categoria/create`  
    - `http://localhost:5015/Producto/create`
    - `http://localhost:5015/Venta/create`

Las cuales unicamente las realice debido a un bug personal que tuve en mi computadora que 
el managment studio no me identificaba la base de datos, y fue mi solucion para ir depurando 
y comprobando todo en el flujo de trabajo.

- De manera personal es mi primer proyecto algo mas alla de programa de consola con C#
en la cual tuve que investigar de una u otra manera ciertas cosas para poder entregarlo, 
pero debido a que anteriormente he realizado proyectos algo mas extensos usando arquitecturas 
similares en lenguajes como php, js y java, se me hizo mucho mas simple.

- Debido a mi falta de experiencia usando lo que es SQLserver y C# me tomo mas tiempo del esperado
poder realizar la prueba tecnica, pero me dejo minimo el sabor de que es interesante realizar proyectos bajo 
esta plataforma, lo cual proximamente sin duda realizare mas proyectos de manera academica bajo arquitectura
api REST (la cual prefiero en lo personal sobre MVC).

- Sin nada mas que decir solo agradezco la oportunidad de poder realizar esta prueba y quedo atento a sus indicaciones,
 comentarios o avisos esperando que se encuentre bien el estimado lector.