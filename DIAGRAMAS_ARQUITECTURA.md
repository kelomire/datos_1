# Diagramas de Arquitectura - Simulación de Redes

## Diagrama 1: Flujo de un Paquete por Dispositivos

```
┌─────────────┐
│  ORIGEN     │ (PC, Servidor, etc)
│ 192.168.1.5 │
└──────┬──────┘
       │ Paquete: 192.168.1.5 → 8.8.8.8
       ▼
┌──────────────────┐
│   FIREWALL       │ (Validar reglas)
│ 10.0.0.1         │
└──────┬───────────┘
       │ ¿Permitido? ✓ Sí
       ▼
┌──────────────────┐
│   ROUTER         │ (Enrutar según destino)
│ 192.168.1.1      │
└──────┬───────────┘
       │ ¿Ruta conocida? Sí → ISP
       ▼
┌──────────────────┐
│   SWITCH         │ (Encontrar puerto MAC)
│ 192.168.1.2      │
└──────┬───────────┘
       │ ¿MAC en tabla? Sí → Puerto 5
       ▼
┌─────────────────┐
│  DESTINO        │
│  8.8.8.8        │
└─────────────────┘
```

---

## Diagrama 2: Jeraquía de Clases

```
                    ┌─────────────────────┐
                    │  DispositivoRed     │ (Abstracta)
                    │  - Nombre           │
                    │  - Direccion        │
                    │  - Activo           │
                    │  - PaquetesRec[]    │
                    │  - PaquetesEnv[]    │
                    │  + ProcesarPaquete()│ ← ABSTRACTO
                    └────────┬────────────┘
                             │
             ┌───────────────┼───────────────┬──────────────┐
             │               │               │              │
             ▼               ▼               ▼              ▼
        ┌────────┐    ┌────────┐    ┌──────────┐    ┌───────────┐
        │ Router │    │ Switch │    │AccessPt. │    │ Firewall  │
        ├────────┤    ├────────┤    ├──────────┤    ├───────────┤
        │- Tabla │    │- Tabla │    │- SSID    │    │- Reglas[] │
        │  Rut[] │    │  MAC[] │    │- Potencia│    │- Estricto │
        │- Bufer │    │- Puert │    │- Ancho   │    │- Aceptados│
        │- Capac │    │  os[]  │    │- Segur.  │    │- Rechazad │
        └────────┘    └────────┘    └──────────┘    └───────────┘
```

---

## Diagrama 3: Composición de la Simulación

```
┌─────────────────────────────────────────────┐
│           Simulacion                        │
│  - Nombre                                   │
│  - Dispositivos[] ──┬──────────────────┐    │
│  - Paquetes[]    ───┼──────────────┐   │    │
│  - EnEjecucion   ───┼──────────────┼───┼────┼─────────────────┐
│  + Iniciar()        │              │   │    │                 │
│  + EjecutarPaso()   │              │   │    │                 │
│  + Detener()        │              │   │    │                 │
│  + CrearPaquete()   │              │   │    │                 │
│  + GenerarReporte() │              │   │    │                 │
└─────────────────────┼──────────────┼───┼────┘                 │
                      │              │   │                      │
         ┌────────────┴──────┐  ┌────┴───┴──────────────┐       │
         │                   │  │                       │       │
         ▼                   ▼  ▼                       ▼       ▼
    ┌─────────────┐  ┌──────────────┐            ┌────────────────┐
    │ Router      │  │ Switch       │   ...      │ PaqueteRed     │
    │ AP          │  │ Firewall     │            │ - Origen       │
    │ ...         │  │ ...          │            │ - Destino      │
    └─────────────┘  └──────────────┘            │ - Contenido    │
                                                  │ - Tamaño       │
                                                  │ - FechaCreacion│
                                                  └────────────────┘
```

---

## Diagrama 4: Flujo de Ejecución de Simulacion

