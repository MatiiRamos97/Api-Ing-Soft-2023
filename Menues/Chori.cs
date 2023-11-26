namespace Menues
{
    public class Chori
    {
      public int IdChori{
         get; 
         set;
      }
      public bool EsVegano{
         get; 
         set;
      }
      public string Descripcion{
         get;
         set;
      }
      public float Precio{
         get;
         set;
      }
      public int Cantidad{
         get;
         set;
      }

      public bool ConPapas{
         get;
         set;
      }

      private int choriComun{
        get; 
        set;
      }
      private int choriVegano{
        get; 
        set;
      }

       
      public void SumarizarChori(){

         if(this.EsVegano){
            choriVegano += 1;
         }
         else
         {
            choriComun += 1;
         }  
      }
    }
}