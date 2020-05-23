using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IAutor
    {
        Respuesta AgregarAutor(Model.AdmLibros.Autor autorInfo);
        Respuesta EliminarAutor(Model.AdmLibros.Autor autorInfo);
        Respuesta EditarAutor(Model.AdmLibros.Autor autorInfo); 
        List<Model.AdmLibros.Autor> consultarAutores();
    }
}
