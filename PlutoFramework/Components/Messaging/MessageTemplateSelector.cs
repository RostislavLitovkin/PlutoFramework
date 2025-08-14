namespace PlutoFramework.Components.Messaging;

public class MessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate IncomingTemplate { get; set; }
    public DataTemplate OutgoingTemplate { get; set; }
    public DataTemplate StatusTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is Message message)
        {
            return message.Type switch
            {
                Message.MessageType.Incoming => IncomingTemplate,
                Message.MessageType.Outgoing => OutgoingTemplate,
                Message.MessageType.Status   => StatusTemplate,
                _ => IncomingTemplate
            };
        }

        return IncomingTemplate;
    }
}