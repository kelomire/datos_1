# 📖 EJEMPLOS DE DATOS PARA INGRESAR EN EL SIMULADOR

## Ejemplo 1: Red Pequeña Simple (RECOMENDADO PARA EMPEZAR)

### Paso a Paso:

```
┌─────────────────────────────────────────────────────┐
│ 📝 Ingrese nombre de la simulación:                  │
│ → Red Simple                                         │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📍 IP del Router:                                    │
│ → 192.168.1.1                                       │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📍 IP del Switch:                                    │
│ → 192.168.1.2                                       │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 🔌 Cantidad de puertos:                              │
│ → 16                                                │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📍 IP del Firewall:                                  │
│ → 10.0.0.1                                          │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📍 IP del Access Point:                              │
│ → 192.168.1.50                                      │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📶 SSID (nombre WiFi):                               │
│ → HomeWiFi                                          │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📊 Potencia señal (0-100):                           │
│ → 80                                                │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 🛣️  Destino IP para ruta:                            │
│ → 10.0.0.0                                          │
│ Próximo dispositivo:                                │
│ → 192.168.1.2                                       │
│ ¿Agregar otra? → n                                  │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 🖥️  MAC para Switch:                                 │
│ → 00:11:22:33:44:55                                 │
│ Puerto: → 1                                         │
│ ¿Otra MAC? → n                                      │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📲 MAC WiFi para Access Point:                       │
│ → AA:BB:CC:DD:EE:FF                                 │
│ ¿Otra? → n                                          │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 🛡️  Regla Firewall:                                  │
│ Origen: → *                                         │
│ Destino: → *                                        │
│ ¿Permitir? → s                                      │
│ ¿Otra regla? → n                                    │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ 📦 Paquete a crear:                                  │
│ Origen: → 192.168.1.1                               │
│ Destino: → 192.168.1.50                             │
│ Contenido: → Ping                                   │
│ Tamaño: → 64                                        │
│ ¿Otro? → n                                          │
└─────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────┐
│ ▶️  Pasos a ejecutar:                                │
│ → 2                                                 │
└─────────────────────────────────────────────────────┘
```

---

## Ejemplo 2: Red Corporativa Completa (AVANZADO)

```
📝 Simulación: Red Empresa ABC

📍 Router: 10.0.0.1
📍 Switch: 10.0.0.2  (Puertos: 48)
📍 Firewall: 10.0.0.254
📍 Access Point: 10.0.0.100 (SSID: EmpresaWiFi, Potencia: 90)

🛣️  RUTAS:
  └─ Destino: 192.168.1.0 → Próximo: 10.0.0.2
  └─ Destino: 172.16.0.0 → Próximo: 10.0.0.254
  └─ Destino: 8.8.8.8 → Próximo: 10.0.0.254

🖥️  MACs EN SWITCH:
  └─ 00:1A:2B:3C:4D:5E → Puerto 1  (PC Oficina 1)
  └─ 00:1A:2B:3C:4D:5F → Puerto 2  (PC Oficina 2)
  └─ 00:1A:2B:3C:4D:60 → Puerto 3  (Servidor)
  └─ 00:1A:2B:3C:4D:61 → Puerto 4  (Impresora)

📲 WiFi EN ACCESS POINT:
  └─ AA:BB:CC:DD:EE:01  (Laptop 1)
  └─ AA:BB:CC:DD:EE:02  (Laptop 2)
  └─ AA:BB:CC:DD:EE:03  (Tablet)

🛡️  REGLAS FIREWALL:
  └─ * → 8.8.8.8 [PERMITIR]
  └─ 10.0.0.* → 192.168.1.* [PERMITIR]
  └─ 172.16.0.* → * [RECHAZAR]

📦 PAQUETES:
  └─ 10.0.0.1 → 10.0.0.100 (HTTP GET, 256 bytes)
  └─ 10.0.0.1 → 10.0.0.254 (DNS Query, 128 bytes)

▶️  Pasos: 5
```

---

## Ejemplo 3: Red Académica (EDUCATIVO)

