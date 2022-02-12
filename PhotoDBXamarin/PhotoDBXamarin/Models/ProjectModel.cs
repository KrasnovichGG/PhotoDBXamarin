using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoDBXamarin.Models
{
    [Table("Борщ")]
    public class ProjectModel
    {
        public ProjectModel()
        {
        }

        public ProjectModel(string name, string imagepath)
        {
            Name = name;
            Imagepath = imagepath;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Imagepath { get; set; }   
    }
}
