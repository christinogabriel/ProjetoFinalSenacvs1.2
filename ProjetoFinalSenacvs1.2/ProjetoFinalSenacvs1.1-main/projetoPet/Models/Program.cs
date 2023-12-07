using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DepemdemcyInjection;
using System;

class Program
{
    static void Main()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
        
        var serviceProvider = new ServiceCollections()
        .AddSingleton(configuration)
        .AddTransient<FluxoDataBase>()
        .BuildServiceProvider();


        using ( var scope = serviceProvider.CreateScope())
        {
            var fluxoDB = scope.ServiceProvider.GetRequiredService<FluxoDataBase>();

            Estoque produto = new Estoque
            {
                IdProduto = 1
                NomeProduto = "Produto Teste"
                ValorProduto = 10,99 m,
                QuantidadeProduto = 10000
            };

            fluxoDB.SaidaProduto(produto);
        }

    }
}

 











// instânciar class = Criar objeto
// Aluno -> class aluno1 -> objeto

