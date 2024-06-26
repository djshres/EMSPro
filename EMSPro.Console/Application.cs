﻿using EMSPro.App.Helper;
using EMSPro.Core.IService;

namespace EMSPro.App
{
    public class Application
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IRoleService _roleService;
        public bool _isLoggedIn = false;
        public string _currentUser = null;

        public Application(IEmployeeService employeeService,
            IDepartmentService departmentService,
            IRoleService roleService)
        {
            _departmentService = departmentService;
            _roleService = roleService;
            _employeeService = employeeService;
        }

        public void Processer()
        {
            DisplayMenu();
            ProcessUserChoice("");
        }

        // Time complexity: O(1)
        // Space complexity: O(1)
        private void DisplayMenu()
        {
            Console.WriteLine("  EEEEE  M   M  SSSSS    PPPP    RRRR    OOO  ");
            Console.WriteLine("  E      MM MM  S        P   P   R   R  O   O ");
            Console.WriteLine("  EEEE   M M M  SSSSS    PPPP    RRRR   O   O ");
            Console.WriteLine("  E      M   M      S    P       R  R   O   O ");
            Console.WriteLine("  EEEEE  M   M  SSSSS    P       R   R   OOO  ");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. List all employees");
            Console.WriteLine("2. Add an employee");
            Console.WriteLine("3. Update an employee");
            Console.WriteLine("4. Delete an employee");
            Console.WriteLine("5. List all departments");
            Console.WriteLine("6. List all roles");
            Console.WriteLine("7. Exit");
        }

        public void ProcessUserChoice(string choice)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var employees = _employeeService.GetAllEmployees();
                        _employeeService.PrintAllEmployees(employees);
                        break;
                    case "2":
                        if (IsAdmin())
                        {
                            _employeeService.AddEmployee();
                        }
                        else
                        {
                            Console.WriteLine("Only admin users can add employees.");
                        }
                        break;
                    case "3":
                        if (IsAdmin())
                        {
                            _employeeService.UpdateEmployee();
                        }
                        else
                        {
                            Console.WriteLine("Only admin users can update employees.");
                        }
                        break;
                    case "4":
                        if (IsAdmin())
                        {
                            _employeeService.DeleteEmployee();
                        }
                        else
                        {
                            Console.WriteLine("Only admin users can delete employees.");
                        }
                        break;
                    case "5":
                        var departments = _departmentService.GetAllDepartments();
                        _departmentService.PrintAllDepartments(departments);
                        break;
                    case "6":
                        var roles = _roleService.GetAllRoles();
                        _roleService.PrintAllRoles(roles);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        break;
                }
            }
        }

        public bool IsAdmin()
        {
            if (!_isLoggedIn)
            {
                Authenticate();
            }

            return _isLoggedIn && _currentUser != null && AuthenticationHelper.userRoles.ContainsKey(_currentUser) && Array.Exists(AuthenticationHelper.userRoles[_currentUser], role => role == "admin");
        }

        public void Authenticate()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Perform authentication based on AuthenticationHelper
            if (AuthenticationHelper.users.ContainsKey(username) && AuthenticationHelper.users[username] == password)
            {
                _currentUser = username;
                _isLoggedIn = true;
            }
            else
            {
                Console.WriteLine("Authentication failed.");
            }
        }
    }
}
