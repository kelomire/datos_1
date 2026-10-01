using Aplicacion.Modelos;

namespace Aplicacion.Ejemplos
{
    /// <summary>
    /// Ejemplo práctico de cómo usar el modelado de simulación de red
    /// </summary>
    public class EjemploSimulacionRed
    {
        public static void EjecutarEjemplo()
        {
            // 1. Crear la simulación
            var simulacion = new Simulacion("Red Corporativa");

            // 2. Crear dispositivos
            var router = new Router("Router-Main", "192.168.1.1", capacidadBufer: 50);
            var switch1 = new Switch("Switch-Planta1", "192.168.1.2", cantidadPuertos: 24);
            var firewall = new Firewall("Firewall-Entrada", "10.0.0.1", modoEstricto: false);
            var ap = new AccessPoint("AP-Wifi", "192.168.1.100", ssid: "OfficePro", 
                                    potenciaSeñal: 85, anchodeBanda: 20);

            // 3. Agregar dispositivos a la simulación
            simulacion.AgregarDispositivo(router);
            simulacion.AgregarDispositivo(switch1);
            simulacion.AgregarDispositivo(firewall);
            simulacion.AgregarDispositivo(ap);

            // 4. Configurar el Router con rutas
            router.AgregarRuta("10.0.0.0", "192.168.1.2");  // Red interna vía Switch
            router.AgregarRuta("8.8.8.8", "10.0.0.1");      // Internet vía Firewall

            // 5. Configurar el Switch con MACs
            switch1.RegistrarMac("AA:BB:CC:DD:EE:01", 1);   // PC Recepción
            switch1.RegistrarMac("AA:BB:CC:DD:EE:02", 2);   // PC Contabilidad
            switch1.RegistrarMac("AA:BB:CC:DD:EE:03", 3);   // Impresora

            // 6. Conectar dispositivos al Access Point
            ap.ConectarDispositivo("AA:BB:CC:DD:EE:11");    // Laptop 1
            ap.ConectarDispositivo("AA:BB:CC:DD:EE:12");    // Laptop 2

            // 7. Configurar reglas del Firewall
            var reglaInternet = new ReglaFirewall("*", "8.8.8.8", permitir: true);
            var reglaLocal = new ReglaFirewall("192.168.1.*", "10.0.0.*", permitir: true);
            var reglaBloqueo = new ReglaFirewall("192.168.100.*", "*", permitir: false);

            firewall.AgregarRegla(reglaInternet);
            firewall.AgregarRegla(reglaLocal);
            firewall.AgregarRegla(reglaBloqueo);

            // 8. Iniciar simulación
            simulacion.Iniciar();

            Console.WriteLine("=== SIMULACIÓN INICIADA ===\n");
            Console.WriteLine(simulacion);

            // 9. Crear paquetes
            try
            {
                // Paquete 1: PC Recepción enviando a Impresora (mismo switch)
                simulacion.CrearPaquete("192.168.1.50", "192.168.1.51", 
                    "Solicitud de impresión", tamaño: 512);

                // Paquete 2: Laptop inalámbrica enviando a Router
                simulacion.CrearPaquete("192.168.1.101", "192.168.1.1", 
                    "Solicitud HTTP", tamaño: 256);

                Console.WriteLine("\n=== PAQUETES CREADOS ===\n");
                foreach (var paquete in simulacion.PaquetesSimulacion)
                {
                    Console.WriteLine(paquete);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando paquetes: {ex.Message}");
            }

            // 10. Ejecutar pasos de simulación
            Console.WriteLine("\n=== EJECUTANDO PASOS ===\n");
            for (int paso = 1; paso <= 3; paso++)
            {
                Console.WriteLine($"--- Paso {paso} ---");
                try
                {
                    simulacion.EjecutarPaso();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en paso: {ex.Message}");
                }
            }

            // 11. Mostrar estado de dispositivos
            Console.WriteLine("\n=== ESTADO DE DISPOSITIVOS ===\n");
            foreach (var dispositivo in simulacion.Dispositivos)
            {
                Console.WriteLine(dispositivo);
                Console.WriteLine($"  Recibidos: {dispositivo.PaquetesRecibidos.Count}");
                Console.WriteLine($"  Enviados: {dispositivo.PaquetesEnviados.Count}");
            }

            // 12. Mostrar estado del Firewall
            Console.WriteLine("\n=== FIREWALL ===");
            Console.WriteLine($"Modo: {(firewall.ModoEstricto ? "Estricto" : "Permisivo")}");
            Console.WriteLine($"Aceptados: {firewall.PaquetesAceptados}");
            Console.WriteLine($"Rechazados: {firewall.PaquetesRechazo}");
            Console.WriteLine("Reglas:");
            foreach (var regla in firewall.Reglas)
            {
                Console.WriteLine($"  {regla}");
            }

            // 13. Mostrar estado del Router
            Console.WriteLine("\n=== ROUTER ===");
            Console.WriteLine($"Rutas configuradas: {router.TablaDireccionamiento.Count}");
            foreach (var ruta in router.TablaDireccionamiento)
            {
                Console.WriteLine($"  {ruta.Key} -> {ruta.Value}");
            }

            // 14. Mostrar estado del AP
            Console.WriteLine("\n=== ACCESS POINT ===");
            Console.WriteLine($"SSID: {ap.Ssid}");
            Console.WriteLine($"Potencia: {ap.PotenciaSeñal}%");
            Console.WriteLine($"Dispositivos conectados: {ap.DispositivosConectados.Count}");
            foreach (var mac in ap.DispositivosConectados)
            {
                Console.WriteLine($"  {mac}");
            }

            // 15. Detener simulación y generar reporte
            simulacion.Detener();

            Console.WriteLine("\n=== REPORTE FINAL ===\n");
            Console.WriteLine(simulacion.GenerarReporte());
        }
    }
}
