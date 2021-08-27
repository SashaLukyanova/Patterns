using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace Patterns
{
    public interface IObserver
    {
        void Updater(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; }

        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");
            foreach (var observer in _observers)
            {
                observer.Updater(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to:." + this.State);
            this.Notify();

        }

    }

    class ConcreteObserverA : IObserver
    {
        public void Updater(ISubject subject)
        {
            if ((subject as Subject).State < 3)
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Updater(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
        }
    }
}