﻿namespace Hystrix.Test.HystrixCommandTestImplementations
{
    using System.IO;
    using System.Threading;
    using Hystrix.Test.CircuitBreakerTestImplementations;

    internal class CommandWithCheckedException : TestHystrixCommand<bool>
    {
        public CommandWithCheckedException(TestCircuitBreaker circuitBreaker)
            : base(new TestCommandBuilder()
            {
                CircuitBreaker = circuitBreaker,
                Metrics = circuitBreaker.Metrics,
                CommandPropertiesDefaults = UnitTestSetterFactory.GetCommandPropertiesSetter().WithExecutionIsolationThreadTimeout(Timeout.InfiniteTimeSpan),
            })
        {
        }

        protected override bool Run()
        {
            throw new IOException("simulated checked exception message");
        }
    }
}
