# 🌐 Simulación de Circulación de Paquetes en Redes

Proyecto educativo que modeliza cómo circulan los paquetes de datos en una red informática, utilizando principios de arquitectura de software, diseño orientado a objetos y validaciones robustas.

---

## ⚡ INICIO RÁPIDO

### Si quieres ejecutar el programa YA (5 min):
1. Lee: [START_HERE.md](START_HERE.md) - Orientación rápida
2. Abre: [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md) - Qué valores ingresar
3. Usa: [TABLA_DATOS.md](TABLA_DATOS.md) - Referencias rápidas
4. Copia: Un ejemplo de [EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md) 
5. Ejecuta: `dotnet run --project src/Aplicacion/Aplicacion.csproj -c Release`

### Si quieres aprender TODO (2-8 horas):
Sigue la ruta de aprendizaje en [INDICE.md](INDICE.md) o [ESTRUCTURA_DOCUMENTOS.md](ESTRUCTURA_DOCUMENTOS.md)

---

## 📚 Descripción del Proyecto

Este proyecto implementa una **simulación de red** donde diferentes dispositivos (Router, Switch, Access Point, Firewall) procesan paquetes de datos siguiendo reglas realistas de funcionamiento.

### Objetivo Educativo:
Entender y modelar:
- **¿Cómo circula un paquete en una red?**
- **¿Qué hace cada dispositivo?**
- **¿Cómo cambia el comportamiento según el tipo de dispositivo?**
- **¿Cómo separar responsabilidades en capas arquitectónicas?**

---

## 🏗️ Arquitectura

```
APLICACION                    PERSISTENCIA                 TESTS
├─ Modelos                   ├─ Repositorios              ├─ ServicioATests
│  ├─ PaqueteRed            │  └─ RepositorioPaquete    └─ ServicioBTests
│  ├─ DispositivoRed        ├─ Entidades
│  ├─ Router                └─ Conexión MySQL
│  ├─ Switch
│  ├─ AccessPoint
│  └─ Firewall
├─ Servicios (por implementar)
└─ Interfaces (por implementar)
```

### Tres Capas Principales:

1. **Aplicación**: Lógica de simulación
   - Modelos de dispositivos y paquetes
   - Algoritmos de procesamiento
   - No conoce BD

2. **Persistencia**: Acceso a datos
   - Guardar eventos en MySQL
   - Recuperar históricos
   - Independiente de lógica

3. **Tests**: Validación
   - Pruebas unitarias de modelos
   - Pruebas de integración
   - Casos extremos

---

## 📋 Contenido Documentación

| Archivo | Descripción |
|---------|-------------|
| **RESUMEN_EJECUTIVO.md** | 🔴 LEER PRIMERO - Visión general del proyecto |
| **ACTIVIDADES_ANALISIS.md** | Análisis profundo de las 3 actividades |
| **DIAGRAMAS_ARQUITECTURA.md** | 9 diagramas visuales de la arquitectura |
| **CUESTIONARIO_REFLEXIVO.md** | 20+ preguntas para reflexionar |

---

## 🎯 Actividades Completadas

### ✅ Actividad 1: Situación Inicial
- Análisis de cómo circula un paquete en red
- Identificación de dispositivos y responsabilidades
- Situaciones donde cambia el comportamiento

### ✅ Actividad 2: Lectura Diagnóstica
- Interpretación de arquitectura C#
- Responsabilidades de cada capa
- Hipótesis sobre pruebas unitarias

### ✅ Actividad 3: Modelado Inicial
- 7 clases con encapsulamiento completo
- Constructores seguros
- Propiedades validadas
- Validaciones exhaustivas

---

## 💻 Clases Implementadas

### 1. **PaqueteRed**
Representa una unidad de datos que circula por la red.

```csharp
var paquete = new PaqueteRed(
    origen: "192.168.1.5",
    destino: "8.8.8.8",
    contenido: "GET /index.html HTTP/1.1",
    tamaño: 256
);
```

**Validaciones:**
- Origen y destino no vacíos
- Tamaño entre 1 y 65535 bytes
- Contenido no vacío

### 2. **DispositivoRed** (Clase Base Abstracta)
Define comportamiento común para todos los dispositivos.

