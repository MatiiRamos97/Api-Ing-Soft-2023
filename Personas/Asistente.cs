namespace Personas{
   public class Asistentes
   {  
      public int PersonaID
      {
         get; 
         set;
      }
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
      public bool Pagado
      {
         get;
         set;
      } 
      public int ChorifestID
      {
         get;
         set;
      } = 0;
   }
}