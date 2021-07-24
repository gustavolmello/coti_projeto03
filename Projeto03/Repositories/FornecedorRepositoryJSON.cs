using Newtonsoft.Json;
using Projeto03.Entities;
using Projeto03.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryJSON : IFornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{fornecedor.IdFornecedor}.json";

            using (var streamWriter = new StreamWriter(path))
            {
                //serializando os dados do fornecedor para JSON
                var json = JsonConvert.SerializeObject
(fornecedor, Formatting.Indented);

                //escrevendo o JSON no arquivo..
                streamWriter.WriteLine(json);
            }
        }

        public void Importar(Guid idFornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{idFornecedor}.json";

            using (var streamReader = new StreamReader(path))
            {
                //ler o conteudo do arquivo
                var conteudo = streamReader.ReadToEnd();

                //deserializar o conteudo JSON lido do arquivo..
                var fornecedor = JsonConvert.DeserializeObject
<Fornecedor>(conteudo);

                //imprimindo
                Console.WriteLine("\nDADOS DO FORNECEDOR:\n");
                Console.WriteLine("ID: " + fornecedor.IdFornecedor);
                Console.WriteLine("NOME: " + fornecedor.Nome);
                Console.WriteLine("CNPJ: " + fornecedor.Cnpj);

                foreach (var item in fornecedor.Produtos)
                {
                    Console.WriteLine("ID: " + item.IdProduto);
                    Console.WriteLine("NOME: " + item.Nome);
                    Console.WriteLine("PRECO: " + item.Preco);
                    Console.WriteLine("QUANTIDADE: " + item.Quantidade);
                    Console.WriteLine("DATA DE CADASTRO: " + item.DataCompra);
                    Console.WriteLine("..");
                }
            }

        }

    }

}
