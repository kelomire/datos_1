# 📊 TABLA VISUAL DE DATOS A INGRESAR

## PLANTILLA SIMPLE (COPIA Y USA)

```
╔════════════════════════════════════════════════════════════════╗
║                    DATOS A INGRESAR                           ║
╠════════════════════════════════════════════════════════════════╣
║                                                                ║
║  📝 Nombre Simulación:     Red Simple                         ║
║                                                                ║
║  🔧 DISPOSITIVOS                                              ║
║  ┌─────────────────────────────────────────────────────────┐ ║
║  │ Router          IP: 192.168.1.1                         │ ║
║  │ Switch          IP: 192.168.1.2       Puertos: 16      │ ║
║  │ Firewall        IP: 10.0.0.1                           │ ║
║  │ Access Point    IP: 192.168.1.100     SSID: MiRed      │ ║
║  │                                       Potencia: 80      │ ║
║  └─────────────────────────────────────────────────────────┘ ║
║                                                                ║
║  🛣️  RUTAS DEL ROUTER                                          ║
║  ┌─────────────────────────────────────────────────────────┐ ║
║  │ Destino: 10.0.0.0  →  Próximo: 192.168.1.2            │ ║
║  └─────────────────────────────────────────────────────────┘ ║
║                                                                ║
║  🖥️  MACs EN SWITCH                                            ║
║  ┌─────────────────────────────────────────────────────────┐ ║
║  │ MAC: 00:11:22:33:44:55        →  Puerto: 1            │ ║
║  └─────────────────────────────────────────────────────────┘ ║
║                                                                ║
║  📲 DISPOSITIVOS WIFI EN AP                                    ║
║  ┌─────────────────────────────────────────────────────────┐ ║
║  │ MAC: AA:BB:CC:DD:EE:FF                                 │ ║
║  └─────────────────────────────────────────────────────────┘ ║
║                                                                ║
║  🛡️  REGLAS FIREWALL                                           ║
║  ┌─────────────────────────────────────────────────────────┐ ║
║  │ Origen: *  →  Destino: *  →  PERMITIR                 │ ║
║  └─────────────────────────────────────────────────────────┘ ║
║                                                                ║
║  📦 PAQUETES                                                  ║
║  ┌─────────────────────────────────────────────────────────┐ ║
║  │ Origen: 192.168.1.1                                   │ ║
║  │ Destino: 192.168.1.100                                │ ║
║  │ Contenido: Ping                                       │ ║
║  │ Tamaño: 256 bytes                                    │ ║
║  └─────────────────────────────────────────────────────────┘ ║
║                                                                ║
║  ▶️  Pasos a ejecutar: 2                                      ║
║                                                                ║
╚════════════════════════════════════════════════════════════════╝
```

---

## TABLA DE DISPOSITIVOS

| Tipo | IP | Función | Parámetros |
|------|-----|---------|-----------|
| 🔀 Router | 192.168.1.1 | Enrutar paquetes | Tabla de rutas |
| 🔌 Switch | 192.168.1.2 | Conectar dispositivos | 16 puertos |
| 📶 Access Point | 192.168.1.100 | WiFi | SSID: MiRed, Potencia: 80% |
| 🛡️ Firewall | 10.0.0.1 | Seguridad | Reglas de filtrado |

---

## TABLA DE DIRECCIONES MAC

| Dispositivo | MAC | Puerto |
|-------------|-----|--------|
| PC Oficina | 00:11:22:33:44:55 | 1 |
| (Laptop WiFi) | AA:BB:CC:DD:EE:FF | - |

---

## TABLA DE RUTAS

| Destino | Próximo Dispositivo |
|---------|-------------------|
| 10.0.0.0 | 192.168.1.2 |

---

## TABLA DE REGLAS FIREWALL

| Origen | Destino | Acción |
|--------|---------|--------|
| * | * | PERMITIR |

---

## TABLA DE PAQUETES

| Origen | Destino | Contenido | Tamaño |
|--------|---------|-----------|--------|
| 192.168.1.1 | 192.168.1.100 | Ping | 256 |

---

## 3 EJEMPLOS LISTOS PARA USAR

### Ejemplo 1: Muy Simple (RECOMENDADO)

```
Red Simple
├─ Router:      192.168.1.1
├─ Switch:      192.168.1.2 (8 puertos)
├─ Firewall:    10.0.0.1
├─ AP:          192.168.1.100 (WiFi, 80%)
├─ Ruta:        10.0.0.0 → 192.168.1.2
├─ MAC Switch:  00:11:22:33:44:55 → Puerto 1
├─ MAC WiFi:    AA:BB:CC:DD:EE:FF
├─ Firewall:    * → * [PERMITIR]
├─ Paquete:     192.168.1.1 → 192.168.1.100 (256 bytes)
└─ Pasos:       2
```

### Ejemplo 2: Empresa Pequeña