```
📝 Simulación: Red Universidad

📍 Router Principal: 192.168.10.1
📍 Switch Principal: 192.168.10.2  (Puertos: 32)
📍 Firewall: 200.1.2.3
📍 Access Point 1: 192.168.10.100 (SSID: UniversityWiFi, Potencia: 95)

🛣️  RUTAS:
  └─ Destino: 0.0.0.0 → Próximo: 200.1.2.3  (Ruta por defecto)

🖥️  MACs (Laboratorio de Informática):
  └─ A1:B2:C3:D4:E5:F0 → Puerto 1
  └─ A1:B2:C3:D4:E5:F1 → Puerto 2
  └─ A1:B2:C3:D4:E5:F2 → Puerto 3
  └─ A1:B2:C3:D4:E5:F3 → Puerto 4
  └─ A1:B2:C3:D4:E5:F4 → Puerto 5

📲 WiFi (Estudiantes):
  └─ FA:CE:B0:0C:00:01
  └─ FA:CE:B0:0C:00:02
  └─ FA:CE:B0:0C:00:03
  └─ FA:CE:B0:0C:00:04

🛡️  REGLAS FIREWALL:
  └─ * → * [PERMITIR]  (Permisivo para educación)

📦 PAQUETES (Simulan comunicación):
  └─ 192.168.10.1 → 192.168.10.2 (VLAN Setup, 512)
  └─ 192.168.10.1 → 192.168.10.100 (Broadcast, 256)

▶️  Pasos: 3
```

---

## Referencia Rápida de Direcciones IP

### Direcciones Privadas Comunes:

```
📍 Rango 192.168.x.x (Pequeñas redes - HOGAR/PYME)
   Router:  192.168.1.1
   Switch:  192.168.1.2
   AP:      192.168.1.100
   Clientes: 192.168.1.10-50

📍 Rango 10.0.0.x (Redes grandes - CORPORATIVO)
   Router:  10.0.0.1
   Switch:  10.0.0.2
   Firewall: 10.0.0.254
   AP:      10.0.0.100
   Clientes: 10.0.0.10-200

📍 Rango 172.16.x.x (Redes muy grandes)
   Usado en empresas grandes
```

---

## Formatos de Direcciones MAC

### Ejemplos Válidos:

```
✓ 00:11:22:33:44:55        (Formato estándar con dos puntos)
✓ 00-11-22-33-44-55        (Con guiones)
✓ AA:BB:CC:DD:EE:FF        (Letras mayúsculas)
✓ aa:bb:cc:dd:ee:ff        (Letras minúsculas)

Patrones para usar:
├─ Oficina 1:        00:1A:2B:3C:4D:5E
├─ Oficina 2:        00:1A:2B:3C:4D:5F
├─ Servidor:         00:1A:2B:3C:4D:60
├─ Impresora:        00:1A:2B:3C:4D:61
├─ Laptop 1:         AA:BB:CC:DD:EE:01
├─ Laptop 2:         AA:BB:CC:DD:EE:02
└─ Tablet:           AA:BB:CC:DD:EE:03
```

---

## Patrones de Firewall

### Reglas Útiles:

```
1️⃣  Permitir todo (Permisivo):
   Origen: *
   Destino: *
   Acción: PERMITIR

2️⃣  Bloquear una red:
   Origen: 192.168.100.*
   Destino: *
   Acción: RECHAZAR

3️⃣  Permitir a Internet:
   Origen: 192.168.*
   Destino: 8.8.8.8
   Acción: PERMITIR

4️⃣  Permitir red interna:
   Origen: 192.168.1.*
   Destino: 10.0.0.*
   Acción: PERMITIR

5️⃣  Bloquear todo menos específicos (Estricto):
   Origen: *
   Destino: *
   Acción: RECHAZAR
   Luego agregar solo lo necesario
```

---

## Contenidos de Paquetes

### Ejemplos Comunes:

