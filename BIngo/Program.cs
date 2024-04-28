int[] rodadas = new int[99];
int qtd_jogadores, qtd_cartelas;
do
{
    Console.WriteLine("Digite a quantidade de jogadores: ");
    qtd_jogadores = int.Parse(Console.ReadLine());
    if (qtd_jogadores < 2)
    {
        Console.WriteLine("Minimo de 2 jogadores para inicar");
    }
} while (qtd_jogadores < 2); //Quantidade de jogadores
do
{
    Console.WriteLine("Digite a quantidade de cartelas: ");
    qtd_cartelas = int.Parse(Console.ReadLine());
    if (qtd_cartelas < 1)
    {
        Console.WriteLine("Minimo de 1 cartela para inicar");
    }
} while (qtd_cartelas < 1); //Quantidade de Cartelas
int[,][,] cartelas_jogadores = new int[qtd_jogadores, qtd_cartelas][,]; //Todas as Cartelas de Todos os jogadores
int[,][,] matriz_aux = new int[qtd_jogadores, qtd_cartelas][,]; //Matrizes Inicializadas em 0 porem quando o numero sorteado existir no espelho dela troca pra 1
int[] rodada_linha_coluna = new int[2];

void Imprimir_Matrizes(int[,][,] jogadores_cartelas, int[,][,] matriz_aux)
{
    for (int jogadores = 0; jogadores < qtd_jogadores; jogadores++)
    {
        Console.WriteLine($"Jogador {jogadores + 1}");

        for (int linha = 0; linha < 5; linha++) //Imprime todas as colunas de cada linha de todas as cartelas antes de passar pra proxima
        {
            for (int cartelas = 0; cartelas < qtd_cartelas; cartelas++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("| ");//Inicio da coluna
                    }

                    if (matriz_aux[jogadores, cartelas][linha, j] == 1) //Verifica se na matriz auxiliar no indice linha,coluna é 1 se sim ele no looping pra printar verde
                    {
                        Console.ForegroundColor = ConsoleColor.Green; //Pintar o valor
                        Console.Write("{0:00} ", jogadores_cartelas[jogadores, cartelas][linha, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0:00} ", jogadores_cartelas[jogadores, cartelas][linha, j]);
                    }

                    if (j == 4) //Fechar coluna pra ir pra proxima linha
                    {
                        Console.Write("|");
                    }
                }
                if (cartelas != qtd_cartelas - 1)
                {
                    Console.Write("   "); // Espaço entre as cartelas
                }
            }
            if (linha != 4)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
int[] gerar_vetores() //Gerar um vetor de 99 posições com valores diferentes para popular as cartelas
{
    int[] popular_cartelas = new int[99];
    for (int i = 1; i < popular_cartelas.Length; i++)
    {
        popular_cartelas[i] = i;
    }
    return popular_cartelas;
}
int[] Numeros_Sorteados(int tamanho_vetor) //Cria um vetor de 99 posições com valores aleatorios não repetidos aonde cada posição desse vetor sera uma rodada
{
    int indice = 0;
    int[] numeros_sorteados = new int[tamanho_vetor];
    while (indice < tamanho_vetor)
    {
        int sorteio = new Random().Next(1, 100);
        bool numero_repetido = false;
        for (int i = 0; i < indice; i++) //Percorre os numeros sorteados ate o momento
        {

            if (sorteio == numeros_sorteados[i]) //Verifica se é repetido e quebra o laço se for
            {
                numero_repetido = true;
                break;
            }
        }
        if (!numero_repetido) //Incrementa no Indice e insere no vetor o numero
        {
            numeros_sorteados[indice] = sorteio;
            indice++;
        }
    }
    return numeros_sorteados;
}
int[,][,] Matriz_Jogador_Cartela() //Gera a matriz de matriz com os jogadores e suas respectivas cartelas
{
    int[,][,] cartelas_jogadores = new int[qtd_jogadores, qtd_cartelas][,];
    for (int jogadores = 0; jogadores < qtd_jogadores; jogadores++)
    {
        for (int cartelas = 0; cartelas < qtd_cartelas; cartelas++)
        {
            int[] popular_cartelas = gerar_vetores();
            int linha = 0, coluna = 0;
            cartelas_jogadores[jogadores, cartelas] = new int[5, 5];
            while (linha < 5)
            {
                int j = new Random().Next(0, popular_cartelas.Length);
                if (popular_cartelas[j] != 0)
                {
                    cartelas_jogadores[jogadores, cartelas][linha, coluna] = popular_cartelas[j];
                    popular_cartelas[j] = 0;
                    coluna++;
                    if (coluna > 4)
                    {
                        linha++;
                        coluna = 0;
                    }
                }
            }

            matriz_aux[jogadores, cartelas] = new int[5, 5]; //Inicializar a matrix auxiliar com todos os valores zerados
        }
    }
    return cartelas_jogadores;
}
void Verificar_Jogo(int[,][,] matriz, ref int[,][,] matriz_auxiliar_1, int[] pontos) //Verifica todos as cartelas alterando pra 1 na matriz auxiliar e verificando linhas e colunas e bingo
{
    int bingo = 0, ganhou_coluna = 0, ganhou_linha = 0, contador_vencedor_linha = 0, contador_vencedor_coluna = 0;
    //Verifica a cartela principal e modifica a auxiliar
    for (int contador_rodadas = 0; contador_rodadas < rodadas.Length && bingo == 0; contador_rodadas++)
    {
        Console.Clear();
        Console.WriteLine($"{contador_rodadas + 1}° Rodada\nNumero Sorteado -> {rodadas[contador_rodadas]}");
        Console.WriteLine("==================================================================================");
        for (int jogadores = 0; jogadores < qtd_jogadores; jogadores++)
        {
            for (int cartelas = 0; cartelas < qtd_cartelas; cartelas++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (rodadas[contador_rodadas] == matriz[jogadores, cartelas][i, j])
                        {
                            matriz_auxiliar_1[jogadores, cartelas][i, j] = 1;

                        }
                    }
                }
            }
        }
        //Verificar cartela cheia por rodada podendo mais de uma na rodada
        for (int jogadores = 0; jogadores < qtd_jogadores; jogadores++)
        {
            for (int cartelas = 0; cartelas < qtd_cartelas; cartelas++)
            {
                int contador = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (matriz_auxiliar_1[jogadores, cartelas][i, j] == 1)
                        {
                            contador++;
                        }
                        if (contador == 25)
                        {
                            pontos[jogadores] += 5;
                            bingo += 1;
                            break;
                        }
                    }
                }
                if (jogadores == qtd_jogadores - 1 && bingo > 0)//Depois de verificar todos os jogadores na rodada se algum der bingo quebra o codigo
                {
                    break;
                }
            }
        }
        //Verificar colunas
        for (int jogadores = 0; jogadores < qtd_jogadores && ganhou_coluna == 0; jogadores++)
        {
            for (int cartelas = 0; cartelas < qtd_cartelas; cartelas++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (matriz_auxiliar_1[jogadores, cartelas][j, i] != 1)
                        {
                            break;
                        }
                        if (j == 4)
                        {
                            contador_vencedor_coluna++;
                            rodada_linha_coluna[1] = contador_rodadas + 1;
                            pontos[jogadores] += 1;
                            Console.WriteLine($"Jogador {jogadores + 1} ganhou Coluna na rodada {contador_rodadas + 1}");
                        }
                    }

                }
            }
            //Depois de verificar todos os jogadores na rodada dando dos devidos pontos pra cada troca a variavel de controle impossibilitando de ganhar novamente em outra rodada
            if (jogadores == qtd_jogadores -1  && contador_vencedor_coluna > 0)
            {
                ganhou_coluna = contador_rodadas;

                break;
            }
        }
        //Verificar linhas
        for (int jogadores = 0; jogadores < qtd_jogadores && ganhou_linha == 0; jogadores++)
        {
            for (int cartelas = 0; cartelas < qtd_cartelas; cartelas++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (matriz_auxiliar_1[jogadores, cartelas][i, j] != 1)
                        {
                            break;
                        }
                        if (j == 4)
                        {
                            rodada_linha_coluna[0] = contador_rodadas + 1;
                            contador_vencedor_linha++;
                            pontos[jogadores] += 1;
                            Console.WriteLine($"Jogador {jogadores + 1} ganhou Linha na rodada {contador_rodadas + 1}");
                        }
                    }

                }
            }
            //Depois de verificar todos os jogadores na rodada dando dos devidos pontos pra cada troca a variavel de controle impossibilitando de ganhar novamente em outra rodada
            if (jogadores == qtd_jogadores - 1 && contador_vencedor_linha > 0)
            {
                ganhou_linha = contador_vencedor_linha;
                break;
            }
        }
        Imprimir_Matrizes(matriz, matriz_auxiliar_1);
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }
    Console.WriteLine("============= BINGOOOOOOOOOOOOO =============");
    Console.WriteLine("A linha foi ganha na rodada : " + rodada_linha_coluna[0]);
    Console.WriteLine("A coluna foi ganha na rodada : " + rodada_linha_coluna[1]);
}
void Verificar_Ganhador(int[] pontos)
{
    int vencedor = 0, maior = 0, qnt_maximo_pontos = 0;

    for (int i = 0; i < pontos.Length; i++)
    {
        if (pontos[i] > maior)
        {
            maior = pontos[i];
            qnt_maximo_pontos = 1;
            vencedor = i;

        }
        else if (pontos[i] == maior)
        {
            qnt_maximo_pontos++;
        }
    }
    if (qnt_maximo_pontos > 1)
    {
        Console.WriteLine("Houve um empate");
    }
    else
    {
        Console.WriteLine($"O vencedor é o jogador {vencedor + 1}");
    }
}//Verificar ganhador ou empate
void jogar_bingo()
{
    int[] pontos_jogadores = new int[qtd_jogadores];



    cartelas_jogadores = Matriz_Jogador_Cartela();
    rodadas = Numeros_Sorteados(99);
    Verificar_Jogo(cartelas_jogadores, ref matriz_aux, pontos_jogadores);
    Verificar_Ganhador(pontos_jogadores);
    Console.WriteLine("=================== PONTOS ===================");
    for (int i = 0; i < qtd_jogadores; i++)
    {
        Console.WriteLine($"Jogador {i + 1}:  " + pontos_jogadores[i]);
    }



}//Carregar o codigo pra jogar
while (true) //Dar a opção pro usuario jogar novamente
{
    jogar_bingo();
    Console.WriteLine("Deseja jogar de novo?\n[1]SIM\n[0]Não");
    int continuar = int.Parse(Console.ReadLine());
    if (continuar == 0)
    {
        break;
    }

}