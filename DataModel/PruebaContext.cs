using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Data;

using Dapper;
using Entities.Entidades;
using System.Data.SqlClient;

namespace Entities
{
    public class PruebaContext : DbContext
    {
        private readonly string _connectionString;
        protected SqlConnection Connection;
        protected SqlConnection connection => Connection ?? (Connection = GetOpenConnection());

        public PruebaContext(DbContextOptions<PruebaContext> options)
                  : base(options)
        {
            _connectionString = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;


            //extension.ConnectionString = connectionString;
        }

        public SqlConnection GetOpenConnection(bool mars = false)
        {

            var cs = _connectionString;
            if (mars)
            {
                var scsb = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            connection.Open();
            return connection;
        }
        public SqlConnection GetClosedConnection()
        {
            var conn = new SqlConnection(_connectionString);
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");
            return conn;
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public DbSet<Reporte> Reportes { get; set; }

        public IEnumerable<T> Query<T>(string query) where T : class
        {
            return connection.Query<T>(query);
        }
    }
}
