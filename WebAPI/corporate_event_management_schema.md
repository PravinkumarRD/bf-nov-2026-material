# Corporate Event Management API — Database Schema & Entity Relationships

This document outlines the database entities, column definitions, and relationships for an internal corporate event management system supporting categories such as Seminars, Tech Trainings, Sports Day, and Annual Day.

---

## 1. Entity Tables

### 1.1 Organization
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the organization |
| `Name` | VARCHAR(150) | Not Null | Company or organization name |
| `Domain` | VARCHAR(100) | Unique | Corporate email domain (e.g., `acme.com`) |
| `LogoUrl` | VARCHAR(255) | Nullable | URL to the organization's branding logo |
| `CreatedAt` | DATETIME | Not Null | Record creation timestamp |

### 1.2 Department
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the department |
| `OrganizationId` | UUID / INT | Foreign Key -> `Organization.Id` | Links department to the parent organization |
| `Name` | VARCHAR(100) | Not Null | Department name (e.g., Engineering, HR, Sales) |
| `Code` | VARCHAR(20) | Nullable | Short department code (e.g., `ENG`, `HR`) |

### 1.3 Employee
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the employee |
| `OrganizationId` | UUID / INT | Foreign Key -> `Organization.Id` | Organization the employee belongs to |
| `DepartmentId` | UUID / INT | Foreign Key -> `Department.Id` | Primary department of the employee |
| `EmployeeCode` | VARCHAR(50) | Unique | Official company staff ID |
| `FullName` | VARCHAR(150) | Not Null | Full name of the employee |
| `Email` | VARCHAR(150) | Unique, Not Null | Corporate email address |
| `Role` | ENUM / VARCHAR | Not Null | `Admin`, `Organizer`, or `Employee` |
| `IsActive` | BOOLEAN | Default: `true` | Indicates if the employee is currently employed |

### 1.4 EventCategory
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the category |
| `OrganizationId` | UUID / INT | Foreign Key -> `Organization.Id` | Organization owning this category |
| `Name` | VARCHAR(100) | Not Null | e.g., Seminar, Tech Training, Sports Day, Annual Day |
| `Description` | TEXT | Nullable | Brief explanation of the category |
| `ColorCode` | VARCHAR(7) | Nullable | Hex code for UI calendar badges (e.g., `#FF5733`) |
| `Icon` | VARCHAR(50) | Nullable | Icon identifier for frontend rendering |

### 1.5 Venue
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the venue |
| `OrganizationId` | UUID / INT | Foreign Key -> `Organization.Id` | Organization owning/managing the venue |
| `Name` | VARCHAR(150) | Not Null | e.g., Main Auditorium, Conference Room B, Zoom |
| `LocationType` | ENUM / VARCHAR | Not Null | `Physical`, `Virtual`, or `Hybrid` |
| `AddressOrLink` | VARCHAR(255) | Not Null | Physical room/address or meeting URL |
| `MaxCapacity` | INT | Nullable | Maximum allowed attendees for safety/space limits |

### 1.6 Event
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the event |
| `OrganizationId` | UUID / INT | Foreign Key -> `Organization.Id` | Parent organization |
| `CategoryId` | UUID / INT | Foreign Key -> `EventCategory.Id` | Classification of the event |
| `VenueId` | UUID / INT | Foreign Key -> `Venue.Id` | Where the event takes place |
| `OrganizerId` | UUID / INT | Foreign Key -> `Employee.Id` | Employee managing the event |
| `Title` | VARCHAR(200) | Not Null | Event headline |
| `Description` | TEXT | Nullable | Detailed agenda, rules, and overview |
| `BannerUrl` | VARCHAR(255) | Nullable | Promotional cover image URL |
| `StartDateTime` | DATETIME | Not Null | Event start date and time |
| `EndDateTime` | DATETIME | Not Null | Event end date and time |
| `RegistrationDeadline` | DATETIME | Nullable | Cutoff timestamp for employee sign-ups |
| `MaxAttendees` | INT | Nullable | Cap on registrations (triggers waitlist if exceeded) |
| `Status` | ENUM / VARCHAR | Not Null | `Draft`, `Published`, `Ongoing`, `Completed`, `Cancelled` |
| `IsMandatory` | BOOLEAN | Default: `false` | Whether attendance is required by company policy |

