# ⚡ GUÍA RÁPIDA - QUÉ INGRESAR

## 🚀 OPCIÓN RÁPIDA (2 minutos)

Copia y pega estos valores cuando se te pida:

```
PREGUNTA                        → RESPUESTA
─────────────────────────────────────────────────────
📝 Nombre simulación            → Red Simple
📍 IP del Router                → 192.168.1.1
📍 IP del Switch                → 192.168.1.2
🔌 Cantidad de puertos           → 16
📍 IP del Firewall              → 10.0.0.1
📍 IP del Access Point          → 192.168.1.100
📶 SSID WiFi                    → MiRed
📊 Potencia señal               → 80

🛣️  Destino IP ruta             → 10.0.0.0
    Próximo dispositivo         → 192.168.1.2
    ¿Agregar otra? (s/n)        → n

🖥️  MAC para Switch             → 00:11:22:33:44:55
    Número puerto               → 1
    ¿Otra MAC? (s/n)            → n

📲 MAC WiFi para AP             → AA:BB:CC:DD:EE:FF
   ¿Otra? (s/n)                → n

🛡️  Origen Firewall             → *
    Destino Firewall            → *
    ¿Permitir? (s/n)            → s
    ¿Otra regla? (s/n)          → n

📦 IP origen paquete            → 192.168.1.1
   IP destino paquete          → 192.168.1.100
   Contenido paquete           → Ping
   Tamaño paquete              → 256
   ¿Otro paquete? (s/n)        → n

▶️  Pasos simulación             → 2
```

---

## 📋 EXPLICACIÓN DE CADA CAMPO

### 📝 Nombre de Simulación
```
¿Qué es? Tu etiqueta para esta simulación
Ejemplo: "Red Simple", "Red Empresa", "Red Test"
Recomendación: Algo descriptivo y corto
```

### 📍 IPs de Dispositivos
```
¿Qué son? Direcciones identificadoras
Formato: xxx.xxx.xxx.xxx

Recomendados:
├─ Router:    192.168.1.1      (puerta de entrada)
├─ Switch:    192.168.1.2      (conecta dispositivos)
├─ AP WiFi:   192.168.1.100    (red inalámbrica)
└─ Firewall:  10.0.0.1         (seguridad)
```

### 🔌 Cantidad de Puertos
```
¿Qué es? Cuántos puertos tiene el Switch
Valores válidos: 1-100
Recomendaciones:
├─ Pequeño (hogar):   8-16 puertos
├─ Mediano (oficina):  24 puertos
└─ Grande (empresa):   48 puertos
```

### 📶 SSID WiFi
```
¿Qué es? Nombre de tu red inalámbrica
Ejemplo: "MiRed", "HomeWiFi", "OfficePro"
Recomendación: Algo que puedas identificar
```

### 📊 Potencia Señal WiFi
```
¿Qué es? Fuerza de la señal (0-100)
0 = Sin señal
50 = Débil
80 = Buena
100 = Excelente

Recomendación: 75-90 para simulación
```

### 🛣️  Rutas del Router
```
¿Qué es? Cómo el router sabe dónde enviar paquetes
Destino IP: A dónde quieres enviar
Próximo: A qué dispositivo lo envías

Ejemplo:
└─ 10.0.0.0 → 192.168.1.2 (red corporativa vía switch)
```

### 🖥️  Direcciones MAC
```
¿Qué es? Dirección física de dispositivo en la red
Formato: AA:BB:CC:DD:EE:FF (12 caracteres hexadecimales)

Ejemplos válidos:
├─ 00:11:22:33:44:55
├─ AA:BB:CC:DD:EE:FF
├─ de:ad:be:ef:ca:fe
└─ 00:1a:2b:3c:4d:5e
```

### 📲 MACs en Access Point
```
¿Qué es? Dispositivos conectados al WiFi
Ejemplo: Laptops, tablets, teléfonos

Simplemente ingresa sus direcciones MAC
```

### 🛡️  Reglas del Firewall
```
¿Qué es? Quién puede comunicarse con quién
Origen: De dónde vienen los paquetes
Destino: A dónde van los paquetes
Acción: PERMITIR o RECHAZAR

Ejemplos:
├─ * → * [PERMITIR]              (dejar todo pasar)
├─ 192.168.* → 10.0.* [PERMITIR] (red privada OK)
└─ 192.168.100.* → * [RECHAZAR]  (bloquear esa red)

* = cualquier dirección
```

