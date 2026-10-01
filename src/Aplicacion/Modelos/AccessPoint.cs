namespace Aplicacion.Modelos
{
    /// <summary>
    /// Representa un Access Point (AP): dispositivo que permite conexión inalámbrica a la red.
    /// Responsabilidad: Conectar dispositivos inalámbricos y gestionar la cobertura.
    /// </summary>
    public class AccessPoint : DispositivoRed
    {
        private List<string> _dispositivosConectados;
        private string _ssid; // Network name
        private int _potenciaSeñal; // 0-100
        private int _anchodeBanda; // MHz
        private string _tipoSeguridad;

        /// <summary>
        /// Nombre de la red (SSID)
        /// </summary>
        public string Ssid 
        { 
            get { return _ssid; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El SSID no puede estar vacío", nameof(Ssid));
                _ssid = value;
            }
        }

        /// <summary>
        /// Potencia de la señal (0-100)
        /// </summary>
        public int PotenciaSeñal 
        { 
            get { return _potenciaSeñal; }
            set 
            { 
                if (value < 0 || value > 100)
                    throw new ArgumentException("La potencia debe estar entre 0 y 100", nameof(PotenciaSeñal));
                _potenciaSeñal = value;
            }
        }

        /// <summary>
        /// Ancho de banda (MHz)
        /// </summary>
        public int AnchodeBanda 
        { 
            get { return _anchodeBanda; }
            set 
            { 
                if (value <= 0)
                    throw new ArgumentException("El ancho de banda debe ser mayor a 0", nameof(AnchodeBanda));
                _anchodeBanda = value;
            }
        }

        /// <summary>
        /// Tipo de seguridad (WPA2, WPA3, Abierta, etc.)
        /// </summary>
        public string TipoSeguridad 
        { 
            get { return _tipoSeguridad; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo de seguridad no puede estar vacío", nameof(TipoSeguridad));
                _tipoSeguridad = value;
            }
        }

        /// <summary>
        /// Dispositivos conectados al AP (solo lectura)
        /// </summary>
        public IReadOnlyList<string> DispositivosConectados 
        { 
            get { return _dispositivosConectados.AsReadOnly(); }
        }

        /// <summary>
        /// Constructor del Access Point
        /// </summary>
        public AccessPoint(string nombre, string direccion, string ssid, int potenciaSeñal = 80, 
                          int anchodeBanda = 20, string tipoSeguridad = "WPA2") 
            : base(nombre, direccion)
        {
            Ssid = ssid;
            PotenciaSeñal = potenciaSeñal;
            AnchodeBanda = anchodeBanda;
            TipoSeguridad = tipoSeguridad;
            _dispositivosConectados = new List<string>();
        }

        /// <summary>
        /// Conectar un dispositivo inalámbrico al AP
        /// </summary>
        public void ConectarDispositivo(string dirMac)
        {
            if (string.IsNullOrWhiteSpace(dirMac))
                throw new ArgumentException("La dirección MAC no puede estar vacía", nameof(dirMac));

            if (_dispositivosConectados.Contains(dirMac))
                throw new InvalidOperationException($"Dispositivo {dirMac} ya está conectado");

            if (!Activo)
                throw new InvalidOperationException($"El AP {Nombre} no está activo");

            _dispositivosConectados.Add(dirMac);
        }

        /// <summary>
        /// Desconectar un dispositivo inalámbrico del AP
        /// </summary>
        public void DesconectarDispositivo(string dirMac)
        {
            if (string.IsNullOrWhiteSpace(dirMac))
                throw new ArgumentException("La dirección MAC no puede estar vacía", nameof(dirMac));

            _dispositivosConectados.Remove(dirMac);
        }

        /// <summary>
        /// Verifica si un dispositivo está conectado
        /// </summary>
        public bool EstaDispositivoConectado(string dirMac)
        {
            return _dispositivosConectados.Contains(dirMac);
        }

        /// <summary>
        /// Procesa un paquete inalámbrico
        /// </summary>
        public override void ProcesarPaquete(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));

            // Verificar que el dispositivo destino esté conectado
            if (!EstaDispositivoConectado(paquete.Destino))
                throw new InvalidOperationException($"Destino {paquete.Destino} no está conectado a este AP");

            // Verificar que hay suficiente potencia de señal
            if (_potenciaSeñal < 30)
                throw new InvalidOperationException("Potencia de señal insuficiente");

            EnviarPaquete(paquete);
        }

        public override string ToString()
        {
            return base.ToString() + $" - SSID: {_ssid}, Dispositivos: {_dispositivosConectados.Count}, " +
                   $"Señal: {_potenciaSeñal}%";
        }
    }
}
