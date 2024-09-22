﻿using System.Net;

namespace Domain.Abstractions;

public class Result<T> where T : class?
{
    private Result(Error error, HttpStatusCode statusCode)
    {
        IsSucess = false;
        StatusCode = statusCode;
        Errors = [error];
    }

    private Result(T? data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {

        IsSucess = true;
        StatusCode = statusCode;
        Errors = [Error.None];
        Data = data;
    }

    public bool IsSucess { get; }

    public bool IsFailure => !IsSucess;

    public List<Error> Errors { get; }

    public T? Data { get; }

    public HttpStatusCode StatusCode { get; }

    public static Result<T> Success(T data, HttpStatusCode code = HttpStatusCode.OK) => new(data, code);

    public static Result<T> Failure(Error error, HttpStatusCode code = HttpStatusCode.BadRequest) => new(error, code);
}