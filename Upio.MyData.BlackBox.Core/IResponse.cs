using Upio.MyData.BlackBox.Core.Logger;

namespace Upio.MyData.BlackBox.Core;

public class IResponse
{
    List<Message> Messages { get; set; }
    public string Mark { get; set; }
}