using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.Exceptions
{
  /// <summary>
  /// Thrown when parameters to handlers are incorrect
  /// </summary>
  [Serializable]
  public class InvalidParameterException : Exception
  {
    public InvalidParameterException() { }
    /// <summary>
    /// </summary>
    /// <param name="message">Invalid parameters</param>
    public InvalidParameterException(string message) : base(message) { }
    public InvalidParameterException(string message, Exception inner) : base(message, inner) { }
    protected InvalidParameterException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
