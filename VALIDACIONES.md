# 📋 Validaciones Implementadas

## Documento de Referencia Rápida

Este archivo documenta todas las validaciones implementadas en las clases del proyecto.

---

## PaqueteRed

### Validaciones en Constructor:
```csharp
public PaqueteRed(string origen, string destino, string contenido, int tamaño)
```

| Parámetro | Validación | Motivo |
|-----------|-----------|--------|
| `origen` | No puede ser null o vacío | Necesitamos saber desde dónde proviene |
| `destino` | No puede ser null o vacío | Necesitamos saber adónde va |
| `contenido` | No puede ser null o vacío | Debe haber algo que transmitir |
| `tamaño` | Debe estar entre 1 y 65535 | Tamaño máximo de IPv4 |

### Validaciones en Propiedades:
```csharp
public string Origen { get; set; }
public string Destino { get; set; }
public string Contenido { get; set; }
public int Tamaño { get; set; }
```

- **Origen**: ❌ Vacío → ArgumentException
- **Destino**: ❌ Vacío → ArgumentException
- **Contenido**: ❌ Vacío → ArgumentException
- **Tamaño**: ❌ ≤ 0 → ArgumentException
- **Tamaño**: ❌ > 65535 → ArgumentException

### Propiedades No Modificables:
- `Id`: Solo lectura (generado en constructor)
- `FechaCreacion`: Solo lectura (timestamp al crear)

---

## DispositivoRed (Clase Base)

### Validaciones en Constructor:
```csharp
protected DispositivoRed(string nombre, string direccion)
```

| Parámetro | Validación |
|-----------|-----------|
| `nombre` | No puede ser null o vacío |
| `direccion` | No puede ser null o vacío |

### Validaciones en Propiedades:
```csharp
public string Nombre { get; set; }
public string Direccion { get; set; }
public bool Activo { get; set; }
```

- **Nombre**: ❌ Vacío → ArgumentException
- **Direccion**: ❌ Vacío → ArgumentException
- **Activo**: ✅ true/false sin restricción

### Validaciones en Métodos:
```csharp
public virtual void RecibirPaquete(PaqueteRed paquete)
public virtual void EnviarPaquete(PaqueteRed paquete)
```

- **paquete**: ❌ null → ArgumentNullException
- **paquete**: ❌ dispositivo inactivo → InvalidOperationException

### Propiedades Solo Lectura:
- `PaquetesRecibidos`: IReadOnlyList (no se puede modificar externamente)
- `PaquetesEnviados`: IReadOnlyList (no se puede modificar externamente)

---

## Router

### Validaciones en Constructor:
```csharp
public Router(string nombre, string direccion, int capacidadBufer = 100)
```

| Parámetro | Validación |
|-----------|-----------|
| `capacidadBufer` | Debe ser > 0 |

### Validaciones en Propiedades:
```csharp
public int CapacidadBufer { get; set; }
```

- **CapacidadBufer**: ❌ ≤ 0 → ArgumentException

### Validaciones en Métodos:
```csharp
public void AgregarRuta(string destinoIp, string proximoDispositivo)
```

| Parámetro | Validación |
|-----------|-----------|
| `destinoIp` | No puede ser vacío |
| `proximoDispositivo` | No puede ser vacío |

```csharp
public void ProcesarPaquete(PaqueteRed paquete)
```

| Validación |
|-----------|
| ❌ paquete null → ArgumentNullException |
| ❌ búfer lleno → InvalidOperationException |

### Propiedades Solo Lectura:
- `TablaDireccionamiento`: IReadOnlyDictionary (obliga a usar AgregarRuta)
- `PaquetesPendientes`: Solo lectura (cálculo de búfer.Count)

---

## Switch

### Validaciones en Constructor:
```csharp
public Switch(string nombre, string direccion, int cantidadPuertos = 24)
```

| Parámetro | Validación |
|-----------|-----------|
| `cantidadPuertos` | Debe ser > 0 |

### Validaciones en Métodos:
```csharp
public void RegistrarMac(string dirMac, int numeroPuerto)
```

