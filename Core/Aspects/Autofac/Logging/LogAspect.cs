using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Core.Aspects.Autofac.Logging;

public class LogAspect : MethodInterception
{
    private readonly LoggerServiceBase _loggerServiceBase;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
            throw new ArgumentException("AspectMessages.WrongLoggerType");

        _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        if (!Debugger.IsAttached)
            _loggerServiceBase?.Info(GetLogDetail(invocation));
    }

    protected override void OnException(IInvocation invocation, Exception e)
    {
        if (!Debugger.IsAttached)
            _loggerServiceBase?.Error(GetLogDetail(invocation), e);
    }

    private string GetLogDetail(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();
        for (var i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name,
            });
        }

        var logDetail = new LogDetail
        {
            FullName = invocation.Method.ReflectedType.FullName,
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            User = _httpContextAccessor.HttpContext is null ||
                    _httpContextAccessor.HttpContext.User.Identity.Name is null
                ? "?"
                : _httpContextAccessor.HttpContext.User.Identity.Name
        };

        return JsonConvert.SerializeObject(logDetail);
    }
}