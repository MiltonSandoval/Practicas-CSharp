using System;

class Program
{
    static void Main()
    {
        // Definimos la matriz n x n
        int[,] matriz = new int[,]
        {
            { 2, 4, 0, 2,0 },
            { 3, 0, 5, 1, 0 },
            { 0, 6, 2, 0,3 },
            { 4, 0, 2, 0,4 },
            { 0, 6, 1, 0, 2 }
        };

        // Calculamos el determinante
        int determinante = CalcularDeterminante(matriz);

        // Mostramos el resultado
        Console.WriteLine("El determinante de la matriz es: " + determinante);
    }

    static int CalcularDeterminante(int[,] matriz)
    {
        int n = matriz.GetLength(0);

        if (n == 1)
        {
            return matriz[0, 0];
        }

        if (n == 2)
        {
            return matriz[0, 0] * matriz[1, 1] - matriz[0, 1] * matriz[1, 0];
        }

        int determinante = 0;

        for (int i = 0; i < n; i++)
        {
            int[,] subMatriz = ObtenerSubMatriz(matriz, 0, i);
            determinante += (i % 2 == 0 ? 1 : -1) * matriz[0, i] * CalcularDeterminante(subMatriz);
        }

        return determinante;
    }

    static int[,] ObtenerSubMatriz(int[,] matriz, int filaOmitida, int columnaOmitida)
    {
        int n = matriz.GetLength(0);
        int[,] subMatriz = new int[n - 1, n - 1];
        int subFila = 0, subColumna = 0;

        for (int i = 0; i < n; i++)
        {
            if (i == filaOmitida) continue;

            subColumna = 0;
            for (int j = 0; j < n; j++)
            {
                if (j == columnaOmitida) continue;

                subMatriz[subFila, subColumna] = matriz[i, j];
                subColumna++;
            }

            subFila++;
        }

        return subMatriz;
    }
}
