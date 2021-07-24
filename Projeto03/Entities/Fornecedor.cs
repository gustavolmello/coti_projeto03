using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Entities
{
    public class Fornecedor
    {
        #region Properties

        public Guid IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        #endregion

        #region Associations

        public List<Produto> Produtos { get; set; }

        #endregion

        #region Constructors

        public Fornecedor()
        {

        }

        public Fornecedor(Guid idFornecedor, string nome, string cnpj)
        {
            IdFornecedor = idFornecedor;
            Nome = nome;
            Cnpj = cnpj;
        }

        #endregion
    }
}