```
Protocol/Service    | Contenido          | Tamaño Típico
--------------------|-------------------|---------------
HTTP                | GET /index.html    | 256-512
HTTPS               | Encrypted Data     | 256-1024
DNS                 | Query              | 64-128
ICMP (Ping)         | Echo Request       | 64
FTP                 | File Transfer      | 512-65535
SSH                 | Remote Login       | 512
SMTP                | Email              | 256-1024
TCP                 | Connection Setup   | 256
UDP                 | Video Stream       | 1024-4096
```

---

## Tamaños de Paquete

```
📊 Rango de Tamaños:

Muy pequeño:   32-64 bytes     (Ping, ACK)
Pequeño:       64-256 bytes    (DNS, pequeños comandos)
Mediano:       256-1024 bytes  (HTTP, correos pequeños)
Grande:        1024-4096 bytes (Archivos, videos)
Muy grande:    4096-65535      (Archivos grandes, transferencias)

⚠️  LÍMITE: 65535 bytes (máximo en IPv4)
```

---

## Sesión Completa Ejemplo

### Entrada paso a paso:

```
Nombre Simulación: Red Test Educativa
IP Router: 192.168.1.1
IP Switch: 192.168.1.2
Puertos: 8
IP Firewall: 10.0.0.1
IP Access Point: 192.168.1.50
SSID: TestLab
Potencia: 75

RUTAS (pregunta 1):
  Destino: 10.0.0.0
  Próximo: 192.168.1.2
  ¿Otra?: n

MACs SWITCH (pregunta 1):
  MAC: 00:11:22:33:44:55
  Puerto: 1
  ¿Otra?: n

WIFI ACCESS POINT (pregunta 1):
  MAC: AA:BB:CC:DD:EE:FF
  ¿Otra?: n

FIREWALL RULES (pregunta 1):
  Origen: *
  Destino: *
  ¿Permitir?: s
  ¿Otra?: n

PAQUETES (pregunta 1):
  Origen: 192.168.1.1
  Destino: 192.168.1.50
  Contenido: Test Packet
  Tamaño: 128
  ¿Otro?: n

PASOS: 2
```

---

## Consejos para Ingresar Datos

✅ **Hazlo así:**
```
1. Empieza con valores simples y pequeños
2. Usa direcciones IP en rango privado (192.168.x.x)
3. No más de 5 MACs la primera vez
4. Reglas de firewall simples
5. Paquetes entre 64-512 bytes
6. Ejecuta 2-3 pasos primero
```

❌ **Evita esto:**
```
1. Direcciones IPs muy complicadas
2. Nombres largos o con caracteres especiales
3. Muchas reglas de firewall complejas
4. Paquetes de 65535 bytes en pruebas iniciales
5. 20+ pasos en simulación
```

---

## Copia y Pega Rápida

### Opción 1: Simple (RECOMENDADO)
```
Simulación: Red Simple
Router: 192.168.1.1
Switch: 192.168.1.2
Puertos: 16
Firewall: 10.0.0.1
AP: 192.168.1.100
SSID: MyNet
Potencia: 85

Ruta 1: 10.0.0.0 → 192.168.1.2
MAC 1: 00:11:22:33:44:55 → Puerto 1
WiFi 1: AA:BB:CC:DD:EE:FF
Regla 1: * → * [PERMITIR]
Paquete 1: 192.168.1.1 → 192.168.1.100 (Test, 256)
Pasos: 2
```

### Opción 2: Corporativa
```
Simulación: Red Empresa
Router: 10.0.0.1
Switch: 10.0.0.2
Puertos: 32
Firewall: 10.0.0.254
AP: 10.0.0.100
SSID: CorporateWiFi
Potencia: 90

Rutas: 10.0.0.0→10.0.0.2, 8.8.8.8→10.0.0.254
MACs: 00:1A:2B:3C:4D:5E→1, 00:1A:2B:3C:4D:5F→2
WiFis: AA:BB:CC:DD:EE:01, AA:BB:CC:DD:EE:02
Reglas: *→*[PERMITIR], 192.168.*→10.0.0.*[PERMITIR]
Paquetes: 10.0.0.1→10.0.0.100 (HTTP, 512)
Pasos: 3
```

---

**¿Necesitas más ejemplos específicos? Pregunta en la sesión interactiva. 🚀**
