using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStatsApi.Infrastructure;

/// <summary>
/// The base class for an outcome from a command or query handler
/// </summary>
public abstract class Outcome { }

public class CommonOutcomes
{
    /// <summary>
    /// Represents a successful outcome that returns some known data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Success<T> : Outcome
    {
        public T Data { get; set; }

        public Success(T data)
        {
            this.Data = data;
        }
    }

    /// <summary>
    /// An outcome indicating that the resource that the caller attempted to get did not exist
    /// </summary>
    public class NotFound : Outcome { }

    /// <summary>
    /// A simplified outcome that returns a validation error for a parameter passed to a command
    /// </summary>
    public class InvalidData : Outcome
    {
        public string ParameterName { get; set; }

        public InvalidData(string parameterName)
        {
            this.ParameterName = parameterName;
        }
    }

    public class UnauthorizedAccess : Outcome { }
}