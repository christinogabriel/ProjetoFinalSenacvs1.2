using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

public class Estoque
{
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public decimal ValorProduto { get; set; }
    public int QuantidadeProduto { get; set; }
}

public class Compras
{
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public decimal ValorProduto { get; set; }
    public string NomeCliente { get; set; }
    public string Endereco { get; set; }
}

public class FluxoDataBase
{
    private readonly string connectionString;

    public FluxoDataBase()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public void SaidaProduto(Estoque produto)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Estoque (IdProduto, NomeProduto, ValorProduto, QuantidadeProduto) " -
                               "VALUES (@IdProduto, @NomeProduto, @ValorProduto, @QuantidadeProduto)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProduto", produto.IdProduto);
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@ValorProduto", produto.ValorProduto);
                    command.Parameters.AddWithValue("@QuantidadeProduto", produto.QuantidadeProduto);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir produto no estoque: {ex.Message}");
        }
    }

    public void RealizarCompra(Compras compra)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Compras (IdProduto, NomeProduto, ValorProduto) " +
                               "VALUES (@IdProduto, @NomeProduto, @ValorProduto)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProduto", compra.IdProduto);
                    command.Parameters.AddWithValue("@NomeProduto", compra.NomeProduto);
                    command.Parameters.AddWithValue("@ValorProduto", compra.ValorProduto);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao realizar compra: {ex.Message}");
        }
    }

    class Program
        
        static void Main()
        {
          FluxoDataBase fluxoDB = new FluxoDataBase();

          Estoque produto = new Estoque {
                IdProduto = 1
                NomeProduto = "Produto teste"
                ValorProduto = 10,99 m,
                QuantidadeProduto = 1000

          };
          fluxoDB.SaidaProduto(produto);
        }
}