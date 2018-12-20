using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTextEditor.Controllers;

namespace WebApplicationTextEditor.Models
{
    public class Text
    {
        public int? id { get; set; }
        public string memo { get; set; }
        public DateTime? createDate { get; set; }
        public string fileName {get; set;}

        public void update()
        {
            string updateStatement = "UPDATE TEXT ";
            updateStatement += $"SET MEMO = '{memo}'";
            updateStatement += $", DateiName = '{fileName}'";
            updateStatement += $" WHERE ID = '{id}'";
            var db = new DataBaseController();
            db.executeNonQuery(updateStatement);
        }

        public void insert()
        {
            string insertStatement = "INSERT INTO TEXT";
            insertStatement += "(id,memo,createdate,DateiName)";
            insertStatement += $"values('{id}','{memo}','{createDate}','{fileName}')";
            var db = new DataBaseController();
            db.executeNonQuery(insertStatement);
        }

        public void delete()
        {
            string deleteStatement = "DELETE FROM TEXT";
            deleteStatement += $" WHERE ID = '{id}'";
            var db = new DataBaseController();
            db.executeNonQuery(deleteStatement);
        }
    }
}
