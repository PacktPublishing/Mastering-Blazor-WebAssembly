using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace RenderTreesSample.Pages
{
	[Route("message-viewer")]
	public class MessageViewer : ComponentBase
	{
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "h1"); // Used to open an HTML element
			builder.AddContent(1, "Message: "); // Add content inside the HTML element
			builder.AddContent(2, _message);
			builder.CloseElement(); // Used to close an open element
			builder.OpenElement(3, "button");
			builder.AddAttribute(4, "class", "btn btn-primary"); // Add attribute with its name and value
			builder.AddAttribute(5, "onclick", EventCallback.Factory.Create(this, UpdateMessage)); // Used to set the value of the @onclick to the UpdateMessage method
			builder.AddContent(6, "Update message"); // Add the text of the button 	
			builder.CloseElement();																							   
		}

		private string _message = "Original message"; 
		private void UpdateMessage()
		{
			_message = "Updated message";
		}
	}
}
