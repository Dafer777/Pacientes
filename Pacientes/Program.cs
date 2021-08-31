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
            Console.WriteLine("2. Actualizar datos de paciente");
            Console.WriteLine("3. Eliminar datos de paciente");
            Console.WriteLine("4. Mostrar listado de paciente");
            Console.WriteLine("5. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    register(); //llamado al metodo registrar
                    return true;
                case "2":
                    updateData(); //llamdo al metodo para actualizar
                    Console.ReadKey();
                    return true;
                case "3":
                    deleteData();//lamado al metodo eliminar
                    Console.ReadKey();
                    return true;
                case "4":
                    //mostrar el contenido del archivo
                    Console.WriteLine("LISTADO DE PACIENTES");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
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
            
            //solicitar los datos del paciente
            Console.WriteLine("DATOS DE LA PERSONA");
            Console.Write("Nombre Completo: ");
            string fullname = Console.ReadLine();
            Console.Write("Edad: ");
            int age = Convert.ToInt32(Console.ReadLine());
           
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
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 1)
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

               
                sw.WriteLine("{0}; {1}", fullname, age);
              
                sw.WriteLine("{0}; {1}", Fecha, Examenes, Les);
                
                sw.WriteLine(consulta);
                sw.Close();

               
            }
        }

        //metodo para leer el contenido del archivo
        private static Dictionary<object, object > readFile()
        {
            //declarar el diccionario
            Dictionary<object, object> listData = new Dictionary<object, object>();
            Dictionary<object, object> list = new Dictionary<object, object>();

            //uso del StreamReader para leer el archivo
            using (var reader = new StreamReader(getPath()))
            {
                //variable para almacenar el contenido del archivo
                string lines;   

                while ((lines = reader.ReadLine()) != null) //mientras no se encuentre una linea vacia se ejecuta el ciclo
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        
                        listData.Add(keyvalue[0], keyvalue[1]);
                    
                       
                    }

                



                }
            }


            //retornar el diccionario
            return listData;
        }

        //metodo para buscar por clave
        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;
        }

        //metodo para actualizar
        private static void updateData()
        {
            //solicitar el elemnto a modificar
            Console.Write("Escriba el nombre del estudiante a actualizar: ");
            var name = Console.ReadLine();

            //realizar la busqueda
            if (search(name))
            {
                Console.WriteLine("El registro existe!");
                Console.Write("Nueva edad: ");
                var newAge = Console.ReadLine();

                //declarar un diccionario
                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[name] = newAge; //actualizar el valor
                Console.WriteLine("El registro ha sido actualizado!");
                File.Delete(getPath()); //eliminamos archivos y posteriormente lo volvemos a crear

                using (StreamWriter sw = File.AppendText(getPath()))
                {
                    //leer diccionario temporal y almacenar los elementos en el archivo
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);
                        // sw.Close();
                    }
                }

            }
            else
            {
                Console.WriteLine("El registro no se encontro!");
            }
        }

        private static void deleteData()
        {
            //solicitar el elemnto a eliminar
            Console.Write("Escriba el nombre del estudiante a eliminar: ");
            var name = Console.ReadLine();

            //realizar la busqueda
            if (search(name))
            {


                //declarar un diccionario
                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp.Remove(name);
                Console.WriteLine("El registro ha sido eliminado!");
                File.Delete(getPath()); //eliminamos archivos y posteriormente lo volvemos a crear

                using (StreamWriter sw = File.AppendText(getPath()))
                {
                    //leer diccionario temporal y almacenar los elementos en el archivo
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);
                        // sw.Close();
                    }
                }

            }
            else
            {
                Console.WriteLine("El registro no se encontro!");
            }
        }
    }
}