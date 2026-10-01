namespace Aplicacion.Modelos
{
    /// <summary>
    /// Representa un paquete de datos que circula por la red.
    /// Encapsula la información necesaria: origen, destino, contenido y metadatos.
    /// </summary>
    public class PaqueteRed
    {
        private string _origen;
        private string _destino;
        private string _contenido;
        private int _tamaño;
        private Guid _id;

        /// <summary>
        /// Identificador único del paquete
        /// </summary>
        public Guid Id 
        { 
            get { return _id; } 
        }

        /// <summary>
        /// Dirección IP o identificador del dispositivo origen
        /// </summary>
        public string Origen 
        { 
            get { return _origen; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El origen no puede estar vacío", nameof(Origen));
                _origen = value;
            }
        }

        /// <summary>
        /// Dirección IP o identificador del dispositivo destino
        /// </summary>
        public string Destino 
        { 
            get { return _destino; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El destino no puede estar vacío", nameof(Destino));
                _destino = value;
            }
        }

        /// <summary>
        /// Contenido del paquete
        /// </summary>
        public string Contenido 
        { 
            get { return _contenido; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El contenido no puede estar vacío", nameof(Contenido));
                _contenido = value;
            }
        }

        /// <summary>
        /// Tamaño del paquete en bytes
        /// </summary>
        public int Tamaño 
        { 
            get { return _tamaño; }
            set 
            { 
                if (value <= 0)
                    throw new ArgumentException("El tamaño debe ser mayor a 0", nameof(Tamaño));
                if (value > 65535)
                    throw new ArgumentException("El tamaño no puede exceder 65535 bytes", nameof(Tamaño));
                _tamaño = value;
            }
        }

        /// <summary>
        /// Timestamp de creación del paquete
        /// </summary>
        public DateTime FechaCreacion { get; }

        /// <summary>
        /// Constructor que inicializa el paquete con validaciones
        /// </summary>
        public PaqueteRed(string origen, string destino, string contenido, int tamaño)
        {
            Origen = origen;
            Destino = destino;
            Contenido = contenido;
            Tamaño = tamaño;
            _id = Guid.NewGuid();
            FechaCreacion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Paquete [{Id}] de {Origen} a {Destino} ({Tamaño} bytes)";
        }
    }
}
