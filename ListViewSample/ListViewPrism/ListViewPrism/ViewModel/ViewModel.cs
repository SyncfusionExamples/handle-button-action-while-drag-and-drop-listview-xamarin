using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;
using System.Reflection;
using ListViewPrism;

namespace Grouping
{
    [Preserve(AllMembers = true)]
    public class ListViewGroupingViewModel
    {
        #region Fields

        private ObservableCollection<ListViewContactsInfo> contactsInfo;
        private Command tapcommand;
        public bool isDragEndRaised = false;
        #endregion

        #region Constructor

        public ListViewGroupingViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public Command TapCommand
        {
            get { return tapcommand; }
            set { tapcommand = value; }
        }
        public ObservableCollection<ListViewContactsInfo> ContactsInfo
        {
            get { return contactsInfo; }
            set { this.contactsInfo = value; }
        }
        #endregion

        #region ItemSource

        public void GenerateSource()
        {
            ContactsInfo = new ObservableCollection<ListViewContactsInfo>();
            Assembly assembly = typeof(GroupingPage).GetTypeInfo().Assembly;
            Random random = new Random();
            for (int i = 0; i < CustomerNames.Count(); i++)
            {
                var details = new ListViewContactsInfo()
                {
                    ContactType = contactType[random.Next(0, 5)],
                    ContactNumber = random.Next(100, 400).ToString() + "-" + random.Next(500, 800).ToString() + "-" + random.Next(1000, 2000).ToString(),
                    ContactName = CustomerNames[i],
                    ContactImage = ImageSource.FromResource("Grouping.Images.Image" + random.Next(0, 28) + ".png", assembly),
            };
                ContactsInfo.Add(details);
            }
            TapCommand = new Command(OnButtonClick);
        }

        private void OnButtonClick(object obj)
        {
            var itemData = obj as ListViewContactsInfo;

            if (isDragEndRaised == true)
            {
                isDragEndRaised = false;
                return;
            }
            else
                App.Current.MainPage.DisplayAlert("", "Tapped item data : " + itemData.ContactName, "OK");

        }

        #endregion

        #region Contacts Information

        string[] contactType = new string[]
        {
            "HOME",
            "WORK",
            "MOBILE",
            "OTHER",
            "BUSINESS"
        };

        string[] CustomerNames = new string[]
        {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason  ",
            "Liam   ",
            "Jacob  ",
            "Jayden ",
            "Ethan  ",
            "Noah   ",
            "Lucas  ",
            "Logan  ",
            "Caleb  ",
            "Caden  ",
            "Jack   ",
            "Ryan   ",
            "Connor ",
            "Michael",
            "Elijah ",
            "Brayden",
            "Benjamin",
            "Nicholas",
            "Alexander",
            "William",
            "Matthew",
            "James  ",
            "Landon ",
            "Nathan ",
            "Dylan  ",
            "Evan   ",
            "Luke   ",
            "Andrew ",
            "Gabriel",
            "Gavin  ",
            "Joshua ",
            "Owen   ",
            "Daniel ",
            "Carter ",
            "Tyler  ",
            "Cameron",
            "Christian",
            "Wyatt  ",
            "Henry  ",
            "Eli    ",
            "Joseph ",
            "Max    ",
            "Isaac  ",
            "Samuel ",
            "Anthony",
            "Grayson",
            "Zachary",
            "David  ",
            "Christopher",
            "John   ",
            "Isaiah ",
            "Levi   ",
            "Jonathan",
            "Oliver ",
            "Chase  ",
            "Cooper ",
            "Tristan",
            "Colton ",
            "Austin ",
            "Colin  ",
            "Charlie",
            "Dominic",
            "Parker ",
            "Hunter ",
            "Thomas ",
            "Alex   ",
            "Ian    ",
            "Jordan ",
            "Cole   ",
            "Julian ",
            "Aaron  ",
            "Carson ",
            "Miles  ",
            "Blake  ",
            "Brody  ",
            "Adam   ",
            "Sebastian",
            "Adrian ",
            "Nolan  ",
            "Sean   ",
            "Riley  ",
            "Bentley",
            "Xavier ",
            "Hayden ",
            "Jeremiah",
            "Jason  ",
            "Jake   ",
            "Asher  ",
            "Micah  ",
            "Jace   ",
            "Brandon",
            "Josiah ",
            "Hudson ",
            "Nathaniel",
            "Bryson ",
            "Ryder  ",
            "Justin ",
            "Bryce  ",
        };

        #endregion
    }
}
