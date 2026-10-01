# 🚀 Guía Rápida de Inicio

## 🎯 **PARA EJECUTAR EL PROGRAMA** (Lee estos PRIMERO)

### ⭐ **3 Archivos esenciales para ingresar datos:**

1. **[GUIA_RAPIDA_ENTRADA.md](GUIA_RAPIDA_ENTRADA.md)** (⭐ EMPIEZA AQUÍ)
   - QUÉ datos debes ingresar
   - Explicación de cada campo
   - Errores comunes y cómo evitarlos
   - Ejemplo rápido (2 minutos)

2. **[TABLA_DATOS.md](TABLA_DATOS.md)** (⭐ USA COMO REFERENCIA)
   - Tablas visuales de valores
   - 3 ejemplos listos para copiar y pegar
   - Plantilla simple

3. **[EJEMPLOS_DATOS.md](EJEMPLOS_DATOS.md)** (⭐ COPIAR Y PEGAR)
   - Ejemplo 1: Red Simple (RECOMENDADO para empezar)
   - Ejemplo 2: Red Empresa
   - Ejemplo 3: Red Corporativa
   - Valores específicos para cada ejemplo

### 🚀 Flujo rápido:
```
Abre: GUIA_RAPIDA_ENTRADA.md (5 min)
  ↓
Abre: TABLA_DATOS.md (como referencia)
  ↓
Elige: Un ejemplo de EJEMPLOS_DATOS.md
  ↓
Ejecuta: dotnet run --project src/Aplicacion/Aplicacion.csproj
  ↓
Ingresa: Los datos del ejemplo
  ↓
Observa: Resultados de la simulación
```

---

## ¿Por dónde empiezo?

### **5 minutos de lectura rápida:**
1. Lee: [README.md](README.md)
2. Ver: Estructura del proyecto arriba

### **30 minutos de aprendizaje:**
1. Lee: [RESUMEN_EJECUTIVO.md](RESUMEN_EJECUTIVO.md)
2. Mira: [DIAGRAMAS_ARQUITECTURA.md](DIAGRAMAS_ARQUITECTURA.md) (primeros 3 diagramas)

### **2 horas de estudio completo:**
1. Lee: [ACTIVIDADES_ANALISIS.md](ACTIVIDADES_ANALISIS.md) 
2. Estudia: Todo [DIAGRAMAS_ARQUITECTURA.md](DIAGRAMAS_ARQUITECTURA.md)
3. Responde: [CUESTIONARIO_REFLEXIVO.md](CUESTIONARIO_REFLEXIVO.md)

### **Profundizando:**
4. Abre y analiza: `src/Aplicacion/Modelos/*.cs`
5. Ejecuta: `src/Aplicacion/Ejemplos/EjemploSimulacionRed.cs`
6. Crea: Tests en `src/Tests/`

---

## 📚 Archivos por Propósito

### Aprender Conceptos:
| Archivo | Tiempo | Contenido |
|---------|--------|----------|
| **README.md** | 10 min | Visión general + ejemplos de uso |
| **RESUMEN_EJECUTIVO.md** | 15 min | Resumen completo de todo |
| **ACTIVIDADES_ANALISIS.md** | 30 min | Análisis profundo de las 3 actividades |

### Entender Arquitectura:
| Archivo | Tiempo | Contenido |
|---------|--------|----------|
| **DIAGRAMAS_ARQUITECTURA.md** | 20 min | 9 diagramas visuales |
| `src/Aplicacion/Modelos/*.cs` | 45 min | Código fuente anotado |

### Practicar y Reflexionar:
| Archivo | Tiempo | Contenido |
|---------|--------|----------|
| **CUESTIONARIO_REFLEXIVO.md** | 30 min | 20+ preguntas |
| `src/Aplicacion/Ejemplos/...cs` | 15 min | Código de ejemplo |

---

## 🎯 Tres Rutas de Aprendizaje

### Ruta 1: PRINCIPIANTE (2 horas)
```
1. Lee: README.md (10 min)
   ↓
2. Ve: DIAGRAMAS (Diagramas 1-3)  (15 min)
   ↓
3. Lee: RESUMEN_EJECUTIVO.md (15 min)
   ↓
4. Estudia: Clases principales (30 min)
   ├─ PaqueteRed.cs
   ├─ DispositivoRed.cs
   └─ Router.cs
   ↓
5. Ejecuta: EjemploSimulacionRed.cs (30 min)
```

