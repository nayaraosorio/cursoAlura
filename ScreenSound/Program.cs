//ScreenSound - Programa sobre avaliação de som
// List<string> listaBandas = new List<string> {"U2", "The Beatle", "Kiss", "Iron Maiden"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int>{5, 8, 10, 6});
bandasRegistradas.Add("The Beatles", new List<int>());
void ExibirMensagemDeBoasVindas()

{
    Console.WriteLine(@"


░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");

}

void ExibirMenu()
{
    ExibirMensagemDeBoasVindas();
    Console.WriteLine("Boas Vindas ao Screen Sound\n");
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para listar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para SAIR\n");
    
    Console.Write("Digite a sua Opção: ");
    string numeroDigitado = Console.ReadLine()!;
    int intNumeroDigitado = int.Parse(numeroDigitado);
    switch (intNumeroDigitado)
    {
        case 1: RegistrarBanda();
            break;
        case 2: BandasRegistradas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: NotaMediaBanda();
            break;
        case 0: Console.WriteLine("Encerrando Sistema...") ;
            break;
        default: Console.WriteLine("Opção Inválida");
            break;
    };
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Registro das Bandas");
    Console.Write("Digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso !");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}

void BandasRegistradas()
{
    Console.Clear();
    ExibirTituloOpcao("Bandas já Registradas");
    // for (int i = 0; i < listaBandas.Count; i++)
    // {
    //     Console.WriteLine($"Banda: {listaBandas[i]}");
    // }
    foreach ( string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite uma tecla para voltar ao menu principal: \n");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void AvaliarBanda()
{
    //Procurar a banda a ser avaliada
    // Se existir a banda >> avaliar
    // senao, volta ao menu
    
    Console.Clear();
    ExibirTituloOpcao("Avaliar Banda");
    Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual nota você atribui para a banda {nomeBanda} ?");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeBanda].Add(nota); //colchete encontra o dicionario usando a chave, adicioa um valor na chave
        Console.WriteLine($"\n A nota {nota} foi registrada com sucesso para a banda {nomeBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não está registrada.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void NotaMediaBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Média da Nota da Banda");
    Console.WriteLine("Digite o nome da banda que deseja descobrir a média: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        double mediaNotaBanda = bandasRegistradas[nomeBanda].Average();
        Console.WriteLine($"A banda {nomeBanda} teve uma nota média de {mediaNotaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenu();
        
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não está registrada.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void ExibirTituloOpcao(string titulo)
{
    int quantidadeLetra = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetra, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
ExibirMenu();