using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Numerics;

public class MeasuresContext : DbContext
{
    public DbSet<Measure> Measures { get; set; }
    public DbSet<Defect> Defects { get; set; }



    public string DbPath { get; }

    public MeasuresContext()
    {
        DbPath = "Server=localhost;Database=MISURAZIONI_FERROVIARIE;Trusted_Connection=true;TrustServerCertificate=True";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"{DbPath}");
}

public class Measure
{
    public int MeasureId { get; set; }
    public Double p1 { get; set; }
    public Double p2 { get; set; }
    public Double p3 { get; set; }
    public Double p4 { get; set; }

}

public class Defect
{
    public int DefectId { get; set; }
    public int p { get; set; }
    public int MeasureId { get; set; }
    public int DefectLength { get; set; } = 0;
    public String Level { get; set; }
    public double Delta { get; set; }


}
