using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqliteDemo4030349
{
    public class LocalDbService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection= new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));
            
            //Le indica al sistema que crea la tabla de nuestro contexto

            _connection.CreateTableAsync<Clientes>();
        }

        //Listar registros de nuestra tabla
        public async Task<List<Clientes>> GetClientes()
        {
            return await _connection.Table<Clientes>().ToListAsync();
        }

        public async Task<Clientes> GetById(int id)
        {
            return await _connection.Table<Clientes>().Where(x=>x.Id == id).FirstOrDefaultAsync();
        }

        //Metodo para crear registro
        public async Task Create(Clientes clientes)
        {
            await _connection.InsertAsync(clientes);
        }

        //Actualizar
        public async Task Update(Clientes clientes)
        {
            await _connection.UpdateAsync(clientes);
        }

        //Eliminar
        public async Task Delete(Clientes clientes)
        {
            await _connection.DeleteAsync(clientes);
        }

    }
}
