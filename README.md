# Organization Management System (OMS) 🚀

A modern web-based management system with professional CSS layouts and employee tracking.
---
## 📖 About the Project
Managing a growing organization requires a reliable way to track human resources and departmental data. This project provides a robust interface for administrators to handle complex organizational tasks. Built with a focus on **Data Integrity** and **User Experience**, it utilizes **Java Swing** for the UI and **JDBC** for seamless database communication.

## ✨ Key Features
* **Employee Lifecycle Management:** Comprehensive CRUD operations (Add, View, Update, Delete) for employee records.
* **Departmental Oversight:** Create and manage departments, assigning leadership and tracking team distributions.
* **Advanced Search Engine:** Instantly locate staff using multi-filter search options (Name, ID, or Role).
* **Role-Based Security:** Secure login system to ensure only authorized administrators can modify organizational data.
* **Interactive Dashboard:** A clean, cinematic UI providing a bird's-eye view of the organization's status.
---
## 🏗️ System Architecture
This diagram illustrates the multi-tier architecture of the application, showing how the UI interacts with the database.
```mermaid
graph TD
    User((Admin User)) --> UI[Presentation Layer: Java Swing]
    UI --> Controller[Logic Layer: Java Controller]
    Controller --> DAO[Data Access Object: JDBC]
    DAO --> DB[(Database: SQL Server/MySQL)]
    DB --> DAO
    DAO --> Controller
    Controller --> UI
```
## ⚙️ Functional Breakdown
A mindmap showing the core functional modules integrated into the system.
```mermaid
mindmap
  root((Organization System))
    Security
      Login Authentication
      Access Control
      Session Management
    Human Resources
      Onboarding
      Profile Updates
      Record Deletion
      Staff Directory
    Structure
      Department Creation
      Manager Assignment
      Hierarchy View
    Reporting
      Data Filtering
      Search Analytics
```
## 👥 Use Case Diagram
This diagram represents the interaction between the Administrator (Actor) and the system's primary functions.
```mermaid
useCaseDiagram
    actor Admin
    rectangle "Organization Management System" {
        Admin --> (Authenticate Login)
        Admin --> (Manage Employee Records)
        Admin --> (Oversee Departments)
        Admin --> (Query System Data)
        (Manage Employee Records) ..> (Database Sync) : <<include>>
        (Oversee Departments) ..> (Database Sync) : <<include>>
    }
```

## 🛠️ Technical Stack
* **Framework:** ASP.NET Core
* **Database:** SQL Server (Dapper ORM)
* **UI/UX:** Custom Cinematic CSS & Responsive Design
---
### 🖼️ Project Gallery
<details>
  <summary><b>Click to View Cinematic Interface (10 Screenshots)</b></summary>
  <br>
  
#### 1. Landing & Introduction
| Home Page | Hero Section | About Us |
| :---: | :---: | :---: |
| <img src="Screenshots/01%20home.png" width="250"> | <img src="Screenshots/02%20hero%20section.png" width="250"> | <img src="Screenshots/03%20about%20.png" width="250"> |

#### 2. Main Dashboard
<p align="center">
  <img src="Screenshots/04%20dashboard.png" width="600" alt="Dashboard Overview">
</p>

#### 3. Organization Management
| Overview | Create | Edit | Delete |
| :---: | :---: | :---: | :---: |
| <img src="Screenshots/05%20organization%20card.png" width="200"> | <img src="Screenshots/06%20create%20organization.png" width="200"> | <img src="Screenshots/07%20edit%20organization.png" width="200"> | <img src="Screenshots/08%20delete%20organization.png" width="200"> |

#### 4. Department Management
| Overview | Create | Edit | Delete |
| :---: | :---: | :---: | :---: |
| <img src="Screenshots/09%20department%20card.png" width="200"> | <img src="Screenshots/10%20create%20department.png" width="200"> | <img src="Screenshots/11%20edit%20department.png" width="200"> | <img src="Screenshots/12%20delete%20department.png" width="200"> |

#### 5. Position Management
| Overview | Create | Edit | Delete |
| :---: | :---: | :---: | :---: |
| <img src="Screenshots/13%20position%20card.png" width="200"> | <img src="Screenshots/14%20create%20position.png" width="200"> | <img src="Screenshots/15%20edit%20position.png" width="200"> | <img src="Screenshots/16%20delete%20position.png" width="200"> |

#### 6. Employee Management
| Overview | Create | Edit | Delete |
| :---: | :---: | :---: | :---: |
| <img src="Screenshots/17%20employee%20card.png" width="200"> | <img src="Screenshots/18%20create%20employee.png" width="200"> | <img src="Screenshots/19%20edit%20employee.png" width="200"> | <img src="Screenshots/20%20delete%20employee.png" width="200"> |

#### 7. Contact Us
<p align="center">
  <img src="Screenshots/21%20contact%20.png" width="450" alt="Contact Page">
</p>
</details>

---
