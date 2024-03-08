using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Személy")]
    public class Jedi
    {
        private string name;
        private int midiChlorianCount;

        [XmlAttribute("Nev")]
        public string Name { get { return name; } set { name = value; } }
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get { return midiChlorianCount; }
            set
            {
                if (value <= 35)
                {
                    throw new ArgumentException("You are not a true jedi!");
                }
                midiChlorianCount = value;
            }
        }
        public Jedi(string name, int midiChlorianCount)
        {
            Name = name;
            MidiChlorianCount = midiChlorianCount;
        }
        public Jedi() { }

    }
}
