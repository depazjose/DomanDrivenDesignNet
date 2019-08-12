using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MDT.Model;
using MDT.Model.Gateway;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MDT.MongoDb
{
    public class EmpleadoImpl : IEmpleadoRepository, IDisposable
    {
        private readonly DBAccess context;
        private readonly DbContextOptions<DBAccess> options;


        public EmpleadoImpl(DBAccess context, DbContextOptions<DBAccess> options)
        {
            this.context = context;
            this.options = options;
        }

        public Task<Empleado> ObtenerEmpleadoPorCodigo(string codigo)
        {
            return Task.Run(() =>
            {
                return MapperObject.mapperWithConstructor.Map<Empleado>(context.Empleado.FirstOrDefault(empleado => empleado.Codigo == codigo));
            });
        }
        public List<Empleado> ObtenerListaEmpleados()
        {
            using (var _context = new DBAccess(options))
            {
                var empleados = new List<Empleado>();

                _context.Empleado.ToList().ForEach(empleado =>
                {
                    empleados.Add(MapperObject.mapper.Map<Empleado>(empleado));
                });
                return empleados;
            }
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}