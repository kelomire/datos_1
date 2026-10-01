using Aplicacion.Modelos;

Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
Console.WriteLine("║     SIMULADOR DE CIRCULACIÓN DE PAQUETES EN REDES        ║");
Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

// 1. Crear simulación
Console.Write("📝 Ingrese nombre de la simulación: ");
string nombreSimulacion = Console.ReadLine() ?? "Red Default";
var simulacion = new Simulacion(nombreSimulacion);

Console.WriteLine("\n🔧 CONFIGURACIÓN DE DISPOSITIVOS\n");

// 2. Crear Router
Console.Write("📍 IP del Router (ej: 192.168.1.1): ");
string ipRouter = Console.ReadLine() ?? "192.168.1.1";
var router = new Router("Router-Principal", ipRouter, capacidadBufer: 100);
simulacion.AgregarDispositivo(router);
Console.WriteLine("✓ Router agregado\n");

// 3. Crear Switch
Console.Write("📍 IP del Switch (ej: 192.168.1.2): ");
string ipSwitch = Console.ReadLine() ?? "192.168.1.2";
Console.Write("🔌 Cantidad de puertos (ej: 24): ");
int puertos = int.TryParse(Console.ReadLine(), out int p) ? p : 24;
var sw = new Switch("Switch-Principal", ipSwitch, cantidadPuertos: puertos);
simulacion.AgregarDispositivo(sw);
Console.WriteLine("✓ Switch agregado\n");

// 4. Crear Firewall
Console.Write("📍 IP del Firewall (ej: 10.0.0.1): ");
string ipFirewall = Console.ReadLine() ?? "10.0.0.1";
var firewall = new Firewall("Firewall-Principal", ipFirewall, modoEstricto: false);
simulacion.AgregarDispositivo(firewall);
Console.WriteLine("✓ Firewall agregado\n");

// 5. Crear Access Point
Console.Write("📍 IP del Access Point (ej: 192.168.1.100): ");
string ipAP = Console.ReadLine() ?? "192.168.1.100";
Console.Write("📶 SSID (nombre red WiFi, ej: MiRed): ");
string ssid = Console.ReadLine() ?? "MiRed";
Console.Write("📊 Potencia señal 0-100 (ej: 85): ");
int potencia = int.TryParse(Console.ReadLine(), out int pot) ? pot : 85;
var ap = new AccessPoint("AP-Principal", ipAP, ssid: ssid, potenciaSeñal: potencia);
simulacion.AgregarDispositivo(ap);
Console.WriteLine("✓ Access Point agregado\n");

// 6. Configurar rutas del Router
Console.WriteLine("🛣️  CONFIGURAR RUTAS DEL ROUTER\n");
bool agregarMasRutas = true;
while (agregarMasRutas)
{
    Console.Write("Destino IP (ej: 10.0.0.0): ");
    string destino = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(destino)) break;
    
    Console.Write("Próximo dispositivo IP: ");
    string proximo = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(proximo)) break;
    
    router.AgregarRuta(destino, proximo);
    Console.WriteLine($"✓ Ruta agregada: {destino} → {proximo}\n");
    
    Console.Write("¿Agregar otra ruta? (s/n): ");
    agregarMasRutas = Console.ReadLine()?.ToLower() == "s";
}

// 7. Registrar MACs en Switch
Console.WriteLine("\n🖥️  REGISTRAR DIRECCIONES MAC EN SWITCH\n");
bool agregarMasMACs = true;
while (agregarMasMACs)
{
    Console.Write("MAC address (ej: AA:BB:CC:DD:EE:01): ");
    string mac = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(mac)) break;
    
    Console.Write("Número de puerto (1-{0}): ", puertos);
    if (!int.TryParse(Console.ReadLine(), out int puerto) || puerto < 1 || puerto > puertos)
    {
        Console.WriteLine("❌ Puerto inválido");
        continue;
    }
    
    sw.RegistrarMac(mac, puerto);
    Console.WriteLine($"✓ MAC registrada: {mac} en puerto {puerto}\n");
    
    Console.Write("¿Registrar otra MAC? (s/n): ");
    agregarMasMACs = Console.ReadLine()?.ToLower() == "s";
}

// 8. Conectar dispositivos al Access Point
Console.WriteLine("\n📲 CONECTAR DISPOSITIVOS AL ACCESS POINT\n");
bool agregarMasWiFi = true;
while (agregarMasWiFi)
{
    Console.Write("MAC del dispositivo WiFi (ej: AA:BB:CC:DD:EE:11): ");
    string macWiFi = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(macWiFi)) break;
    
    try
    {
        ap.ConectarDispositivo(macWiFi);
        Console.WriteLine($"✓ Dispositivo conectado: {macWiFi}\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}\n");
    }
    
    Console.Write("¿Conectar otro dispositivo? (s/n): ");
    agregarMasWiFi = Console.ReadLine()?.ToLower() == "s";
}

