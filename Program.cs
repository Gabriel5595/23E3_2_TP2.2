using System;

class Pessoa
{
    public string Nome { get; }
    public DateTime DataNascimento { get; }

    public Pessoa(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public int CalcularIdade()
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - DataNascimento.Year;
        
        // Subtrai um ano se a data de nascimento ainda não ocorreu este ano
        if (hoje < DataNascimento.AddYears(idade))
        {
            idade--;
        }
        
        return idade;
    }

    public bool EhMaiorDeIdade()
    {
        return CalcularIdade() >= 18;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o nome da pessoa: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a data de nascimento (dd/mm/aaaa): ");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Pessoa pessoa = new Pessoa(nome, dataNascimento);

        if (pessoa.EhMaiorDeIdade())
        {
            Console.WriteLine($"{pessoa.Nome} é maior de idade.");
        }
        else
        {
            Console.WriteLine($"{pessoa.Nome} é menor de idade.");
        }
    }
}