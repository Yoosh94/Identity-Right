﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRight.Models;

namespace IdentityRight.Services
{
    public class ManageuserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ManageuserRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
        public bool DoesLinkExist(string apiKey,string userID)
        {
            
            return true;
        }


    }
}