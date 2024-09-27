using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Metadata;
using System;
using System.Linq;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        List<double> thresholdsp1 = new List<double>();
        List<double> thresholdsp2 = new List<double>();
        List<double> thresholdsp3 = new List<double>();
        List<double> thresholdsp4 = new List<double>();

        GetThresholdsFromDB(thresholdsp1, thresholdsp2, thresholdsp3, thresholdsp4);

        using (var context = new MeasuresContext())
        {
            //SETUP
            //GetDataFromCsv(context);

            //RESET DEFECTS TABLE
            ResetDefects(context);


            //DATA ANALYSIS
            var list = context.Measures;            

            List<Defect> TotalDefects = new List<Defect>();

            TotalDefects.AddRange(CalculateDefectsP1(thresholdsp1,1,list));
            //TotalDefects.AddRange(CalculateDefectsP2(thresholdsp2, 2, list));
            //TotalDefects.AddRange(CalculateDefectsP3(thresholdsp3, 3, list));
            //TotalDefects.AddRange(CalculateDefectsP4(thresholdsp4, 4, list));

            context.Defects.AddRange(TotalDefects);
            context.SaveChanges();
        }

    }

    private static void GetThresholdsFromDB(List<double> thresholdsp1, List<double> thresholdsp2, List<double> thresholdsp3, List<double> thresholdsp4)
    {
        using (SqlConnection connection = new SqlConnection("Server=localhost;Database=MISURAZIONI_FERROVIARIE;Trusted_Connection=true;TrustServerCertificate=True"))
        {
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[Thresholds]", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    
                    var dbl = reader.GetInt32(0);
                    var dbl1 = reader.GetInt32(1);
                    var dbl2 = reader.GetInt32(2);
                    thresholdsp1.Add(dbl);
                    thresholdsp1.Add(dbl1);
                    thresholdsp1.Add(dbl2);
                    
                    reader.Read();
                    
                    dbl = reader.GetInt32(0);
                    dbl1 = reader.GetInt32(1);
                    dbl2 = reader.GetInt32(2);
                    thresholdsp2.Add(dbl);
                    thresholdsp2.Add(dbl1);
                    thresholdsp2.Add(dbl2);
                    
                    reader.Read();
                    
                    dbl = reader.GetInt32(0);
                    dbl1 = reader.GetInt32(1);
                    dbl2 = reader.GetInt32(2);
                    thresholdsp3.Add(dbl);
                    thresholdsp3.Add(dbl1);
                    thresholdsp3.Add(dbl2);
                    
                    reader.Read();
                    
                    dbl = reader.GetInt32(0);
                    dbl1 = reader.GetInt32(1);
                    dbl2 = reader.GetInt32(2);
                    thresholdsp4.Add(dbl);
                    thresholdsp4.Add(dbl1);
                    thresholdsp4.Add(dbl2);
                    
                }
            }
        }
    }

    private static List<Defect> CalculateDefectsP1(List<double> thresholds, int p,  DbSet<Measure> list, double initialMM = 0, double finalMM = double.MaxValue)
    {
        List<Defect> AllDefects = new List<Defect>();
        
        //prendo tutte le misure maggiori della soglia bassa
        var defectsLow = list
                        .AsEnumerable()
                        .Where(m => m.p1 > thresholds[0] && m.p1 < thresholds[1] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();

        List<Defect> DefectsLow = new List<Defect>();        
        
        foreach (var item in defectsLow)
        {
            GetDefects(thresholds[0], p, DefectsLow, item.p1, item.MeasureId, "Low");
        }
        CompressDefects(DefectsLow);
        AllDefects.AddRange(DefectsLow);

        var defectsMedium = list
                            .AsEnumerable()
                            .Where(m => m.p1 > thresholds[1] && m.p1 < thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                            .OrderBy(m => m.MeasureId)
                            .ToList();
        List<Defect> DefectsMedium = new List<Defect>();
       
        foreach (var item in defectsMedium)
        {
            GetDefects(thresholds[1], p, DefectsMedium, item.p1, item.MeasureId, "Medium");
        }
        CompressDefects(DefectsMedium);
        AllDefects.AddRange(DefectsMedium);

        var defectsHigh = list
                        .AsEnumerable()
                        .Where(m => m.p1 > thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();
        List<Defect> DefectsHigh = new List<Defect>();
        foreach (var item in defectsHigh)
        {
            GetDefects(thresholds[2], p, DefectsHigh, item.p1, item.MeasureId, "High");
        }
        CompressDefects(DefectsHigh);
        AllDefects.AddRange(DefectsMedium);

        return AllDefects;

    }    
    private static List<Defect> CalculateDefectsP2(List<double> thresholds, int p, DbSet<Measure> list, double initialMM = 0, double finalMM = double.MaxValue)
    {
        List<Defect> AllDefects = new List<Defect>();

        //prendo tutte le misure maggiori della soglia bassa
        var defectsLow = list
                        .AsEnumerable()
                        .Where(m => m.p2 > thresholds[0] && m.p2 < thresholds[1] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();

        List<Defect> DefectsLow = new List<Defect>();


        foreach (var item in defectsLow)
        {
            GetDefects(thresholds[0], p, DefectsLow, item.p2, item.MeasureId, "Low");
        }
        CompressDefects(DefectsLow);
        AllDefects.AddRange(DefectsLow);

        var defectsMedium = list
                            .AsEnumerable()
                            .Where(m => m.p2 > thresholds[1] && m.p2 < thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                            .OrderBy(m => m.MeasureId)
                            .ToList();
        List<Defect> DefectsMedium = new List<Defect>();

        foreach (var item in defectsMedium)
        {
            GetDefects(thresholds[1], p, DefectsMedium, item.p2, item.MeasureId, "Medium");
        }
        CompressDefects(DefectsMedium);
        AllDefects.AddRange(DefectsMedium);

        var defectsHigh = list
                        .AsEnumerable()
                        .Where(m => m.p2 > thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();
        List<Defect> DefectsHigh = new List<Defect>();
        foreach (var item in defectsHigh)
        {
            GetDefects(thresholds[2], p, DefectsHigh, item.p2, item.MeasureId, "High");
        }
        CompressDefects(DefectsHigh);
        AllDefects.AddRange(DefectsMedium);

        return AllDefects;

    }
    private static List<Defect> CalculateDefectsP3(List<double> thresholds, int p, DbSet<Measure> list, double initialMM = 0, double finalMM = double.MaxValue)
    {
        List<Defect> AllDefects = new List<Defect>();

        //prendo tutte le misure maggiori della soglia bassa
        var defectsLow = list
                        .AsEnumerable()
                        .Where(m => m.p3 > thresholds[0] && m.p3 < thresholds[1] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();

        List<Defect> DefectsLow = new List<Defect>();


        foreach (var item in defectsLow)
        {
            GetDefects(thresholds[0], p, DefectsLow, item.p3, item.MeasureId, "Low");
        }
        CompressDefects(DefectsLow);
        AllDefects.AddRange(DefectsLow);

        var defectsMedium = list
                            .AsEnumerable()
                            .Where(m => m.p3 > thresholds[1] && m.p3 < thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                            .OrderBy(m => m.MeasureId)
                            .ToList();
        List<Defect> DefectsMedium = new List<Defect>();

        foreach (var item in defectsMedium)
        {
            GetDefects(thresholds[1], p, DefectsMedium, item.p3, item.MeasureId, "Medium");
        }
        CompressDefects(DefectsMedium);
        AllDefects.AddRange(DefectsMedium);

        var defectsHigh = list
                        .AsEnumerable()
                        .Where(m => m.p3 > thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();
        List<Defect> DefectsHigh = new List<Defect>();
        foreach (var item in defectsHigh)
        {
            GetDefects(thresholds[2], p, DefectsHigh, item.p3, item.MeasureId, "High");
        }
        CompressDefects(DefectsHigh);
        AllDefects.AddRange(DefectsMedium);

        return AllDefects;

    }
    private static List<Defect> CalculateDefectsP4(List<double> thresholds, int p, DbSet<Measure> list, double initialMM = 0, double finalMM = double.MaxValue)
    {
        List<Defect> AllDefects = new List<Defect>();

        //prendo tutte le misure maggiori della soglia bassa
        var defectsLow = list
                        .AsEnumerable()
                        .Where(m => m.p4 > thresholds[0] && m.p4 < thresholds[1] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();

        List<Defect> DefectsLow = new List<Defect>();


        foreach (var item in defectsLow)
        {
            GetDefects(thresholds[0], p, DefectsLow, item.p4, item.MeasureId, "Low");
        }
        CompressDefects(DefectsLow);
        AllDefects.AddRange(DefectsLow);

        var defectsMedium = list
                            .AsEnumerable()
                            .Where(m => m.p4 > thresholds[1] && m.p4 < thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                            .OrderBy(m => m.MeasureId)
                            .ToList();
        List<Defect> DefectsMedium = new List<Defect>();

        foreach (var item in defectsMedium)
        {
            GetDefects(thresholds[1], p, DefectsMedium, item.p4, item.MeasureId, "Medium");
        }
        CompressDefects(DefectsMedium);
        AllDefects.AddRange(DefectsMedium);

        var defectsHigh = list
                        .AsEnumerable()
                        .Where(m => m.p4 > thresholds[2] && m.MeasureId > initialMM && m.MeasureId < finalMM)
                        .OrderBy(m => m.MeasureId)
                        .ToList();
        List<Defect> DefectsHigh = new List<Defect>();
        foreach (var item in defectsHigh)
        {
            GetDefects(thresholds[2], p, DefectsHigh, item.p4, item.MeasureId, "High");
        }
        CompressDefects(DefectsHigh);
        AllDefects.AddRange(DefectsMedium);

        return AllDefects;

    }


    private static void GetDefects(double threshold, int p, List<Defect> Defects, double parameter, int MeasureId, string Level)
    {
        Defect temp = new Defect(); 
        temp.MeasureId = MeasureId;
        temp.Level = Level;
        temp.Delta = parameter - threshold;
        temp.p = p;
        Defects.Add(temp);
    }

    private static void GetDataFromCsv(MeasuresContext context)
    {
        using (var reader = new StreamReader(@"C:\Users\nlosa\source\repos\TestTecnico\TestTecnico\ff3f3add-7b1d-4f08-ba27-7a9c24fbcd34.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Measure>().ToList();
            Console.WriteLine(records.ToString());
            context.Measures.AddRange(records);
            context.SaveChanges();
        }
    }

    private static void ResetDefects(MeasuresContext context)
    {
        // RESET DEFECTS TABLE
        var records = from m in context.Defects
                      select m;
        foreach (var record in records)
        {
            context.Defects.Remove(record);
        }
        context.SaveChanges();
    }

    private static void CompressDefects(List<Defect> DefectsOnp)
    {
        List<Defect> defectsToRemove = new List<Defect>();

        int i = 0;

        int length;
        while (i < DefectsOnp.Count - 2 )
        {
            length = 0;
            while(DefectsOnp[i].MeasureId == DefectsOnp[i + 1].MeasureId - 1)
            {
                length++;
                defectsToRemove.Add(DefectsOnp[i + 1]);
                DefectsOnp[i].DefectLength = length;
                i++;
            }
            i= i + length;
            i++;
        }
            
        foreach (var item in defectsToRemove)
        {
            DefectsOnp.Remove(item);
        }
    }
}

