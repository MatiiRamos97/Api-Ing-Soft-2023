namespace Personas{
   public class Admin
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
      public int AdminId 
      {  
         get; 
         set;
      }
      public string Contraseña{
         get;
         set;
      } = "";  
   }
}