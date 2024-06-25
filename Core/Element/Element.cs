using OpenQA.Selenium;

namespace Assignment.Core.Element;

public class Element
{
    public By By{get; set;}

    public Element(By by)
    {
        By = by;
    }
    
    
}