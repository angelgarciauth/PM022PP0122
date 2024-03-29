﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM022PP0122.Models;
using SQLite;

namespace PM022PP0122.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;
        /*Constructor de clase*/
        
        public DataBase(string dbpath) {
            dbase = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la base de datos
            dbase.CreateTableAsync<Empleado>(); //creando tabla de empleados

            dbase.CreateTableAsync<Contactos>();
        }

        #region Operaciones

        //CRUD -CREATE  -READ  -UPDATE  -DELETE


        //Create
        public Task<int> EmpleSave(Empleado emple)
        {
            if(emple.id != 0)
            {
                return dbase.UpdateAsync(emple);
            }
            else
            {
                return dbase.InsertAsync(emple);
            }
        }

        //Read
        public Task<List<Empleado>> ObtenerListaEmple()
        {
            return dbase.Table<Empleado>().ToListAsync();
        }

        //Read v2
        public Task<Empleado> ObtenerEmple(int pid)
        {
            return dbase.Table<Empleado>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        //Delete

        public Task<int> EmpleDelete(Empleado emple)
        {
            return dbase.DeleteAsync(emple);
        }

        #endregion Operaciones

        #region contactos
        public Task<int> contactoSave(Contactos contactos)
        {
            if (contactos.id != 0)
            {
                return dbase.UpdateAsync(contactos);
            }
            else
            {
                return dbase.InsertAsync(contactos);
            }
        }

        //Read
        public Task<List<Contactos>> ObtenerListaContacto()
        {
            return dbase.Table<Contactos>().ToListAsync();
        }

        //Read v2
        public Task<Contactos> ObtenerContacto(int pid)
        {
            return dbase.Table<Contactos>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        //Delete

        public Task<int> ContactoDelete(Contactos contacto)
        {
            return dbase.DeleteAsync(contacto);
        }

        #endregion contactos

    }
}