### 1.7 EventSession
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the sub-session |
| `EventId` | UUID / INT | Foreign Key -> `Event.Id` | Parent event this session belongs to |
| `Title` | VARCHAR(200) | Not Null | Session or agenda item title |
| `Description` | TEXT | Nullable | Details of the talk, activity, or match |
| `SpeakerName` | VARCHAR(150) | Nullable | Host, trainer, or speaker for the session |
| `StartTime` | DATETIME | Not Null | Session start timestamp |
| `EndTime` | DATETIME | Not Null | Session end timestamp |
| `RoomOrTrack` | VARCHAR(100) | Nullable | Specific track, stage, or field name |

### 1.8 EventTeam *(For Sports Day / Group Competitions)*
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the team |
| `EventId` | UUID / INT | Foreign Key -> `Event.Id` | Event the team is competing in |
| `CaptainId` | UUID / INT | Foreign Key -> `Employee.Id` | Employee leading/creating the team |
| `TeamName` | VARCHAR(100) | Not Null | Display name of the team |
| `CreatedAt` | DATETIME | Not Null | Timestamp when the team was formed |

### 1.9 EventRegistration
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the registration |
| `EventId` | UUID / INT | Foreign Key -> `Event.Id` | Event being registered for |
| `EmployeeId` | UUID / INT | Foreign Key -> `Employee.Id` | Employee signing up |
| `TeamId` | UUID / INT | Foreign Key -> `EventTeam.Id` (Nullable) | Links employee to a team if it's a group event |
| `RegisteredAt` | DATETIME | Not Null | Timestamp of registration |
| `Status` | ENUM / VARCHAR | Not Null | `Registered`, `Waitlisted`, `Cancelled`, `Attended`, `NoShow` |
| `CheckInTime` | DATETIME | Nullable | Timestamp when employee checked in at the venue |
| `QrCodeToken` | VARCHAR(255) | Unique | Unique token for QR-based entry scanning |

### 1.10 EventTargetAudience
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `EventId` | UUID / INT | Primary Key, FK -> `Event.Id` | Restricted event |
| `DepartmentId` | UUID / INT | Primary Key, FK -> `Department.Id` | Department eligible to view/join the event |

### 1.11 EventFeedback
| Column Name | Data Type | Constraints / Key | Description |
| :--- | :--- | :--- | :--- |
| `Id` | UUID / INT | Primary Key | Unique identifier for the feedback entry |
| `EventId` | UUID / INT | Foreign Key -> `Event.Id` | Event being reviewed |
| `EmployeeId` | UUID / INT | Foreign Key -> `Employee.Id` | Employee submitting the review |
| `Rating` | INT | Not Null (1–5) | Numeric satisfaction score |
| `Comments` | TEXT | Nullable | Written feedback or suggestions |
| `SubmittedAt` | DATETIME | Not Null | Timestamp of submission |

---

## 2. Summary of Relationships

| Relationship | Type | Description |
| :--- | :--- | :--- |
| **Organization -> Employees / Events** | `1 : N` | An organization owns many employees, departments, venues, and events. |
| **Department -> Employees** | `1 : N` | A department has many employees; an employee belongs to one primary department. |
| **EventCategory -> Events** | `1 : N` | One category (e.g., "Tech Training") classifies many events. |
| **Venue -> Events** | `1 : N` | A venue hosts many events over time (preventing double-booking via date checks). |
| **Employee (Organizer) -> Events** | `1 : N` | An employee can create/manage multiple events. |
| **Event -> EventSessions** | `1 : N` | An event can be broken down into multiple timed agenda items/sessions. |
| **Event -> EventTeams** | `1 : N` | A group/sports event can have multiple competing teams. |
| **Employee <-> Event** | `M : N` | Handled via **EventRegistration**. Many employees register for many events. |
| **Event <-> Department** | `M : N` | Handled via **EventTargetAudience** to restrict events to specific teams. |

---

## 3. Architectural & Implementation Notes

1. **Waitlist Automation:** Pair `Event.MaxAttendees` with `EventRegistration.Status` (`Registered` vs. `Waitlisted`). When a registered employee cancels, trigger an automated promotion for the earliest waitlisted entry.
2. **Venue Conflict Detection:** Before saving or publishing an `Event`, validate that no overlapping `Published` or `Ongoing` events exist for the same `VenueId` between `StartDateTime` and `EndDateTime`.
3. **Check-in & Attendance:** Use `EventRegistration.QrCodeToken` to generate unique passes sent via email/calendar invite, allowing organizers to scan attendees at the door and populate `CheckInTime` and set `Status = Attended`.
4. **Approval Workflow (Optional Extension):** If non-admin employees are permitted to propose events, add `ApprovedById` (FK -> `Employee.Id`) and `ApprovedAt` (DATETIME) to the `Event` table.