```csharp
// No se puede instanciar directamente
// DispositivoRed dispositivo = new DispositivoRed(); ❌

// Se heredan en subclases concretas
Router router = new Router("Router-Main", "192.168.1.1");
```

**Métodos:**
- `RecibirPaquete(paquete)`: Registra entrada
- `EnviarPaquete(paquete)`: Registra salida
- `ProcesarPaquete(paquete)`: ABSTRACTO - implementado en subclases

### 3. **Router**
Enruta paquetes según dirección IP destino.

```csharp
var router = new Router("Router-Main", "192.168.1.1", capacidadBufer: 50);

// Configurar tabla de rutas
router.AgregarRuta("10.0.0.0", "192.168.1.2");      // Red interna
router.AgregarRuta("8.8.8.8", "10.0.0.1");           // Internet

// Procesar paquete
router.ProcesarPaquete(paquete);
var proximoPaquete = router.EnrutarProximoPaquete();
```

**Características:**
- Tabla de direccionamiento (IP → dispositivo)
- Búfer con capacidad configurable
- Búsqueda de ruta

### 4. **Switch**
Conmuta paquetes según dirección MAC.

```csharp
var sw = new Switch("Switch-Planta1", "192.168.1.2", cantidadPuertos: 24);

// Registrar direcciones MAC
sw.RegistrarMac("AA:BB:CC:DD:EE:01", puerto: 1);
sw.RegistrarMac("AA:BB:CC:DD:EE:02", puerto: 2);

// Procesar paquete
sw.ProcesarPaquete(paquete);
```

**Características:**
- Tabla MAC (MAC → puerto)
- Control de puertos
- Conmutación L2

### 5. **AccessPoint**
Proporciona conectividad inalámbrica.

```csharp
var ap = new AccessPoint(
    nombre: "AP-Wifi",
    direccion: "192.168.1.100",
    ssid: "OfficePro",
    potenciaSeñal: 85,
    anchodeBanda: 20,
    tipoSeguridad: "WPA2"
);

// Conectar dispositivo
ap.ConectarDispositivo("AA:BB:CC:DD:EE:11");

// Procesar paquete
ap.ProcesarPaquete(paquete);
```

**Características:**
- SSID, potencia de señal
- Dispositivos conectados
- Validación de cobertura

### 6. **Firewall**
Filtra tráfico según reglas de seguridad.

```csharp
var fw = new Firewall("Firewall-Entrada", "10.0.0.1", modoEstricto: false);

// Agregar reglas
var regla1 = new ReglaFirewall("*", "8.8.8.8", permitir: true);
var regla2 = new ReglaFirewall("192.168.100.*", "*", permitir: false);
fw.AgregarRegla(regla1);
fw.AgregarRegla(regla2);

// Procesar paquete
fw.ProcesarPaquete(paquete);
```

**Características:**
- Reglas de filtrado
- Modo estricto (whitelist) o permisivo (blacklist)
- Contadores de aceptados/rechazados

### 7. **Simulacion**
Orquesta la simulación completa.

```csharp
var sim = new Simulacion("Red Corporativa");

// Agregar dispositivos
sim.AgregarDispositivo(router);
sim.AgregarDispositivo(switch1);
sim.AgregarDispositivo(firewall);

// Iniciar y ejecutar
sim.Iniciar();
sim.CrearPaquete("192.168.1.5", "8.8.8.8", "HTTP GET", 256);
sim.EjecutarPaso();  // Procesar un paso
sim.Detener();

// Reportes
Console.WriteLine(sim.GenerarReporte());
```

**Características:**
- Gestión de dispositivos
- Creación de paquetes
- Ejecución paso a paso
- Generación de reportes

---

## 🚀 Cómo Usar

### 1. **Entender los Conceptos**
```bash
# Lee primero estos archivos en orden:
1. RESUMEN_EJECUTIVO.md          (5 min - visión general)
2. ACTIVIDADES_ANALISIS.md       (20 min - análisis profundo)
3. DIAGRAMAS_ARQUITECTURA.md     (10 min - visuales)
```

