using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Patterns
{   

    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();
            subject.State = 0;

            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();

        }
    }
}