### Ruta 2: INTERMEDIO (4 horas)
```
1. Ruta 1 completa (2 horas)
   ↓
2. Lee: ACTIVIDADES_ANALISIS.md (30 min)
   ↓
3. Estudia: TODO código (45 min)
   ├─ Router.cs
   ├─ Switch.cs
   ├─ AccessPoint.cs
   └─ Firewall.cs
   ↓
4. Responde: CUESTIONARIO_REFLEXIVO (30 min)
   ↓
5. Escribe: Tests básicos (30 min)
```

### Ruta 3: AVANZADO (8+ horas)
```
1. Ruta 2 completa (4 horas)
   ↓
2. Profundiza: DIAGRAMAS (todos) (30 min)
   ↓
3. Implementa: Servicios en Aplicacion/Servicios/ (2 horas)
   ↓
4. Implementa: Persistencia en src/Persistencia/ (2 horas)
   ↓
5. Escribe: Suite completa de tests (1+ hora)
   ↓
6. Extiende: Nuevas clases y funcionalidades
```

---

## 🎬 Primeros Pasos

### Paso 1: Leer README
```bash
# Abre y lee
README.md
```

### Paso 2: Ver Diagramas
```bash
# Abre y estudia los 3 primeros diagramas
DIAGRAMAS_ARQUITECTURA.md
# Enfócate en:
# - Diagrama 1: Flujo de paquete
# - Diagrama 2: Jerarquía de clases
# - Diagrama 3: Composición de Simulacion
```

### Paso 3: Ejecutar Ejemplo
```bash
# Abre el archivo de ejemplo
src/Aplicacion/Ejemplos/EjemploSimulacionRed.cs

# Lee el código y entiende qué hace
# (Luego: dotnet run para ejecutar)
```

### Paso 4: Analizar una Clase
```bash
# Abre y analiza
src/Aplicacion/Modelos/Router.cs

# Identifica:
# - Propiedades privadas
# - Propiedades públicas
# - Validaciones
# - Métodos públicos
```

### Paso 5: Responder Preguntas
```bash
# Abre y responde las primeras 5 preguntas
CUESTIONARIO_REFLEXIVO.md
# Secciones: 1.1, 1.2, 1.3, 1.4, 2.1
```

---

## 📖 Conceptos Clave

### 1. Paquete de Datos
```
PaqueteRed = {
  id: Guid (único),
  origen: IP origen,
  destino: IP destino,
  contenido: bytes,
  tamaño: 1-65535 bytes,
  fechaCreacion: timestamp
}
```

### 2. Dispositivo Base
```
DispositivoRed = {
  nombre: identificador,
  direccion: IP,
  activo: true/false,
  paquetesRecibidos[],
  paquetesEnviados[]
}
+ ProcesarPaquete() [abstracto - cada uno diferente]
```

### 3. Router (Enrutamiento)
```
Responsabilidad: Decidir siguiente dispositivo
Método: Tabla de direccionamiento (destino → próximo)
Lógica: Busca destino en tabla, encola y enruta
```

### 4. Switch (Conmutación)
```
Responsabilidad: Encontrar puerto correcto
Método: Tabla MAC (MAC → puerto)
Lógica: Busca MAC destino, envía a puerto
```

### 5. Firewall (Filtrado)
```
Responsabilidad: Aceptar/Rechazar según reglas
Método: Lista de reglas (origen, destino, acción)
Lógica: Evalúa reglas, cuenta aceptados/rechazados
```

### 6. Simulacion (Orquestación)
```
Responsabilidad: Coordinar todo
Métodos: Iniciar, CrearPaquete, EjecutarPaso, Detener
Lógica: Gestiona dispositivos, ejecuta ciclos de simulación
```

---

## 💻 Código Mínimo para Comenzar

```csharp
using Aplicacion.Modelos;

// 1. Crear objetos
var paquete = new PaqueteRed("192.168.1.5", "8.8.8.8", "GET", 256);
var router = new Router("R1", "192.168.1.1");

// 2. Validar que funcionan
Console.WriteLine(paquete);      // Imprime: Paquete [ID] de ... a ...
Console.WriteLine(router);       // Imprime: Router [R1] - Activo

// 3. Interactuar
router.AgregarRuta("8.8.8.8", "10.0.0.1");
router.RecibirPaquete(paquete);

// 4. Ver resultado
Console.WriteLine($"Paquetes recibidos: {router.PaquetesRecibidos.Count}");
```

---

## ❓ Preguntas Frecuentes

