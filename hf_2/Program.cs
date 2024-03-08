using System.ComponentModel;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace ModernLangToolsApp;

public class Program
{
    [Description("Feladat2")]
    public static void JediSer()
    {
        Jedi jediSer = new Jedi("Obi-Wan", 15000);
        var serializer = new XmlSerializer(typeof(Jedi));
        var stream = new FileStream("Jedi.xml", FileMode.Create);
        serializer.Serialize(stream, jediSer);
        stream.Close();
        stream = new FileStream("Jedi.xml", FileMode.Open);
        var jediDeser = (Jedi)serializer.Deserialize(stream);
        stream.Close();
        Console.WriteLine($"Nev: {jediDeser.Name}, MidiChlorianSzam: {jediDeser.MidiChlorianCount}");
    }

    [Description("Feladat3")]
    public static void TestAddRemove(JediTanacs JT)
    {
        JT.CouncilChangedEvent += message => Console.WriteLine(message);
        JT.Add(new Jedi { Name = "Yoda", MidiChlorianCount = 900 });
        JT.Add(new Jedi { Name = "Mace Windu", MidiChlorianCount = 450 });
        JT.Remove();
        JT.Remove();
    }

    [Description("Feladat4")]
    public static void TestDelegate(JediTanacs JT)
    {
        JT.Add(new Jedi { Name = "Yoda", MidiChlorianCount = 900 });
        JT.Add(new Jedi { Name = "Shaak Ti", MidiChlorianCount = 529 });
        JT.Add(new Jedi { Name = "Leia Skywalker", MidiChlorianCount = 450 });

        List<Jedi> lowJedis = JT.LowMidiChlorianCount_Delegate();
        Console.WriteLine("Alacsony midi-chlorianos Jedik delegate-tel:\t");
        foreach (Jedi j in lowJedis)
        {
            Console.WriteLine($" {j.Name} ");
        }
    }

    [Description("Feladat5")]
    public static void TestLambda(JediTanacs JT)
    {
        JT.Add(new Jedi("Anakin", 20000));
        JT.Add(new Jedi("Luke",500));
        JT.Add(new Jedi("Obi-Wan", 15000));

        List<Jedi> lowJedis = JT.LowMidiChlorianCount_Lambda();
        Console.WriteLine("Alacsony midi-chlorianos Jedik lambdával:\t");
        foreach (Jedi j in lowJedis)
        {
            Console.WriteLine($" {j.Name} ");
        }
    }

    [Description("Feladat6")]
    static void test6()
    {
        var employees = new Person[] { new Person("Joe", 20), new Person("Jill", 30) };

        ReportPrinter reportPrinter = new ReportPrinter(
            employees,
            () => Console.WriteLine("Employees"),
            (person, index) => Console.WriteLine($"{index}. Name: {person.Name} (Age: {person.Age})"),
            () => Console.WriteLine($"Number of Employees: {employees.Length}")
        );
        reportPrinter.PrintReport();
    }

    public static void Main(string[] args)
    {
        JediTanacs tanacs = new JediTanacs();
        JediSer();
        TestAddRemove(tanacs);
        TestDelegate(tanacs);
        TestLambda(tanacs);
        test6();
    }
}
