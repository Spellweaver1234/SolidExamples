﻿namespace SolidExamples.DIP
{
    // Принцип инверсии зависимостей (DIP)
    // Данный принцип гласит, что, во-первых, классы высокого уровня не должны зависеть от низкоуровневых классов.При этом оба должны зависеть от абстракций.
    // Во-вторых, абстракции не должны зависеть от деталей, но детали должны зависеть от абстракций.Классы высокого уровня реализуют бизнес-правила или логику
    // в системе(приложении). Низкоуровневые классы занимаются более подробными операциями, другими словами, они могут заниматься записью информации
    // в базу данных или передачей сообщений в операционную систему или службы и т.п.
    // Говорят, что высокоуровневый класс, который имеет зависимость от классов низкого уровня или какого-либо другого класса и много знает о
    // других классах, с которыми он взаимодействует, тесно связан. Когда класс явно знает о дизайне и реализации другого класса, возникает риск того,
    // что изменения в одном классе нарушат другой класс.
    // Поэтому мы должны держать эти высокоуровневые и низкоуровневые классы слабо связанными, насколько мы можем.Чтобы сделать это, нам нужно сделать
    // их зависимыми от абстракций, а не друг от друга.
    // Давайте рассмотрим пример.Предположим, что после сохранения некоторых деталей в базе данных существует одна система уведомлений:
    public class Email
    {
        public void Send()
        {
            // код для отправки email-письма
        }
    }

    // Уведомление
    public class Notification
    {
        private Email email;
        public Notification()
        {
            email = new Email();
        }

        public void EmailDistribution()
        {
            email.Send();
        }
    }
    // Теперь класс Notification полностью зависит от класса Email, потому что он отправляет только один тип уведомлений.
    // А если мы захотим ввести какие-либо другие уведомления, например отправку? Тогда нам понадобится изменить всю систему уведомлений.
    // В данном случае это система является тесно связанной.Что мы можем сделать, чтобы она была слабо связанной? Посмотрите на следующую реализацию:

    public interface IMessenger
    {
        void Send();
    }

    public class Email : IMessenger
    {
        public void Send()
        {
            // код для отправки email-письма
        }
    }

    public class SMS : IMessenger
    {
        public void Send()
        {
            // код для отправки SMS
        }
    }

    // Уведомление
    public class Notification
    {
        private IMessenger _messenger;
        public Notification()
        {
            _messenger = new Email();
        }

        public void DoNotify()
        {
            _messenger.Send();
        }
    }
    // В данном случае класс Notification все еще зависит от класса Email, т.к.использует его объект в конструкторе.
    // В данном случае мы можем использовать принцип внедрения зависимостей(dependency injection – DI).
    // Существует три базовых принципа внедрения зависимостей. 

    // Внедрение зависимостей через конструктор(Constructor Injection)
    public class Notification
    {
        private IMessenger _messenger;
        public Notification(IMessenger mes)
        {
            _messenger = mes;
        }

        public void DoNotify()
        {
            _messenger.Send();
        }
    }
    // Внедрение зависимостей через свойства(Property Injection)
    public class Notification
    {
        private IMessenger _messenger;
        public Notification()
        {

        }

        public IMessenger Messanger
        {
            set
            {
                _messenger = value;
            }
        }

        public void DoNotify()
        {
            _messenger.Send();
        }
    }
    // Внедрение зависимостей через метод(Method Injection)
    public class Notification
    {
        public void DoNotify(IMessenger mes)
        {
            mes.Send();
        }
    }
}