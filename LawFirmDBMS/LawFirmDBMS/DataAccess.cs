//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
// See the blog post here for help on using the generated code: http://erikej.blogspot.dk/2014/10/database-first-with-sqlite-in-universal.html
using System.Data.SQLite;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace LawFirmDBMS
{
	public class SqlDB
    {
		const string path = "server=127.0.0.1;user id=root;database=law_firm";
		MySqlConnection connection = new MySqlConnection(path);
        public void InsertIntoLawyer(Lawyer lawyer)
        {
			try
			{
				string lawyerInsert = "INSERT INTO LAWYER(name, designation, billables, phone, password) VALUES(@name, @designation, @billables, @phone" +
					", @password)";
				MySqlCommand insert = new MySqlCommand(lawyerInsert, connection);
				insert.Parameters.AddWithValue("@name", lawyer.FullName);
				insert.Parameters.AddWithValue("@designation", lawyer.Designation);
				insert.Parameters.AddWithValue("@billables", lawyer.Billables);
				insert.Parameters.AddWithValue("@phone", lawyer.Phone);
				insert.Parameters.AddWithValue("@password", lawyer.Password);

				connection.Open();
				insert.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				Debug.WriteLine(e);
			}
		}
		public Lawyer GetLawyer(string password, string phoneNumber) 
		{
			Lawyer lawyer = new Lawyer();
			try
			{
				string getLawyerDetails = "SELECT * FROM LAWYER WHERE PHONE=@phone AND PASSWORD=@password;";
				connection.Open();
				MySqlCommand command = new MySqlCommand(getLawyerDetails, connection);
				command.Parameters.AddWithValue("@phone", phoneNumber);
				command.Parameters.AddWithValue("@password", password);
				MySqlDataReader getLawyer = command.ExecuteReader();
				if (getLawyer.HasRows)
				{
					lawyer = new Lawyer
					{
						LawyerID = getLawyer.GetInt32(0),
						FullName = getLawyer.GetString(1),
						Designation = getLawyer.GetString(2),
						Billables = getLawyer.GetInt32(3),
						Phone = getLawyer.GetString(4),
						Password = getLawyer.GetString(5)
					};
				}
				getLawyer.Close();
				return lawyer;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				return lawyer;
			}
		}
		public void InsertIntoCases(Case _case)
		{
			try
			{
				string caseInsert = "INSERT INTO CASE(status, hours_billed, title, courtroom_number, cl_id) VALUES(@status, " +
					"@hours_billed, @title, @courtroom_number, @cl_id);";
				MySqlCommand insert = new MySqlCommand(caseInsert, connection);
				insert.Parameters.AddWithValue("@status", _case.Status);
				insert.Parameters.AddWithValue("@hours_billed", _case.HoursBilled);
				insert.Parameters.AddWithValue("@title", _case.Title);
				insert.Parameters.AddWithValue("@courtroom_number", _case.CourtroomNumber);
				connection.Open();
				insert.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}
		public List<Case> GetCases()
		{
			List<Case> caseList = new List<Case>();
			string getCases = "SELECT * FROM CASES;";
			connection.Open();
			MySqlCommand command = new MySqlCommand(getCases, connection);
			MySqlDataReader cases = command.ExecuteReader();
			if (cases.HasRows)
			{
				while (cases.Read())
				{
					Case _case = new Case
					{
						CaseID = cases.GetInt32(0),
						Title = cases.GetString(1),
						Status = cases.GetString(2),
						HoursBilled = cases.GetInt32(3),
						ClientID = cases.GetInt32(4),
						CourtroomNumber = cases.GetString(5)
					};
					caseList.Add(_case);
					cases.NextResult();
				}
			}
			cases.Close();
			return caseList;
		}
		public void InsertIntoClient(Client client)
		{
			try
			{
				string caseInsert = "INSERT INTO CLIENT(cl_id, name, case_id, phone) VALUES(@cl_id, @name, @case_id, @phone);";
				MySqlCommand insert = new MySqlCommand(caseInsert, connection);
				insert.Parameters.AddWithValue("@cl_id", client.ClientID);
				insert.Parameters.AddWithValue("@name", client.FullName);
				insert.Parameters.AddWithValue("@case_id", client.CaseID);
				insert.Parameters.AddWithValue("@phone", client.Phone);
				connection.Open();
				insert.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}
		public List<Client> GetClients()
		{
			List<Client> clientList = new List<Client>();
			string getClients = "SELECT * FROM CLIENT;";
			connection.Open();
			MySqlCommand command = new MySqlCommand(getClients, connection);
			MySqlDataReader clients = command.ExecuteReader();
			if (clients.HasRows)
			{
				while(clients.Read())
				{
					Client client = new Client
					{
						ClientID = clients.GetInt32(0),
						FullName = clients.GetString(1),
						CaseID = clients.GetInt32(2),
						Phone = clients.GetString(3)
					};
					clientList.Add(client);
					clients.NextResult();
				}
			}
			clients.Close();
			return clientList;

		}

	}

	public class Lawyer
	{
		public int LawyerID { get; set; }

		public string FullName { get; set; }

		public string Designation { get; set; }

		public string Phone { get; set; }

		public string Password { get; set; }

		public int Billables { get; set; }
	}

	public class Client
	{
		public int ClientID { get; set; }

		public string FullName { get; set; }

		public string Phone { get; set; }

		public int CaseID { get; set; }

	}

	public class Case
	{
		public int CaseID { get; set; }

		public string Status { get; set; }

		public int HoursBilled { get; set; }

		public int ClientID { get; set; }

		public string CourtroomNumber { get; set; }

		public string Title { get; set; }
	}

	public class Paralegals
	{
		public int PID { get; set; }

		public string Phone { get; set; }
	}

	public class CaseRecord
	{
		public int DocID { get; set; }

		public int CaseID { get; set; }

		public int PID { get; set; }
	}


}
