using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugeesUnitedApi.Exceptions
{
  /// <summary>
  /// Error to be thrown when DELETE action is not allowed
  /// </summary>
  [Serializable]
  public class NoDeleteException : Exception
  {
    public NoDeleteException() { }
    /// <summary>
    /// </summary>
    /// <param name="message">Delete is not allowed on this action</param>
    public NoDeleteException(string message) : base(message) { }
    public NoDeleteException(string message, Exception inner) : base(message, inner) { }
    protected NoDeleteException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
