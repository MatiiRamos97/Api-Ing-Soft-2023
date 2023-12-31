using Chorifests;
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
      public Admin? admin { get; set; }
      public Asistentes? asistentes { get; set; }
   }
}