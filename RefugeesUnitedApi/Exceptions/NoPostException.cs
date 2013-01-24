using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.Exceptions
{
  /// <summary>
  /// This error is returned whenever a collection or a resource prevents the use of the POST method.
  /// </summary>
  [Serializable]
  public class NoPostException : Exception
  {
    public NoPostException() { }
    /// <summary>
    /// </summary>
    /// <param name="message">POST calls are not accepted for this request.</param>
    public NoPostException(string message) : base(message) { }
    public NoPostException(string message, Exception inner) : base(message, inner) { }
    protected NoPostException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
