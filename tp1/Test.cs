using System;

namespace tp1
{
    internal class Test
    {
        private static ClubDeportivo clubDeportivo = new ClubDeportivo("Club Atlético del Sol");

        private static void mostrarResultadoPrueba(bool resultado)
        {
            if (resultado) {
                Console.WriteLine("Prueba exitosa!");
            }
            else {
                Console.WriteLine("XXX OJO Prueba fallida XXX");
            }
        }
        private static void evaluarResultadoEsperado(string resultado, string resultadoEsperado)
        {
            Console.WriteLine("Resultado obtenido: " + resultado + " resultado esperado: " + resultadoEsperado);
            mostrarResultadoPrueba(resultado == resultadoEsperado);
        }
        private static void evaluarResultadoEsperado(bool resultado, bool resultadoEsperado)
        {
            Console.WriteLine("Resultado obtenido: " + resultado + " resultado esperado: " + resultadoEsperado);
            mostrarResultadoPrueba(resultado == resultadoEsperado);
        }

        private static void probarAltaSocio(string nombre, string dni, string resultadoEsperado)
        {
            Console.WriteLine($"Probando registrar Nombre: {nombre}, DNI: {dni}");
            evaluarResultadoEsperado(clubDeportivo.altaSocio(nombre, dni), resultadoEsperado);
        }
        private static void probarAltaActividad(string nombre, int cupoMax, int cupoDisponible, double precio, bool resultadoEsperado)
        {
            Console.WriteLine($"Probando registrar Nombre: {nombre}, cupo máximo: {cupoMax}, cupo disponible: {cupoDisponible}, precio: {precio}");
            evaluarResultadoEsperado(clubDeportivo.altaActividad(nombre, cupoMax, cupoDisponible, precio), resultadoEsperado);
        }
        private static void probarInscribirActividad(string nomActividad, string dni, string resultadoEsperado)
        {
            Console.WriteLine($"Probando inscribir socio dni: {dni} en actividad {nomActividad}.");
            evaluarResultadoEsperado(clubDeportivo.inscribirActividad(nomActividad, dni), resultadoEsperado);
        }
        static void Main(string[] args)
        {
            probarAltaSocio("Franco Gomez", "40587156", "INSCRIPCION_EXITOSA");
            probarAltaSocio("Lucía Sanchez", "39485741", "INSCRIPCION_EXITOSA");
            probarAltaSocio("María Bolano", "35752741", "INSCRIPCION_EXITOSA");
            probarAltaSocio("Matías Ferraro", "31851772", "INSCRIPCION_EXITOSA");
            probarAltaSocio("Matías Ferraro", "31851772", "NO_SE_PUDO_REGISTRAR");

            // Testing alta de actividades deportivas
            probarAltaActividad("Canotaje", 2, 2, 15000, true);
            probarAltaActividad("Hockey", 15, 5, 18000, true);
            probarAltaActividad("Natación", 20, 15, 18000, true);
            probarAltaActividad("Canotaje", 2, 2, 15000, true);
            probarAltaActividad("Equitación", 15, 5, 18000, true);
            probarAltaActividad("Equitación", 15, 5, 18000, false);

            // Testing inscripción de socios a actividades deportivas
            probarInscribirActividad("Canotaje", "40587156", "INSCRIPCION_EXITOSA");
            probarInscribirActividad("Canotaje", "39485741", "INSCRIPCION_EXITOSA");
            probarInscribirActividad("Hockey", "39485741", "INSCRIPCION_EXITOSA");
            probarInscribirActividad("Natación", "39485741", "INSCRIPCION_EXITOSA");
            probarInscribirActividad("Equitación", "39485741", "TOPE_DE_ACTIVIDADES_ALCANZADO");
            probarInscribirActividad("Canotaje", "35752741", "NO_HAY_CUPO_DISPONIBLE");
            probarInscribirActividad("Futbol", "31851772", "ACTIVIDAD_INEXISTENTE");
            probarInscribirActividad("Hockey", "41851328", "SOCIO_INEXISTENTE");

            Console.WriteLine("===================== Listado de socios ============================");
            clubDeportivo.listarSocios();
            Console.WriteLine("===================== Listado de actividades =======================");
            clubDeportivo.listarActividades();
        }
    }
}
