using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Sorting.Comparators
{
    [Serializable]
    public class Student
    {
        public string name { get; set; }
        public  int section{ get; set; }
        public static Comparer<Student> BY_NAME = new ByNameComparer();
        public static Comparer<Student> BY_SECTION= new BySectionComparer();

        private class ByNameComparer : Comparer<Student>
        {
            public override int Compare(Student firstStudent, Student secondStudent)
            {
                return firstStudent.name.CompareTo(secondStudent.name);
            }
        }
        private class BySectionComparer : Comparer<Student>
        {
            public override int Compare(Student firstStudent, Student secondStudent)
            {
                return firstStudent.section.CompareTo(secondStudent.section);
            }
        }

        public static void Test()
        {
            var studentAlice = new Student(){name = "Alice", section = 1};
            var studentMark = new Student(){name = "Mark", section = 1};
            var studentJohn = new Student(){name = "John", section = 1};
            var students = new List<Student>() {studentMark, studentAlice, studentJohn};
            var serialized = JsonSerializer.Serialize(students);
            Console.WriteLine(JsonSerializer.Serialize(students));
            students.Sort(BY_NAME);
            Console.WriteLine(JsonSerializer.Serialize(students));
            /*[{"name":"Mark","section":1},{"name":"Alice","section":1},{"name":"John","section":1}]
            [{"name":"Alice","section":1},{"name":"John","section":1},{"name":"Mark","section":1}]*/

        }
        
    }
}