| Parámetro | Validación |
|-----------|-----------|
| `dirMac` | No puede ser vacío |
| `numeroPuerto` | Debe estar entre 1 y cantidadPuertos |

```csharp
public void EstablecerEstadoPuerto(int numeroPuerto, bool activo)
```

| Parámetro | Validación |
|-----------|-----------|
| `numeroPuerto` | Debe estar entre 1 y cantidadPuertos |

### Propiedades Solo Lectura:
- `TablaMac`: IReadOnlyDictionary (obliga a usar RegistrarMac)

---

## AccessPoint

### Validaciones en Constructor:
```csharp
public AccessPoint(string nombre, string direccion, string ssid, 
                  int potenciaSeñal = 80, int anchodeBanda = 20, 
                  string tipoSeguridad = "WPA2")
```

| Parámetro | Validación |
|-----------|-----------|
| `ssid` | No puede ser vacío |
| `potenciaSeñal` | Debe estar entre 0 y 100 |
| `anchodeBanda` | Debe ser > 0 |
| `tipoSeguridad` | No puede ser vacío |

### Validaciones en Propiedades:
```csharp
public string Ssid { get; set; }
public int PotenciaSeñal { get; set; }
public int AnchodeBanda { get; set; }
public string TipoSeguridad { get; set; }
```

- **Ssid**: ❌ Vacío → ArgumentException
- **PotenciaSeñal**: ❌ < 0 o > 100 → ArgumentException
- **AnchodeBanda**: ❌ ≤ 0 → ArgumentException
- **TipoSeguridad**: ❌ Vacío → ArgumentException

### Validaciones en Métodos:
```csharp
public void ConectarDispositivo(string dirMac)
```

| Validación |
|-----------|
| ❌ dirMac vacío → ArgumentException |
| ❌ dirMac ya conectado → InvalidOperationException |
| ❌ AP inactivo → InvalidOperationException |

```csharp
public void ProcesarPaquete(PaqueteRed paquete)
```

| Validación |
|-----------|
| ❌ paquete null → ArgumentNullException |
| ❌ destino no conectado → InvalidOperationException |
| ❌ potencia < 30% → InvalidOperationException |

### Propiedades Solo Lectura:
- `DispositivosConectados`: IReadOnlyList (obliga a usar ConectarDispositivo)

---

## Firewall

### Validaciones en Constructor:
```csharp
public Firewall(string nombre, string direccion, bool modoEstricto = false)
```

- Sin validaciones adicionales (heredadas de DispositivoRed)

### Validaciones en Métodos:
```csharp
public void AgregarRegla(ReglaFirewall regla)
```

| Validación |
|-----------|
| ❌ regla null → ArgumentNullException |

```csharp
public void ProcesarPaquete(PaqueteRed paquete)
```

| Validación |
|-----------|
| ❌ paquete null → ArgumentNullException |
| ❌ paquete rechazado → InvalidOperationException |

### Propiedades Solo Lectura:
- `Reglas`: IReadOnlyList (obliga a usar AgregarRegla)

---

## ReglaFirewall

### Validaciones en Constructor:
```csharp
public ReglaFirewall(string origenPatron, string destinoPatron, bool permitir = true)
```

| Parámetro | Validación |
|-----------|-----------|
| `origenPatron` | No puede ser vacío (puede ser "*") |
| `destinoPatron` | No puede ser vacío (puede ser "*") |

---

## Simulacion

### Validaciones en Constructor:
```csharp
public Simulacion(string nombre)
```

| Parámetro | Validación |
|-----------|-----------|
| `nombre` | No puede ser vacío |

### Validaciones en Propiedades:
```csharp
public string Nombre { get; set; }
```

- **Nombre**: ❌ Vacío → ArgumentException

### Validaciones en Métodos:
```csharp
public void AgregarDispositivo(DispositivoRed dispositivo)
```

| Validación |
|-----------|
| ❌ dispositivo null → ArgumentNullException |
| ❌ simulación en ejecución → InvalidOperationException |
| ❌ dirección duplicada → InvalidOperationException |

