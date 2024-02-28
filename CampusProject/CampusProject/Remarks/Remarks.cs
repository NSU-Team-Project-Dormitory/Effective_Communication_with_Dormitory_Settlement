using System;
using System.Collections.Generic;

namespace CampusProject
{
    public enum NoteType
    {
        Cleaning,
        FireSafety,
        Behavior,
        Custom
    }

    public class RoomRemarks
    {
        private List<string> remarks;

        public RoomRemarks()
        {
            remarks = new List<string>();
        }

        public void AddRemark(NoteType type, string content, int noteNumber)
        {
            remarks.Add($"{type.ToString()}: {noteNumber} - {content}");
        }

        public void ViewRemarks()
        {
            if (remarks.Count == 0)
            {
                Console.WriteLine("Замечаний пока нет\n");
            }
            else
            {
                Console.WriteLine("Замечания:");
                foreach (var remark in remarks)
                {
                    Console.WriteLine(remark);
                }
            }
        }
    }
}
