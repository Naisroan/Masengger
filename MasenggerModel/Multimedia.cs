using System;

namespace MasenggerModel
{
    [Serializable]
    public class Multimedia
    {
        public int Id { get; set; }

        public string Ruta { get; set; }

        public string Nombre { get; set; }

        public string Extension { get; set; }

        public byte[] Contenido { get; set; }
    }
}
