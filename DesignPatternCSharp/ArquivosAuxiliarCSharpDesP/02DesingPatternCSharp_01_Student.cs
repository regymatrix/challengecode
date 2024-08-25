using System;
using System.Collections.Generic;

// Classe Produto
public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataVencimento { get; private set; }

    public Produto(int id, string nome, DateTime dataVencimento)
    {
        Id = id;
        Nome = nome;
        DataVencimento = dataVencimento;
    }

    public bool EstaVencido(DateTime dataAtual)
    {
        return DataVencimento < dataAtual;
    }
}

// Enum TipoFuncionario
public enum TipoFuncionario
{
    Gerente,
    Supervisor,
    Operador
}

// Classe Funcionario
public class Funcionario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public TipoFuncionario Tipo { get; private set; }

    public Funcionario(int id, string nome, TipoFuncionario tipo)
    {
        Id = id;
        Nome = nome;
        Tipo = tipo;
    }

    public void VerificarProdutosVencidos(List<Produto> produtos, DateTime dataAtual)
    {
        if (Tipo == TipoFuncionario.Gerente)
        {
            Console.WriteLine($"Gerente {Nome} verificando produtos vencidos:");
            foreach (var produto in produtos)
            {
                if (produto.EstaVencido(dataAtual))
                {
                    Console.WriteLine($"Produto: {produto.Nome} (ID: {produto.Id}) está vencido. Data de Vencimento: {produto.DataVencimento.ToShortDateString()}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Funcionário {Nome} (Tipo: {Tipo}) não tem permissão para verificar produtos vencidos.");
        }
    }
}

// Uso do sistema de monitoramento de vencimento sem Observer
class Program
{
    static void Main(string[] args)
    {
        // Criando produtos
        List<Produto> produtos = new List<Produto>
        {
            new Produto(1, "Leite", new DateTime(2024, 8, 20)),
            new Produto(2, "Iogurte", new DateTime(2024, 8, 22)),
            new Produto(3, "Queijo", new DateTime(2024, 8, 19))
        };

        // Criando funcionários
        Funcionario gerente = new Funcionario(1, "Ana", TipoFuncionario.Gerente);
        Funcionario supervisor = new Funcionario(2, "Carlos", TipoFuncionario.Supervisor);
        Funcionario operador = new Funcionario(3, "Mariana", TipoFuncionario.Operador);

        // Verificando produtos vencidos com a data atual
        DateTime dataAtual = DateTime.Now;
        
        gerente.VerificarProdutosVencidos(produtos, dataAtual);
        supervisor.VerificarProdutosVencidos(produtos, dataAtual);
        operador.VerificarProdutosVencidos(produtos, dataAtual);
    }
}
