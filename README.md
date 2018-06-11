# SearchWordInArray

The purpose of the application is to generate an algorithm to find a word passed by a parameter and return the positions of the letters in the matrix.

For the functionality the "chain of responsibility" pattern was used because my idea was to go through the matrix and when I found the first letter of the searched word the method does a sweep between different directions of the matrix (Up, Down, Right, Left, Diagonal, Reverse Diagonal), that is, as long as I do not find the word the receiver (Direction) knows how to follow (Towards Which Direction) once found I return their positions.
