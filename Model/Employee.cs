﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_C.F_.ViewModel;

namespace Project_C.F_.Model
{
    public class Employee : MainViewModel
    {
        private string _EmployeeID;
        private string fullName;
        private string email;
        private string password;
        private string contactNumber;
        private string gender;
        private DateTime hoursWorked;
        private int activtiyStatus;
        private string jobPosition;
        private DateTime dateJoined;
        private DateTime birthDate;
        private string country;
        private string homeAddress;
        private string provincialAddress;

        public string EmployeeID 
        { 
            get { return _EmployeeID; } 
            set { _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); } 
        } 
        public string FullName 
        {
            get { return fullName; }
            set { fullName = value; OnPropertyChanged(); OnPropertyChanged(nameof(fullName)); }
        }
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); OnPropertyChanged(nameof(email); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(password)); }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; OnPropertyChanged(); OnPropertyChanged(nameof(contactNumber)); }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); OnPropertyChanged(nameof(gender)); }
        }
        public DateTime HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; OnPropertyChanged(); OnPropertyChanged(nameof(hoursWorked)); }
        }
    }
}
