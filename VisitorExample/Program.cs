using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure objectStructure = new ObjectStructure();

            objectStructure.Add(new ConcreteElementA());
            objectStructure.Add(new ConcreteElementB());

            ConcreteVisitor1 cea = new ConcreteVisitor1();
            ConcreteVisitor2 ceb = new ConcreteVisitor2();

            objectStructure.Accept(cea);
            objectStructure.Accept(ceb);
            Console.ReadKey();
        }

        class ObjectStructure
        {
            private List<Element> _elements = new List<Element>();

            public void Accept(Visitor visitor)
            {
                foreach (Element element in _elements)
                {
                    element.Accept(visitor);
                }
            }

            public void Add(Element element)
            {
                _elements.Add(element);
            }

        }

        abstract class Element
        {
            public abstract void Accept(Visitor visitor);
            
        }

        class ConcreteElementA : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementA(this);
            }
            
        }

        class ConcreteElementB : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementB(this);
            }
        }
        abstract class Visitor
        {
            public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);

            public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);

        }

        class ConcreteVisitor1 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
            {
                Console.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name);
            }

            public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
            {
                Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name);
            }
        }

        class ConcreteVisitor2 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
            {
                Console.WriteLine("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name);
            }

            public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
            {
                Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name);
            }
        }

       
    }
}
