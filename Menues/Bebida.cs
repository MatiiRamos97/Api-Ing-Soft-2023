namespace Menues
{
   public class Bebida 
   {  
    public int BebidaID { get; set; }
    public string Nombre { get; set; } = ""; 

    public string Linea { get; set;} = "";
    public string Tipo { get; set; } = "";
    public decimal Precio { get; set; }
    public bool Alcoholica { get; set; }
    public double Litros { get; set;} = 0;
    public DateTime FechaFabricacion { get; set; }

    }
}