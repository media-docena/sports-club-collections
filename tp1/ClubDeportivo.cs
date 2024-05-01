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
            if (socio == null) {
                Socio nuevoSocio = new Socio(++idUltimoSocio, nombre, dni);
                socios.Add(nuevoSocio);
                return "INSCRIPCION_EXITOSA";
            }
            return "NO_SE_PUDO_REGISTRAR";
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
            if (socio == null) {
                return "SOCIO_INEXISTENTE";
            }

            Actividad actividad = buscarActividad(nomActividad);
            if (actividad == null) {
                return "ACTIVIDAD_INEXISTENTE";
            }

            if (actividad.CupoDisponible == 0) {
                return "NO_HAY_CUPO_DISPONIBLE";
            }

            bool seAgregoaActividad = socio.agregarActividad(actividad);

            if (seAgregoaActividad) {
                actividad.agregarInscripto(socio);
                actividad.restarCupo();
                return "INSCRIPCION_EXITOSA";
            }
            else {
                return "TOPE_DE_ACTIVIDADES_ALCANZADO";
            }
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

