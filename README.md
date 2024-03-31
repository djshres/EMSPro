Employee Management System (EMS) Application

Welcome to the Employee Management System (EMS) application! This application facilitates efficient management of employees, departments, and roles within your organization. Below are detailed instructions on how to set up and effectively utilize the application:

### Setup

#### Database Configuration:

1. Ensure you have a SQL Server database available locally.
2. Update the `appsettings.json` file located in the MyApp project with your database connection string under the key `DefaultConnection`. 
    - Example: `"DefaultConnection": "Server=localhost;Database=EMSDB;Trusted_Connection=True;"`

#### Running the Application:

1. Compile and run the MyApp project.
2. Upon startup, the application will seed default departments and roles into your database.

### Features

1. **List all employees**:
    - Displays a comprehensive list of all employees currently registered in the system.

2. **Add an employee**:
    - Allows an admin user to add a new employee to the system by providing relevant information such as name, department, and role.

3. **Update an employee**:
    - Permits an admin user to modify the details of an existing employee, such as their name, department, or role.

4. **Delete an employee**:
    - Enables an admin user to remove an employee from the system entirely.

5. **List all departments**:
    - Provides an overview of all departments existing within the organization.

6. **List all roles**:
    - Offers a comprehensive list of all roles available within the organization.

7. **Exit**:
    - Allows users to exit the application at any time.

### Usage

#### Authentication:

- Upon initiating the application, you will be prompted to enter your username and password.
- Default admin credentials: 
    - Username: admin
    - Password: password
- Only users with admin privileges (such as the default admin user) can perform actions like adding, updating, or deleting employees.

#### Menu Navigation:

- Utilize the numeric keys to navigate through the menu options displayed on the screen.
- Follow the on-screen instructions for each menu option to execute the desired actions effectively.

#### Exiting the Application:

- To exit the application, select option 7 from the menu.

### Contributing

If you wish to contribute to the enhancement of this application, you are encouraged to fork the repository, implement your changes, and then submit a pull request.

### Feedback

Your feedback and suggestions for improving the application are highly valued. Please feel free to reach out to us with any thoughts or ideas you may have.

Thank you for choosing the EMS application for your employee management needs. We hope it enhances your organizational efficiency and productivity.
