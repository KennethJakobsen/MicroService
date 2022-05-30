using System;
namespace EventEmitter
{
	public interface ISendEvent
	{
		string Description { get; }
		Task SendAsync();
	}
}

