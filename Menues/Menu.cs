namespace Menues
{
   public class Menu 
   {  
      public int MenuID
      {
         get; 
         set;
      }
      public int ChorifestID
      {
         get;
         set;
      } = 0;
      public string Nombre
      {
         get; 
         set;
      } = "";
      public ChoriPan? ChoriPan { get; set;} 
      public Bebida? Bebida {get; set;}
    }

}