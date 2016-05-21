﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    interface IntDAO<T>:IDisposable where T:class, new()
    {
        bool Inserir(T model);
        bool Atualizar(T model);
        bool Remover(T model);
        List<T> Listar();
    }
}
