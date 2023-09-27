namespace Veterinaria
{
  public class Mascota
  {
    public string Nombre { get; set; }
    public Especie Especie { get; }
    public bool EsHabitual { get; set; }
  }
}

// +-----------------+
// |    Mascota      |
// +-----------------+
// | - nombre        |
// | - especie       |
// | - esHabitual    |
// +-----------------+
//         |
//         |
//         |   1..*
// +-----------------+
// |   Veterinaria   |
// +-----------------+
// | - razonSocial   |
// | - atenciones    |
// +-----------------+
//         |
//         |
//         |   1..*
// +-----------------+
// |    Atención     |
// +-----------------+
// | - codigo        |
// | - tipoCobro     |
// +-----------------+
//         |
//         |
//         |   1
// +-----------------+
// |  ITipoAtencion  |
// +-----------------+
// | -  importe()    |
// +-----------------+
//         |
//         |
//         |   1
// +-----------------+
// |    Médica       |
// +-----------------+
// | - mascota       |
// | - importeConsulta|
// +-----------------+
//         |
//         |
//         |   1
// +-----------------+
// |    Tienda       |
// +-----------------+
// | - importeTotal  |
// | - descuentoVale |
// +-----------------+

// public class Médica : Atención, ITipoAtencion
// {
//     // ...

//     public decimal Importe()
//     {
//         // Lógica específica para calcular el importe de una atención médica
//         // Puedes acceder a los atributos de la clase Médica para realizar los cálculos necesarios
//         // Por ejemplo:
//         return importeConsulta;
//     }
// }
// Y en la clase "Tienda" implementarías el método "Importe" de acuerdo a la lógica específica de una atención de tienda:

// public class Tienda : Atención, ITipoAtencion
// {
//     // ...

//     public decimal Importe()
//     {
//         // Lógica específica para calcular el importe de una atención de tienda
//         // Puedes acceder a los atributos de la clase Tienda para realizar los cálculos necesarios
//         // Por ejemplo:
//         decimal importeFinal = importeTotal - descuentoVale;
//         return importeFinal;
//     }
// }