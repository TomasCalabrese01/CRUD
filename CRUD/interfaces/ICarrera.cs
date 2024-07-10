using CRUD.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.interfaces
{
    internal interface ICarrera
    {
        //PROPIEDADES
        string Nombre { get; set; }

        string Sigla { get; set; }

        string Titulo { get; set; }

        int Duracion { get; set; }

        //METODOS
        Carrera FindBySigla(string sigla); 

        List<Carrera> List();

        bool NameExist(string nombre);


        bool SiglaExist(string sigla);

    }
}
