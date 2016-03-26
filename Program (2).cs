using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{

    class Multitude
    {
        private ArrayList Elements = new ArrayList();
        private int Length
        {
            get 
            {
                return this.Elements.Count;
            }
        }
        public Multitude(params object[] values)
        {
            foreach (object element in values)
            {
                if (!this.Elements.Contains(element))
                {
                    this.Elements.Add(element);
                }
            }
        }
        public object this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Elements.Count)
                {
                    return this.Elements[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (i >= 0 && i < this.Elements.Count)
                {
                    this.Elements[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public override string ToString()
        {
            string result = "{";
            foreach (object element in this.Elements)
            {
                result = String.Concat(result, Convert.ToString(element));
                if (element != this.Elements[this.Elements.Count - 1])
                {
                    result = String.Concat(result, ", ");
                }
            }
            result = String.Concat(result, "}");
            return result;
        }
        public void AddElements(params object[] values)
        {
            foreach (object element in values)
            {
                if (!this.Elements.Contains(element))
                {
                    this.Elements.Add(element);
                }
            }
        }
        public void AddElement(object el)
        {
            if (!this.Elements.Contains(el))
            {
                this.Elements.Add(el);
            }
        }
        public void DelElement(object el)
        {
            if (this.Elements.Contains(el))
            {
                this.Elements.Remove(el);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void Intersection(Multitude first_mult, Multitude second_mult)
        {
            ArrayList auxSet1 = new ArrayList();
            auxSet1 = first_mult.Elements;
            ArrayList auxSet2 = new ArrayList();
            auxSet2 = second_mult.Elements;
            ArrayList emptylst = new ArrayList();
            this.Elements = emptylst; 
            foreach (object el in auxSet1)
            {
                if (auxSet2.Contains(el))
                {
                    this.AddElement(el);
                }
            }
        }
        public void Union(Multitude first_mult, Multitude second_mult)
        {
            ArrayList auxSet1 = new ArrayList();
            auxSet1 = first_mult.Elements;
            ArrayList auxSet2 = new ArrayList();
            auxSet2 = second_mult.Elements;
            ArrayList emptylst = new ArrayList();
            this.Elements = emptylst; 
            foreach (object el in auxSet1)
            {
                this.AddElement(el);
            }
            foreach (object el in auxSet2)
            {
                this.AddElement(el);
            }
        }
        public void Difference(Multitude first_mult, Multitude second_mult)
        {
            ArrayList auxSet1 = new ArrayList();
            auxSet1 = first_mult.Elements;
            ArrayList auxSet2 = new ArrayList();
            auxSet2 = second_mult.Elements;
            ArrayList emptylst = new ArrayList();
            this.Elements = emptylst; 
            foreach (object el in auxSet1)
            {
                if (!auxSet2.Contains(el))
                {
                    this.AddElement(el);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Multitude A = new Multitude(2, 4, 6, 8, 10);
            Console.WriteLine("Множество А:\n{0}", A);
            Multitude B = new Multitude("F", "F", 0, 1, '^', 'v', 'x');
            Console.WriteLine("Множество В:\n{0}", B);
            Console.WriteLine("Заметьте, что элемент \"F\" вошёл в В только один раз. Это связано с тем,\nчто в множестве каждый элемент может повторяться не больше одного раза.");
            Multitude C = new Multitude(1, 2, 3);
            Console.WriteLine("Множество С:\n{0}", C);
            C.Intersection(A, B);
            Console.WriteLine("Пересечение множеств А и В:\n{0}", C);
            B.AddElements(2, 4);
            Console.WriteLine("Множество B*, полученное добавлением элементов \"2\" и \"4\" в множество В:\n{0}", B);
            A.AddElement('^');
            Console.WriteLine("Множество A*, полученное добавлением элемента \"^\" в множество A:\n{0}", A);
            C.Intersection(A, B);
            Console.WriteLine("Пересечение множеств А* и B*:\n{0}", C);
            C.Union(A, B);
            Console.WriteLine("Множество С*, полученное объединением множеств А* и B*:\n{0}", C);
            C.Difference(C, A);
            Console.WriteLine("Разность множеств С* и А*:\n{0}", C);
            try
            {
                B.DelElement(999);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Ошибка, в множестве В* отсутствует указанный элемент!");
            }
            Console.ReadKey();
        }
    }
}
