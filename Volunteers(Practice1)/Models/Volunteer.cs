﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteers_Practice1_.Models
{
    
    public class Volunteer
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string preferences { get; set; }
        public string skills { get; set; }
        public string availability { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string education { get; set; }
        public string licenses { get; set; }
        public string emergName { get; set; }
        public string emergPhone { get; set; }
        public string emergEmail { get; set; }
        public string emergAdd { get; set; }
       // public Boolean dlOnFile { get; set; }
        //public Boolean socialOnFile { get; set; }
        public string  approvalStatus { get; set; }
        
        public string activeStatus { get; set; }

        public Volunteer()
        {

        }// end constructor
    }
}
