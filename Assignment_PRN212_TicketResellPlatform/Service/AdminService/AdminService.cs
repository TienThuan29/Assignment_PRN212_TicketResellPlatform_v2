﻿using BusinessObject;
using Repository.Def;
using Repository.Impl;
using Service.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly ITransactionRepository iTransactionRepository;
        private readonly IStaffRepository iStaffRepository;
        private readonly IUserRepository iUserRepository;

        public AdminService()
        {
            iTransactionRepository = new TransactionRepository();
            iStaffRepository = new StaffRepository();
            iUserRepository = new UserRepository();
        }

        public bool AddStaff(BusinessObject.Staff item)
        {
            return iStaffRepository.AddStaff(item);
        }

        public bool ChangeEnableOfStaff(string id)
        {
            return iStaffRepository.ChangeEnableOfStaff(id);
        }

        public bool ChangeEnableOfUser(string id)
        {
            return iUserRepository.ChangeEnableOfUser(id);
        }

        public bool CheckExistUsername(string username)
        {
            return iStaffRepository.CheckExistUsername(username);
        }

        public List<EventRevenue> GetEventRevenueList()
        {
            return iStaffRepository.GetEventRevenueList();
        }

        public List<BusinessObject.Staff> GetListStaff()
        {
            return iStaffRepository.GetAll();
        }

        public BusinessObject.Staff GetStaffById(string id)
        {
            return iStaffRepository.GetStaffById(id);
        }

        public List<Transaction> GetTransactions()
        {
            return iTransactionRepository.GetTransactions();
        }

        public List<Transaction> GetTransactionsListOfType(string type)
        {
            return iTransactionRepository.GetTransactionsListOfType(type);
        }

        public List<BusinessObject.User> GetUsers()
        {
            return (List<BusinessObject.User>) iUserRepository.GetAll();
        }

        public List<BusinessObject.Staff> Search(string str)
        {
            return iStaffRepository.Search(str);
        }

        public List<EventRevenue> SearchEventRevenueList(string str)
        {
            return iStaffRepository.SearchEventRevenueList(str);
        }

        public List<Transaction> SearchTransaction(string query)
        {
            return iTransactionRepository.Search(query);
        }

        public List<Transaction> SearchTransactionOfType(string query, string type)
        {
            return iTransactionRepository.SearchOfType(query, type);
        }

        public List<BusinessObject.User> SearchUser(string query)
        {
            return iUserRepository.Search(query);
        }

        public bool UpdateStaff(BusinessObject.Staff item)
        {
            return iStaffRepository.UpdateStaff(item);
        }
    }
}
