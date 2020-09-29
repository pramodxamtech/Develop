using DatarynxApp.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatarynxApp.Models
{
    public class BaseItem : ObservablePattern
    {
        int _id = 0;
        int syn = 0;
        [SQLite.PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public int Sync
        {
            get
            {
                return syn;
            }
            set
            {
                syn = value;
                OnPropertyChanged("Sync");
            }
        }
    }
}
