using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
    internal class ClubDeportivo
    {
        private string razonSocial;
        private List<Socio> socios;
        private List<Actividad> actividades;
        private int idUltimoSocio;
        private int idUltimaActividad;

        public ClubDeportivo(string razonSocial) {
            this.razonSocial = razonSocial;
            this.socios = new List<Socio>();
            this.actividades = new List<Actividad>();
        }

        private Socio buscarSocio(string dni)
        {
            Socio socioaBuscar = null;
            int i = 0;
            while (i < socios.Count && socioaBuscar == null) {
                if (socios[i].DNI.Equals(dni)) {
                    socioaBuscar = socios[i];
                }
                else {
                    i++;
                }
            }
            return socioaBuscar;
        }

        private Actividad buscarActividad(string nombre)
        {
            Actividad actividadaBuscar = null;
            int i = 0;
            while (i < actividades.Count && actividadaBuscar == null) {
                if (actividades[i].Nombre.Equals(nombre)) {
                    actividadaBuscar = actividades[i];
                }
                else {
                    i++;
                }
            }
            return actividadaBuscar;
        }

        public string altaSocio(string nombre, string dni)
        {
            Socio socio = buscarSocio(dni);
            string resultado = "NO_SE_PUDO_REGISTRAR";
            if (socio == null) {
                Socio nuevoSocio = new Socio(++idUltimoSocio, nombre, dni);
                socios.Add(nuevoSocio);
                resultado = "INSCRIPCION_EXITOSA";
            }
            return resultado;
        }

        public bool altaActividad(string nombre, int cupoMax, int cupoDisponible, double precio)
        {
            bool seDioDeAlta = false;
            Actividad actividad = buscarActividad(nombre);
            if (actividad == null) {
                Actividad nuevaActividad = new Actividad(++idUltimaActividad, nombre, cupoMax, cupoDisponible, precio);
                actividades.Add(nuevaActividad);
                return !seDioDeAlta;
            }
            return seDioDeAlta;
        }

        public string inscribirActividad(string nomActividad, string dni)
        {
            Socio socio = buscarSocio(dni);
            Actividad actividad = buscarActividad(nomActividad);
            string resultado;

            if (socio == null) {
                resultado = "SOCIO_INEXISTENTE";
            }
            else if (actividad == null) {
                resultado = "ACTIVIDAD_INEXISTENTE";
            }
            else if (actividad.CupoDisponible == 0) {
                resultado = "NO_HAY_CUPO_DISPONIBLE";
            }
            else {
                bool seAgregoaActividad = socio.agregarActividad(actividad);
                if (seAgregoaActividad) {
                    actividad.agregarInscripto(socio);
                    actividad.restarCupo();
                    resultado = "INSCRIPCION_EXITOSA";
                }
                else {
                    resultado = "TOPE_DE_ACTIVIDADES_ALCANZADO";
                }
            }

            return resultado;
        }

        public void listarSocios()
        {
            foreach(var socio in socios) {
                Console.WriteLine(socio);
            }
        }
        public void listarActividades()
        {
            foreach(var actividad in actividades) {
                Console.WriteLine(actividad);
            }
        }

    }
}

