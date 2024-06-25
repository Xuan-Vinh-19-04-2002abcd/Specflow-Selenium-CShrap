using Assignment.Core.Element;
using Assignment.Core.Extensions;
using Assignment.Test.DataObject;
using OpenQA.Selenium;

namespace Assignment.Test.Pages;

public class FormRegisterStudentPage
{
    private Element _txtFirstName  = new Element(By.Id("firstName"));
    private Element _txtLastName  = new Element(By.Id("lastName"));
    private Element _txtEmail  = new Element(By.Id("userEmail"));
    private Element _txtMobile  = new Element(By.Id("userNumber"));
    private Element _txtDateOfBirth  = new Element(By.Id("dateOfBirthInput"));
    private Element _txtSubject  = new Element(By.Id("subjectsInput"));
    private Element _inpPicture  = new Element(By.Id("uploadPicture"));
    private Element _txaCurrentAddress  = new Element(By.Id("currentAddress"));
    private Element _btnSubmit = new Element(By.Id("submit"));
    public Element _lblThankYouMessage = new Element(By.XPath("//div[contains(@class,'modal-title')]"));

    public Element _lblResultInfo(string fieldName)
    {
        return new Element(By.XPath($"//td[text()='{fieldName}']/following-sibling::td"));
    }

    private Element _txtGender(string gender)
    {
        return new Element(By.XPath($"//div[@id='genterWrapper']//label[text()='{gender}']"));
    }

    private Element _txtHobbies(string hobbies)
    {
        return new Element(By.XPath($"//div[@id='hobbiesWrapper']//label[text()='{hobbies}']"));
    }

    private Element _optionElement(string value)
    {
        return new Element(By.XPath($"//div[contains(@class,'option') and text()='{value}']"));
    }

    private Element _seletectLocation(string valueId)
    {
        return new Element(By.XPath($"//div[@id='{valueId}']//input"));
    }

    public void EnterSubjects(List<string> subjects)
    {
        foreach (var subject in subjects)
        {
            _txtSubject.EnterText(subject);
            _optionElement(subject).ClickOnElement();
        }
    }

    public void EnterHobbies(List<string> hobbies)
    {
        foreach (var hobbie in hobbies)
        {
            _txtHobbies(hobbie).ClickOnElement();
        }
    }

    public void EnterLocation(string valueId, string location)
    {
        _seletectLocation(valueId).EnterText(location);
        _optionElement(location).ClickOnElement();
    }



    public void RegisterStudent(Student student)
    {
        _txtFirstName.EnterText(student.FirstName);
        _txtLastName.EnterText(student.LastName);
        _txtEmail.EnterText(student.Email);
        _txtGender(student.Gender).ClickOnElement();
        _txtMobile.EnterText(student.PhoneNumber);
        _txtDateOfBirth.SelectDateFromDatePicker(student.DateOfBirth);
        EnterSubjects(student.Subject);
        EnterHobbies(student.Hobbies);
        _inpPicture.EnterText(student.GetAbsolutePictureFilePath());
        _txaCurrentAddress.EnterText(student.CurrentAddress);
        EnterLocation("state", student.State);
        EnterLocation("city", student.City);
        _btnSubmit.SubmitOnElement();
    }


    public string GetStudentName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }

    public string GetDateOfBirth(string dateOfBirth)
    {
        return StringExtensions.ConvertDateFormat(dateOfBirth);
    }


    public string ConvertListStringToString(List<string> listString)
    {
        return string.Join(", ", listString);
    }

    public string GetStateCity(string state, string city)
    {
        return $"{state} {city}";
    }

    public bool checkThankYouMessage()
    {
        return (_lblThankYouMessage.GetTextElement() == "Thanks for submitting the form");
    }

    public bool checkStudentNameResult(string firstName, string lastName)
    {
        return (_lblResultInfo("Student Name").GetTextElement() == $"{firstName} {lastName}");
    }

    public bool checkEmailResult(string expectedValue)
    {
        return (_lblResultInfo("Student Email").GetTextElement() == expectedValue);
    }

    public bool checkGenderResult(string expectedValue)
    {
        return (_lblResultInfo("Gender").GetTextElement() == expectedValue);
    }

    public bool checkMobileResult(string expectedValue)
    {
        return (_lblResultInfo("Mobile").GetTextElement() == expectedValue);

    }
    public bool checkDateOfBirthResult(string dateOfBirth)
    {
        var acturalResult = StringExtensions.ConvertDateFormat(dateOfBirth);
        return (_lblResultInfo("Date of Birth").GetTextElement() == acturalResult);
    }
    
    public bool checkSubjectResult(List<string> subject)
    {
        var acturalResult = string.Join(", ", subject);
        return (_lblResultInfo("Subjects").GetTextElement() == acturalResult);
    }
    
    public bool checkHobbiesResult(List<string> hobbies)
    {
        var acturalResult = string.Join(", ", hobbies);
        return (_lblResultInfo("Hobbies").GetTextElement() == acturalResult);
    }
    public bool checkPictureResult(string pathPicture)
    {
        return (_lblResultInfo("Picture").GetTextElement() == pathPicture);
    }

    public bool checkAddressResult(string address)
    {
        return (_lblResultInfo("Address").GetTextElement() == address );
    }

    public bool checkStateCityResult(string state, string city)
    {
        return (_lblResultInfo("State and City").GetTextElement() == $"{state} {city}");
    }
    public bool checkStudentInforAfterRegister(Student student)
    {
        return (
                checkThankYouMessage() &&
                checkStudentNameResult(student.FirstName, student.LastName) &&
                checkEmailResult(student.Email) &&
                checkGenderResult(student.Gender) &&
                checkMobileResult(student.PhoneNumber) &&
                checkDateOfBirthResult(student.DateOfBirth) &&
                checkSubjectResult(student.Subject) &&
                checkHobbiesResult(student.Hobbies) &&
                checkPictureResult(student.Picture) &&
                checkAddressResult(student.CurrentAddress) &&
                checkStateCityResult(student.State, student.City));
    }
    
}