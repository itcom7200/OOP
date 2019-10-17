using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOP.Models
{
    public class Account
    {

        //Attribute (ไว้เก็บตัวแปร Variables)

        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        

        //Behavior (เก็บ Method หรือ Functions)

        public void addID()
        {
            id++;
        }
        public string fullName()
        {
            return firstname + " " + lastname;
        }
        
    }
    
}