using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
    internal class Socio
    {
        private int ACTIVIDADES_MAX = 3;
        private int id;
        private string nombre;
        private string dni;
        private List<Actividad> actividadesDepor;

        public Socio(int id, string nombre, string DNI)
        {
            this.id = id;
            this.nombre = nombre;
            this.dni = DNI;
            this.actividadesDepor = new List<Actividad>();
        }

        public string DNI { get => dni; }

        public bool agregarActividad(Actividad actividad)
        {
            bool agregada = false;
            if (actividadesDepor.Count < ACTIVIDADES_MAX) {
                actividadesDepor.Add(actividad);
                return !agregada;
            }
            return agregada;
        }

        public override string ToString()
        {
            return $"Id: {id} Nombre: {nombre} DNI: {dni}.";
        }
    }
}

