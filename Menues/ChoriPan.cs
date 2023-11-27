namespace Menues
{
   public class ChoriPan 
   {  
    public int ChoriPanID { get; set; } 
    public string Nombre { get; set; } = "";
    
    public bool LlevaTomate { get; set;}

    public bool LLevaLechuga { get; set;}

    public bool LLevaAderezo { get; set;}
    public bool EsCarne { get; set; }
    public bool EsVegano {get; set;}
    public bool EsPan { get; set; }
    }
}