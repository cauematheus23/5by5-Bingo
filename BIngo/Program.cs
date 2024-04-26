//int[] popular_matrizes = new int[98];


int[,] cartela1 = new int[5, 5];
int[] rodadas = new int[99];
int qtd_jogadores = 2, qtd_cartelas = 3;
int[][][,]vetor_cartelas = new int[qtd_jogadores][][,];
int[][][,]matriz_aux = new int[qtd_jogadores][][,];
int contador_rodadas = 0, jogador_1 = 0, jogador_2 = 0;
bool linha = false, coluna = false, cartela_cheia = false;
void Imprimir_Matrizes(int[,] matriz, int[,] matriz_aux)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (matriz_aux[i, j] == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0:00} ",matriz[i, j]);
                Console.ResetColor();
            }
            else
            {
                Console.Write("{0:00} ",matriz[i, j]);
            }
        }
        Console.WriteLine();
    }

}
int[] gerar_vetores()
{
    int[] popular_matrizes = new int[99];
    for (int i = 1; i < popular_matrizes.Length; i++)
    {
        popular_matrizes[i] = i;
    }
    return popular_matrizes;
}
int[] Gerar_Vetor_Aleatorios(int tamanho_vetor)
{
    int indice = 0;
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
    //for (int i = 0; i < numeros_sorteados.Length; i++)
    //    Console.Write(numeros_sorteados[i] + " ");
    return numeros_sorteados;
}
int[,] Gerar_Cartelas()
{
    int[] popular_matrizes = gerar_vetores();
    int linha = 0, coluna = 0;
    int[,] cartela = new int[5, 5];

    while (linha < 5)
    {
        while (true)
        {
            int j = new Random().Next(1, 99);
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

int [,] Gerar_Vetor_Cartelas()
{
    int[,] cartela = new int[5, 5];

    for (int i = 0; i < qtd_jogadores; i++)
    {
        vetor_cartelas[i] = new int[qtd_cartelas][,];
        matriz_aux[i] = new int[qtd_cartelas][,];
        for (int j = 0; j < qtd_cartelas; j++)
        {
            vetor_cartelas[i][j] = Gerar_Cartelas();
            matriz_aux[i][j] = new int [5,5];    
            cartela = vetor_cartelas[i][j];
        }
    }return cartela;
}
Gerar_Vetor_Cartelas();
Imprimir_Matrizes(vetor_cartelas[0][1], matriz_aux[0][1]);
Console.WriteLine();

for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        Console.Write(vetor_cartelas[0][2][i, j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine();

rodadas = Gerar_Vetor_Aleatorios(99);
Console.WriteLine(rodadas.Length);
void Verificar_Vetores(int[,] matriz, ref int[,] matriz_auxiliar_1)
{
    cartela_cheia = false;
    linha = false;
    coluna = false;
    

    for (contador_rodadas = 0; contador_rodadas < rodadas.Length; contador_rodadas++)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {

                if (rodadas[contador_rodadas] == matriz[i, j])
                {
                    matriz_auxiliar_1[i, j] = 1;

                }
                if (matriz_auxiliar_1[0, j] == 1 && matriz_auxiliar_1[1, j] == 1 && matriz_auxiliar_1[2, j] == 1 && matriz_auxiliar_1[3, j] == 1 && matriz_auxiliar_1[4, j] == 1)
                {
                    coluna = true;
                    break;
                }
            }

            if (matriz_auxiliar_1[i, 0] == 1 && matriz_auxiliar_1[i, 1] == 1 && matriz_auxiliar_1[i, 2] == 1 && matriz_auxiliar_1[i, 3] == 1 && matriz_auxiliar_1[i, 4] == 1)
            {
                linha = true;
                break;
            }

        }
        Console.WriteLine("Numero da Rodada: " + rodadas[contador_rodadas]);
        Imprimir_Matrizes(matriz, matriz_auxiliar_1);
        if (linha == true || coluna == true )
        {
            break;
        }
    }
}

for (int i = 0; i < qtd_jogadores; i++)
{
    for (int j = 0; j < qtd_cartelas; j++)
    {
        Verificar_Vetores(vetor_cartelas[i][j], ref matriz_aux[i][j]);
        Console.ReadKey();
    }
}
Console.ReadKey();
Console.WriteLine(jogador_1);
