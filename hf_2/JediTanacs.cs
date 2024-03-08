using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{
    public delegate void CouncilChanged(string message);
    public class JediTanacs
    {
        private List<Jedi> members = new List<Jedi>();
        public event CouncilChanged CouncilChangedEvent;

        public void Add(Jedi j)
        {
            members.Add(j);
            CouncilChangedEvent?.Invoke($"Új tanácstag : {j.Name}");
        }
        public void Remove()
        {
            if (members.Count == 0) { CouncilChangedEvent?.Invoke("A Jeditanácsnak már nincs egy tagja sem."); }
            else
            {
                Jedi j = members[members.Count - 1];
                members.RemoveAt(members.Count - 1);
                string message = members.Count > 0 ? $"A tanácstagot eltávolították: {j.Name}" : "A Jeditanács teljesen kiürült.";
                CouncilChangedEvent?.Invoke(message);
            }
        }
        private bool HasLowMidiChlorians(Jedi jedi)
        {
            return jedi.MidiChlorianCount < 530;
        }
        public List<Jedi> LowMidiChlorianCount_Delegate()
        {
            return members.FindAll(HasLowMidiChlorians);
        }
        public List<Jedi> LowMidiChlorianCount_Lambda()
        {
            return members.FindAll(l => l.MidiChlorianCount < 1000);
        }
    }
}
