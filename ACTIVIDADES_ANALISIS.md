# Análisis de la Circulación de Paquetes en Redes de Datos

## ACTIVIDAD 1: Situación Inicial - Circulación de Paquetes

### ¿Cómo circula un paquete en una red?

Un paquete de datos es una **unidad de información** que se transmite de un dispositivo a otro. Su viaje por la red sigue este proceso:

```
[ORIGEN] → [ENRUTAMIENTO] → [CONMUTACIÓN] → [FILTRADO] → [DESTINO]
```

### Componentes clave de un paquete:

| Elemento | Descripción | Ejemplo |
|----------|-------------|---------|
| **Origen** | Dispositivo que envía el paquete | PC1 (192.168.1.10) |
| **Destino** | Dispositivo que recibe el paquete | Servidor (10.0.0.1) |
| **Contenido** | Datos que se transmiten | Solicitud HTTP |
| **Metadatos** | Info del protocolo | IP, MAC, puertos |

### Dispositivos que procesan el paquete:

#### 1. **Router**
- **Responsabilidad**: Decidir el camino del paquete
- **Herramienta**: Tabla de direccionamiento (routing table)
- **Regla**: "Mira la IP destino y envía al siguiente dispositivo"
- **Cambio de comportamiento**: Si no conoce la ruta → descarta o usa ruta por defecto

#### 2. **Switch**
- **Responsabilidad**: Conectar dispositivos en la misma red local
- **Herramienta**: Tabla MAC (direcciones físicas)
- **Regla**: "Busca la MAC destino y envía al puerto correcto"
- **Cambio de comportamiento**: Si no conoce la MAC → broadcast (envía a todos)

#### 3. **Access Point (AP)**
- **Responsabilidad**: Conectar dispositivos inalámbricos
- **Herramienta**: Lista de dispositivos conectados
- **Regla**: "Si el dispositivo está conectado, reenvía; si no, rechaza"
- **Cambio de comportamiento**: Si la señal es débil → rechaza o desconecta

#### 4. **Firewall**
- **Responsabilidad**: Proteger la red filtrando tráfico
- **Herramienta**: Reglas de seguridad (ACLs)
- **Regla**: "Aplica reglas: ¿permitir o rechazar este paquete?"
- **Cambio de comportamiento**: Según origen/destino/contenido → acepta o rechaza

### Situaciones donde el comportamiento cambia:

| Situación | Dispositivo | Comportamiento |
|-----------|-------------|----------------|
| Paquete para red desconocida | Router | Usa ruta por defecto o descarta |
| MAC destino no en tabla | Switch | Broadcast (envía a todos los puertos) |
| Dispositivo inalámbrico sin conexión | AP | Rechaza el paquete |
| Origen bloqueado | Firewall | Rechaza y registra intento |
| Búfer lleno | Router/Switch | Descarta paquetes (congestión) |
| Dispositivo inactivo | Cualquiera | No procesa paquetes |

---

## ACTIVIDAD 2: Lectura Diagnóstica de la Arquitectura

### Análisis de la Arquitectura Propuesta

```
APLICACION
  ├─ Modelos/        ← Aquí definimos los conceptos (PaqueteRed, DispositivoRed, etc.)
  ├─ Servicios/      ← Lógica de la simulación
  └─ Interfaces/     ← Contratos para extensibilidad

PERSISTENCIA
  ├─ Repositorios/   ← Acceso a datos (guardar resultados)
  ├─ Entidades/      ← Modelos de base de datos
  └─ Conexión DB     ← Manejo de conexión a MySQL

TESTS
  ├─ ServicioATests.cs  ← Validar lógica de dispositivos
  └─ ServicioBTests.cs  ← Validar flujo de paquetes
```

### Responsabilidades de cada capa:

#### **Capa de Aplicación (Aplicacion)**
**Responsabilidad**: Contiene la lógica de negocio de la simulación

- Definir QUÉ son los dispositivos, paquetes y la simulación
- Implementar la lógica de procesamiento
- Coordinar el flujo de ejecución
- NO debe conectarse directamente a BD

**Preguntas que responde**:
- ¿Cómo procesa el Router un paquete?
- ¿Qué hace un Firewall?
- ¿Cómo circula un paquete entre dispositivos?

#### **Capa de Persistencia (Persistencia)**
**Responsabilidad**: Guarda y recupera datos en base de datos

- Definir CÓMO se almacenan los resultados
- Gestionar conexiones a MySQL
- Proporcionar métodos para guardar paquetes, eventos, logs
- Ser independiente de la lógica de simulación

**Preguntas que responde**:
- ¿Dónde guardamos los resultados de la simulación?
- ¿Cómo conectamos a MySQL?
- ¿Qué datos necesitamos persistir?

#### **Capa de Tests (Tests)**
**Responsabilidad**: Validar que la aplicación funcione correctamente

- Probar que cada dispositivo procesa paquetes correctamente
- Verificar que las validaciones funcionan
- Confirmar que la simulación ejecuta sin errores
- Validar casos extremos y errores

**Preguntas que responde**:
- ¿El Router enruta correctamente?
- ¿El Firewall rechaza paquetes no permitidos?
- ¿Se pierden datos en congestión?

### Hipótesis iniciales sobre la arquitectura:

**✓ Lo que sí entendemos:**
1. Cada capa tiene responsabilidades separadas (Separation of Concerns)
2. Aplicación contiene la lógica, Persistencia el almacenamiento
3. Tests valida que todo funciona

