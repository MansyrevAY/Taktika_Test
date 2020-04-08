using System.Xml;

public static class GetFromConfig
{
    /// <summary>
    /// Returns everything inside specified elementName
    /// </summary>
    /// <param name="elementName"></param>
    /// <returns></returns>
    public static string GetElement(string elementName)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("config.xml");

        XmlNodeList elemList = doc.GetElementsByTagName(elementName);
        return elemList[0].InnerText;
    }
}
