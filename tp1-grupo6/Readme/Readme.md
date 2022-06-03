									Bienvenidos al tp2 Red Social

				                     	Instrucciones de uso


*Una vez ejecutado el programa usted estara presente en la pantalla de login del la red social

*Usted puede loguearse directamente ingresando mail y contraseña , o bien puede regristrarse ingresando al boton de REGISTRAR

*Si opta por clickear registrarse , sera llevado a la pantalla de registro , donde debera completar los campos
que le solicita el sistema, estos tienen comprobacion de nulos, verificacion de email bien escrito y de contraseña,
Acto seguido de registrarse , lo llevara nuevamente al login , donde con los datos ingresados y creados recientes podra acceder a la red

*Usted estara entonces en el index de la red social vera su nombre de usuario en sistema y podra generar un Post.
*Para generar un post debera escribir el contenido donde dice " que esta pensando" al dar en el boton de crear
el post se vera reflejado en la parte de abajo donde luego podra eliminarlo y actualizarlo.


										Explicacion de codigo

El codigo de registro de usuario, logueo,generacion de Post modificacion y eliminaciones de los mismos se  encuentra en la carpeta de LOGICA -> RedSocial , donde esta ultima clase
posee los metodos pertinentes. A su vez dentro de la clase de DB_Management se encuentra el codigo encargado de hacer
las consultas y querys pertinentes para la insercion , modificacion y eliminacion de registros de la red contra la 
base de datos.
Luego de esto dentro de la carpeta de ""Front"" estarán todos los formularios y vistas
dentro de ellas el manejo de metodos de la clase de logica para hacer funcionar la vista.


											Base de datos

Dentro de la carpeta del proyecto encontrará la carpeta "BD" la cual contiene el script de generacion de la base de datos
junto con unos pocos datos ya generados para realizar pruebas , asi como usuarios ya creados


										Informacion importante:
Se deberá cambiar el connectionString asociado en Properties.Resources para que matchee con el nuevo equipo donde se probara


