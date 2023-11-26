namespace Personas{
   public class Asistentes
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