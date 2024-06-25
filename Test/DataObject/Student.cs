using Assignment.Test.Constant;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using StringExtensions = Assignment.Core.Extensions.StringExtensions;

namespace Assignment.Test.DataObject;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string DateOfBirth { get; set; }
    public List<string> Subject { get; set; }
    public string Picture { get; set; }
    public List<string> Hobbies { get; set; }
    public string CurrentAddress { get; set; }
    public string State { get; set; }
    public string City { get; set; }

    public Student(string firstName, string lastName, string email, string gender, string phoneNumber,
        string dateOfBirth, List<string> subject, string picture, List<string> hobbies, string currentAddress,
        string state, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Gender = gender;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Subject = subject;
        Picture = picture;
        Hobbies = hobbies;
        CurrentAddress = currentAddress;
        State = state;
        City = city;
    }

    public string GetAbsolutePictureFilePath()
    {
        string basePath = Path.Combine(Directory.GetCurrentDirectory(), FileConstant.ImageDataFilePath);
        return Path.Combine(basePath, Picture);
    }

    
    
}

