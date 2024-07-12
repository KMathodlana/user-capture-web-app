using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;
using UserCaptureTest1.Models;

namespace UserCaptureTest1.Pages
{
    public class UserGridModel : PageModel
    {
        private const string _filePath = @".\userData.xml";

        public List<UserData> Users = new List<UserData>();

        [BindProperty]
        [XmlElement("User")]
        public UserData? User { get; set; }

        public void OnGet()
        {
            Users = GetUsersFromXMLFile();

        }

        public void OnPostAddUser()
        {
            if (User == null)
            {
                return;
            }

            Users = GetUsersFromXMLFile();

            var newIndex = Users.Count + 1;
            User.UserId = Users.Any(u => u.UserId == newIndex) ? newIndex + 1 : newIndex;
            Users.Add(User);

            WriteToXMLFile();
        }

        public void OnPostEditUser()
        {
            if (User == null)
            {
                return;
            }

            Users = GetUsersFromXMLFile();

            var user = Users.FirstOrDefault(u => u.UserId == User.UserId);
            if (user == null)
            {
                return;
            }

            var updatingUserIndex = Users.IndexOf(user);
            Users.RemoveAt(updatingUserIndex);
            Users.Insert(updatingUserIndex, User);

            WriteToXMLFile();
        }

        public void OnPostDeleteUser(int userId)
        {
            Users = GetUsersFromXMLFile();

            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return;
            }

            Users.Remove(user);
            WriteToXMLFile();
        }

        private List<UserData> GetUsersFromXMLFile()
        {
            try
            {
                List<UserData> users;

                XmlSerializer serializer = new XmlSerializer(typeof(List<UserData>));
                using (FileStream fileStream = new FileStream(_filePath, FileMode.Open))
                {
                    users = (List<UserData>)serializer.Deserialize(fileStream);
                }

                return users ?? new List<UserData>();
            }
            catch (Exception)
            {
                return new List<UserData>();
            }
        }

        private bool WriteToXMLFile()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<UserData>));
                using (var fileStream = new FileStream(_filePath, FileMode.Create))
                {
                    serializer.Serialize(fileStream, Users);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
