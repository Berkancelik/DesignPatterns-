namespace WebApp.ChainOfResponsibility.Web.ChainOfResponsibility
{
    public class Processhandler : IProcessHandler
    {
        private  IProcessHandler nextProcessHandler;
        public virtual object handle(object o)
        {
            if (nextProcessHandler != null)
            {
                return nextProcessHandler.handle(o);
            }
            return null;
        }

        public IProcessHandler SetNext(IProcessHandler processHandler)
        {
            nextProcessHandler = processHandler;
            return nextProcessHandler;
        }
    }
}
