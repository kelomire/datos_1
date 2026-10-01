# Cuestionario Reflexivo - Simulación de Redes

## SECCIÓN 1: Conceptos Previos (Actividad 1)

**Pregunta 1.1:** Describe con tus propias palabras cómo circula un paquete desde una PC hasta un servidor web en internet. Identifica al menos 5 dispositivos que intervienen.

**Respuesta esperada:**
- Router local
- Firewall
- ISP Gateway
- Routers de backbone
- Servidor web

---

**Pregunta 1.2:** ¿Qué pasa si un Router no conoce la ruta hacia el destino de un paquete? Describe dos soluciones posibles.

**Respuesta esperada:**
- Solución 1: Usa la ruta por defecto (default route)
- Solución 2: Descarta el paquete y envía ICMP Unreachable

---

**Pregunta 1.3:** En un switch, ¿por qué es importante la tabla MAC? ¿Qué ventaja tiene respecto a enviar el paquete a todos los puertos?

**Respuesta esperada:**
- Evita congestión de red
- Aumenta privacidad
- Mejora eficiencia
- Solo llega a puerto correcto

---

**Pregunta 1.4:** ¿Cuál es la diferencia entre un Access Point y un Switch convencional?

| Aspecto | Access Point | Switch |
|---------|--------------|--------|
| Conectividad | Inalámbrica | Alámbrica |
| Protocolo | 802.11 WiFi | 802.3 Ethernet |
| Tabla | Dispositivos WiFi | Direcciones MAC |
| Rango | ~100 metros | Misma red local |

---

## SECCIÓN 2: Interpretación Arquitectónica (Actividad 2)

**Pregunta 2.1:** ¿Por qué es importante separar la Aplicación de la Persistencia?

**Respuesta esperada:**
- Cambiar BD sin modificar lógica
- Testear sin BD
- Reutilizar en diferentes contextos
- Facilita mantenimiento

---

**Pregunta 2.2:** En nuestro proyecto, ¿dónde debería ir la lógica para "guardar un paquete en base de datos"?

- ❌ En la clase `PaqueteRed` (violaría responsabilidad única)
- ❌ En `DispositivoRed` (es de aplicación, no persistencia)
- ✓ En un `RepositorioPaquete` en la capa Persistencia

**Respuesta esperada:**
```csharp
// Persistencia/Repositorios/RepositorioPaquete.cs
public void GuardarPaquete(PaqueteRed paquete)
{
    // Lógica de guardado en BD
}
```

---

**Pregunta 2.3:** Escribe 3 pruebas unitarias que debería tener la clase `Router`:

1. **Test 1:** Verifica que `AgregarRuta()` guarda correctamente
2. **Test 2:** Verifica que `EnrutarProximoPaquete()` rechaza si búfer vacío
3. **Test 3:** Verifica que no se agrega ruta duplicada

---

**Pregunta 2.4:** ¿Qué información deberíamos persistir de una simulación?

**Respuesta esperada:**
- Paquetes enviados/recibidos
- Decisiones de cada dispositivo
- Errores/rechazos
- Timeline (cuándo ocurrió cada evento)
- Estadísticas finales

---

## SECCIÓN 3: Modelado y Diseño (Actividad 3)

**Pregunta 3.1:** ¿Por qué `DispositivoRed` es una clase **abstracta** y no concreta?

**Respuesta esperada:**
- No existe un "dispositivo genérico" en la red
- Cada dispositivo tiene comportamiento específico
- `ProcesarPaquete()` es diferente en cada uno
- Obliga a implementar subclases válidas

---

**Pregunta 3.2:** Analiza esta validación en `PaqueteRed`:

```csharp
if (value > 65535)
    throw new ArgumentException("El tamaño no puede exceder 65535 bytes");
```

**Preguntas:**
- a) ¿De dónde viene el número 65535?
- b) ¿Qué pasaría si no lo validamos?
- c) ¿Es esta la responsabilidad de `PaqueteRed`?

**Respuesta esperada:**
- a) Tamaño máximo de campo Length en IPv4 (16 bits)
- b) Paquetes inválidos llenarían la red
- c) Sí, porque es parte de la definición válida de un paquete

---

**Pregunta 3.3:** El `Router` tiene una propiedad `TablaDireccionamiento` que es `IReadOnlyDictionary`. ¿Por qué no devolvemos directamente el `Dictionary`?

**Respuesta esperada:**
- Evita que código externo modifique la tabla
- Obliga a usar `AgregarRuta()` (que valida)
- Mantiene integridad de datos
- Respeta el encapsulamiento

