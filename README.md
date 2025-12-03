# Cambios
Hice cambios en: 
1. Vendedor.cs (al final).
2. RepositoriosClientes.cs (al final)
3. RepoVendedores (al final).

La lógica fue: 
1. El vendedor tiene id clientes
2. Filtro los clientes que tengan ventas registradas
3. Calculo el monto total de las ventas del vendedor
4. descarto los que tengan menos del monto que introduce el usuario.
5. Ordeno de mayor a menor en una lista
6. guardo todo en un diccionario.

Perdí tiempo haciendo los test. 
Si hubiera seguido por el camino de hacer andar el bot hubiera sido mejor. 
1. Faltó hacer cambios en interfaz.cs y en el helper agregar el comando. 
Con esos dos cambios que no eran mas de 40 lineas el bot reconoce el comando y es capaz de mostrar el diccionario que genero en vendedor con el método "rankingVendedores"

