using System;
using System.Threading.Tasks;

namespace WKHomeWork.Library.Commands
{
    public interface ICommand
    {

    }

    public interface IHandleCommand
    {

    }

    public interface IHandleCommand<TCommand> : IHandleCommand
        where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandBus
    {
        Task SendCommand<TCommand>(TCommand cmd) where TCommand : ICommand;
    }

    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, IHandleCommand> _handlersFactory;

        public CommandBus(Func<Type, IHandleCommand> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public async Task SendCommand<T>(T cmd) where T : ICommand
        {
            var handler = (IHandleCommand<T>)_handlersFactory(typeof(T));
            await handler.Handle(cmd);
        }
    }
    
}