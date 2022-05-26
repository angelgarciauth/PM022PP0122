using PM022PP0122.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM022PP0122.Controller
{
    public class DataBaseBase
    {

        //Delete

        public Task<int> EmpleDelete(Empleado emple)
        {
            return dbase.DeleteAsync(emple);
        }


        //CRUD -CREATE  -READ  -UPDATE  -DELETE


        //Create
        public Task<int> EmpleSave(Empleado emple)
        {
            if (emple.id != 0)
            {
                return dbase.UpdateAsync(emple);
            }
            else
            {
                return dbase.InsertAsync(emple);
            }
        }

        //Read v2
        public Task<Empleado> ObtenerEmple(int pid)
        {
            return dbase.Table<Empleado>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        //Read
        public Task<List<Empleado>> ObtenerListaEmple()
        {
            return dbase.Table<Empleado>().ToListAsync();
        }
    }
}