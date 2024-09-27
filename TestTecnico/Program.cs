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
        List<double> thresholds = new List<double>();

        using (SqlConnection connection = new SqlConnection("Server=localhost;Database=MISURAZIONI_FERROVIARIE;Trusted_Connection=true;TrustServerCertificate=True"))
        {
            using (SqlCommand cmd = new SqlCommand("select * from [dbo].[Thresholds]", connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dbl = reader.GetInt32(0);
                        var dbl1 = reader.GetInt32(1);
                        var dbl2 = reader.GetInt32(2);
                        thresholds.Add(dbl);
                        thresholds.Add(dbl1);
                        thresholds.Add(dbl2);
                    }
                }
            }


            using (var context = new MeasuresContext())
            {
                //using (var reader = new StreamReader(@"C:\Users\nlosa\source\repos\TestTecnico\TestTecnico\ff3f3add-7b1d-4f08-ba27-7a9c24fbcd34.csv"))
                //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                //{
                //    var records = csv.GetRecords<Measure>().ToList();
                //    Console.WriteLine(records.ToString());
                //    context.Measures.AddRange(records);
                //    context.SaveChanges();
                //}

                var list = context.Measures;

                // reset defects table
                var records = from m in context.Defects
                              select m;
                foreach (var record in records)
                {
                    context.Defects.Remove(record);
                }
                context.SaveChanges();

                var defectsLowOnp1 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p1 > thresholds[0])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsLowOnp1 = new List<Defect>();
                Defect temp = new Defect();
                foreach (var item in defectsLowOnp1)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Low";
                    temp.Delta = thresholds[0] - item.p1;
                    temp.p = 1;
                    DefectsLowOnp1.Add(temp);
                }
                CompressDefects(DefectsLowOnp1);
                context.Defects.AddRange(DefectsLowOnp1);

                var defectsMediumOnp1 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p1 > thresholds[1])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsMediumOnp1 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsMediumOnp1)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Medium";
                    temp.Delta = thresholds[1] - item.p1;
                    temp.p = 1;
                    DefectsMediumOnp1.Add(temp);
                }
                CompressDefects(DefectsMediumOnp1);
                context.Defects.AddRange(DefectsMediumOnp1);

                var defectsHighOnp1 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p1 > thresholds[2])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsHighOnp1 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsHighOnp1)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "High";
                    temp.Delta = thresholds[2] - item.p1;
                    temp.p = 1;
                    DefectsHighOnp1.Add(temp);
                }
                CompressDefects(DefectsHighOnp1);
                context.Defects.AddRange(DefectsHighOnp1);

                var defectsLowOnp2 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p2 > thresholds[3])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsLowOnp2 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsLowOnp2)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Low";
                    temp.Delta = thresholds[3] - item.p2;
                    temp.p = 2;
                    DefectsLowOnp2.Add(temp);
                }
                CompressDefects(DefectsLowOnp2);
                context.Defects.AddRange(DefectsLowOnp2);

                var defectsMediumOnp2 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p2 > thresholds[4])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsMediumOnp2 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsMediumOnp2)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Medium";
                    temp.Delta = thresholds[4] - item.p2;
                    temp.p = 2;
                    DefectsMediumOnp2.Add(temp);
                }
                CompressDefects(DefectsMediumOnp2);
                context.Defects.AddRange(DefectsMediumOnp2);

                var defectsHighOnp2 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p2 > thresholds[5])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsHighOnp2 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsHighOnp2)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "High";
                    temp.Delta = thresholds[5] - item.p2;
                    temp.p = 2;
                    DefectsHighOnp2.Add(temp);
                }
                CompressDefects(DefectsHighOnp2);
                context.Defects.AddRange(DefectsHighOnp2);

                var defectsLowOnp3 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p3 > thresholds[6])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsLowOnp3 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsLowOnp3)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Low";
                    temp.Delta = thresholds[6] - item.p3;
                    temp.p = 3;
                    DefectsLowOnp3.Add(temp);
                }
                CompressDefects(DefectsLowOnp3);
                context.Defects.AddRange(DefectsLowOnp3);

                var defectsMediumOnp3 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p3 > thresholds[7])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsMediumOnp3 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsMediumOnp3)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Medium";
                    temp.Delta = thresholds[7] - item.p3;
                    temp.p = 3;
                    DefectsMediumOnp3.Add(temp);
                }
                CompressDefects(DefectsMediumOnp3);
                context.Defects.AddRange(DefectsMediumOnp3);

                var defectsHighOnp3 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p3 > thresholds[8])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsHighOnp3 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsHighOnp3)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "High";
                    temp.Delta = thresholds[8] - item.p3;
                    temp.p = 3;
                    DefectsHighOnp3.Add(temp);
                }
                CompressDefects(DefectsHighOnp3);
                context.Defects.AddRange(DefectsHighOnp3);

                var defectsLowOnp4 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p4 > thresholds[9])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsLowOnp4 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsLowOnp4)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Low";
                    temp.Delta = thresholds[9] - item.p4;
                    temp.p = 4;
                    DefectsLowOnp4.Add(temp);
                }
                CompressDefects(DefectsLowOnp4);
                context.Defects.AddRange(DefectsLowOnp4);

                var defectsMediumOnp4 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p4 > thresholds[10])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsMediumOnp4 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsMediumOnp4)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "Medium";
                    temp.Delta = thresholds[10] - item.p4;
                    temp.p = 4;
                    DefectsMediumOnp4.Add(temp);
                }
                CompressDefects(DefectsMediumOnp4);
                context.Defects.AddRange(DefectsMediumOnp4);

                var defectsHighOnp4 = context.Measures
                    .AsEnumerable()
                    .Where(m => m.p4 > thresholds[11])
                    .OrderBy(m => m.MeasureId)
                    .ToList();
                List<Defect> DefectsHighOnp4 = new List<Defect>();
                temp = new Defect();
                foreach (var item in defectsHighOnp4)
                {
                    temp.MeasureId = item.MeasureId;
                    temp.Level = "High";
                    temp.Delta = thresholds[11] - item.p4;
                    temp.p = 4;
                    DefectsHighOnp4.Add(temp);
                }
                CompressDefects(DefectsHighOnp4);
                context.Defects.AddRange(DefectsHighOnp4);


                context.SaveChanges();
            }
        }
    }

    private static void CompressDefects(List<Defect> DefectsOnp)
    {
        List<Defect> defectsToRemove = new List<Defect>();
        for (int i = 0; i < DefectsOnp.Count-2; i++)
        {
            if (DefectsOnp[i].MeasureId == DefectsOnp[i + 2].MeasureId + 2)
            {
                defectsToRemove.Add(DefectsOnp[i + 1]);
            }
        }
        foreach (var item in defectsToRemove)
        {
            DefectsOnp.Remove(item);
        }
    }
}

