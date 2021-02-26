using Microsoft.EntityFrameworkCore;
using ListaTareas.Models;
using ListaTareas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTareas.Services
{
    public class CTareas : ITareas
    {
        private readonly ListaTareasContext _tareas;

        public CTareas(ListaTareasContext tareas)
        {
            _tareas = tareas;
        }


        public bool BuscarTareaId(int tareaId)
        {
            return _tareas.Tareas.Any(x=>x.Id==tareaId);
        }

        public bool BuscarTareaTitulo(string titulo)
        {
            bool valor = _tareas.Tareas.Any(x => x.Titulo.ToLower().Trim() == titulo.ToLower().Trim());

            return valor;
        }

        public bool CreateTarea(Tarea Tarea)
        {
            if (Tarea == null)
            {
                throw new ArgumentNullException();
            }
                        
            _tareas.Tareas.Add(Tarea);
            return Save();
            
        }

        public bool DeleteTarea(Tarea Tarea)
        {
            _tareas.Tareas.Remove(Tarea);
           return Save();

        }

        public async Task<Tarea> GetTareaById(int tareaId)
        {
          return await _tareas.Tareas.FirstOrDefaultAsync(x=>x.Id == tareaId);
        }

        public async Task<IEnumerable<Tarea>> GetTareas()
        {
            return await _tareas.Tareas.OrderBy(x=>x.Titulo).ToListAsync();
        }

        public bool Save()
        {
          return _tareas.SaveChanges()>=0 ? true:false ;
        }

        public void UpdateTarea(Tarea Tarea)
        {
            _tareas.Tareas.Update(Tarea);
            Save();
           

        }
    }
}