### 2. **Estudiar el Código**
```csharp
// Ver clase PaqueteRed
src/Aplicacion/Modelos/PaqueteRed.cs

// Ver clase DispositivoRed (base)
src/Aplicacion/Modelos/DispositivoRed.cs

// Ver implementaciones concretas
src/Aplicacion/Modelos/Router.cs
src/Aplicacion/Modelos/Switch.cs
// ... etc
```

### 3. **Ejecutar el Ejemplo**
```csharp
// Ver ejemplo completo de uso
src/Aplicacion/Ejemplos/EjemploSimulacionRed.cs

// Ejecutar: dotnet run
```

### 4. **Responder Cuestionario**
```bash
# Reflexionar sobre:
CUESTIONARIO_REFLEXIVO.md
```

### 5. **Escribir Tests**
```csharp
// Implementar en:
src/Tests/ServicioATests.cs
src/Tests/ServicioBTests.cs
```

---

## 📊 Ejemplo Completo de Uso

```csharp
// Crear simulación
var simulacion = new Simulacion("Red Corporativa");

// Crear dispositivos
var router = new Router("Router-Main", "192.168.1.1");
var firewall = new Firewall("FW", "10.0.0.1");
var switch1 = new Switch("SW1", "192.168.1.2");

// Agregarlos a la simulación
simulacion.AgregarDispositivo(router);
simulacion.AgregarDispositivo(firewall);
simulacion.AgregarDispositivo(switch1);

// Configurar
router.AgregarRuta("10.0.0.0", "192.168.1.2");
switch1.RegistrarMac("AA:BB:CC:DD:EE:01", 1);
firewall.AgregarRegla(new ReglaFirewall("*", "8.8.8.8", true));

// Ejecutar
simulacion.Iniciar();
simulacion.CrearPaquete("192.168.1.5", "8.8.8.8", "HTTP", 256);
simulacion.EjecutarPaso();
simulacion.Detener();

// Mostrar resultados
Console.WriteLine(simulacion.GenerarReporte());
```

**Salida esperada:**
```
=== Reporte de Simulación: Red Corporativa ===
Estado: Detenida
Duración: 0.05s
Dispositivos: 3
  - Router [Router-Main] - 192.168.1.1 - Activo
    Recibidos: 1, Enviados: 1
  - Switch [SW1] - 192.168.1.2 - Activo
    Recibidos: 0, Enviados: 0
  - Firewall [FW] - 10.0.0.1 - Activo
    Recibidos: 1, Enviados: 1
Total paquetes: 1
```

---

## 🔍 Principios de Diseño Aplicados

### 1. **Encapsulamiento**
- Variables privadas (`_nombre`)
- Propiedades públicas (`public string Nombre { get; set; }`)
- Listas inmutables (`IReadOnlyList<>`)

### 2. **Validación**
- En constructor: Estado inicial válido
- En setters: Cambios validados
- En métodos: Precondiciones verificadas

### 3. **Herencia y Polimorfismo**
- `DispositivoRed` clase base abstracta
- Cada dispositivo implementa `ProcesarPaquete()` diferente
- Código genérico funciona con cualquier subclase

### 4. **Responsabilidad Única**
- `PaqueteRed`: Ser un paquete
- `Router`: Enrutar según IP
- `Switch`: Conmutar según MAC
- `Firewall`: Filtrar según reglas

### 5. **Composición sobre Herencia**
- `Simulacion` CONTIENE dispositivos (no hereda)
- `Firewall` CONTIENE reglas (composición)
- Mejor que herencia profunda

---

## 📈 Próximos Pasos

### Corto Plazo:
1. ✅ Completar modelado (HECHO)
2. 📝 Escribir tests unitarios
3. 🔧 Implementar servicios
4. 💾 Implementar persistencia

### Mediano Plazo:
5. 🖥️ Crear interfaz gráfica
6. 📊 Agregar reportes avanzados
7. 🔌 Simular nuevos dispositivos
8. 📡 Implementar protocolos (ARP, DNS, DHCP)

### Largo Plazo:
9. 🌐 Publicar proyecto
10. 📚 Crear documentación completa
11. 🎓 Usar como material educativo

---

## 📚 Estructura de Archivos