**P: ¿Necesito instalar algo?**
A: Solo .NET 6+ y un editor (VS Code, Visual Studio)

**P: ¿Cómo ejecuto el código?**
A: `dotnet run` en la carpeta del proyecto

**P: ¿Dónde veo los errores?**
A: La validación lanza excepciones cuando datos inválidos

**P: ¿Qué sigue después de leer todo?**
A: Ver RESUMEN_EJECUTIVO.md → "Próximos Pasos"

**P: ¿Puedo extender las clases?**
A: Sí, crea nuevos dispositivos heredando de DispositivoRed

**P: ¿Se pueden guardar resultados?**
A: No aún, pero Persistencia está lista para implementar

---

## 📋 Verificación de Comprensión

Después de estudiar, deberías poder responder:

### Nivel 1 (Básico):
- [ ] ¿Qué es un PaqueteRed?
- [ ] ¿Cuál es la diferencia entre Router y Switch?
- [ ] ¿Qué hace un Firewall?

### Nivel 2 (Intermedio):
- [ ] ¿Por qué DispositivoRed es abstracta?
- [ ] ¿Cómo valida PaqueteRed sus datos?
- [ ] ¿Qué es una tabla de enrutamiento?

### Nivel 3 (Avanzado):
- [ ] ¿Cómo fluyen los datos en Simulacion?
- [ ] ¿Qué patrón de diseño usa Firewall con ReglaFirewall?
- [ ] ¿Por qué usamos IReadOnlyList en lugar de List[]?

---

## 🔗 Enlaces Rápidos

| Recurso | Ubicación |
|---------|-----------|
| Clase PaqueteRed | [PaqueteRed.cs](src/Aplicacion/Modelos/PaqueteRed.cs) |
| Clase DispositivoRed | [DispositivoRed.cs](src/Aplicacion/Modelos/DispositivoRed.cs) |
| Clase Router | [Router.cs](src/Aplicacion/Modelos/Router.cs) |
| Clase Switch | [Switch.cs](src/Aplicacion/Modelos/Switch.cs) |
| Clase AccessPoint | [AccessPoint.cs](src/Aplicacion/Modelos/AccessPoint.cs) |
| Clase Firewall | [Firewall.cs](src/Aplicacion/Modelos/Firewall.cs) |
| Clase Simulacion | [Simulacion.cs](src/Aplicacion/Modelos/Simulacion.cs) |
| Ejemplo de Uso | [EjemploSimulacionRed.cs](src/Aplicacion/Ejemplos/EjemploSimulacionRed.cs) |

---

## ✅ Checklist de Completitud

### Documentación:
- ✅ README.md - Documentación principal
- ✅ RESUMEN_EJECUTIVO.md - Resumen completo
- ✅ ACTIVIDADES_ANALISIS.md - Análisis detallado
- ✅ DIAGRAMAS_ARQUITECTURA.md - 9 diagramas
- ✅ CUESTIONARIO_REFLEXIVO.md - 20+ preguntas
- ✅ INDICE.md - Este archivo

### Código:
- ✅ PaqueteRed.cs - Unidad de datos
- ✅ DispositivoRed.cs - Base abstracta
- ✅ Router.cs - Enrutamiento
- ✅ Switch.cs - Conmutación
- ✅ AccessPoint.cs - WiFi
- ✅ Firewall.cs - Seguridad
- ✅ Simulacion.cs - Orquestación
- ✅ EjemploSimulacionRed.cs - Ejemplo completo

### Próximos:
- ⏳ Tests unitarios
- ⏳ Servicios
- ⏳ Persistencia

---

## 🎓 Consejos para Aprender

1. **No leas todo de una vez**: Usa las rutas de aprendizaje
2. **Ejecuta código**: Toma ejemplos y modifícalos
3. **Escribe tests**: Valida tu comprensión
4. **Crea extensiones**: Nuevas clases de dispositivos
5. **Dibuja diagramas**: Tu propio entendimiento
6. **Enseña a otros**: Explica lo que aprendiste

---

## 📞 Soporte

Si tienes dudas:
1. Revisa [CUESTIONARIO_REFLEXIVO.md](CUESTIONARIO_REFLEXIVO.md)
2. Lee comentarios en el código
3. Estudia los diagramas
4. Ejecuta y experimenta

---

**Última actualización**: Octubre 2026  
**Estado**: Listo para usar  
**Tiempo estimado de estudio**: 2-8 horas (según ruta)
