using DatarynxApp.Common;
using DatarynxApp.Models;
using DatarynxApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatarynxApp.Services
{
    public class DataStorageService
    {
        DBService dbservice;
        public DataStorageService()
        {
            dbservice = new DBService(Constants.DatabaseName);
        }
        public async void StoreJsonData()
        {
            try
            {
                ObservableCollection<DatarynxRecord> ObjContactList = new ObservableCollection<DatarynxRecord>();
                string jsonFileName = @"DatarynxData.json";
                var jsonString = GetJsonData(jsonFileName);
                ObjContactList =  JsonConvert.DeserializeObject<ObservableCollection<DatarynxRecord>>(jsonString);
                if (!dbservice.TableExists("DatarynxRecord"))
                {
                    dbservice.CreateTable<DatarynxRecord>();
                    foreach (var data in ObjContactList)
                    {
                        DatarynxRecord datarynxRecord = new DatarynxRecord();
                        datarynxRecord.CodingType = data.CodingType;
                        datarynxRecord.StoreAddress = data.StoreAddress;
                        datarynxRecord.StoreName = data.StoreName;
                        datarynxRecord.TaskState = data.TaskState;
                        if (datarynxRecord.TaskState == "Not Started")
                        {
                            datarynxRecord.IsVisible = true;
                            datarynxRecord.Image = "GreenIIcon.png";
                        }
                        else
                        {
                            datarynxRecord.Image = "GrayIicon.png";
                        }

                        datarynxRecord.WeekDate = data.WeekDate;
                        datarynxRecord.WeekNo = data.WeekNo;

                        dbservice.SaveItem(datarynxRecord);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static string GetJsonData(string filePath)
        {
            string result = string.Empty;
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                var resource = string.Format("DatarynxApp.JsonFile.{0}", filePath);
                using (var stream = asm.GetManifestResourceStream(resource))
                {
                    if (stream != null)
                    {
                        var reader = new StreamReader(stream);
                        result = reader.ReadToEnd();
                    }
                }
            }
            catch
            {

            }
            return result;
        }
    }
}

