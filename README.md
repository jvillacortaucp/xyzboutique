# xyzboutique
Empresa XYZ boutique que tiene como actividad principal la venta de productos básicos.

En el Api se debe logear para obtener una Jason Web Token. Logeandose en el endpoint users login con la siguiente informacion:
email: administrator@localhost 
clave: Administrator1!

El login respondera con el JWT, la cual se debe setear en el boton Authorize de Swagger.

Ejemplo:

Llenar la casilla en blanco de la siguiente forma:

Bearer OAISUDFasjfdlkasjdfkjasfkjaslkfdjOISAUDFOIAS....

y seleccionar Login.

Seguidamente podra utilizar los endpoints para Crear un pedido y para cambiar el estado de un pedido.


Ademas se implemento un workflow en github actions para CI/CD vinculado a la rama release 1.0. La misma que ante cualquier pull request inicia un proceso
build y deploy hacia un app service de azure.
