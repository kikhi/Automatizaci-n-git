# Automatización Git


Este programa esta desarrollado para que a travez de una inspeccion rapida el programador pueda ejecutar los comandos de git en solo dos clicks elijiendo acciones


### Empezando
  
  - Basta con solo descargar el repositorio y abrirlo en un editor de codigo
  - El codigo esta creado en c#
  - Por el momento el programa no te mete a tu cuenta por lo que ese paso lo debes hacer manualmente


### Tutorial

El objetivo de acortar codico solo es acerlo a travez de un boton o con la posibilidad de hacerlo mediante voz en una vercion futura


  Primero tenemos git clone que es para clonar de github a una carpeta local, en el programa tiene el valor .1


    ```
        git clone
    ```

  Para guardar cambios y subir usamos se registraron los siguientes comandos


    ```
        git add .

        git commit -m ""

        git push
    ```

  Si no estas en la rama main puedes seguir los siguientes comandos  
  
    ```
        git init

        git add .

        git commit -m "first commit"

        git remote add origin https://github.com/NOMBRE_USUARIO/NOMBRE_PROYECTO.git

        git push -u origin main

        git branch -m master main
    ```
  

### Documentacion de la arquitectura
