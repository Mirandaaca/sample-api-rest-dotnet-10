using System.Diagnostics;
using CIWithJenkins.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CIWithJenkins.Handlers
{
    public sealed class DomainExceptionHandler : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;
        private readonly ILogger<DomainExceptionHandler> _logger;

        public DomainExceptionHandler(
            IProblemDetailsService problemDetailsService,
            ILogger<DomainExceptionHandler> logger)
        {
            _problemDetailsService = problemDetailsService;
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails = exception switch
            {
                // FluentValidation errors: 400 with field-by-field details
                ValidationException validationException
                    => BuildValidationProblem(validationException),

                // Any domain exception: it itself says its code and title
                DomainException domainException => new ProblemDetails
                {
                    Status = domainException.StatusCode,
                    Title = domainException.Title,
                    Detail = domainException.Message
                },

                // Everything else is a real and unexpected failure
                _ => BuildUnexpectedProblem(httpContext, exception)
            };

            problemDetails.Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}";
            problemDetails.Extensions["traceId"] = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            httpContext.Response.StatusCode =
                problemDetails.Status ?? StatusCodes.Status500InternalServerError;

            // Returning true means "I handled this exception"
            // If false is returned, it would pass to the next registered IExceptionHandler
            return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = problemDetails,
                Exception = exception
            });
        }

        private static ProblemDetails BuildValidationProblem(ValidationException exception)
        {
            var errors = exception.Errors
                .GroupBy(failure => failure.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(failure => failure.ErrorMessage).ToArray());

            return new ValidationProblemDetails(errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "One or more validation errors"
            };
        }

        private ProblemDetails BuildUnexpectedProblem(HttpContext httpContext, Exception exception)
        {
            _logger.LogError(
                exception,
                "Exception not handled in {Method} {Path}",
                httpContext.Request.Method,
                httpContext.Request.Path);

            return new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server Internal Error",
                Detail = "An unexpected error occurred. If the problem persists, report the traceId."
            };
        }
    }
}
