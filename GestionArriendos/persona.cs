using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace GestionArriendos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Persona(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
        }
    }

    public class Arrendatario : Persona
    {
        public List<Contrato_Arrendamiento> Contratos { get; } = new List<Contrato_Arrendamiento>();

        public Arrendatario(string nombre, string direccion) : base(nombre, direccion)
        {
        }

        public void AgregarContrato(Contrato_Arrendamiento contrato)
        {
            Contratos.Add(contrato);
        }

        public void RegistrarPagoMensual(Contrato_Arrendamiento contrato, decimal monto, DateTime fechaPago)
        {
            if (contrato != null && Contratos.Contains(contrato))
            {
                var pago = new Pago_Arriendo(monto, contrato.ReferenciaContrato, fechaPago);
                contrato.RegistrarPago(pago);
            }
            else
            {
                throw new ArgumentException("El contrato proporcionado no es válido.");
            }
        }
    }

    public class Arrendador : Persona
    {
        public List<string> Propiedades { get; } = new List<string>();

        public Arrendador(string nombre, string direccion) : base(nombre, direccion)
        {
        }

        public void AgregarPropiedad(string propiedad)
        {
            Propiedades.Add(propiedad);
        }
    }

    public class Contrato_Pago
    {
        public decimal MontoMensual { get; set; }
        public int ReferenciaContrato { get; set; }

        public Contrato_Pago(decimal montoMensual, int referenciaContrato)
        {
            MontoMensual = montoMensual;
            ReferenciaContrato = referenciaContrato;
        }
    }

    public class Contrato_Arrendamiento : Contrato_Pago
    {
        public string PropiedadAlquilada { get; set; }
        public DateTime FechaInicio { get; set; }
        public List<Pago_Arriendo> Pagos { get; } = new List<Pago_Arriendo>();

        public Contrato_Arrendamiento(decimal montoMensual, int referenciaContrato, string propiedadAlquilada, DateTime fechaInicio)
            : base(montoMensual, referenciaContrato)
        {
            PropiedadAlquilada = propiedadAlquilada;
            FechaInicio = fechaInicio;
        }

        public void ImprimirContrato()
        {
            Console.WriteLine("Detalles del contrato de arrendamiento:");
            Console.WriteLine($"Propiedad alquilada: {PropiedadAlquilada}");
            Console.WriteLine($"Monto mensual: {MontoMensual}");
            Console.WriteLine($"Fecha de inicio: {FechaInicio}");
            Console.WriteLine($"Referencia de contrato: {ReferenciaContrato}");
        }

        public void RegistrarPago(Pago_Arriendo pago)
        {
            // Verificar que el monto pagado coincida con el monto mensual del contrato
            if (pago.MontoMensual == MontoMensual)
            {
                Pagos.Add(pago);
            }
            else
            {
                throw new ArgumentException("El monto pagado no coincide con el monto mensual del contrato.");
            }
        }

        public List<Pago_Arriendo> ObtenerPagos()
        {
            return Pagos;
        }
    }

    public class Pago_Arriendo : Contrato_Pago
    {
        public DateTime FechaPago { get; set; }

        public Pago_Arriendo(decimal montoMensual, int referenciaContrato, DateTime fechaPago)
            : base(montoMensual, referenciaContrato)
        {
            FechaPago = fechaPago;
        }

        public void GenerarInformePago()
        {
            Console.WriteLine("Factura de pago:");
            Console.WriteLine($"Fecha de pago: {FechaPago}");
            Console.WriteLine($"Monto pagado: {MontoMensual}");
            Console.WriteLine("Pago exitoso");
        }
    }
}


// Ejemplo de implementacion :)))
/*
 class Program
{
    static void Main(string[] args)
    {
        // Crear un arrendador y un arrendatario
        Arrendador arrendador = new Arrendador("Juan", "Calle Principal");
        Arrendatario arrendatario = new Arrendatario("Maria", "Calle Secundaria");

        // Agregar una propiedad al arrendador
        arrendador.AgregarPropiedad("Casa en la playa");

        // Crear un contrato de arrendamiento
        Contrato_Arrendamiento contrato = new Contrato_Arrendamiento(1000, 1, "Casa en la playa", DateTime.Now);

        // Agregar el contrato al arrendatario
        arrendatario.AgregarContrato(contrato);

        // Registrar un pago mensual
        arrendatario.RegistrarPagoMensual(contrato, 1000, DateTime.Now);

        // Imprimir el contrato y generar un informe de pago
        contrato.ImprimirContrato();
        var pagos = contrato.ObtenerPagos();
        foreach (var pago in pagos)
        {
            pago.GenerarInformePago();
        }
    }
}
 */