using System;

namespace WebApp.ChainOfResponsibility.Web.ChainOfResponsibility
{
    public interface IProcessHandler
    {
        IProcessHandler SetNext(IProcessHandler processHandler);
        Object handle(Object o);
    }
}
