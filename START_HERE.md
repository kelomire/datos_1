# ⚡ START HERE - COMIENZA AQUÍ

## Si quieres ejecutar el programa en 5 minutos:

### 1️⃣ Compila el proyecto
```bash
cd /home/et12alumno/datos_1
dotnet build
```

### 2️⃣ Abre esta carpeta para valores por defecto
```
GUIA_RAPIDA_ENTRADA.md    ← Qué significan los campos
TABLA_DATOS.md            ← Valores por defecto
EJEMPLOS_DATOS.md         ← Copiar y pegar (RECOMENDADO)
```

### 3️⃣ Elige un ejemplo y cópialo
```
Abre: EJEMPLOS_DATOS.md
Elige: "Ejemplo 1: Red Simple" ← ⭐ RECOMENDADO para primera vez
Copia los valores
```

### 4️⃣ Ejecuta el programa
```bash
dotnet run --project src/Aplicacion/Aplicacion.csproj -c Release
```

### 5️⃣ Pega los valores que copiaste
```
El programa te pide datos
Pega los valores del ejemplo
Presiona Enter
Observa la simulación
```

---

## Si quieres entender TODO en 2 horas:

### Lee estos en orden:
1. [README.md](README.md) - 10 min
2. [RESUMEN_EJECUTIVO.md](RESUMEN_EJECUTIVO.md) - 15 min
3. [DIAGRAMAS_ARQUITECTURA.md](DIAGRAMAS_ARQUITECTURA.md) - 20 min (primeros 3 diagramas)
4. [ACTIVIDADES_ANALISIS.md](ACTIVIDADES_ANALISIS.md) - 30 min
5. Abre `src/Aplicacion/Modelos/*.cs` - Analiza el código (30 min)
6. Ejecuta el programa con ejemplos - 15 min

---

## 📁 Archivos Principales

### Para Ejecutar (NECESARIOS):
- [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md) - Qué datos ingresar
- [TABLA_DATOS.md](TABLA_DATOS.md) - Tabla de valores
- [EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md) - Ejemplos listos

### Para Aprender (RECOMENDADOS):
- [README.md](README.md) - Introducción
- [RESUMEN_EJECUTIVO.md](RESUMEN_EJECUTIVO.md) - Resumen
- [DIAGRAMAS_ARQUITECTURA.md](DIAGRAMAS_ARQUITECTURA.md) - 9 diagramas
- [ACTIVIDADES_ANALISIS.md](ACTIVIDADES_ANALISIS.md) - Análisis

### Para Profundizar (OPCIONALES):
- [CUESTIONARIO_REFLEXIVO.md](CUESTIONARIO_REFLEXIVO.md) - 20+ preguntas
- [VALIDACIONES.md](VALIDACIONES.md) - Validaciones técnicas
- [TRABAJO_COMPLETADO.md](TRABAJO_COMPLETADO.md) - Resumen visual
- [INDICE.md](INDICE.md) - Índice completo

### Código:
- `src/Aplicacion/Modelos/` - 7 clases
- `src/Aplicacion/Program.cs` - Programa interactivo

---

## 🎯 Ejemplo COPIAR Y PEGAR (Más Simple)

```
Simulación: Red Simple
Router IP: 192.168.1.1
Switch IP: 192.168.1.2
Puertos: 16
Firewall IP: 10.0.0.1
AP IP: 192.168.1.100
SSID: MiRed
Potencia: 80
Ruta: 10.0.0.0 → 192.168.1.2
MAC: 00:11:22:33:44:55 → Puerto 1
MAC WiFi: AA:BB:CC:DD:EE:FF
Firewall: * → * PERMITIR
Paquete: 192.168.1.1 → 192.168.1.100 (Ping, 256)
Pasos: 2
```

**Para más ejemplos**, abre: [EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md)

---

## ❓ Preguntas Frecuentes

**P: ¿Por dónde empiezo?**
R: Lee [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md) primero

**P: ¿Qué valores debo usar?**
R: Abre [TABLA_DATOS.md](TABLA_DATOS.md) o [EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md)

**P: ¿Cuál es la dirección IP correcta?**
R: Usa la que ya configuraste. Por defecto: `192.168.1.1`

**P: ¿Qué pasa si me equivoco?**
R: El programa te lo dirá. Lee [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md#-errores-comunes)

**P: ¿Cómo empiezo a aprender arquitectura?**
R: Lee [README.md](README.md) y mira [DIAGRAMAS_ARQUITECTURA.md](DIAGRAMAS_ARQUITECTURA.md)

---

## ✅ Paso a Paso para la Primera Ejecución

```
1. Abre terminal en: /home/et12alumno/datos_1
   
2. Compila:
   $ dotnet build
   
3. Abre archivo: EJEMPLOS_DATOS.md
   
4. Busca: "Ejemplo 1: Red Simple"
   
5. Copia: Todos los valores del ejemplo
   
6. Ejecuta:
   $ dotnet run --project src/Aplicacion/Aplicacion.csproj -c Release
   
7. Cuando pida datos:
   Pega los valores copiados
   
8. Observa: La simulación en acción
```

---

## 🎓 Rutas de Estudio

### Ruta Ejecutar (15 min):
```
1. Lee: GUIA_RAPIDA_ENTRADA.md
2. Abre: TABLA_DATOS.md
3. Copia: De EJEMPLOS_DATOS.md
4. Ejecuta: dotnet run...
5. Disfruta!
```

### Ruta Aprender (2 horas):
```
1. README.md (10 min)
2. DIAGRAMAS_ARQUITECTURA.md (20 min)
3. Código en src/Aplicacion/Modelos/ (60 min)
4. ACTIVIDADES_ANALISIS.md (30 min)
```

### Ruta Experto (8+ horas):
```
Ruta Aprender (2 horas)
+ CUESTIONARIO_REFLEXIVO.md (30 min)
+ Escribir Tests (2 horas)
+ Implementar Persistencia (2 horas)
+ Crear extensiones (2+ horas)
```

---

## 📞 Recursos Rápidos

| Necesito | Abrir |
|----------|-------|
| Ver qué ingresar | [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md) |
| Valores rápidos | [TABLA_DATOS.md](TABLA_DATOS.md) |
| Ejemplo completo | [EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md) |
| Entender todo | [README.md](README.md) |
| Ver diagramas | [DIAGRAMAS_ARQUITECTURA.md](DIAGRAMAS_ARQUITECTURA.md) |
| Ver código | `src/Aplicacion/Modelos/` |
| Reflexionar | [CUESTIONARIO_REFLEXIVO.md](CUESTIONARIO_REFLEXIVO.md) |

---

## 🚀 ¡Listo! Comienza con:

### Opción A: Ejecutar YA (5 min)
→ Lee: [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md)

### Opción B: Aprender Primero (2 horas)
→ Lee: [README.md](README.md)

---

**¿Necesitas ayuda? Mira el archivo correspondiente en la tabla de arriba.**

**¿Listo? ¡Abre [GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md) ahora mismo! 🚀**
