using CRUD.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.CLASES
{
    internal class Usuario : IABMC, IUsuario


    {
        static List<Usuario> List_Usuarios = new List<Usuario>();

        private static int Last_ID = 1;

        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string email { get; set; }


        public List<Usuario> List() // Devuelve la lista completa de usuarios
        {
            return List_Usuarios;
        }

        public void Add(Usuario usuario) //añade un nuevo usuario 
        {
            //COMPROBAR SI HAY UN USUARIO CON EL MISMO MAIL
            //COMPROBAR SI HAY UN USUARIO CON EL MISMO DNI 
            if (EmailExist(usuario.email)) throw new Exception("Ya hay otro usuario con el email ingresado");
            if (DniExist(usuario.Dni)) throw new Exception("Ya hay otro usuario con el dni ingresado");
            //SE AGREGA EL USUARIO A LA LISTA
            usuario.ID = Last_ID;
            Last_ID++;
            List_Usuarios.Add(usuario);

        }

        public bool DniExist(int Dni) // Verifica si existe algun usuario en la lista con el dni proporcionado
        {

            foreach (Usuario u in List_Usuarios)
            {
                if (u.Dni == Dni) return true;
            }
            return false;
        }

        public bool EmailExist(string email) // Verifica si existe algun usuario en la lista con el email proporcionado
        {
            {
                foreach (Usuario u in List_Usuarios)
                {
                    if (u.email == email) return true;
                }
                return false;
            }
        }

        public void Erase(int dni)//METODO PARA ELIMINAR UN USUARIO DE LA LISTA BASANDOSE EN SU DNI
        {
            //SI ENCUENTRA UN USUARIO CON EL MISMO DNI LO ELIMINA
            //EN CASO CONTRARIO NOS LANZA UNA EXCEPCION
            foreach (Usuario u in List_Usuarios)
            {
                if (u.Dni == dni)
                {
                    List_Usuarios.Remove(u);
                }
            }
            throw new Exception("No se encuentra el usuario con el DNI: " + dni);
        }

        public Usuario Find(int id)//ACCEDE Y RECORRE LA LISTA USUARIOS
        {
            
            //VERIFICAR SI EXISTE UN USUARIO EN LA LISTA CON EL MISMO ID COMPARADO CON EL PARAMETRO INT ID, REGRESA EL USUARIO
            //EN CASO CONTRARIO, RETORNAR UNA EXCEPCION
            foreach (Usuario u in List_Usuarios)
            {
                if (u.ID == id) return u;
            }
            throw new Exception("No se encuentra el usuario con el ID: " + id);
        }

        public Usuario FindByDni(int Dni) //busca un usuario basandose en su DNi
        {
            //itera sobre cada usuario de la lista
            foreach (Usuario u in List_Usuarios)
            {
                if (u.Dni == Dni) return u; // Si encuentra el usuario con el DNI buscado, lo devuelve
            }
            throw new Exception("No se encuentra el usuario con el DNI ingresado: " + Dni); // Si no encuentra el usuario con el DNI buscado, lanza una excepción
        }

        public Usuario FindByEmail(string email)
        {
            foreach (Usuario u in List_Usuarios)
            {
                if (u.email == email) return u;
            }
            throw new Exception("No se encuentra el usuario con el email ingresado: " + email);
        }

        public void Modify(Usuario usuario)//METODO QUE ACTUALIZA INFORMACION DE USUARIO
        {
            //SI EL USUARIO ES NULL SIGNIFICA QUE NO EXISTE USUARIO CON ESE ID
            //SI EL USUARIO EXISTE SE ACTUALIZA SU NOMBRE
            Usuario u = Find(usuario.ID);
            if (u == null) throw new Exception("El usuario que desea modificar no existe en la lista");
            u.Nombre = usuario.Nombre; //lo modifica
        }



    }
}