```csharp
public DispositivoRed ObtenerDispositivo(string direccion)
```

| Validación |
|-----------|
| ❌ dirección vacía → ArgumentException |

```csharp
public void CrearPaquete(string origen, string destino, string contenido, int tamaño)
```

| Validación |
|-----------|
| ❌ simulación no en ejecución → InvalidOperationException |
| ❌ origen no existe → InvalidOperationException |
| ❌ validaciones de PaqueteRed también aplican |

```csharp
public void EjecutarPaso()
```

| Validación |
|-----------|
| ❌ simulación no en ejecución → InvalidOperationException |

### Propiedades Solo Lectura:
- `Dispositivos`: IReadOnlyList (obliga a usar AgregarDispositivo)
- `PaquetesSimulacion`: IReadOnlyList (obliga a usar CrearPaquete)

---

## 📊 Resumen de Validaciones

| Tipo de Validación | Cantidad | Ejemplos |
|-------------------|----------|----------|
| Nulos | 12 | PaqueteRed null en EnviarPaquete |
| Vacíos (string) | 20 | Nombre, Direccion, Origen, Destino |
| Rangos numéricos | 15 | Tamaño 1-65535, Potencia 0-100 |
| Estado del objeto | 10 | Dispositivo activo, simulación en ejecución |
| Lógica de negocio | 8 | Búfer lleno, MAC no registrada |
| **TOTAL** | **65+** | |

---

## 🎯 Principios de Validación

### 1. **Fallo Rápido (Fail Fast)**
- Validar en constructor antes de crear objeto
- Errores detectados inmediatamente
- No hay objetos en estado inválido

### 2. **Encapsulamiento**
- Validar en setters también
- Mantener invariantes durante vida del objeto
- Lanzar excepciones para cambios inválidos

### 3. **Mensajes Claros**
```csharp
throw new ArgumentException("El tamaño debe estar entre 1 y 65535 bytes", 
                            nameof(Tamaño));
```
- Incluir valor esperado
- Incluir nombre del parámetro
- Específico, no genérico

### 4. **Excepciones Apropiadas**
```csharp
// Argumento inválido
throw new ArgumentException();

// Argumento nulo
throw new ArgumentNullException();

// Violación de precondición
throw new InvalidOperationException();
```

---

## 🔍 Cómo Leer el Código

Cuando veas una validación como:
```csharp
if (string.IsNullOrWhiteSpace(value))
    throw new ArgumentException("No puede estar vacío", nameof(Nombre));
```

Significa:
1. **Condición**: Si el valor es null, vacío o solo espacios
2. **Acción**: Lanza excepción
3. **Mensaje**: Describe el problema
4. **Parámetro**: Identifica cuál parámetro tiene el problema

---

## ✅ Testing de Validaciones

Ejemplo de test:
```csharp
[Test]
public void PaqueteRedRechazaTamañoNegativo()
{
    // Act & Assert
    Assert.Throws<ArgumentException>(() => 
        new PaqueteRed("1.1.1.1", "2.2.2.2", "test", -1)
    );
}

[Test]
public void PaqueteRedAceptaTamañoValido()
{
    // Act
    var paquete = new PaqueteRed("1.1.1.1", "2.2.2.2", "test", 256);
    
    // Assert
    Assert.That(paquete.Tamaño, Is.EqualTo(256));
}
```

---

## 📝 Notas Importantes

1. **Validación ≠ Complejidad**: 65+ validaciones en ~900 líneas
2. **Protección**: Sin validación, errores sutiles más adelante
3. **Claridad**: Errores inmediatos = debugging más fácil
4. **Profesionalismo**: Código de producción tiene validaciones
5. **Testing**: Cada validación debería tener test

---

## 🔗 Referencias

- `ArgumentException`: Argumento inválido
- `ArgumentNullException`: Argumento null (específico)
- `InvalidOperationException`: Operación inválida en estado actual
- `IReadOnlyList<T>`: Interfaz de lista de solo lectura
- `IReadOnlyDictionary<K,V>`: Interfaz de diccionario de solo lectura

---

**Última actualización**: Octubre 2026
