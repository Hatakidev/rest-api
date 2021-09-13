using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static BackEnd.RetrieveDataClass;

namespace BackEnd
{
    [Produces("application/json")]
    class Program
    {
        
        static async Task Main(string[] args)
        {
            
        }
            
        
        [HttpGet]
        public void Get(string GetBlogList)
        {
            
            string sqlstring = "server=localhost;user=root;database=books;password=;port=80";
            MySqlConnection conn = new MySqlConnection(sqlstring);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            string Query = "SELECT * FROM books where `book` =";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataReader MSQLRD = cmd.ExecuteReader();
            List<BlogViews> GetBlogList = new List<BlogViews>();

            if (MSQLRD.HasRows)
            {

                while (MSQLRD.Read())
                {
                    BlogViews BV = new BlogViews();
                    BV.id = (MSQLRD["id"].ToString());
                    BV.DisplayTopic = (MSQLRD["Topic"].ToString());
                    BV.DisplayMain = (MSQLRD["Summary"].ToString());
                    GetBlogList.Add(BV);
                }
            }
            conn.Close();
            return GetBlogList;
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost]
        public void Post([FromBody] RetrieveDataClass value)
        {
            string sqlstring = "server=localhost;;user id=root;Password=;Database=books;";
            MySqlConnection conn = new MySqlConnection(sqlstring);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            string Query = "INSERT INTO books (id,book,author,year of publishing)values('" + value.book + "','" + value.author + "','" + value.year_of_publising + "');";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            cmd.ExecuteReader();
            conn.Close();

        }
    }
}
