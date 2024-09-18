using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] a1 = { "arp", "live", "strong" };
        string[] a2 = { "lively", "alive", "harp", "sharp", "armstrong" };

       
        var result = a1
            .Where(s1 => a2.Any(s2 => s2.Contains(s1))) 
            .OrderBy(s => s)
            .ToArray();
        Console.WriteLine(string.Join(", ", result)); 
    }
}



    