namespace TODO.Domain.Boards;

public record Description
{
	public Description(string value)
	{
		ArgumentNullException.ThrowIfNullOrEmpty(value);

		if (value.Trim().Length > 1000)
		{
			throw new ArgumentException($"Description is too long.");
		}

		Value = value.Trim();
	}

	public string Value { get; }

	override public string ToString() => Value;
}
