namespace BooksStore.Server.Exceptions
{
	public class DomainException : Exception
	{
		public IEnumerable<string> Errors { get; set; }
        public DomainException(string message) : base(message)
        {
			Errors = Enumerable.Empty<string>();
        }

		public DomainException(string message, IEnumerable<string> errors) : this(message)
		{
			Errors = errors;
		}

	}
}
