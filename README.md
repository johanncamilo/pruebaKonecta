# pruebaKonecta en C#

## Pasos y Consideraciones para su ejecución
1. Proyecto hecho con **Visual Studio 2022** y **.net 6**
2. Es posible que se necesiten los siguientes paquetes de NuGet

    > Microsoft.EntityFrameworkCore.SqlServer v 6.0.3
    > Microsoft.EntityFrameworkCore.Tools v 6.0.3

3. Importar la base de datos usando la opción `Import Data-tier Application` nombrandola `PruebaKonecta` usando el archivo **PruebaKonecta.bacpac**
    > Se usó **SqlServer 2019** y **ManagementStudio 2019** en la base de datos
4. modificar el `ConnectionString` con el nombre de la máquinna en **appsettings.json**
5. Ejecutar el proyecto
6. los querys solicitados en la prueba se encuentran en el archivo **consultas.sql**