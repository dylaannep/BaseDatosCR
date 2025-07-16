using Microsoft.EntityFrameworkCore;
using Tarea4DylanEspinozaPereira.Models;
using System.Globalization;
using System.Text;

using var context = new CRContext();

if (!context.Provincias.Any())
{
    Console.WriteLine("La base de datos está vacía, se procederá a llenarla desde el archivo CSV...");

    string rutaCsv = Path.Combine("data", "CR.csv");

    if (!File.Exists(rutaCsv))
    {
        Console.WriteLine($" :( No se encontró el archivo {rutaCsv}");
        return;
    }

    var lineas = File.ReadAllLines(rutaCsv);

    foreach (var (linea, index) in lineas.Select((value, i) => (value, i)))
    {
        if (index == 0) continue; // Saltar encabezado

        var partes = linea.Split(',');

        if (partes.Length != 3) continue;

        string nombreProvincia = partes[0].Trim();
        string nombreCanton = partes[1].Trim();
        string nombreDistrito = partes[2].Trim();

        // 1. Obtener o crear provincia
        var provincia = context.Provincias.FirstOrDefault(p => p.Nombre == nombreProvincia);
        if (provincia == null)
        {
            provincia = new Provincia { Nombre = nombreProvincia };
            context.Provincias.Add(provincia);
            context.SaveChanges();
        }

        // 2. Obtener o crear cantón
        var canton = context.Cantones
            .FirstOrDefault(c => c.Nombre == nombreCanton && c.ProvinciaFK == provincia.ProvinciaPK);

        if (canton == null)
        {
            canton = new Canton
            {
                Nombre = nombreCanton,
                ProvinciaFK = provincia.ProvinciaPK
            };
            context.Cantones.Add(canton);
            context.SaveChanges();
        }

        // 3. Verificar si el distrito ya existe
        var existeDistrito = context.Distritos
            .Any(d => d.Nombre == nombreDistrito && d.CantonFK == canton.CantonPK);

        if (!existeDistrito)
        {
            var distrito = new Distrito
            {
                Nombre = nombreDistrito,
                CantonFK = canton.CantonPK
            };
            context.Distritos.Add(distrito);
        }
    }

    context.SaveChanges();

    Console.WriteLine("✅ Base de datos llenada correctamente desde el archivo CSV.");
}
else
{
    Console.WriteLine("La base de datos ya contiene información :) ");

    Console.WriteLine("\nProvincias:\n");

    var provincias = context.Provincias.ToList();
    foreach (var provincia in provincias)
    {
        Console.WriteLine($"{provincia.ProvinciaPK}. {provincia.Nombre}");
    }

    Console.Write("\n> Indique la provincia: ");
    int provinciaId = int.Parse(Console.ReadLine() ?? "0");
    var provinciaSeleccionada = context.Provincias.FirstOrDefault(p => p.ProvinciaPK == provinciaId);

    if (provinciaSeleccionada == null)
    {
        Console.WriteLine("❌ Provincia no válida.");
        return;
    }

    var cantones = context.Cantones
        .Where(c => c.ProvinciaFK == provinciaId)
        .ToList();

    Console.WriteLine("\nCantones:\n");
    foreach (var canton in cantones)
    {
        Console.WriteLine($"{canton.CantonPK}. {canton.Nombre}");
    }

    Console.Write("\n> Indique el cantón: ");
    int cantonId = int.Parse(Console.ReadLine() ?? "0");
    var cantonSeleccionado = context.Cantones.FirstOrDefault(c => c.CantonPK == cantonId && c.ProvinciaFK == provinciaId);

    if (cantonSeleccionado == null)
    {
        Console.WriteLine("❌ Cantón no válido.");
        return;
    }

    var distritos = context.Distritos
        .Where(d => d.CantonFK == cantonId)
        .ToList();

    var rutaArchivo = Path.Combine("data", $"{provinciaId}-{cantonId}.csv");

    Console.WriteLine($"\nGenerando y guardando el archivo {provinciaId}-{cantonId}.csv...");

    using (var writer = new StreamWriter(rutaArchivo, false, Encoding.UTF8))
    {
        writer.WriteLine("Provincia,Canton,Distrito");

        foreach (var distrito in distritos)
        {
            writer.WriteLine($"{provinciaSeleccionada.Nombre},{cantonSeleccionado.Nombre},{distrito.Nombre}");
        }
    }

    Console.WriteLine("✅ Archivo CSV generado correctamente.");
}

