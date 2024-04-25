using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
    internal class ClubDeportivo
    {
        private List<Socio> socios;
        private List<Actividad> actividades;
        private int idUltimoSocio;
        private int idUltimaActividad;

        public ClubDeportivo() { }

        private T buscar<T>(string buscado, List<T> lista)
        {
            T aBuscar = default;
            int i = 0;
            while (i < lista.Count && aBuscar == null) {
                if (lista[i].Equals(buscado)) {
                    aBuscar = lista[i];
                }
                else {
                    i++;
                }
            }
            return aBuscar;
        }

        public Socio buscarSocio(string dni)
        {
            return buscar(dni, socios);
        }

        public Actividad buscarActividad(string nombre)
        {
            return buscar(nombre, actividades);
        }

        public string altaSocio(string nombre, string dni)
        {
            string resultado = "NO_SE_PUDO_REGISTRAR";
            Socio nuevoSocio = new Socio(++idUltimoSocio, nombre, dni);
            if (nuevoSocio != null) {
                socios.Add(nuevoSocio);
                resultado = "INSCRIPCION_EXITOSA";
                return resultado;
            }
            return resultado;
        }

        public bool altaActividad(string nombre, int cupoMax, int cupoDisponible, double precio)
        {
            bool seDioDeAlta = false;
            Actividad nuevaActividad = new Actividad(++idUltimaActividad, nombre, cupoMax, cupoDisponible, precio);
            if (nuevaActividad != null) {
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

    }
}