```
datos_1/
├── README.md                          ← Estás aquí
├── RESUMEN_EJECUTIVO.md               ← Leer primero
├── ACTIVIDADES_ANALISIS.md            ← Análisis detallado
├── DIAGRAMAS_ARQUITECTURA.md          ← Visuales
├── CUESTIONARIO_REFLEXIVO.md          ← Preguntas
│
├── src/
│   ├── Aplicacion/
│   │   ├── Modelos/
│   │   │   ├── PaqueteRed.cs
│   │   │   ├── DispositivoRed.cs
│   │   │   ├── Router.cs
│   │   │   ├── Switch.cs
│   │   │   ├── AccessPoint.cs
│   │   │   ├── Firewall.cs
│   │   │   └── Simulacion.cs
│   │   ├── Ejemplos/
│   │   │   └── EjemploSimulacionRed.cs
│   │   ├── Servicios/              [Por implementar]
│   │   └── Interfaces/             [Por implementar]
│   │
│   ├── Persistencia/
│   │   ├── IDbConnectionFactory.cs
│   │   ├── MySqlConnection.cs
│   │   ├── Repositorios/           [Por implementar]
│   │   └── Entidades/              [Por implementar]
│   │
│   └── Tests/
│       ├── ServicioATests.cs        [Por implementar]
│       └── ServicioBTests.cs        [Por implementar]
│
└── scripts/
    ├── script1.sql
    └── script2.sql
```

---

## 🎓 Para Docentes

### Cómo usar este material:

1. **Introducción** (1 clase):
   - Proyectar DIAGRAMAS_ARQUITECTURA.md
   - Discutir qué hace cada dispositivo

2. **Análisis Conceptual** (2 clases):
   - Leer ACTIVIDADES_ANALISIS.md
   - Responder CUESTIONARIO_REFLEXIVO.md

3. **Análisis de Código** (3 clases):
   - Estudiar cada clase
   - Identificar validaciones
   - Explicar herencia y polimorfismo

4. **Ejercicios Prácticos** (4 clases):
   - Escribir tests
   - Extender con nuevos dispositivos
   - Implementar persistencia

### Evaluación:
- Cuestionario reflexivo respondido
- Tests unitarios escritos
- Extensiones del modelado
- Presentación de aprendizajes

---

## 💡 Ideas para Extensiones

### Fácil:
- Nueva clase `Impresora : DispositivoRed`
- Nueva clase `Servidor : DispositivoRed`
- Estadísticas por dispositivo

### Intermedio:
- Persistencia en MySQL
- Generador automático de tráfico
- Visualización en consola

### Avanzado:
- Interfaz gráfica (WPF/WinForms)
- Simulación de protocolos (ARP, DNS)
- Análisis de rendimiento
- Detectar cuellos de botella

---

## ✅ Checklist de Aprendizaje

- ⬜ Leí RESUMEN_EJECUTIVO.md
- ⬜ Leí ACTIVIDADES_ANALISIS.md
- ⬜ Estudié DIAGRAMAS_ARQUITECTURA.md
- ⬜ Respondí CUESTIONARIO_REFLEXIVO.md
- ⬜ Entiendo qué hace cada clase
- ⬜ Entiendo validaciones y encapsulamiento
- ⬜ Puedo explicar flujo de paquetes
- ⬜ Puedo escribir tests para nuevas clases
- ⬜ Puedo extender el modelado

---

## 🔗 Recursos Complementarios

- RFC 791: IPv4 Specification
- IEEE 802.3: Ethernet
- IEEE 802.11: Wireless LAN (WiFi)
- OWASP: Firewall Best Practices
- Cisco Packet Tracer: Network Simulation

---

## 📝 Notas

- Este proyecto es **educativo**, no de producción
- El modelado es **simplificado** para facilitar comprensión
- La simulación es **secuencial**, no paralela (por simplicidad)
- Enfasis en **principios de diseño**, no en rendimiento

---

## 👤 Autor

Proyecto creado con fines educativos para enseñar:
- Arquitectura de software
- Diseño orientado a objetos
- Modelado de dominios
- Conceptos de redes

---

**Última actualización**: Octubre 2026  
**Estado**: Completo y listo para usar  
**Versión**: 1.0