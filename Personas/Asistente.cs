
namespace Personas
{
   public class Asistentes : Persona
   {  
      public int AsistenteID
      {
         get; 
         set;
      }
      
      public bool Asistio
      {
         get; 
         set;
      }
      public bool Pagado{
         get;
         set;
      } 
      public string Descripcion{
         get;
         set;
      } = "";

      public int ChorifestID
      {
         get; 
         set;
      }
   }
}
