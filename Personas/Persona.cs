//using Asistentes;
namespace Personas
{
   public class Persona 
   {  
      public int PersonaID
      {
         get; 
         set;
      }
      public string Nombre
      {
         get; 
         set;
      } = "";
      public string Apellido
      {
         get; 
         set;
      } = "";
      public string Email{
         get;
         set;
      } = ""; 

      public string NombreCompleto{
         get
         {
            return this.Nombre + " " + this.Apellido;
         }
      }

       public string TipoPersona { get; set; } // Esto se usará como discriminador


   }
}