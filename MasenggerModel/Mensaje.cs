using System;

namespace MasenggerModel
{
    [Serializable]
    public class Mensaje
    {
        public int Id { get; set; }

        public int IdGrupo { get; set; }

        public int IdUsuario { get; set; }

        public int IdUsuarioRemitente { get; set; }

        public string NickUsuarioRemitente { get; set; }

        public string Contenido { get; set; }

        public string RutaContenido { get; set; }

        public byte[] Binario { get; set; }

        public DateTime FechaAlta { get; set; }
    }
}