**? Dudas a resolver durante la Indagación:**
1. ¿Cómo conectar Aplicación con Persistencia sin acoplamiento?
2. ¿Qué patrón usar: Repository Pattern, Dependency Injection?
3. ¿Cómo manejar excepciones y logs?
4. ¿Qué eventos de la simulación debemos persistir?
5. ¿Cómo hacer la simulación determinística para tests?

### Pruebas Unitarias - Qué entendemos:

**Definición**: Validan que una unidad de código (método/clase) funciona correctamente en aislamiento

**Lo que debería validar el proyecto Tests**:
- ✓ PaqueteRed: Validaciones de constructor (origen, destino, contenido no vacíos)
- ✓ Router: Enrutamiento correcto, manejo de búfer lleno
- ✓ Switch: Registro de MACs, broadcast cuando no encuentra destino
- ✓ AccessPoint: Conexión/desconexión, rechazo si no está activo
- ✓ Firewall: Aplicación de reglas, rechazo de paquetes bloqueados
- ✓ Simulación: Creación de paquetes, ejecución de pasos

---

## ACTIVIDAD 3: Modelado Inicial de Clases

### Principios aplicados:

#### **1. Encapsulamiento**
- Variables privadas (`_nombre`, `_direccion`)
- Propiedades públicas con lógica de validación
- Métodos protegidos en clase base

```csharp
private string _nombre;
public string Nombre 
{ 
    get { return _nombre; }
    set { /* validación */ }
}
```

#### **2. Constructores**
- Inicializan el estado válido del objeto
- Realizan validaciones al crear
- Evitan crear objetos "a medio construir"

```csharp
public PaqueteRed(string origen, string destino, string contenido, int tamaño)
{
    Origen = origen;        // Valida mediante property
    Destino = destino;      // Valida mediante property
    // ...
}
```

#### **3. Propiedades**
- Controlan acceso a datos
- Validan cambios de estado
- Permiten cálculos bajo demanda

```csharp
public int Tamaño 
{ 
    get { return _tamaño; }
    set 
    { 
        if (value <= 0)
            throw new ArgumentException("Debe ser > 0");
        _tamaño = value;
    }
}
```

#### **4. Validaciones**
- En constructores: evita objetos inválidos
- En properties: valida cambios de estado
- En métodos: verifica precondiciones

```csharp
if (string.IsNullOrWhiteSpace(value))
    throw new ArgumentException("No puede estar vacío", nameof(Nombre));
```

### Estructura de clases creadas:

```
┌─ PaqueteRed
│  ├─ Propiedades: Id, Origen, Destino, Contenido, Tamaño, FechaCreacion
│  └─ Métodos: Constructor validado, ToString()
│
├─ DispositivoRed (CLASE BASE ABSTRACTA)
│  ├─ Propiedades: Nombre, Direccion, Activo, PaquetesRecibidos, PaquetesEnviados
│  ├─ Métodos: RecibirPaquete(), EnviarPaquete(), ProcesarPaquete() [abstracto]
│  └─ Herencia: Router, Switch, AccessPoint, Firewall
│
├─ Router : DispositivoRed
│  ├─ Propiedades: TablaDireccionamiento, CapacidadBufer, PaquetesPendientes
│  ├─ Métodos: AgregarRuta(), ObtenerProximoDispositivo(), EnrutarProximoPaquete()
│  └─ Responsabilidad: Enrutamiento IP
│
├─ Switch : DispositivoRed
│  ├─ Propiedades: TablaMac, CantidadPuertos, PuertosActivos
│  ├─ Métodos: RegistrarMac(), ObtenerPuertoMac(), EstablecerEstadoPuerto()
│  └─ Responsabilidad: Conmutación Ethernet
│
├─ AccessPoint : DispositivoRed
│  ├─ Propiedades: Ssid, PotenciaSeñal, AnchodeBanda, TipoSeguridad, DispositivosConectados
│  ├─ Métodos: ConectarDispositivo(), DesconectarDispositivo(), EstaDispositivoConectado()
│  └─ Responsabilidad: Conectividad inalámbrica
│
├─ Firewall : DispositivoRed
│  ├─ Propiedades: Reglas, ModoEstricto, PaquetesRechazo, PaquetesAceptados
│  ├─ Métodos: AgregarRegla(), EsPaquetePermitido()
│  ├─ Composición: ReglaFirewall
│  └─ Responsabilidad: Filtrado y seguridad
│
└─ Simulacion
   ├─ Propiedades: Nombre, Dispositivos, PaquetesSimulacion, EnEjecucion
   ├─ Métodos: AgregarDispositivo(), ObtenerDispositivo(), Iniciar(), Detener(), 
   │           CrearPaquete(), EjecutarPaso(), GenerarReporte()
   └─ Responsabilidad: Orquestación de la simulación
```

### Relaciones entre clases:

```
Simulacion
  ├── "contiene muchos" → DispositivoRed[]
  │                       ├── Router
  │                       ├── Switch
  │                       ├── AccessPoint
  │                       └── Firewall
  │
  ├── "contiene muchos" → PaqueteRed[]
  │
  └── DispositivoRed
       ├── "contiene muchos" → PaqueteRed[] (Recibidos)
       └── "contiene muchos" → PaqueteRed[] (Enviados)

Firewall
  └── "contiene muchos" → ReglaFirewall[]
```

---

## Próximos pasos:

1. **Implementar Servicios**: Crear lógica de orquestación
2. **Implementar Persistencia**: Guardar eventos en MySQL
3. **Escribir Tests**: Validar cada clase y método
4. **Crear UI**: Mostrar la simulación en acción
