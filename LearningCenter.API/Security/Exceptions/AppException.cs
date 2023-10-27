using System.Globalization;
using System.Runtime.Serialization;

namespace LearningCenter.API.Security.Domain;

public class AppException : Exception
{
    public AppException() :base() 
    {
    }

    public AppException(string message) : base(message)
    {
    }

    public AppException(string message, params object[] args) 
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}