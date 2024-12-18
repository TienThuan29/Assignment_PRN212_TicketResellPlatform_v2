﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public interface IAdminService
    {
        public List<Transaction> GetTransactions();

        public List<Transaction> GetTransactionsListOfType(string type);

        public List<BusinessObject.Staff> GetListStaff();

        public List<BusinessObject.User> GetUsers();

        List<BusinessObject.Staff> Search(string str);

        List<Transaction> SearchTransaction(string query);

        List<Transaction> SearchTransactionOfType(string query, string type);

        List<BusinessObject.User> SearchUser(string query);

        bool AddStaff(BusinessObject.Staff item);

        bool ChangeEnableOfStaff(string id);

        bool ChangeEnableOfUser(string id);

        bool CheckExistUsername(string username);

        List<EventRevenue> GetEventRevenueList();

        List<EventRevenue> SearchEventRevenueList(string str);

        BusinessObject.Staff GetStaffById(string id);

        bool UpdateStaff(BusinessObject.Staff item);
    }
}
