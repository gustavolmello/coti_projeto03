using Projeto03.Entities;
using Projeto03.Interfaces;
using Projeto03.Repositories;
using System;
using System.Collections.Generic;

namespace Projeto03
{
    class Program
    {
        static void Main(string[] args)
        {
            //criando um objeto fornecedor utilizando 
            //o construtor com entrada de argumentos
            var fornecedor = new Fornecedor(Guid.NewGuid(),
                                 "Fornecedor Teste", "12345678908765");

            //inicializando a lista de produtos do fornecedor
            fornecedor.Produtos = new List<Produto>();

            //adicionando produtos na lista..
            fornecedor.Produtos.Add(new Produto(Guid.NewGuid(),
"Notebook", 2000, 10, new DateTime(2021, 07, 09)));

            fornecedor.Produtos.Add(new Produto(Guid.NewGuid(),
"Mochila", 500, 20, new DateTime(2021, 07, 10)));
            fornecedor.Produtos.Add(new Produto(Guid.NewGuid(),
"Celular", 1000, 15, new DateTime(2021, 07, 11)));

            try
            {
                Console.Write("Informe o tipo de arquivo desejado(JSON ou TXT): ");

                var tipo = Console.ReadLine();

                //criando um objeto para a interface
                IFornecedorRepository fornecedorRepository = null; //vazio

                if (tipo.Equals("JSON", StringComparison.OrdinalIgnoreCase))
                {
                    //inicializando a interface com 
                    //a classe FornecedorRepositoryJSON..
                    fornecedorRepository = new FornecedorRepositoryJSON();
                    //POLIMORFISMO
                }
                else if (tipo.Equals("TXT", StringComparison.OrdinalIgnoreCase))
                {
                    //inicializando a interface com a classe 
                    //FornecedorRepositoryTXT
                    fornecedorRepository = new FornecedorRepositoryTXT(); //POLIMORFISMO
                }
                else
                {
                    //lançar para o bloco catch
                    throw new Exception("Tipo de arquivo inválido!");
                }

                //exportar o fornecedor..
                fornecedorRepository.Exportar(fornecedor);
                fornecedorRepository.Importar(fornecedor.IdFornecedor);

                Console.WriteLine("\nOperação realizada com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }

            Console.ReadKey();
        }

    }

}
