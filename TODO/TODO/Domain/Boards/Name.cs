namespace TODO.Domain.Boards;

public record Name
{
	public Name(string value)
	{
		ArgumentNullException.ThrowIfNullOrEmpty(value);

		if (value.Trim().Length > 100)
		{
			throw new ArgumentException($"Name is too long.");
		}

		Value = value.Trim();
	}

	public string Value { get; }

	public override string ToString() => Value;
}
