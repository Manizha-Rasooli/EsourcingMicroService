using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.PipelineBehaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehavior(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();
            var reponse = await next();
            _timer.Stop();

            var elapseMilliSeconds = _timer.ElapsedMilliseconds;
            if(elapseMilliSeconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning(" Long running request : {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName, elapseMilliSeconds, request);
            }
            return reponse;
        }
    }
}
