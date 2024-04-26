int[] popular_matrizes = new int[98];
int[,] cartela1 = new int[5, 5];
int indice = 0;
for (int i = 0; i < popular_matrizes.Length; i++)
{
    popular_matrizes[i] = i;
}
int Gerar_Vetor_Aleatorios(int tamanho_vetor) 
{
    int[] numeros_sorteados = new int[tamanho_vetor];
    while (indice < tamanho_vetor)
    {
        int sorteio = new Random().Next(1, 100);
        bool numero_repetido = false;
        for (int i = 0; i < indice; i++)
        {
            if (sorteio == numeros_sorteados[i])
            {
                numero_repetido = true;
                break;
            }
        }
        if (!numero_repetido)
        {
            numeros_sorteados[indice] = sorteio;
            indice++;
        }
    }
    for (int i = 0; i < numeros_sorteados.Length; i++)
        Console.Write(numeros_sorteados[i] + " ");
    return numeros_sorteados[tamanho_vetor];
}
int[,] Gerar_Cartelas()
{
    int linha = 0, coluna = 0;
    int[,] cartela = new int[5,5];
    
    while (linha < 5)
    {
        while (true)
        {
            int j = new Random().Next(1, 5);
            if (popular_matrizes[j] != 0)
            {
                cartela[linha, coluna] = popular_matrizes[j];
                popular_matrizes[j] = 0;
                coluna++;
                if (coluna > 4)
                {
                    linha++;
                    coluna = 0;
                }
                break;
            }
        }
    }

    return cartela; 
}

cartela1 = Gerar_Cartelas();
for (int i = 0;i < 5; i++)
{
    for(int j = 0; j < 5; j++)
    {
        Console.Write(cartela1[i,j] + " ");
    }
    Console.WriteLine();
}
