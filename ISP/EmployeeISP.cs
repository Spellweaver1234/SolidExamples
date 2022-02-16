﻿namespace SolidExamples.ISP
{
    // Принцип разделения интерфейсов (ISP)
    // Принцип разделения интерфейсов гласит, что клиенты не должны принудительно внедрять интерфейсы, которые они не используют.
    // Давайте предположим, что есть одна база данных для хранения данных всех типов сотрудников(то есть Junior и Senior).
    // Какой будет лучший подход для нашего интерфейса?

    public interface IEmployee
    {
        bool AddDetailsEmployee();
    }
    // Допустим все классы Employee наследуют этот интерфейс для сохранения данных.Теперь предположим, что компания однажды сказала вам,
    // что они хотят читать данные только для сотрудников в должности senior.Что вы будете делать, просто добавьте один метод в этот интерфейс?

    public interface IEmployee
    {
        bool AddDetailsEmployee();
        bool ShowDetailsEmployee(int id);
    }

    // Но теперь мы что-то ломаем.Мы вынуждаем объекты JuniorEmployee показывать свои данные из базы данных.Таким образом,
    // решение заключается в том, чтобы передать эту ответственность другому интерфейсу:

    public interface IOperationAdd
    {
        bool AddDetailsEmployee();
    }

    public interface IOperationGet
    {
        bool ShowDetailsEmployee(int id);
    }
    // И теперь, класс JuniorEmployee будет реализовывать только интерфейс IOperationAdd, а SeniorEmployee оба интерфейса.
    // Таким образом обеспечивается разделение интерфейсов.
}