### 📦 Paquetes
```
¿Qué es? Datos que circulan por la red
Origen: De qué dispositivo sale
Destino: A qué dispositivo va
Contenido: Qué tipo de datos (texto libre)
Tamaño: Bytes (1-65535)

Ejemplo:
└─ De 192.168.1.1 a 192.168.1.100
   Contenido: "HTTP GET"
   Tamaño: 256 bytes
```

### ▶️  Pasos de Simulación
```
¿Qué es? Cuántos pasos ejecutar
Cada paso = procesamiento de dispositivos

Recomendación: 2-5 pasos iniciales
```

---

## 🎯 VALORES SEGUROS (ÚSALOS SI DUDA)

```
Si no sabes qué poner, usa SIEMPRE estos:

Nombre:        Red Demo
Router:        192.168.1.1
Switch:        192.168.1.2
Puertos:       16
Firewall:      10.0.0.1
AP:            192.168.1.100
SSID:          WiFiTest
Potencia:      80
Ruta:          10.0.0.0 → 192.168.1.2
MAC:           00:11:22:33:44:55
Puerto MAC:    1
MAC WiFi:      AA:BB:CC:DD:EE:FF
Firewall:      * → * [PERMITIR]
Paquete:       192.168.1.1 → 192.168.1.100
Contenido:     Test
Tamaño:        256
Pasos:         2
```

---

## ⚠️ ERRORES COMUNES (Y CÓMO EVITARLOS)

### ❌ IP no encontrada
```
PROBLEMA: Ingresaste una IP que no es dispositivo
SOLUCIÓN: Usa solo las IPs que configuraste:
  - 192.168.1.1 (Router)
  - 192.168.1.2 (Switch)
  - 192.168.1.100 (AP)
  - 10.0.0.1 (Firewall)
```

### ❌ MAC duplicada
```
PROBLEMA: Ingresaste la misma MAC dos veces
SOLUCIÓN: Cada MAC debe ser única:
  - Dispositivo 1: 00:11:22:33:44:55
  - Dispositivo 2: 00:11:22:33:44:56  ← diferente
```

### ❌ Puerto inválido
```
PROBLEMA: Número de puerto mayor que cantidad de puertos
SOLUCIÓN: Si dijiste 16 puertos, usa 1-16
```

### ❌ Tamaño de paquete inválido
```
PROBLEMA: Valor < 1 o > 65535
SOLUCIÓN: Usa: 64, 128, 256, 512, 1024, etc.
```

---

## 🔥 EJEMPLO COMPLETO DE ENTRADA/SALIDA

### TU ENTRADA:
```
Simulación: Red Escuela
Router: 192.168.1.1
Switch: 192.168.1.2
Puertos: 8
Firewall: 10.0.0.1
AP: 192.168.1.50
SSID: SchoolWiFi
Potencia: 90
Ruta: 10.0.0.0 → 192.168.1.2
MACs: 00:1a:2b:3c:4d:5e (puerto 1)
WiFi: AA:BB:CC:DD:EE:01
Regla: * → * [PERMITIR]
Paquete: 192.168.1.1 → 192.168.1.50 ("Datos", 256)
Pasos: 3
```

### SALIDA DEL PROGRAMA:
```
✓ Simulación creada: Red Escuela
✓ Router agregado: 192.168.1.1
✓ Switch agregado: 192.168.1.2 (8 puertos)
✓ Firewall agregado: 10.0.0.1
✓ Access Point agregado: 192.168.1.50
✓ Ruta agregada: 10.0.0.0 → 192.168.1.2
✓ MAC registrada: 00:1a:2b:3c:4d:5e en puerto 1
✓ Dispositivo WiFi conectado: AA:BB:CC:DD:EE:01
✓ Regla agregada: * → * [PERMITIR]
✓ Paquete creado: 192.168.1.1 → 192.168.1.50
✓ Simulación ejecutada: 3 pasos completados

📊 REPORTE:
   Dispositivos: 4
   Paquetes procesados: 1
   Estado: Completado en 0.05s
```

---

**¿Listo para probar? ¡Ejecuta el programa y usa estos valores! 🚀**

Ver más ejemplos: `EJEMPLOS_DATOS.md`
