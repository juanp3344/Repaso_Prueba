
public class Metodos{
public static void IMPRIMIR(String mensaje)
{
    Console.WriteLine(mensaje);
}

public static string? lea (String mensaje)
{
    string? Escribir ="";
    IMPRIMIR(mensaje);
    try
    {
       Escribir = Console.ReadLine();
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Error de E/S: {ex.Message}");
    }
    return Escribir;
}


public static Deportistas Ingreso_De_Datos()
{
    Deportistas e = new Deportistas();
    int id_Retorno;
    decimal sueldo;

    while (!int.TryParse(lea("Ingrese el ID del deportista"), out id_Retorno))
        IMPRIMIR("ID inválido, intente nuevamente.");

    while (!decimal.TryParse(lea("Ingrese el sueldo del deportista"), out sueldo))
        IMPRIMIR("Sueldo inválido, intente nuevamente.");

    return new Deportistas()
    {
        id = id_Retorno,
        Cedula = lea("Ingrese la cedula del deportista:"),
        Nombre = lea("Ingrese el nombre del deportista:"),
        sueldo = sueldo,
        sueldo_neto = e.sueldo_valor(sueldo)

    };
}

public static Entrenadores Ingreso_De_DatosE()
{

    int id_Retorno;
    decimal sueldo;
    Entrenadores e = new Entrenadores();

    while (!int.TryParse(lea("Ingrese el ID del entrenador"), out id_Retorno))
        IMPRIMIR("ID inválido, intente nuevamente.");

    while (!decimal.TryParse(lea("Ingrese el sueldo del entrenador"), out sueldo))
        IMPRIMIR("Sueldo inválido, intente nuevamente.");

    return new Entrenadores()
    {
        id = id_Retorno,
        Cedula = lea("Ingrese la cedula del entrenador:"),
        Nombre = lea("Ingrese el nombre del entrenador:"),
        sueldo = sueldo,
        sueldo_neto = e.sueldo_valor(sueldo)
        //???????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????'''''''''
    };
}
public static void MostarDatos(Deportistas objD)
{
    IMPRIMIR($"""
        ID: {objD.id}
        Cedula: {objD.Cedula}
        Nombre: {objD.Nombre}
        Sueldo: {objD.sueldo}
        Sueldo neto: {objD.sueldo_neto }
        """);
}
public static void MostarDatos(Entrenadores objE)
{
    IMPRIMIR($"""
        ID: {objE.id}
        Cedula: {objE.Cedula}
        Nombre: {objE.Nombre}
        Sueldo: {objE.sueldo}
        Sueldo neto: {objE.sueldo_neto }
        """);
}
}

class Program
{
    static void Main(string[] args)
    {
        Deportistas deportista3 = Metodos.Ingreso_De_Datos();
        Metodos.MostarDatos(deportista3);
        Entrenadores entrenador = Metodos.Ingreso_De_DatosE();
        Metodos.MostarDatos(entrenador);
    }
}


public class Deportes
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public DateTime fecha { get; set; }
    public bool activo { get; set; }


    public List<Deportes_Equipos>? Deportes_Equipos { get; set; }
    public List<Implementos>? Implementos { get; set; }
}

public class Deportes_Equipos
{
    public int id { get; set; }
    public int Equipo { get; set; }
    public int Deporte { get; set; }
    public Equipos? _Equipo { get; set; }
    public Deportes? _Deporte { get; set; }

}

public class Equipos
{
    public int id { get; set; }
    public string? Nombre { get; set; }
    public DateTime fecha { get; set; }
    public bool activo { get; set; }

    public List<Deportes_Equipos>? Deportes_Equipos { get; set; }
    public List<Entrenadores>? Entrenadores { get; set; }
    public List<Deportistas>? Deportistas { get; set; }
}

public abstract class Personas
{
    public int id { get; set; }
    public string? Cedula { get; set; }
    public string? Nombre { get; set; }
    public DateTime fecha { get; set; }
    public decimal sueldo {get; set;}
    public bool activo { get; set; }

   public abstract decimal sueldo_valor(decimal valor);

}

public class Entrenadores : Personas
{
    public decimal sueldo_neto;
    public int Equipo { get; set; }
    public Equipos? _Equipo { get; set; }


    public override decimal sueldo_valor(decimal valor)
    {
        decimal retorno;
        retorno = valor+(valor*0.20m);

        return retorno;
    }
}

//¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡
public class Deportistas : Personas
{
    public decimal sueldo_neto;
    public int Equipo { get; set; }
    public Equipos? _Equipo { get; set; }

     public override decimal sueldo_valor(decimal valor)
    {
        decimal retorno;
        retorno = valor+(valor*0.10m);

        return retorno;
    }
}



public class Implementos
{
    public int id { get; set; }
    public string? Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public bool Activo { get; set; }
    public int Deporte { get; set; }

    public Deportes? _Deporte { get; set; }
}