```
┌──────────────────────┐
│  new Simulacion()    │ → Estado: Inicializado
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│ AgregarDispositivo() │ → Agrega Router, Switch, AP, Firewall
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│  Iniciar()           │ → Estado: EnEjecucion = true
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│ CrearPaquete()       │ (Múltiples veces)
│ - Valida origen      │ → Paquete en lista
│ - Valida destino     │    y en dispositivo origen
│ - Crea PaqueteRed    │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│ EjecutarPaso()       │ (Múltiples veces)
│ - Para cada dispositivo:
│   - Si está activo:
│     - Procesa paquetes pendientes
│     - Cada dispositivo aplica su lógica
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│  Detener()           │ → Estado: EnEjecucion = false
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│ GenerarReporte()     │ → Estadísticas finales
└──────────────────────┘
```

---

## Diagrama 5: Procesamiento de Paquete en Router

```
CrearPaquete()
│
├─ PaqueteRed validado ✓
│  (origen, destino, tamaño OK)
│
└─ dispositivo.RecibirPaquete()
   │
   ├─ Agrega a PaquetesRecibidos[]
   │
   └─ EjecutarPaso()
      │
      ├─ Detecta paquete no enviado
      │
      └─ router.ProcesarPaquete()
         │
         ├─ Valida paquete
         │
         ├─ Encola en Bufer
         │  (si hay espacio)
         │
         └─ EnrutarProximoPaquete()
            │
            ├─ Desenrola del Bufer
            │
            ├─ Busca en TablaDireccionamiento[destino]
            │  ¿Encontrada?
            │  ├─ Sí → Próximo dispositivo
            │  └─ No → Excepción
            │
            └─ router.EnviarPaquete()
               │
               └─ Agrega a PaquetesEnviados[]
                  (Listo para siguiente dispositivo)
```

---

## Diagrama 6: Filtrado en Firewall

```
Firewall.ProcesarPaquete(paquete)
│
├─ Reglas[] vacío?
│  ├─ Sí y ModoEstricto=true → Rechaza (PaquetesRechazo++)
│  └─ Sí y ModoEstricto=false → Acepta (PaquetesAceptados++)
│
└─ Para cada Regla en Reglas[]:
   │
   ├─ ¿Coincide patrón?
   │  (origen y destino)
   │
   ├─ Sí:
   │  └─ Regla.Permitir?
   │     ├─ true → Acepta y retorna
   │     └─ false → Rechaza y retorna
   │
   └─ No: Continúa siguiente regla
   
Si no hay coincidencias:
│
├─ ModoEstricto = true → Rechaza (Whitelist)
└─ ModoEstricto = false → Acepta (Blacklist)

Resultado:
├─ Acepta → PaquetesAceptados++
│           EnviarPaquete()
└─ Rechaza → PaquetesRechazo++
            Excepción
```

---

## Diagrama 7: Arquitectura por Capas

```
┌──────────────────────────────────────────────────────────┐
│                    PRESENTACION                          │
│ (Consola, Web, Desktop - aún no implementada)           │
└─────────────────┬──────────────────────────────────────┘
                  │
┌─────────────────▼──────────────────────────────────────┐
│                 APLICACION (Business Logic)            │
│ ┌────────────────────────────────────────────────────┐ │
│ │ Modelos: PaqueteRed, DispositivoRed, etc.        │ │
│ │ Servicios: Simuladores, Generadores de tráfico   │ │
│ │ Interfaces: Contratos para extensibilidad        │ │
│ └────────────────────────────────────────────────────┘ │
│ ↓ Dependencia → (Interfaces)                          │
└─────────────────┬──────────────────────────────────────┘
                  │
┌─────────────────▼──────────────────────────────────────┐
│              PERSISTENCIA (Data Access)               │
│ ┌────────────────────────────────────────────────────┐ │
│ │ Repositorios: Guardar/Recuperar datos            │ │
│ │ Entidades: Mapeo a BD                            │ │
│ │ Conexión: MySQL, SQL Server, etc.                │ │
│ └────────────────────────────────────────────────────┘ │
└─────────────────┬──────────────────────────────────────┘
                  │
┌─────────────────▼──────────────────────────────────────┐
│              BASE DE DATOS (MySQL)                     │
│ ├─ Paquetes                                           │
│ ├─ Eventos                                            │
│ └─ Configuraciones                                    │
└──────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────┐
│                    TESTS (Quality Assurance)            │
│ ├─ Unitarios (Modelos)                                 │
│ ├─ Integración (Aplicacion + Persistencia)             │
│ └─ End-to-End (Simulación completa)                    │
└──────────────────────────────────────────────────────────┘
```

