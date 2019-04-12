using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MifParser
{
    public class MyParser : IParser
    {
        public void Parse()
        {
            using (var db = new GeoDbContext())
            {
                using (StreamReader ownerReader = new StreamReader(new FileStream("Export_Output.mid", FileMode.Open),
                        Encoding.GetEncoding(1251)),
                    landReader = new StreamReader(new FileStream("Export_Output.mif", FileMode.Open),
                        Encoding.GetEncoding(1251)))
                {
                    while (!landReader.ReadLine().Contains("DATA"))
                    {
                    } //move cursor to data beginning

                    var i = 0; //for test
                    while (!ownerReader.EndOfStream)
                    {
                        i++; //for test

                        var line = ownerReader.ReadLine();
                        var ownerToAdd = new Owner(LineOwnerToStringArray(line)); //build-up Owner
                        db.Owners.Add(ownerToAdd); //add Owner

                        //build-up Points of current Owner 
                        int.TryParse(landReader.ReadLine().Replace("REGION", ""), out var region);
                        int.TryParse(landReader.ReadLine(), out var count);

                        var pointsToAdd = new List<Point>(count);
                        for (var j = 0; j < count; j++)
                        {
                            var arr = landReader.ReadLine().Split(' ');
                            double.TryParse(arr[0], NumberStyles.AllowDecimalPoint,
                                new NumberFormatInfo {CurrencyDecimalSeparator = "."}, out var x);
                            double.TryParse(arr[1], NumberStyles.AllowDecimalPoint,
                                new NumberFormatInfo {CurrencyDecimalSeparator = "."}, out var y);
                            pointsToAdd.Add(new Point {Region = region, X = x, Y = y});
                        }

                        string s;
                        do
                        {
                            s = landReader.ReadLine();
                        } while (!s.Contains("BRUSH")); //to the next portion of data


                        //not initialized id in Point 
                        foreach (var point in pointsToAdd) point.OwnerId = ownerToAdd.ObjectId;

                        db.Points.AddRange(pointsToAdd); //add
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        } //save changes


                        //if (i == 2) break;//for test
                        Console.WriteLine(i);
                    }
                }
            }
        }

        public static int? ParseNullableInt(string s)
        {
            return int.TryParse(s, out var res) ? res : (int?) null;
        }

        public static double? ParseNullableDouble(string s)
        {
            var formatProvider = new NumberFormatInfo {CurrencyDecimalSeparator = "."};
            return double.TryParse(s, NumberStyles.AllowDecimalPoint, formatProvider, out var res)
                ? res
                : (double?) null;
        }

        public static string[] LineOwnerToStringArray(string s1)
        {
            var strings = s1.Split('\"');
            for (var i = 0; i < strings.Length; i++)
                if (i % 2 == 1 && i != 0) //temporarily replace commas inside ""
                    strings[i] = strings[i].Replace(",", "_");

            s1 = string.Concat(strings);
            strings = s1.Split(',');
            for (var i = 0; i < strings.Length; i++)
                if (strings[i].Contains("_"))
                    strings[i] = strings[i].Replace("_", ",");

            return strings;
        }
    }
}