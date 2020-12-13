using System;

namespace MasenggerModel
{
    [Serializable]
    public class FiltroLista
    {
        public int IdGrupo { get; set; }

        public int IdUsuario { get; set; }

        public string NickRemitente { get; set; }

        public int IdUsuarioRemitente { get; set; }
    }
}
