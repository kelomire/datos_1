namespace Aplicacion.Modelos
{
    /// <summary>
    /// Representa un Router: dispositivo que enruta paquetes basándose en direcciones IP.
    /// Responsabilidad: Decidir el próximo salto (hop) del paquete hacia su destino.
    /// </summary>
    public class Router : DispositivoRed
    {
        private Dictionary<string, string> _tablaDireccionamiento; // destino -> próximo dispositivo
        private int _capacidadBufer;
        private Queue<PaqueteRed> _bufer;

        /// <summary>
        /// Tabla de direccionamiento del router (destino -> próximo dispositivo)
        /// </summary>
        public IReadOnlyDictionary<string, string> TablaDireccionamiento 
        { 
            get { return _tablaDireccionamiento.AsReadOnly(); }
        }

        /// <summary>
        /// Número de paquetes pendientes en el búfer
        /// </summary>
        public int PaquetesPendientes 
        { 
            get { return _bufer.Count; }
        }

        /// <summary>
        /// Capacidad máxima del búfer
        /// </summary>
        public int CapacidadBufer 
        { 
            get { return _capacidadBufer; }
            set 
            { 
                if (value <= 0)
                    throw new ArgumentException("La capacidad debe ser mayor a 0", nameof(CapacidadBufer));
                _capacidadBufer = value;
            }
        }

        /// <summary>
        /// Constructor del router con tabla de direccionamiento inicial
        /// </summary>
        public Router(string nombre, string direccion, int capacidadBufer = 100) 
            : base(nombre, direccion)
        {
            CapacidadBufer = capacidadBufer;
            _tablaDireccionamiento = new Dictionary<string, string>();
            _bufer = new Queue<PaqueteRed>();
        }

        /// <summary>
        /// Agrega una entrada a la tabla de direccionamiento
        /// </summary>
        public void AgregarRuta(string destinoIp, string proximoDispositivo)
        {
            if (string.IsNullOrWhiteSpace(destinoIp))
                throw new ArgumentException("La IP destino no puede estar vacía", nameof(destinoIp));
            if (string.IsNullOrWhiteSpace(proximoDispositivo))
                throw new ArgumentException("El próximo dispositivo no puede estar vacío", nameof(proximoDispositivo));

            _tablaDireccionamiento[destinoIp] = proximoDispositivo;
        }

        /// <summary>
        /// Obtiene el próximo dispositivo para un destino específico
        /// </summary>
        public string ObtenerProximoDispositivoAsync(string destinoIp)
        {
            if (_tablaDireccionamiento.TryGetValue(destinoIp, out var proximo))
                return proximo;

            return null; // Ruta no encontrada
        }

        /// <summary>
        /// Procesa un paquete: lo encola en el búfer y lo enruta según la tabla
        /// </summary>
        public override void ProcesarPaquete(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));

            if (_bufer.Count >= _capacidadBufer)
                throw new InvalidOperationException($"Búfer lleno en router {Nombre}");

            _bufer.Enqueue(paquete);
        }

        /// <summary>
        /// Enruta el próximo paquete del búfer
        /// </summary>
        public PaqueteRed EnrutarProximoPaquete()
        {
            if (_bufer.Count == 0)
                return null;

            var paquete = _bufer.Dequeue();
            var proximoDispositivo = ObtenerProximoDispositivoAsync(paquete.Destino);

            if (proximoDispositivo == null)
                throw new InvalidOperationException($"No hay ruta para destino {paquete.Destino}");

            EnviarPaquete(paquete);
            return paquete;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Rutas: {_tablaDireccionamiento.Count}, Búfer: {_bufer.Count}/{_capacidadBufer}";
        }
    }
}
