using CRUD.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.CLASES
{
    public class Carrera : IID, IABMC_Carrera, ICarrera
    {
        // Propiedades de la interfaz IID
        public int ID { get; set; }

        // Propiedades de la interfaz ICarrera
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        

        private static int Last_ID = 1;
        // Lista estática para almacenar objetos Carrera
        private static List<Carrera> List_Carrera = new List<Carrera>();
        public Carrera FindBySigla(string sigla) //busca la carrera en la lista por sigla 
        {
            return List_Carrera.FirstOrDefault(c => c.Sigla == sigla);
        }

        public List<Carrera> List()  // Devuelve la lista completa de carreras
        {
            return List_Carrera;
        }

        public bool NameExist(string nombre) // Verifica si existe alguna carrera en la lista con el nombre proporcionado
        {
            return List_Carrera.Any(c => c.Nombre == nombre);
        }

        public bool SiglaExist(string sigla) // Verifica si existe alguna carrera en la lista con la sigla proporcionada
        {
            return List_Carrera.Any(c => c.Sigla == sigla);
        }

        public void Modify(Carrera carrera)     // Busca la carrera en la lista usando el ID
        {
            Carrera c = Find(carrera.ID);
            // Si no encuentra la carrera, lanza una excepción
            if (c == null) throw new Exception("La carrera que desea modificar no existe en la lista");
            // Si encuentra la carrera, actualiza sus atributos con los nuevos valores
            c.Nombre = carrera.Nombre;
            c.Sigla = carrera.Sigla;
            c.Titulo = carrera.Titulo;
            c.Duracion = carrera.Duracion;
        }

        public void Add(Carrera carrera) //añade una nueva carrera al listado
        {
            // Verifica si ya existe una carrera con el mismo nombre
            if (NameExist(carrera.Nombre)) 
            {
                // Si el nombre ya existe, lanza una excepción

                throw new Exception("La carrera " + carrera.Nombre + " ya existe");
            }

            // Asigna un ID único a la carrera
            carrera.ID = Last_ID;
            Last_ID++;
            List_Carrera.Add(carrera);
        }

        public void Erase(int id) //ELIMINA UN OBJETO DE CARRERA SEGUN SI ID
        {
            Carrera carrera = Find(id); // Busca la carrera por ID
            if (carrera != null)
            {
                List_Carrera.Remove(carrera); // Elimina la carrera si la encuentra
            } else
            {
                throw new Exception("La carrera con el id " + id + " no existe");
            }
        }

        public Carrera Find(int id) //BUSCA UNA CARRERA BASANDOSE EN SU ID 
        {
            foreach (Carrera c in List_Carrera)
            {
                if (c.ID == ID) return c;
            }
            throw new Exception("No se encuentra la carrera con el Id: " + ID);

        }

        

    }
}
