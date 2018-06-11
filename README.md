# SearchWordInArray

Objetivo

La aplicación tiene como objetivo generar un algoritmo para encontrar una palabra pasada por parámetro y devolver las posiciones de las letras en la matriz.

Para la funcionalidad fue utilizado el patrón “chain of responsibility” debido que mi idea fue recorrer la matriz y cuando encentrar la primera letra de la palabra buscada el método hace una barredura entre diferentes direcciones de la matriz (Arriba, Abajo, Derecha, Izquierda, Diagonal, Diagonal Reversa), o sea mientras no encuentro la palabra el receptor (Dirección) sabe cómo seguir (Hacia Cual Dirección) una vez encontrada devuelvo sus posiciones.
