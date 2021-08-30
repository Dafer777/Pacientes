using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pacientes
{
    class Program
    {

        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu(); //llamdo al metodo Menu()
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            //crear el menu para mostrar al usuario
            //Console.Clear(); //permite limpiar la consola
            Console.WriteLine("Seleccion la operación a realizar: ");
            Console.WriteLine("1. Registrar nuevo paciente");
            Console.WriteLine("2. Actualizar datos del paciente");
            Console.WriteLine("3. Eliminar datos del paciente");
            Console.WriteLine("4. Mostrar listado de pacientes");
            Console.WriteLine("5. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    register(); //llamado al metodo registrar
                    return true;
                case "2":
                 
                    return true;
                case "3":
               
                    return true;
                case "4":
                   
                    return true;
                case "5":
                    return false;
                default:
                    return false;
            }
        }

        //metodo para obtener la ruta del archivo
        private static string getPath()
        {
            string path = @"D:\ejemplo\registros.txt";
            return path;
        }

        //metodo para registrar datos en el archivo
        private static void register()
        {
            string consulta;
            //solicitar los datos del estudiante
            Console.WriteLine("DATOS DE LA PERSONA");
            Console.Write("Nombre Completo: ");
            string fullname = Console.ReadLine();
            Console.Write("Edad: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Telefono: ");
            int Tel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("REGISTRO MEDICO DE LA PERSONA ");
            Console.WriteLine("Ultima fecha de sus examenes: ");
            string Fecha = Console.ReadLine(); //ultima fecha de examenes medicos
            Console.WriteLine("Resultados de sus ultimos examenes: ");
            string Examenes = Console.ReadLine(); // resultados de sus ultimos examenes
            Console.WriteLine("Ha tenido lesiones recientemente digitelas: ");
            string Les = Console.ReadLine(); // ultimas lesiones padecidas
            Console.WriteLine("Desea programar cita: ");
            Console.WriteLine("1. Si");
            Console.WriteLine("2. No");
            string i = Console.ReadLine();
            if (i == "si")
            {
                Console.WriteLine("Digite el dia de la cita: ");
                consulta = Console.ReadLine();

            }
            else
            {
                consulta = "No tiene cita la persona";
                Console.WriteLine("No se le a asignado su cita");
            }



            //crear el archivo, uso de StreamWriter para escribir el archivo
            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("Datos Personales");
                sw.WriteLine("{0}; {1}", fullname, age, Tel);
                sw.WriteLine("Registro medico");
                sw.WriteLine("{0}; {1}", Fecha, Examenes, Les);
                sw.WriteLine("Fecha de su cita");
                sw.WriteLine(consulta);
                sw.Close();
            }

            Console.ReadKey();
        }
    }
}
