using ListaTareas.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTareas.Interfaces
{
    public interface ITareas
    {
        Task<IEnumerable<Tarea>> GetTareas();

        Task<Tarea> GetTareaById(int tareaId);

        bool BuscarTareaTitulo(string titulo);

        bool BuscarTareaId(int tareaId);

        bool CreateTarea(Tarea Tarea);

        void UpdateTarea(Tarea Tarea);


        bool DeleteTarea(Tarea Tarea);

        bool Save();
    }
}
