namespace Aplicacion.Modelos
{
    /// <summary>
    /// Orquesta la simulación completa de una red.
    /// Responsabilidad: Gestionar dispositivos, crear paquetes y ejecutar pasos de simulación.
    /// </summary>
    public class Simulacion
    {
        private List<DispositivoRed> _dispositivos;
        private List<PaqueteRed> _paquetesSimulacion;
        private string _nombre;
        private DateTime _inicioSimulacion;
        private bool _enEjecucion;

        /// <summary>
        /// Nombre de la simulación
        /// </summary>
        public string Nombre 
        { 
            get { return _nombre; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío", nameof(Nombre));
                _nombre = value;
            }
        }

        /// <summary>
        /// Dispositivos en la red
        /// </summary>
        public IReadOnlyList<DispositivoRed> Dispositivos 
        { 
            get { return _dispositivos.AsReadOnly(); }
        }

        /// <summary>
        /// Paquetes creados en la simulación
        /// </summary>
        public IReadOnlyList<PaqueteRed> PaquetesSimulacion 
        { 
            get { return _paquetesSimulacion.AsReadOnly(); }
        }

        /// <summary>
        /// ¿Está la simulación en ejecución?
        /// </summary>
        public bool EnEjecucion 
        { 
            get { return _enEjecucion; }
        }

        /// <summary>
        /// Duración de la simulación
        /// </summary>
        public TimeSpan DuracionSimulacion 
        { 
            get { return _enEjecucion ? TimeSpan.Zero : DateTime.Now - _inicioSimulacion; }
        }

        /// <summary>
        /// Constructor de la simulación
        /// </summary>
        public Simulacion(string nombre)
        {
            Nombre = nombre;
            _dispositivos = new List<DispositivoRed>();
            _paquetesSimulacion = new List<PaqueteRed>();
            _enEjecucion = false;
        }

        /// <summary>
        /// Agrega un dispositivo a la red
        /// </summary>
        public void AgregarDispositivo(DispositivoRed dispositivo)
        {
            if (dispositivo == null)
                throw new ArgumentNullException(nameof(dispositivo));

            if (_enEjecucion)
                throw new InvalidOperationException("No se pueden agregar dispositivos durante la simulación");

            // Verificar que no haya duplicados por dirección
            if (_dispositivos.Any(d => d.Direccion == dispositivo.Direccion))
                throw new InvalidOperationException($"Ya existe un dispositivo con la dirección {dispositivo.Direccion}");

            _dispositivos.Add(dispositivo);
        }

        /// <summary>
        /// Obtiene un dispositivo por su dirección
        /// </summary>
        public DispositivoRed ObtenerDispositivo(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede estar vacía", nameof(direccion));

            return _dispositivos.FirstOrDefault(d => d.Direccion == direccion);
        }

        /// <summary>
        /// Inicia la simulación
        /// </summary>
        public void Iniciar()
        {
            if (_dispositivos.Count == 0)
                throw new InvalidOperationException("No hay dispositivos configurados en la red");

            _enEjecucion = true;
            _inicioSimulacion = DateTime.Now;
        }

        /// <summary>
        /// Detiene la simulación
        /// </summary>
        public void Detener()
        {
            _enEjecucion = false;
        }

        /// <summary>
        /// Crea e inyecta un paquete en la simulación
        /// </summary>
        public void CrearPaquete(string origen, string destino, string contenido, int tamaño)
        {
            if (!_enEjecucion)
                throw new InvalidOperationException("La simulación no está en ejecución");

            var paquete = new PaqueteRed(origen, destino, contenido, tamaño);
            _paquetesSimulacion.Add(paquete);

            // Enviar paquete al dispositivo origen
            var dispositivoOrigen = ObtenerDispositivo(origen);
            if (dispositivoOrigen == null)
                throw new InvalidOperationException($"Dispositivo origen no encontrado: {origen}");

            dispositivoOrigen.RecibirPaquete(paquete);
        }

        /// <summary>
        /// Ejecuta un paso de la simulación procesando paquetes
        /// </summary>
        public void EjecutarPaso()
        {
            if (!_enEjecucion)
                throw new InvalidOperationException("La simulación no está en ejecución");

            foreach (var dispositivo in _dispositivos)
            {
                if (dispositivo.Activo)
                {
                    // Procesar paquetes pendientes del dispositivo
                    var paquetesPendientes = dispositivo.PaquetesRecibidos
                        .Except(dispositivo.PaquetesEnviados)
                        .ToList();

                    foreach (var paquete in paquetesPendientes)
                    {
                        try
                        {
                            dispositivo.ProcesarPaquete(paquete);
                        }
                        catch (Exception ex)
                        {
                            // Registrar error pero continuar simulación
                            Console.WriteLine($"Error procesando paquete en {dispositivo.Nombre}: {ex.Message}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Genera un reporte de la simulación
        /// </summary>
        public string GenerarReporte()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"=== Reporte de Simulación: {_nombre} ===");
            sb.AppendLine($"Estado: {(_enEjecucion ? "En ejecución" : "Detenida")}");
            sb.AppendLine($"Duración: {DuracionSimulacion.TotalSeconds:F2}s");
            sb.AppendLine($"Dispositivos: {_dispositivos.Count}");
            
            foreach (var dispositivo in _dispositivos)
            {
                sb.AppendLine($"  - {dispositivo}");
                sb.AppendLine($"    Recibidos: {dispositivo.PaquetesRecibidos.Count}, " +
                            $"Enviados: {dispositivo.PaquetesEnviados.Count}");
            }

            sb.AppendLine($"Total paquetes: {_paquetesSimulacion.Count}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"Simulación [{_nombre}] - Dispositivos: {_dispositivos.Count}, " +
                   $"Paquetes: {_paquetesSimulacion.Count}, Estado: {(_enEjecucion ? "Activa" : "Inactiva")}";
        }
    }
}
