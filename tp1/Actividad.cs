using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
    internal class Actividad
    {
        private int id;
        private string nombre;
        private int cupoMax;
        private int cupoDisponible;
        private double precio;
        private List<Socio> inscriptos;

        public Actividad(int id, string nombre, int cupoMax, int cupoDisponible, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.cupoMax = cupoMax;
            this.CupoDisponible = cupoDisponible;
            this.precio = precio;
            this.inscriptos = new List<Socio>();
        }

        public int Id { get => id; }
        public string Nombre { get => nombre; }
        public int CupoDisponible
        {
            get => cupoDisponible;
            set
            {
                if (value >= 0) {
                    cupoDisponible = value;
                }
            }
        }

        public void restarCupo()
        {
            cupoDisponible--;
        }

        public bool agregarInscripto(Socio socio)
        {
            bool agregado = false;
            if (cupoDisponible > 0) {
                inscriptos.Add(socio);
                return !agregado;
            }
            return agregado;
        }

        public override string ToString()
        {
            return $"id: {id} Nombre: {nombre} Cupo max: {cupoMax} Cupo disponible: {cupoDisponible} Precio: {precio}.";
        }
    }
}