---

**Pregunta 3.4:** Diseña una nueva clase `Impresora : DispositivoRed`. ¿Cuál sería su responsabilidad? ¿Qué propiedades tendría?

**Respuesta esperada:**

```csharp
public class Impresora : DispositivoRed
{
    public int PapelDisponible { get; set; }      // Hojas
    public bool EstaImprimiendo { get; set; }
    public Queue<PaqueteRed> ColaImpresion { get; private set; }
    
    public override void ProcesarPaquete(PaqueteRed paquete)
    {
        // Valida que sea solicitud de impresión
        // Valida que tenga papel
        // Agrega a cola
    }
}
```

---

**Pregunta 3.5:** En `Firewall`, ¿por qué separamos `ReglaFirewall` en una clase independiente?

**Respuesta esperada:**
- Una regla es un concepto distinto
- Facilita reutilización
- Permite probar reglas independientemente
- Mejor organización del código

---

## SECCIÓN 4: Integración y Reflexión

**Pregunta 4.1:** Dibuja un diagrama (texto o descripción) de cómo fluyen los datos en nuestra arquitectura:

```
[Usuario] 
   ↓
[Aplicacion.Simulacion] → orquesta
   ├─→ [Modelos] → define concepto
   ├─→ [Servicios] → calcula (futuro)
   ↓
[Persistencia.Repositorios] → guarda
   ├─→ [IDbConnectionFactory] → conecta BD
   └─→ [MySqlConnection] → ejecuta queries
   
[Tests] → valida todo
```

---

**Pregunta 4.2:** ¿Cómo probaríamos que el Firewall funciona correctamente sin usar base de datos?

**Respuesta esperada:**
```csharp
[Test]
public void TestFirewallRechazaPaqueteNoPermitido()
{
    // Arrange
    var fw = new Firewall("FW", "10.0.0.1");
    var regla = new ReglaFirewall("192.168.*", "10.0.0.*", permitir: false);
    fw.AgregarRegla(regla);
    var paquete = new PaqueteRed("192.168.1.1", "10.0.0.1", "test", 100);
    
    // Act & Assert
    Assert.Throws<InvalidOperationException>(() => fw.ProcesarPaquete(paquete));
}
```

---

**Pregunta 4.3:** ¿Qué patrón de diseño estamos usando al separar modelo de persistencia?

**Respuesta esperada:**
- **Repository Pattern**: Los repositorios abstraen el acceso a datos
- **Dependency Inversion**: La aplicación no depende de implementación BD
- **Layered Architecture**: Capas con responsabilidades bien definidas

---

**Pregunta 4.4:** Imagina que en el futuro queremos simular 1 millón de paquetes. ¿Qué problemas de diseño podrían aparecer?

**Respuesta esperada:**
- Memoria: Guardar 1M de objetos es costoso
- Rendimiento: Búsquedas en diccionarios pueden ser lentas
- Persistencia: ¿Guardar todo en BD? ¿Cuándo?
- Concurrencia: ¿Procesamiento paralelo de paquetes?

**Posibles soluciones:**
- Event sourcing (guardar eventos, no estado final)
- Streaming (procesar paquetes sin guardarlos todos)
- Caché (guardar solo últimos N paquetes)
- Async/await (procesar en paralelo)

---

## SECCIÓN 5: Validación Personal

**Reflexión Final:**

Después de completar estas actividades, responde:

1. ¿Entiendes cómo circula un paquete por una red? **Sí / Parcialmente / No**

2. ¿Puedes explicar qué hace cada dispositivo (Router, Switch, AP, Firewall)?
   **Sí / Parcialmente / No**

3. ¿Entiendes por qué separamos Aplicación de Persistencia?
   **Sí / Parcialmente / No**

4. ¿Podrías escribir tests para una nueva clase `Impresora`?
   **Sí / Parcialmente / No**

5. **Lo más importante que aprendiste:**
   ```
   (Escribe aquí tu reflexión)
   ```

6. **Preguntas que aún tengo:**
   ```
   (Escribe aquí tus dudas)
   ```

---

## Recursos Complementarios

### Lecturas Recomendadas:
- RFC 791 (IPv4 Specification)
- IEEE 802.3 (Ethernet)
- IEEE 802.11 (WiFi)
- OWASP Firewall Rules

### Conceptos a profundizar:
- Routing protocols (OSPF, BGP)
- Network switching algorithms
- Packet filtering techniques
- Network simulation tools (ns-3, Cisco Packet Tracer)

### Próxima etapa:
Implementar los Servicios que coordinen la simulación completa.
