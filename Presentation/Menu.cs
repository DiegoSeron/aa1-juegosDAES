namespace Juegos.Presentation;

class Menu
{

    
    public void MenuAdmin(){
        Console.WriteLine("soy el menú de Admin");
    }

    public void MenuUser(){
        Console.WriteLine("soy el menú de User");
        MenuUserSignIn();
        MenuUserRegister();
    }


     public void MenuUserSignIn(){
        Console.WriteLine("soy el menú de User de iniciar sesion");
    } 
     public void MenuUserRegister(){
        Console.WriteLine("soy el menú de User de Registro");
    } 
}