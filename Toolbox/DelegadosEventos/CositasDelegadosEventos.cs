using System;
using System.Threading.Tasks;

namespace DelegadosEventos
{
    public class CositasDelegadosEventos
    {
        //DEFINO UN TIPO DE DELEGADO 'DELEGADODEMIFUNCION' CON LA FIRMA
        //QUE VAN A TENER QUE RESPETAR TODAS LAS FUNCIONES MANEJADAS POR LOS
        //OBJETOS DELEGADOS.
        public delegate void DelegadoDeMiFuncion(Int32 num1, Int32 num2);

        //INSTANCIO UN OBJETO DEL TIPO DELEGADO 'DELEGADODEMIFUNCION'
        //AL CONSTRUCTOR LE PASO COMO PARAMETRO LA DIRECCION DE MEMORIA
        //DEL METODO QUE SE VA A EJECUTAR CUANDO SEA INVOCADO
        DelegadoDeMiFuncion MiDelegado = new DelegadoDeMiFuncion("METODO QUE TIENE QUE EJECUTAR");

        //UTILIZANDO EL METODO INVOKE EXPLICITAMENTE
        MiDelegado.Invoke(15, 20);

        //O IMPLICITAMENTE
       MiDelegado(10, 5);

        "-------------------------------------------------------------------------------------------------------------"
        //DECLARO UN DELEGADO
        public delegate void LimiteSueldoDelegado(Double sueldo, Empleado e);

        //DECLARO UN EVENTO
        public event LimiteSueldoDelegado LimiteSueldo;

         //LANZO EL EVENTO
        this.LimiteSueldo(value, this);

        //ASOCIO EL EVENTO A SU MANEJADOR
        empleadoEvento.LimiteSueldo += new LimiteSueldoDelegado(SobreSueldo_Evento);

        //METODO MANEJADOR DEL EVENTO QUE TIENE QUE TENER LA MISMA FIRMA QUE EL TIPO DELEGADO
        public static void SobreSueldo_Evento(Double importe, Empleado e)
        {
            Console.WriteLine("Se ha sobrepasado, para el empleado {0}, el límite establecido de sueldo",
                              e.Nombre);

            Console.WriteLine("El importe de $ {0:#,###.00} no es válido!!!", importe);

        }

        "--------------------------------------------------------------------------------------------------"
        //GENERAR HILO 
         Task task = Task.Run(() => usuario1.RecuperarInfo(rutaArchivo3));
         task.Wait();

       //PARAMETRISADO
       Task t = Task.Run(() => Program.MetodoTareaParam(5, "hola mundo"));

        /*
        1-Crea un Task, creo el método TraerPlanetas():void
        2-En el subproceso invoco al método TraerPlanetas()
        2-Traigo los planetas de la base de datos a través del hilo secundario.
        3-Modifico el ReachTextBox a través del hilo principal.
        */
        private void btnTraer_Click(object sender, EventArgs e)
        {
            Task tsk = new Task(() => this.TraerPlanetas());
            tsk.Start();
        }
        private void TraerPlanetas()
        {
            List<Planeta> planetas = new List<Planeta>();
            AccesoDatos datosPlanetas = new AccesoDatos();
            planetas = datosPlanetas.ObtenerListaPlaneta();
            //CON ESTO ACCEDO AL CONTROL QUE SE EJECUTA EN EL HILO PRINCIPAL
            if (richTextBox1.InvokeRequired)
            {
                Action ac = TraerPlanetas;
                Invoke(ac);
            }
            else
            {
                foreach (Planeta item in planetas)
                {
                    richTextBox1.Text += item.ToString();
                }
            }
        }


    }
}
