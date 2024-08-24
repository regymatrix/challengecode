using System;

// Classe Produto
public class Produto
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }

    public Produto(string nome, decimal precoInicial)
    {
        Nome = nome;
        Preco = precoInicial;
    }

    public void AtualizarPreco(decimal percentual)
    {
        Preco += Preco * (percentual / 100);
        Console.WriteLine($"Produto: {Nome}, Novo Preço: {Preco:C}");
    }
}

// Classe AumentoPreco sem Observer
public class AumentoPreco
{
    private Produto produto1;
    private Produto produto2;
    private Produto produto3;
    public DateTime DataAumento { get; private set; }

    public AumentoPreco(DateTime dataAumento, Produto produto1, Produto produto2, Produto produto3)
    {
        DataAumento = dataAumento;
        this.produto1 = produto1;
        this.produto2 = produto2;
        this.produto3 = produto3;
    }

    public void AplicarAumento(decimal percentual)
    {
        Console.WriteLine($"Aplicando aumento de {percentual}% em {DataAumento.ToShortDateString()}");
        produto1.AtualizarPreco(percentual);
        produto2.AtualizarPreco(percentual);
        produto3.AtualizarPreco(percentual);
    }
}

// Uso do sistema de almoxarifado sem Observer
class Program
{
    static void Main(string[] args)
    {
        // Criando produtos
        Produto produto1 = new Produto("Caneta", 2.00m);
        Produto produto2 = new Produto("Caderno", 15.00m);
        Produto produto3 = new Produto("Mochila", 120.00m);

        // Criando o aumento de preços e associando diretamente os produtos
        AumentoPreco aumentoPreco = new AumentoPreco(DateTime.Now, produto1, produto2, produto3);

        // Aplicando aumento de preços
        aumentoPreco.AplicarAumento(10); // Aumenta os preços em 10%
        aumentoPreco.AplicarAumento(5);  // Aumenta os preços em mais 5%
    }
}
