using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneoCSharp.src.Modules.Estadisticas.Domain.Entities
{
    public class Estadistica
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Otros campos relevantes para la estadística

        public Estadistica(int id, string nombre, double valor , string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Valor = valor;
            Descripcion = descripcion;
            FechaCreacion = DateTime.Now;
        }      
    }
}