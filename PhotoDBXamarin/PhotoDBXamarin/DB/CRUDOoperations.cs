using PhotoDBXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoDBXamarin.DB
{
    public class CRUDOperation
    {
        SQLiteConnection db;
        public CRUDOperation(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<ProjectModel>();
        }
        public IEnumerable<ProjectModel> GetProjects()
        {
            return db.Table<ProjectModel>();
        }
        public int SaveItem(ProjectModel projectModel)
        {
            if (projectModel.Id != 0)
            {
                db.Update(projectModel);
                return projectModel.Id;
            }
            else
            {
                return db.Insert(projectModel);
            }
        }
        public int DeleteItem(int id)
        {
            return db.Delete<ProjectModel>(id);
        }
    }
}
