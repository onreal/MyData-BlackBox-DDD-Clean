namespace Upio.MyData.BlackBox.Core.Logger;

public interface IMessageLogger
{
    public Task Log(Message message);
    public Task<List<Message>> Messages { get; }
}