using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace TorneoCSharp.src.Shared.Helpers
{
    public class DatabaseInitializer
    {
        private readonly string _connStr;

        public DatabaseInitializer(string connStr)
        {
            _connStr = connStr;
        }

        public void CreateDatabase()
        {
            using (var conexion = new MySqlConnection(_connStr))
            {
                conexion.Open();

                string databaseCreate = @"
                    DROP DATABASE IF EXISTS torneodb;
                    CREATE DATABASE IF NOT EXISTS torneodb;
                    ";
                Ejecutar(databaseCreate, conexion);
            }
        }

        public void DropTablas()
        {
            using (var conexion = new MySqlConnection(_connStr))
            {
                conexion.Open();

                string dropTablaTorneo = @"
                    DROP TABLE IF EXISTS torneo";

                string dropTablaEquipo = @"
                    DROP TABLE IF EXISTS equipo;";


                // Ejecuta las consultas
                Ejecutar(dropTablaEquipo, conexion);
                Ejecutar(dropTablaTorneo, conexion);
            }
        }

        public void CrearTablas()
        {
            using (var conexion = new MySqlConnection(_connStr))
            {
                conexion.Open();

                string crearTablaTorneo = @"
                    CREATE TABLE IF NOT EXISTS torneo (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Nombre VARCHAR(100) NOT NULL,
                        FechaInicio DATETIME NOT NULL,
                        FechaFin DATETIME NOT NULL
                    )ENGINE=INNODB;";

                string crearTablaEquipo = @"
                    CREATE TABLE IF NOT EXISTS equipo (
                        Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                        Nombre VARCHAR(100) NOT NULL,
                        FechaCreacion DATETIME NOT NULL,
                        Pais VARCHAR(100) NOT NULL
                    );";

                // Ejecuta las consultas
                Ejecutar(crearTablaEquipo, conexion);
                Ejecutar(crearTablaTorneo, conexion);
            }
        }

        private void Ejecutar(string query, MySqlConnection conexion)
        {
            using (var comando = new MySqlCommand(query, conexion))
            {
                comando.ExecuteNonQuery();
            }
        }
    }
}