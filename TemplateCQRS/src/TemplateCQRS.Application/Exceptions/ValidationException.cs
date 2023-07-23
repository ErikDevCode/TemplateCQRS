namespace TemplateCQRS.Application.Exceptions
{
    using System.Collections.Generic;
    using ApplicationException = TemplateCQRS.Domain.Exceptions.ApplicationException;

    public sealed class ValidationException : ApplicationException
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base("Error en validación", "Uno o mas errores de validacion han ocurrido")
            => this.ErrorsDictionary = errorsDictionary;

        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}

