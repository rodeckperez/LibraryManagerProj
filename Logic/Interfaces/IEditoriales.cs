using Model;
using Model.AdmLibros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEditoriales
    {
        Respuesta agregarEditorial(Editorial editorial);
        Respuesta EditarEditorial(Editorial editorial);
        Respuesta EliminarEditorial(Editorial editorial);
        List<Editorial> ConsultarEditoriales();
    }
}
