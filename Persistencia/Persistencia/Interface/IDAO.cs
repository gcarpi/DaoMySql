using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    interface IDAO<T>:IDisposable where T:class, new()
    {
        long Inserir(T model);
        bool Atualizar(T model);
        bool Remover(T model);
        List<T> Listar();
        T Buscar(long codigo);
        long Contagem();
    }
}