// 9. Configurar reglas del Firewall
Console.WriteLine("\n🛡️  CONFIGURAR REGLAS DEL FIREWALL\n");
bool agregarMasReglas = true;
while (agregarMasReglas)
{
    Console.Write("IP/Patrón origen (* para cualquiera): ");
    string origen = Console.ReadLine() ?? "*";
    
    Console.Write("IP/Patrón destino (* para cualquiera): ");
    string destino = Console.ReadLine() ?? "*";
    
    Console.Write("¿Permitir? (s/n): ");
    bool permitir = Console.ReadLine()?.ToLower() == "s";
    
    var regla = new ReglaFirewall(origen, destino, permitir);
    firewall.AgregarRegla(regla);
    Console.WriteLine($"✓ Regla agregada: {origen} → {destino} [{(permitir ? "PERMITIR" : "RECHAZAR")}]\n");
    
    Console.Write("¿Agregar otra regla? (s/n): ");
    agregarMasReglas = Console.ReadLine()?.ToLower() == "s";
}

// 10. Mostrar configuración
Console.WriteLine("\n" + new string('=', 60));
Console.WriteLine("📊 CONFIGURACIÓN ACTUAL");
Console.WriteLine(new string('=', 60) + "\n");

Console.WriteLine(simulacion);
Console.WriteLine($"\n🔀 ROUTER - Rutas configuradas: {router.TablaDireccionamiento.Count}");
foreach (var ruta in router.TablaDireccionamiento)
{
    Console.WriteLine($"   {ruta.Key} → {ruta.Value}");
}

Console.WriteLine($"\n🔌 SWITCH - MACs registradas: {sw.TablaMac.Count}");
foreach (var mac in sw.TablaMac)
{
    Console.WriteLine($"   {mac.Key} en puerto {mac.Value}");
}

Console.WriteLine($"\n📶 ACCESS POINT - SSID: {ap.Ssid}, Dispositivos: {ap.DispositivosConectados.Count}");
foreach (var dev in ap.DispositivosConectados)
{
    Console.WriteLine($"   {dev}");
}

Console.WriteLine($"\n🛡️  FIREWALL - Reglas: {firewall.Reglas.Count}");
foreach (var regla in firewall.Reglas)
{
    Console.WriteLine($"   {regla}");
}

// 11. Crear paquetes
Console.WriteLine("\n" + new string('=', 60));
Console.WriteLine("📦 CREAR PAQUETES");
Console.WriteLine(new string('=', 60) + "\n");

simulacion.Iniciar();

bool crearMasPaquetes = true;
while (crearMasPaquetes)
{
    Console.Write("IP origen: ");
    string origen = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(origen)) break;
    
    Console.Write("IP destino: ");
    string destino = Console.ReadLine() ?? "";
    
    Console.Write("Contenido del paquete: ");
    string contenido = Console.ReadLine() ?? "Datos";
    
    Console.Write("Tamaño en bytes (1-65535): ");
    if (!int.TryParse(Console.ReadLine(), out int tamaño) || tamaño < 1 || tamaño > 65535)
    {
        Console.WriteLine("❌ Tamaño inválido");
        continue;
    }
    
    try
    {
        simulacion.CrearPaquete(origen, destino, contenido, tamaño);
        Console.WriteLine($"✓ Paquete creado: {origen} → {destino} ({tamaño} bytes)\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}\n");
    }
    
    Console.Write("¿Crear otro paquete? (s/n): ");
    crearMasPaquetes = Console.ReadLine()?.ToLower() == "s";
}

// 12. Ejecutar pasos de simulación
Console.WriteLine("\n" + new string('=', 60));
Console.WriteLine("▶️  EJECUTAR SIMULACIÓN");
Console.WriteLine(new string('=', 60) + "\n");

Console.Write("¿Cuántos pasos ejecutar? (ej: 5): ");
if (int.TryParse(Console.ReadLine(), out int pasos))
{
    for (int i = 1; i <= pasos; i++)
    {
        Console.WriteLine($"--- Paso {i} ---");
        simulacion.EjecutarPaso();
    }
}

// 13. Mostrar reporte final
simulacion.Detener();
Console.WriteLine("\n" + new string('=', 60));
Console.WriteLine(simulacion.GenerarReporte());
Console.WriteLine(new string('=', 60));
