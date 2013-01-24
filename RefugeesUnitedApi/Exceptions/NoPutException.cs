using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.Exceptions
{
  /// <summary>
  /// This error is returned whenever someone tries to execute a PUT request on a collection or a resource that prevents PUT requests.
  /// </summary>
  [Serializable]
  public class NoPutException : Exception
  {
    public NoPutException() { }
    public NoPutException(string message) : base(message) { }
    public NoPutException(string message, Exception inner) : base(message, inner) { }
    protected NoPutException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
