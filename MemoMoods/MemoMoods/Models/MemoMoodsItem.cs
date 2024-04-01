using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MemoMoods.Models
{
    internal class MemoMoodsItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CowMood { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string JournalEntry {  get; set; }
        public bool GoalsMet { get; set; }

        public MemoMoodsItem()
        {
            Date = DateTime.Now.Date;
            
        }
        public string FormattedDate
        {
            get { return Date.ToString("MM-dd-yy"); } 
        }

	}
}