```
Red Empresa
├─ Router:      10.0.0.1
├─ Switch:      10.0.0.2 (24 puertos)
├─ Firewall:    10.0.0.254
├─ AP:          10.0.0.100 (WiFi, 90%)
├─ Rutas:       
│  ├─ 192.168.1.0 → 10.0.0.2
│  └─ 8.8.8.8 → 10.0.0.254
├─ MACs Switch: 
│  ├─ 00:1A:2B:3C:4D:5E → Puerto 1
│  ├─ 00:1A:2B:3C:4D:5F → Puerto 2
│  └─ 00:1A:2B:3C:4D:60 → Puerto 3
├─ MACs WiFi:
│  ├─ AA:BB:CC:DD:EE:01
│  └─ AA:BB:CC:DD:EE:02
├─ Reglas:
│  ├─ * → 8.8.8.8 [PERMITIR]
│  └─ 10.0.0.* → 192.168.* [PERMITIR]
├─ Paquetes:
│  ├─ 10.0.0.1 → 10.0.0.100 (HTTP, 512)
│  └─ 10.0.0.1 → 10.0.0.254 (DNS, 128)
└─ Pasos:       3
```

### Ejemplo 3: Corporativa

```
Red Corporativa
├─ Router:      200.1.2.3
├─ Switch:      200.1.2.4 (48 puertos)
├─ Firewall:    200.1.2.254
├─ AP:          200.1.2.100 (WiFi, 95%)
├─ Rutas:
│  ├─ 0.0.0.0 → 200.1.2.4
│  ├─ 192.168.* → 200.1.2.4
│  └─ 172.16.* → 200.1.2.254
├─ MACs (5 dispositivos):
│  ├─ A1:B2:C3:D4:E5:F0 → Puerto 1
│  ├─ A1:B2:C3:D4:E5:F1 → Puerto 2
│  ├─ A1:B2:C3:D4:E5:F2 → Puerto 3
│  ├─ A1:B2:C3:D4:E5:F3 → Puerto 4
│  └─ A1:B2:C3:D4:E5:F4 → Puerto 5
├─ MACs WiFi (4 dispositivos):
│  ├─ FA:CE:B0:0C:00:01
│  ├─ FA:CE:B0:0C:00:02
│  ├─ FA:CE:B0:0C:00:03
│  └─ FA:CE:B0:0C:00:04
├─ Reglas:
│  ├─ * → * [PERMITIR]
│  ├─ 192.168.* → 172.16.* [PERMITIR]
│  └─ 172.16.100.* → * [RECHAZAR]
├─ Paquetes:
│  ├─ 200.1.2.1 → 200.1.2.100 (VLAN Setup, 512)
│  ├─ 200.1.2.1 → 200.1.2.2 (Broadcast, 256)
│  └─ 200.1.2.3 → 200.1.2.254 (Config, 384)
└─ Pasos:       5
```

---

## FLUJO VISUAL DE LA ENTRADA

```
                    INICIO
                      ↓
          ┌───────────────────────┐
          │ Nombre Simulación     │  "Red Simple"
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ Dispositivos          │  4 IPs
          │ (Router, Switch...)   │  
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ Configurar Rutas      │  IP → IP
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ Registrar MACs        │  Direcciones físicas
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ WiFi Access Point     │  MACs conectadas
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ Reglas Firewall       │  Origen→Destino
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ Crear Paquetes        │  Datos a enviar
          └───────────┬───────────┘
                      ↓
          ┌───────────────────────┐
          │ Ejecutar Pasos        │  Número de pasos
          └───────────┬───────────┘
                      ↓
                  REPORTE FINAL
```

---

## VALIDACIÓN RÁPIDA

✅ **Válido:**
- IP: 192.168.1.1 ✓
- MAC: AA:BB:CC:DD:EE:FF ✓
- Tamaño: 256 bytes ✓
- Puertos: 24 ✓

❌ **Inválido:**
- IP: 999.999.999.999 ✗
- MAC: AA:BB:CC:DD:EE (incompleto) ✗
- Tamaño: 999999 bytes ✗
- Puertos: -5 ✗

---

## HOJA DE REFERENCIA RÁPIDA

```
COPIAR-PEGAR ESTOS VALORES:

SIMPLE:
Red Simple | 192.168.1.1 | 192.168.1.2 | 16 | 10.0.0.1 | 192.168.1.100 | MiRed | 80
10.0.0.0→192.168.1.2 | 00:11:22:33:44:55→1 | AA:BB:CC:DD:EE:FF | *→*[s] | 192.168.1.1→192.168.1.100[Ping, 256] | 2

EMPRESA:
Red Empresa | 10.0.0.1 | 10.0.0.2 | 24 | 10.0.0.254 | 10.0.0.100 | Corp | 90
192.168.0→10.0.0.2 | 00:1A:2B:3C:4D:5E→1 | AA:BB:CC:DD:EE:01 | *→8.8.8.8[s] | 10.0.0.1→10.0.0.100[HTTP, 512] | 3
```

---

**Documentos relacionados:**
- 📖 [EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md) - Ejemplos detallados
- ⚡ [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md) - Guía rápida
- 📊 [Esta tabla](TABLA_DATOS.md) - Referencia visual
