using System;
namespace MockFrontend;

	public interface IInteractWithGateway
	{
		string Description { get; }
		Task SendAsync();
	}

