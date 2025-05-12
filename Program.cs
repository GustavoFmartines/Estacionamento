Console.Clear();

    string tipo;
    bool entradaValida = false;

    Console.ForegroundColor = ConsoleColor.Blue;

Console.WriteLine("---Estacionamento---");

    Console.ResetColor();

// Validação do tipo de veículo, lavagem/valet e dos minutos (pesquisei no chat gpt pq tava me dando raiva dar erro caso eu não colocasse p/g, s/n ou quando colocava letras na entrada de tempo).
//ainda não compreendo muito bem como funciona essa validação/loop.

do
{
    Console.Write(@"
Tamanho do veículo (P/G)......: ");
    tipo = Console.ReadLine()!.ToUpper();

    if (tipo != "P" && tipo != "G")
    {
        Console.WriteLine("Entrada inválida. Digite 'P' para pequeno ou 'G' para grande.");
    }
    else
    {
        entradaValida = true;
    }
} while (!entradaValida);

int minutos;
do
{
Console.Write("Tempo de permanência (min)....: ");
    string entradaMinutos = Console.ReadLine()!;

if (!int.TryParse(entradaMinutos, out minutos) || minutos < 0)
{
        Console.WriteLine("Entrada inválida. Digite apenas números inteiros.");
        minutos = -1;
}
else if (minutos > 720)
{

        Console.WriteLine("O tempo excede o limite de 12h.");
        return;

}

} while (minutos < 0);

string valet;
do
{
    Console.Write("Serviço de valet? (S/N).......: ");
    valet = Console.ReadLine()!.ToUpper();

if (valet != "S" && valet != "N")
{
        Console.WriteLine("Entrada inválida. Digite 'S' para sim ou 'N' para não.");
}
} while (valet != "S" && valet != "N");

string lavagem;
do
{

        Console.Write("Serviço de lavagem? (S/N).....: ");
    lavagem = Console.ReadLine()!.ToUpper();

if (lavagem != "S" && lavagem != "N")

{

        Console.WriteLine("Entrada inválida. Digite 'S' para sim ou 'N' para não.");
    
}
} while (lavagem != "S" && lavagem != "N");

double valorEstacionamento = 0;
double valorValet = 0;
double valorLavagem = 0;

bool Grande = tipo == "G";
double diaria = Grande ? 80.0 : 50.0;

//Comando para indicar a tolerancia de 5 minutos
if (minutos <= 65)
{

        valorEstacionamento = 20.0;

}
else if (minutos >= 305)
{

        valorEstacionamento = diaria;

}
else
{

    valorEstacionamento = Grande ? 40.0 : 30.0;

}
if (valet == "S")
{

    valorValet = valorEstacionamento * 0.20;

}
if (lavagem == "S")
{

    valorLavagem = Grande ? 100.0 : 50.0;

}

double total = valorEstacionamento + valorValet + valorLavagem;

Console.WriteLine();
Console.WriteLine($"Estacionamento..: R${valorEstacionamento:F2}");
Console.WriteLine($"Vallet..........: R${valorValet:F2}");
Console.WriteLine($"Lavagem.........: R${valorLavagem:F2}");
Console.WriteLine("-----------------------------");
Console.WriteLine($"Total...........: R${total:F2}");
