namespace Aplicacion.Modelos
{
    /// <summary>
    /// Representa un Firewall: dispositivo que filtra y controla el tráfico de red.
    /// Responsabilidad: Aceptar o rechazar paquetes según reglas de seguridad.
    /// </summary>
    public class Firewall : DispositivoRed
    {
        private List<ReglaFirewall> _reglas;
        private bool _modoEstricto; // Rechaza todo por defecto (whitelist)
        private int _paquetesRechazo;
        private int _paquetesAceptados;

        /// <summary>
        /// Reglas configuradas en el firewall
        /// </summary>
        public IReadOnlyList<ReglaFirewall> Reglas 
        { 
            get { return _reglas.AsReadOnly(); }
        }

        /// <summary>
        /// Modo estricto (rechaza todo excepto lo permitido explícitamente)
        /// </summary>
        public bool ModoEstricto 
        { 
            get { return _modoEstricto; }
            set { _modoEstricto = value; }
        }

        /// <summary>
        /// Contador de paquetes rechazados
        /// </summary>
        public int PaquetesRechazo 
        { 
            get { return _paquetesRechazo; }
        }

        /// <summary>
        /// Contador de paquetes aceptados
        /// </summary>
        public int PaquetesAceptados 
        { 
            get { return _paquetesAceptados; }
        }

        /// <summary>
        /// Constructor del Firewall
        /// </summary>
        public Firewall(string nombre, string direccion, bool modoEstricto = false) 
            : base(nombre, direccion)
        {
            _reglas = new List<ReglaFirewall>();
            _modoEstricto = modoEstricto;
            _paquetesRechazo = 0;
            _paquetesAceptados = 0;
        }

        /// <summary>
        /// Agrega una regla de firewall
        /// </summary>
        public void AgregarRegla(ReglaFirewall regla)
        {
            if (regla == null)
                throw new ArgumentNullException(nameof(regla));

            _reglas.Add(regla);
        }

        /// <summary>
        /// Evalúa si un paquete cumple con las reglas
        /// </summary>
        public bool EsPaquetePermitido(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));

            // Buscar coincidencias en las reglas
            foreach (var regla in _reglas)
            {
                if (regla.Coincidir(paquete))
                    return regla.Permitir;
            }

            // Si está en modo estricto y no hay coincidencia, rechaza
            if (_modoEstricto)
                return false;

            // Por defecto, permite
            return true;
        }

        /// <summary>
        /// Procesa un paquete aplicando las reglas de firewall
        /// </summary>
        public override void ProcesarPaquete(PaqueteRed paquete)
        {
            if (paquete == null)
                throw new ArgumentNullException(nameof(paquete));

            if (EsPaquetePermitido(paquete))
            {
                EnviarPaquete(paquete);
                _paquetesAceptados++;
            }
            else
            {
                _paquetesRechazo++;
                throw new InvalidOperationException($"Paquete rechazado por firewall: {paquete.Origen} -> {paquete.Destino}");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" - Reglas: {_reglas.Count}, Modo: {(_modoEstricto ? "Estricto" : "Permisivo")}, " +
                   $"Aceptados: {_paquetesAceptados}, Rechazados: {_paquetesRechazo}";
        }
    }

    /// <summary>
    /// Representa una regla de filtrado del firewall
    /// </summary>
    public class ReglaFirewall
    {
        private string _origenPatron;
        private string _destinoPatron;
        private bool _permitir;

        /// <summary>
        /// Patrón de IP origen (* = cualquiera)
        /// </summary>
        public string OrigenPatron 
        { 
            get { return _origenPatron; }
        }

        /// <summary>
        /// Patrón de IP destino (* = cualquiera)
        /// </summary>
        public string DestinoPatron 
        { 
            get { return _destinoPatron; }
        }

        /// <summary>
        /// ¿Permite o rechaza el tráfico que coincide?
        /// </summary>
        public bool Permitir 
        { 
            get { return _permitir; }
        }

        public ReglaFirewall(string origenPatron, string destinoPatron, bool permitir = true)
        {
            if (string.IsNullOrWhiteSpace(origenPatron))
                throw new ArgumentException("El patrón de origen no puede estar vacío", nameof(origenPatron));
            if (string.IsNullOrWhiteSpace(destinoPatron))
                throw new ArgumentException("El patrón de destino no puede estar vacío", nameof(destinoPatron));

            _origenPatron = origenPatron;
            _destinoPatron = destinoPatron;
            _permitir = permitir;
        }

        /// <summary>
        /// Verifica si un paquete coincide con esta regla
        /// </summary>
        public bool Coincidir(PaqueteRed paquete)
        {
            bool coincidenOrigen = _origenPatron == "*" || paquete.Origen == _origenPatron;
            bool coincidenDestino = _destinoPatron == "*" || paquete.Destino == _destinoPatron;

            return coincidenOrigen && coincidenDestino;
        }

        public override string ToString()
        {
            return $"Regla: {_origenPatron} -> {_destinoPatron} [{(_permitir ? "Permitir" : "Rechazar")}]";
        }
    }
}
