Una biblioteca necesita un software que le permita registrar los datos de los libros que posee y de sus préstamos. De cada libro conoce su código, título, precio de reposición (para el caso de extravíos o daños) y estado (1: disponible, 2: prestado, 3: extraviado).

Por otro lado, cada vez que un libro es prestado se registra el nombre del solicitante, la cantidad de días del préstamo y si fue devuelto o no. El conjunto de préstamos debe ser almacenado como un atributo del libro en cuestión.
Se necesita entonces un programa en Java que obtenga de dos archivos de texto los datos de los libros y sus préstamos y luego de finalizada la carga informe:

    -Cantidad de libros en cada estado (tres totales)
    -Sumatoria del precio de reposición de todos los libros extraviados
    -Nombre de todos los solicitantes de un libro en particular identificado por su título
    -Promedio de veces que fueron prestados los libros de la biblioteca. Es decir, se debe responder a la consulta de cuántas veces es prestado en promedio cada libro (es un promedio simple entre cantidad de prestamos y cantidad de libros)
