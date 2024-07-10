using CRUD.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.interfaces
{
    internal interface IABMC : IID
    {
        //METODOS 
        void Modify(Usuario usuario);

        void Add(Usuario usuario);

        void Erase(int dni);

        Usuario Find(int id);

    }
}
