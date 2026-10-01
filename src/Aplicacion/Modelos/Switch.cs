namespace Aplicacion.Modelos
{
    /// <summary>
    /// Representa un Switch: dispositivo que conmuta (conecta) puertos según direcciones MAC.
    /// Responsabilidad: Reenviar paquetes al puerto correcto basándose en la tabla MAC.
    /// </summary>
    public class Switch : DispositivoRed
    {
        private Dictionary<string, int> _tablaMac; // MAC -> número de puerto
        private int _cantidadPuertos;
        private Dictionary<int, bool> _puertosActivos; // número de puerto -> estado

        /// <summary>
        /// Tabla de direcciones MAC
        /// </summary>
        public IReadOnlyDictionary<string, int> TablaMac 
        { 
            get { return _tablaMac.AsReadOnly(); }
        }

        /// <summary>
        /// Cantidad de puertos disponibles
        /// </summary>
        public int CantidadPuertos 
        { 
            get { return _cantidadPuertos; }
        }

        /// <summary>
        /// Constructor del switch con número de puertos
        /// </summary>
        public Switch(string nombre, string direccion, int cantidadPuertos = 24) 
            : base(nombre, direccion)
        {
            if (cantidadPuertos <= 0)
                throw new ArgumentException("La cantidad de puertos debe ser mayor a 0", nameof(cantidadPuertos));

            _cantidadPuertos = cantidadPuertos;
            _tablaMac = new Dictionary<string, int>();
            _puertosActivos = new Dictionary<int, bool>();

            // Inicializar todos los puertos como activos
            for (int i = 1; i <= cantidadPuertos; i++)
                _puertosActivos[i] = true;
        }

        /// <summary>
        /// Registra una dirección MAC en un puerto específico
        /// </summary>
        public void RegistrarMac(string dirMac, int numeroPuerto)
        {
            if (string.IsNullOrWhiteSpace(dirMac))
                throw new ArgumentException("La dirección MAC no puede estar vacía", nameof(dirMac));
            
            if (numeroPuerto < 1 || numeroPuerto > _cantidadPuertos)
                throw new ArgumentException($"Número de puerto inválido: {numeroPuerto}", nameof(numeroPuerto));

            _tablaMac[dirMac] = numeroPuerto;
        }

        /// <summary>
        /// Obtiene el puerto asociado a una dirección MAC
        /// </summary>
        public int ObtenerPuertoMac(string dirMac)
        {
            if (_tablaMac.TryGetValue(dirMac, out var puerto))
                return puerto;

            return -1; // MAC no encontrada
        }

        /// <summary>
        /// Activar o desactivar un puerto específico
        /// </summary>
        public void EstablecerEstadoPuerto(int numeroPuerto, bool activo)
        {
            if (numeroPuerto < 1 || numeroPuerto > _cantidadPuertos)
                throw new ArgumentException($"Número de puerto inválido: {numeroPuerto}", nameof(numeroPuerto));

            _puertosActivos[numeroPuerto] = activo;
        }

        /// <summary>
        /// Verifica si un puerto está activo
        /// </summary>
        public bool EsPuertoActivo(int numeroPuerto)
        {
            if (numeroPuerto < 1 || numeroPuerto > _cantidadPuertos)
                return false;

            return _puertosActivos[numeroPuerto];
        }

        /// <summary>
        /// Procesa un paquete conmutándolo al puerto correcto
        /// </summary>
        public override void ProcesarPaquete(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));

            // En un switch real, se usaría la MAC destino
            // Aquí simplificamos conmutando a todos los puertos activos (broadcast)
            int puerto = ObtenerPuertoMac(paquete.Destino);
            
            if (puerto != -1 && EsPuertoActivo(puerto))
                EnviarPaquete(paquete);
            else
                throw new InvalidOperationException($"Destino no encontrado o puerto inactivo");
        }

        public override string ToString()
        {
            return base.ToString() + $" - Puertos: {_cantidadPuertos}, MACs registradas: {_tablaMac.Count}";
        }
    }
}
