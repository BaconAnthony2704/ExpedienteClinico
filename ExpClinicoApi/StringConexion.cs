using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi
{
    public class StringConexion
    {
        public string obtenerRuta()
        {
            string ruta = "\\srvuse.txt";
            string line;
            var CurrentDirectory = Environment.CurrentDirectory;
            String conexion="";
            //Accedemos a la ruta del archivo
            try
            {
                StreamReader sr = new StreamReader(CurrentDirectory+ruta);
                line = sr.ReadLine();
                sr.Close();


                switch (line)
                {
                    case "dev":
                        conexion = "server=localhost;user=root;database=clinica;port=3306;password='';";
                        break;
                    case "prd":
                        conexion = "server=remotemysql.com;user=3ExE2H1Roh;port=3306;database=3ExE2H1Roh;password='Zr6eXf4jyi';";
                        break;
                    case "memo":
                        conexion= "server=localhost;user=root;database=prueba;port=3306;password='';";
                        break;

                }
                return conexion;

            }catch(Exception e)
            {
                throw e;
            }
            
            
            //Console.WriteLine(CurrentDirectory);
        }
    }

    
}
