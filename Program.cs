// Programa para cálculo de IMC - versão 1.0
/*
double imc, peso, altura;
Console.WriteLine("");
Console.WriteLine("Programa para cáculo de IMC");
Console.WriteLine("");
Console.WriteLine("Digite seu peso: ");
peso = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Informe sua altura: ");
altura = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("");
Console.WriteLine("Resultado do IMC");
imc = peso / (altura * altura);
if (imc < 18.5)
{
    Console.WriteLine("IMC Calculado: " + imc.ToString("F2"));
    Console.WriteLine("Abaixo do peso");
    Console.WriteLine("");
}
else if (imc >= 18.5 && imc <= 24.9) 
{
    Console.WriteLine("IMC Calculado: " + imc.ToString("F2"));
    Console.WriteLine("Peso normal");
    Console.WriteLine("");
}
else if (imc > 24.9 && imc <= 29.9) 
{
    Console.WriteLine("IMC Calculado: " + imc.ToString("F2"));
    Console.WriteLine("Pré-Obesidade");
    Console.WriteLine("");
}
else if (imc > 29.9 && imc <= 34.9)
{
    Console.WriteLine("IMC Calculado: " + imc.ToString("F2"));
    Console.WriteLine("Obesidade Grau-I");
    Console.WriteLine("");
}
else if (imc > 34.9 && imc <= 39.9) 
{
    Console.WriteLine("IMC Calculado: " + imc.ToString("F2"));
    Console.WriteLine("Obesidade Grau-II");
    Console.WriteLine("");
}
else 
{
    Console.WriteLine("IMC Calculado: " + imc.ToString("F2"));
    Console.WriteLine("Obesidade Grau-III");
    Console.WriteLine("");
}
*/

/* 9 – Desenvolva um algoritmo que calcule o IMC de uma determinada pessoa, e grave os resultados em um 
arquivo de texto, onde ao acessar a aplicação será solicitado se quer fazer um novo cadastro ou consultar 
os existentes. Cadastrando um novo calculo de IMC, será necessário informar o nome, idade, peso e altura. 
O cálculo do IMC é feito dividindo o peso (em quilogramas) pela altura (em metros) ao quadrado. Ao gravar 
em um arquivo de texto, os dados anteriores deverão ser mantidos. versão 1.1
*/
string acao = "";
string caminho = "imc.txt";
double peso, altura, imc;
string nome; 
string resultado = "";
int idade;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("#####################");
Console.WriteLine("N - Novo ############");
Console.WriteLine("C - Consultar #######");
Console.WriteLine("S - Sair#############");
Console.WriteLine("#####################");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("Informe uma operação: ");
Console.ResetColor();

acao = Console.ReadLine().ToUpper();
Console.WriteLine();

while (acao != "S")
{
    if (acao == "N")
    {
        Console.Write("Informe o nome: ");
        nome = Console.ReadLine();

        Console.Write("Informe a idade: ");
        int.TryParse(Console.ReadLine(), out idade);

        Console.Write("Informe o peso: ");
        double.TryParse(Console.ReadLine(), out peso);

        Console.Write("Informe a altura: ");
        double.TryParse(Console.ReadLine(), out altura);

        imc = Math.Round((peso / (altura * altura)));

        if (imc < 18.5)
        {
            resultado = "Peso abaixo do normal";
        }
        else if (imc > 18.5 && imc < 25)
        {
            resultado = "Peso normal";
        }
        else if (imc > 25 && imc < 30)
        {
            resultado = "Sobre peso";
        }
        else if (imc > 30 && imc < 35)
        {
            resultado = "Grau de obesidade I";
        }
        else if (imc > 35 && imc < 40)
        {
            resultado = "Grau de obesidade II";
        }
        else if (imc > 40)
        {
            resultado = "Grau de obesidade III";
        }


        if (resultado != "" && imc > 0 && altura > 0 && peso > 0 && nome.Trim().Length > 2 && idade > 0)
        {


            StreamWriter sw = new StreamWriter(caminho, true);

            sw.WriteLine(string.Format("Nome: {0}", nome));
            sw.WriteLine(string.Format("Idade: {0}", idade));
            sw.WriteLine(string.Format("Peso: {0}", peso));
            sw.WriteLine(string.Format("Altura: {0}", altura));
            sw.WriteLine(string.Format("IMC: {0}", imc));
            sw.WriteLine(string.Format("Resultado: {0}", resultado));
            sw.WriteLine("------------------------------------------");

            sw.Close();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("-->Dados inválidos, operação cancelada!!!");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    else if (acao == "C")
    {
        StreamReader sr = new StreamReader(caminho);

        while (!sr.EndOfStream)
        {
            Console.WriteLine(sr.ReadLine());
        }

        sr.Close();
    }

    Console.WriteLine();
    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadKey();


    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("#####################");
    Console.WriteLine("N - Novo ############");
    Console.WriteLine("C - Consultar #######");
    Console.WriteLine("S - Sair#############");
    Console.WriteLine("#####################");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Informe uma operação: ");
    Console.ResetColor();

    acao = Console.ReadLine().ToUpper();
    Console.WriteLine();
}