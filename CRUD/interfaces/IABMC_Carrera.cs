using CRUD.CLASES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.interfaces
{
    internal interface IABMC_Carrera : IID
    {
        //METODOS 
        void Modify(Carrera carrera); //MODIFICAR CARRERA EXISTENTE 

        void Add(Carrera carrera); //AÑADIR UNA CARRERA 

        void Erase(int id); // BORRA UNA CARRERA POR SU ID 

        Carrera Find(int id); // ENCUENTRA CARRERA POR ID 
    }
}
