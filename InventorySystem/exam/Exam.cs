namespace MatCom.Exam
{

    public class Exam
    {
        public static IInventory GetInventory()
        {
            // Devuelva aquí su instancia de IInventory
            return new Inventory(new Category("root", null));
        }

        // Borre esta excepción y ponga su nombre como string, e.j.
        // Nombre => "Fulano Pérez Pérez";
        public static string Nombre => "Franco Hernandez Piloto";

        // Borre esta excepción y ponga su grupo como string, e.j.
        // Grupo => "C2XX";
        public static string Grupo => "C111";
    }
}