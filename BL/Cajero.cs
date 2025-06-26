using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cajero
    {
        //Validar que el cajero no pueda superar la cantidad de efectivo que tiene de límite
        //CASO: usuario quiere retirar 130, problema, solo quedan dos billetes de mil en el cajero ¿Qué debe pasar?
        public static ML.Result RetirarEfectivo(decimal retiro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.ExamenPracticoCajeroEntities context = new DL.ExamenPracticoCajeroEntities())
                {

                    // Verificar el total de dinero disponible en el cajero
                    decimal totalEfectivo = context.Cajeroes.Sum(c => c.Denominacion * c.Cantidad);

                    if (retiro > totalEfectivo)
                    {
                        result.Correct = false;
                        result.Message = "No hay suficiente efectivo en el cajero.";
                        return result;
                    }

                    int filasAfectadas = context.RetirarEfectivo(retiro);

                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo completar el retiro.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public static ML.Result CajeroGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.ExamenPracticoCajeroEntities context = new DL.ExamenPracticoCajeroEntities())
                {
                    var query = context.CajeroGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach(var item in query)
                        {
                            ML.Cajero cajero = new ML.Cajero();
                            cajero.Tipo = new ML.Tipo();

                            cajero.IdCajero = item.IdCajero;
                            cajero.Tipo.Nombre = item.Nombre;
                            cajero.Cantidad = item.Cantidad;
                            cajero.Denominacion = item.Denominacion;

                            result.Objects.Add(cajero);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
