namespace Sofbeauty_API_MiguelCR.ModelsDTOs
{
    public class ProductDTO
    {
        public int ProductoId { get; set; } 
        
        public string PNombre { get; set; }

        public string Descripcion { get; set; }

        public string Tipo { get; set; }    

        public decimal Precio { get; set; } 

        public string Imagen { get; set; }

        public int Existencias { get; set; }

        //public string Email { get; set; } = null!;


    }
}
