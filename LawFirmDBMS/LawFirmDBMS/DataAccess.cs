//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using System.Data.SQLite;
using System;
// TODO: Fix all these squiggly lines.
namespace LawFirmDBMS
{
	public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }
        
         public void Create()
        {
            using (SQLiteConnection db = new SQLiteConnection(_path))
            {
                db.CreateTable<CASE_RECORD>();
                db.CreateTable<CASES>();
                db.CreateTable<CLIENT>();
                db.CreateTable<COUNSELS>();
                db.CreateTable<HANDLES>();
                db.CreateTable<LAWYER>();
                db.CreateTable<PARALEGAL>();
            }
        }
    }
    public partial class CASE_RECORD
    {
        [NotNull]
        public Int64 DOC_ID { get; set; }
        
        [NotNull]
        public Int64 CASE_ID { get; set; }
        
        [NotNull]
        public Int64 P_ID { get; set; }
        
    }
    
    public partial class CASES
    {
        [PrimaryKey, AutoIncrement]
        public Int64 CASE_ID { get; set; }
        
        [NotNull]
        public String STATUS  { get; set; }
        
        [NotNull]
        public Int64 HOURS_BILLED { get; set; }
        
        [NotNull]
        public Int64 CL_ID { get; set; }
        
        [NotNull]
        public String STAGE { get; set; }
        
        [NotNull]
        public String COURTROOM_NO { get; set; }
        
    }
    
    public partial class CLIENT
    {
        [PrimaryKey, AutoIncrement]
        public Int64 CL_ID { get; set; }
        
        [NotNull]
        public String NAME { get; set; }
        
        [NotNull]
        public Int64 CASE_ID { get; set; }
        
        [NotNull]
        public String PHONE { get; set; }
        
    }
    
    public partial class COUNSELS
    {
        [NotNull]
        public Int64 CL_ID { get; set; }
        
        [NotNull]
        public Int64 L_ID { get; set; }
        
    }
    
    public partial class HANDLES
    {
        [NotNull]
        public Int64 L_ID { get; set; }
        
        [NotNull]
        public Int64 CASE_ID { get; set; }
        
    }
    
    public partial class LAWYER
    {
        [PrimaryKey, AutoIncrement]
        public Int64 L_ID { get; set; }
        
        [NotNull]
        public String NAME { get; set; }
        
        [NotNull]
        public String DESIGNATION { get; set; }
        
        [NotNull]
        public Int64 BILLABLES { get; set; }
        
        [NotNull]
        public String PHONE { get; set; }
        
    }
    
    public partial class PARALEGAL
    {
        [PrimaryKey, AutoIncrement]
        public Int64 P_ID { get; set; }
        
        [NotNull]
        public String PHONE { get; set; }
        
    }
    
}
