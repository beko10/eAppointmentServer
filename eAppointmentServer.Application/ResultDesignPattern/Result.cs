﻿public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public static Result<T> Success(T data, string message = "", int statusCode = 200)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Data = data,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static Result<T> Success(string message = "", int statusCode = 200)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static Result<T> Failure(string message, int statusCode = 400)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = statusCode
        };
    }
}
