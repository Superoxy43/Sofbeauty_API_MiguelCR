namespace Sofbeauty_API_MiguelCR.ModelsDTOs
{
    public class UsuarioDTO
    {

        public int UsuarioID { get; set; }
        public string Correo { get; set; } = null;
        public string Nombre { get; set; } = null;
        public string Telefono { get; set; }
        public string contrasennia { get; set; } = null;
        public int RolId { get; set; }


        public string? RolDescripcion { get; set; }
    }
}
