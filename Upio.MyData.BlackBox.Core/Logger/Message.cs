namespace Upio.MyData.BlackBox.Core.Logger;

public abstract class Message
{
    public bool IsSuccess { get; set; }
    public string Value { get; set; }
    public int Code { get; set; }
    public int Order { get; set; }
}