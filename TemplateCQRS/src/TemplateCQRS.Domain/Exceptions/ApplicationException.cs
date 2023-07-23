namespace TemplateCQRS.Domain.Exceptions
{
    using System;

    public abstract class ApplicationException : Exception
    {
        protected ApplicationException(string title, string message)
            : base(message) =>
            this.Title = title;

        public string Title { get; }
    }
}

