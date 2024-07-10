using CRUD.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.interfaces
{
    internal interface IUsuario
    {
       //PROPIEDADES 
        string Nombre { get; set; }
        
        int Dni { get; set; }

        String email { get; set; }

        //METODOS
        bool DniExist(int Dni);

        bool EmailExist(string email);

        Usuario FindByEmail(string email);

        Usuario FindByDni(int Dni);
    }
}
