using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Rougamo.Context;
using System.Data;

namespace MaiziWPF.Services.Domain.Shared
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionalAttribute : Rougamo.MoAttribute
    {
        public Propagation Propagation { get; set; } = Propagation.Required;
        public IsolationLevel IsolationLevel { get; set; }
        private readonly static AsyncLocal<IServiceProvider> _serviceProvider = new();
        public static void SetServiceProvider(IServiceProvider serviceProvider) => _serviceProvider.Value = serviceProvider;
        private IUnitOfWork _uow;
        public override void OnEntry(MethodContext context)
        {
            var uowManager = _serviceProvider.Value.GetService<UnitOfWorkManager>();
            _uow = uowManager.Begin(this.Propagation, this.IsolationLevel);
        }
        public override void OnExit(MethodContext context)
        {
            if (typeof(Task).IsAssignableFrom(context.ReturnType) && context.ReturnValue != null && context.ReturnValue is Task)
                ((Task)context.ReturnValue).ContinueWith(t => _OnExit());
            else _OnExit();

            void _OnExit()
            {
                try
                {
                    if (context.Exception == null) _uow.Commit();
                    else _uow.Rollback();
                }
                finally
                {
                    _uow.Dispose();
                }
            }
        }
    }
}
