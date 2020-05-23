using Model;
using Model.AdmLibros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ICategorias
    {
        Respuesta AgregarCategoria(Categoria categoria);
        Respuesta EditarCategoria(Categoria categoria);
        Respuesta EliminarCategoria(Categoria categoria);
        List<Categoria> consultarCategorias();
    }
}
