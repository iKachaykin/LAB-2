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
            foreach (object el in first_mult.Elements)
            {
                if (second_mult.Elements.Contains(el))
                {
                    this.AddElement(el);
                }
            }
        }
        public void Union(Multitude first_mult, Multitude second_mult)
        {
            foreach (object el in first_mult.Elements)
            {
                this.AddElement(el);
            }
            foreach (object el in second_mult.Elements)
            {
                this.AddElement(el);
            }
        }
        public void Difference(Multitude first_mult, Multitude second_mult)
        {
            foreach (object el in first_mult.Elements)
            {
                if (!second_mult.Elements.Contains(el))
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
            Console.ReadKey();
        }
    }
}
