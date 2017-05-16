using Kikyvhyun.Entities.Base;
using Kikyvhyun.Entities.Relations;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kikyvhyun.Entities
{
    public class Meeting : EntityBase
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private DateTime meetingStart;
        private DateTime meetingEnd;
        private String meetingName;
        private List<People> people;
        private List<User> users;
        private List<Category> categories;
        private Address address;
        private int addressId;
        #endregion

        #region Properties
        [ForeignKey(typeof(Address))]
        public int AddressId
        {
            get { return addressId; }
            set
            {
                addressId = value;
                OnPropertyChanged("AddressId");
            }
        }

        [ManyToMany(typeof(CategoryMeeting))]
        public List<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        [ManyToMany(typeof(UserMeeting))]
        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        [ManyToMany(typeof(PeopleMeeting))]
        public List<People> People
        {
            get { return people; }
            set
            {
                people = value;
                OnPropertyChanged("People");
            }
        }

        public String MeetingName
        {
            get { return meetingName; }
            set
            {
                meetingName = value;
                OnPropertyChanged("MeetingName");
            }
        }

        public DateTime MeetingStart
        {
            get { return meetingStart; }
            set
            {
                meetingStart = value;
                OnPropertyChanged("MeetingStart");
            }
        }

        public DateTime MeetingEnd
        {
            get { return meetingEnd; }
            set
            {
                meetingEnd = value;
                OnPropertyChanged("MeetingEnd");
            }
        }

        [ManyToOne]
        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        #endregion

        #region Constructors
        public Meeting()
        {
            people = new List<Entities.People>();
            users = new List<User>();
            categories = new List<Category>();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
    }
}
