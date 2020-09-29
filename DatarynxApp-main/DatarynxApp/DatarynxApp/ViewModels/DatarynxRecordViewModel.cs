using DatarynxApp.Common;
using DatarynxApp.Models;
using DatarynxApp.Services;
using DatarynxApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace DatarynxApp.ViewModels
{
    public class DatarynxRecordViewModel: ObservablePattern
    {
        private ObservableCollection<DatarynxRecord> datarynxRecords;
        public ObservableCollection<DatarynxRecord> DatarynxRecords
        {
            get { return datarynxRecords; }
            set
            {
                if (datarynxRecords != value)
                {
                    datarynxRecords = value;
                    OnPropertyChanged();
                }
            }
        }
        DBService dbservice;
        public DatarynxRecordViewModel()
        {
            DatarynxRecords = new ObservableCollection<DatarynxRecord>();
            dbservice = new DBService(Constants.DatabaseName);
            Task.Run(async () => {
                GetDbData();
            });
        }

        public async void GetDbData()
        {
            try
            {
                if (dbservice.TableExists("DatarynxRecord"))
                {
                    var AllRecord = dbservice.Query<DatarynxRecord>("select * from DatarynxRecord", new object[] { });
                    foreach (var data in AllRecord)
                    {
                        DatarynxRecord datarynxRecord = new DatarynxRecord();
                        datarynxRecord = data;
                        DatarynxRecords.Add(datarynxRecord);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