---

## Diagrama 8: Ciclo de Vida de un Paquete

```
ETAPA 1: CREACIÓN
├─ new PaqueteRed(origen, destino, contenido, tamaño)
├─ Validaciones ejecutadas
└─ Id único generado

ETAPA 2: INYECCIÓN
├─ simulacion.CrearPaquete()
├─ Paquete agregado a Simulacion.Paquetes[]
└─ Paquete agregado a dispositivo.PaquetesRecibidos[]

ETAPA 3: PROCESAMIENTO (por dispositivo)
├─ Router:
│  ├─ Encola en búfer
│  └─ Busca ruta en tabla
│
├─ Switch:
│  ├─ Busca MAC en tabla
│  └─ Envía al puerto correspondiente
│
├─ Firewall:
│  ├─ Evalúa reglas
│  └─ Acepta/Rechaza
│
└─ AccessPoint:
   ├─ Verifica conexión WiFi
   └─ Envía si está en rango

ETAPA 4: ENVÍO
├─ dispositivo.EnviarPaquete()
├─ Agregado a PaquetesEnviados[]
└─ Listo para siguiente dispositivo

ETAPA 5: PERSISTENCIA
├─ Guardado en base de datos
└─ Disponible para reportes

ETAPA 6: ANÁLISIS
├─ Estadísticas generadas
├─ Reportes creados
└─ Simulación completada
```

---

## Diagrama 9: Ejemplo de Flujo Real

```
Simulación: "Red Corporativa"

ESTADO INICIAL:
├─ Router: 192.168.1.1
├─ Switch: 192.168.1.2
├─ Firewall: 10.0.0.1
└─ AP: 192.168.1.100

CONFIGURACIÓN:
├─ Router.AgregarRuta("10.0.0.0", "192.168.1.2")
├─ Switch.RegistrarMac("AA:BB:CC:DD:EE:01", 1)
├─ AP.ConectarDispositivo("AA:BB:CC:DD:EE:11")
└─ Firewall.AgregarRegla(ReglaFirewall("*", "8.8.8.8", true))

EJECUCIÓN:

Paso 1:
├─ CrearPaquete("192.168.1.50", "8.8.8.8", "HTTP GET", 256)
├─ PaqueteRed creado y validado
└─ Router.RecibirPaquete()

Paso 2:
├─ Router.EjecutarPaso()
├─ Router busca ruta → "10.0.0.1" (Firewall)
└─ Router envía a Firewall

Paso 3:
├─ Firewall.EjecutarPaso()
├─ Firewall evalúa regla → permitir (destino 8.8.8.8)
├─ Firewall.PaquetesAceptados++ (1)
└─ Firewall envía (en simulación real, a ISP)

FINAL:
├─ Simulacion.GenerarReporte()
├─ ✓ Paquetes procesados: 1
├─ ✓ Router: 1 enviado
├─ ✓ Firewall: 1 aceptado
└─ [Guardado en BD para análisis]
```

---

## Notas de Diseño

### ¿Por qué DispositivoRed es abstracta?
- No existe un dispositivo "genérico" que implemente todos los comportamientos
- Cada subclase implementa `ProcesarPaquete()` de forma diferente
- Obliga a crear dispositivos específicos válidos

### ¿Por qué Simulacion no hereda de DispositivoRed?
- Simulacion NO es un dispositivo
- Es un orquestador que CONTIENE dispositivos
- Responsabilidad diferente: gestionar, no procesar paquetes

### ¿Por qué usamos IReadOnly...?
- Evita que código externo modifique estructuras internas
- Obliga a usar métodos públicos (que validan)
- Mantiene invariantes de la clase

### ¿Por qué validar en propiedades?
- Detecta errores lo antes posible
- Mantiene objeto siempre en estado válido
- Facilita debugging
