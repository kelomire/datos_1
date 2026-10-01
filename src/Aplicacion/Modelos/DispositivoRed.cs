namespace Aplicacion.Modelos
{
    /// <summary>
    /// Clase base abstracta para todos los dispositivos de red.
    /// Define el comportamiento común: recepción, procesamiento y envío de paquetes.
    /// </summary>
    public abstract class DispositivoRed
    {
        private string _nombre;
        private string _direccion;
        private bool _activo;
        protected List<PaqueteRed> _paquetesRecibidos;
        protected List<PaqueteRed> _paquetesEnviados;

        /// <summary>
        /// Nombre o identificador del dispositivo
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
        /// Dirección IP del dispositivo
        /// </summary>
        public string Direccion 
        { 
            get { return _direccion; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La dirección no puede estar vacía", nameof(Direccion));
                _direccion = value;
            }
        }

        /// <summary>
        /// Estado del dispositivo (activo/inactivo)
        /// </summary>
        public bool Activo 
        { 
            get { return _activo; }
            set { _activo = value; }
        }

        /// <summary>
        /// Lista de paquetes recibidos (solo lectura)
        /// </summary>
        public IReadOnlyList<PaqueteRed> PaquetesRecibidos 
        { 
            get { return _paquetesRecibidos.AsReadOnly(); }
        }

        /// <summary>
        /// Lista de paquetes enviados (solo lectura)
        /// </summary>
        public IReadOnlyList<PaqueteRed> PaquetesEnviados 
        { 
            get { return _paquetesEnviados.AsReadOnly(); }
        }

        /// <summary>
        /// Constructor base para dispositivos de red
        /// </summary>
        protected DispositivoRed(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            _activo = true;
            _paquetesRecibidos = new List<PaqueteRed>();
            _paquetesEnviados = new List<PaqueteRed>();
        }

        /// <summary>
        /// Método abstracto que define cómo cada dispositivo procesa un paquete
        /// </summary>
        public abstract void ProcesarPaquete(PaqueteRed paquete);

        /// <summary>
        /// Recibe un paquete y lo registra
        /// </summary>
        public virtual void RecibirPaquete(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));
            
            if (!_activo)
                throw new InvalidOperationException($"El dispositivo {Nombre} no está activo");

            _paquetesRecibidos.Add(paquete);
        }

        /// <summary>
        /// Envía un paquete y lo registra
        /// </summary>
        public virtual void EnviarPaquete(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));
            
            if (!_activo)
                throw new InvalidOperationException($"El dispositivo {Nombre} no está activo");

            _paquetesEnviados.Add(paquete);
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Nombre}] - {Direccion} - {(_activo ? "Activo" : "Inactivo")}";
        }
    }
}
