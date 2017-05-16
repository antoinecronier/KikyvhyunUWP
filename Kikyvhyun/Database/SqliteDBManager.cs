using Kikyvhyun.Entities;
using Kikyvhyun.Entities.Base;
using Kikyvhyun.Entities.Relations;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Kikyvhyun.Database
{
    public class SqliteDBManager<T> where T : EntityBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        private const string DB_NAME = "//Kikyvhyun.db";
        #endregion

        #region Variables
        SQLiteConnection connection;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public SqliteDBManager()
        {
            connection = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
            ApplicationData.Current.LocalFolder.Path + DB_NAME);
            try
            {
                //connection.CreateTable<T>();
                LoadAll();
            }
            catch (Exception e)
            {
                connection.MigrateTable<T>();
            }
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void LoadAll()
        {
            connection.CreateTable<CategoryMeeting>();
            connection.CreateTable<PeopleMeeting>();
            connection.CreateTable<UserMeeting>();
            connection.CreateTable<Category>();
            connection.CreateTable<Address>();
            connection.CreateTable<Meeting>();
            connection.CreateTable<People>();
            connection.CreateTable<User>();
        }

        public void Insert(T item)
        {
            connection.Insert(item);
        }

        public void Insert(List<T> items)
        {
            foreach (var item in items)
            {
                Insert(item);
            }
        }

        public void InsertWithChildren(T item)
        {
            connection.InsertWithChildren(item);
        }

        public void InsertWithChildren(List<T> items)
        {
            foreach (var item in items)
            {
                InsertWithChildren(item);
            }
        }

        public T Get(int id)
        {
            return connection.Find<T>(id);
        }

        public List<T> Get()
        {
            return connection.Table<T>().ToList();
        }

        public T GetWithChildren(int id)
        {
            return connection.GetWithChildren<T>(id);
        }

        public List<T> GetWithChildren()
        {
            return connection.GetAllWithChildren<T>();
        }

        public void Update(T item)
        {
            connection.Update(item);
        }

        public void Update(List<T> items)
        {
            foreach (var item in items)
            {
                Update(item);
            }
        }

        public void UpdateWithChildren(T item)
        {
            connection.UpdateWithChildren(item);
        }

        public void UpdateWithChildren(List<T> items)
        {
            foreach (var item in items)
            {
                UpdateWithChildren(item);
            }
        }

        public void Delete(T item)
        {
            connection.Delete(item);
        }

        public void Delete(List<T> items)
        {
            foreach (var item in items)
            {
                Delete(item);
            }
        }
        #endregion

        #region Events
        #endregion


    }
}
