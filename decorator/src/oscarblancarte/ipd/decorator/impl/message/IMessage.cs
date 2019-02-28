using System;

/**
 * @author Oscar Javier Blancarte Iturralde
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipd.decorator.impl.message{
    public interface IMessage {
        
        IMessage ProcessMessage();
        string GetContent();
        void SetContent(string content);
    }
}