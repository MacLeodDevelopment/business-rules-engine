﻿namespace BusinessRulesEngine.Domain.Interfaces
{
    public interface IBusinessEvent
    {
        string Message { get; }
        object Data { get; }
    }
}