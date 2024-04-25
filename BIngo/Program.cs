int[] numeros_sorteados = new int[98];
int[,] cartela = new int[5, 5];
int indice = 0, linha = 0, coluna = 0;

while (indice < numeros_sorteados.Length)
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
    } if (!numero_repetido)
    {
        numeros_sorteados[indice] = sorteio;
        indice++;
    }
}
for (int i = 0; i < numeros_sorteados.Length; i++)
    Console.Write(numeros_sorteados[i] + " ");


for (int i = 0; i < 5; i++)
    {
    for (int j = 0; j < 5; j++)
    {
       int contador = new Random().Next(1, 100);
        if (numeros_sorteados[contador] > 0)
        {
            cartela[i, j] = numeros_sorteados[contador];
            numeros_sorteados[contador ] = 0;
            
        }
    }
    
}
Console.WriteLine();
for (int i = 0;i < 5; i++)
{
    for(int j = 0; j < 5; j++)
    {
        Console.Write(cartela[i,j] + " ");
    }
    Console.WriteLine();
}
