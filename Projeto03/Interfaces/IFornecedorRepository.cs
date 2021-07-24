using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Interfaces
{
    public interface IFornecedorRepository
    {
        void Exportar(Fornecedor fornecedor);
        void Importar(Guid IdFornecedor);
    }
}
