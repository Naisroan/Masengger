using System;

namespace MasenggerModel
{
    [Serializable]
    public class Usuario
    {
        public int Id { get; set; }

        public string Nick { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }
    }
}
