# Software requirements specification for project Effective

# Communication with Dormitory Settlement

## 1. Authors

- Zhitnik Elizabeth Vladimirovna
- Kozoliy Mikhail Mikhailovich
- Vlasenko Ivan Alexeevich
- Kozorez Nikita Fedorovich

Mentor: Mokin Konstantin Yuryevich

## 2. Introduction

## Importance of the project

At the moment, there is no unified system for communication between departments
responsible for settling students in dormitories, all work has to be done manually. There is
a need to create and implement the necessary system for tracking the residence of
students.

## Main Concept

We are going to solve the task of creating a component for simplifying the work of tracking
the residents in the dormitory. The information is going to be presented in a visual way as a
plan of the floor with rooms and occupied places. The data is going to be automatically
updated when the status of the rooms changes and provide current information on
available places.

## Main scenario

We will consider the main scenario as the staff's work with the program from the moment a
student submits a paper application for a dorm room to the moment the student graduates
from the university.
Submitting an application

The initial step is to submit a paper application to an employee of the dean's office. The
student enters the state: "Student has submitted an application". The staff member can use
the functionality to view available rooms in the dormitories in order to identify those
students who can be assigned to the dormitory. After making a list of students who can be
placed in the dormitory, the employee enters the student's information into the program
with his/her full name, passbook number, group number, room number and then this data
is stored in the database. The student enters the state: "Determined to be assigned to a
dormitory".
Checking into a dormitory


Once a student has been assigned to a dormitory, he/she needs to bring a set of
certificates, until this moment the student is not considered to be checked in. After
collecting all the necessary documents, the student goes to the staff member of the
corresponding dormitory to conclude a contract. The hostel employee concludes the
contract with the student and fills in the details of his/her contract number, the end date and
the start date of the contract. After entering the contract number, the student is considered
to be settled in the dormitory. The student moves to the status: "Checked into the
dormitory".
Updating student data

While a student is living in a dormitory, one of the following events may occur:

1. The students need to be swapped.
2. The student's contract has expired. The student needs to be evicted.
3. The student should be reprimanded after violating the dormitory rules.
4. The student's information needs to be changed.
5. The student is ending his/her residence in the dormitory.
All these events can be handled by the employee using the application functionality. Also,
each event is accompanied by a notification according to the dormitory.
The student completes his or her residence in the dormitory

Due to some reasons the student terminates his/her residence in the dormitory, after the
procedure of checking the room, handing over the keys, the dormitory staff member makes
the fields of the student's room and the student's contract number empty. The student is
considered as not living in the dormitory, but his/her information is saved for possible re-
occupancy. The student goes to the status: "Terminated residence in the dormitory".

Completion of the student's studies at the university

When a student leaves the university, whether it is expulsion or graduation, a member of
the residence hall staff will do the same as when a student is evicted from the dormitory.
The deanery staff member then removes all information about the student. The student
goes to the state: "Has completed his/her studies at the university"

## 3. Glossary

- Dormitory – building for students to live in while studying at the university. Students
    live in groups in rooms, the number of people per room varies.
- Employee – person responsible for check-in, check-out, maintaining the database of
    contracts, control of student accommodation. Обозначим два вида сотрудников
       1. Сотрудник деканата – отвечает за определение студента в общежитие,
          отправки некоторых уведомлений, выселение студента при отчислении.
       2. Сотрудник общежития – отвечает за заключение договора со студентом,
          его заселение/выселение/переселение, отправку уведомлений,
          переселение студента.
- Dormitory accommodation – conclusion of a dormitory accommodation agreement
    with the student, entering it into the database of dormitories.
- Eviction from the dormitory – cancellation of the contract with the student for his/her
    residence in the dormitory.


- Student Contract – a specific document with a specific number, validity period. It is
    necessary to control the student's residence in the hostel, it is concluded when the
    student moves into the hostel.
- Student - a person studying at NSU, from the side of dormitory accommodation has
    several states:
1. A student who has not submitted an application. A student who is studying at the
university but does not need dormitory accommodation.
2. Student has submitted an application. Student in need of dormitory housing, has
completed a paper application. Student's application, along with others, forms a list
of applicants for occupancy.
3. Determined to be assigned to a dormitory. Deanery staff member selected the
number of students according to the number of available rooms. Entered the student
in the database with his/her full name, student record book number, room number (a
place in the room is considered reserved for the student).
4. Checked into the dormitory. The student has collected the necessary certificates for
check-in, the commandant has concluded a contract with the student. Changed
room number if required (room is considered occupied).
5. Terminated residence in the dormitory. Student terminates residence for some
reason. Commandant verified the condition of the room, took away the keys (the
room is considered vacant).
6. Has completed his/her studies at the university. The state continues the state of
termination of residence, only in this case the deanery employee removes the
student from the database.

## 4. Actors

## 4.1 Name: Deanery Employee

Description:
A deanery employee who is responsible for determining the student's placement in the
dormitory, deleting information about the student upon graduation. General control of
students' accommodation in the dormitory.

Main goals:

- Placing a student in a dormitory
- Replacement of students
- Student eviction
- Updating student data
- Writing reprimands/requests
- Removing a student from the database
- Student swapping


## 4. 2 Name: Dormitory Employee

Description:

A dormitory staff member who is responsible for the entire process of a student living in the
dormitory

Main goals:

- Moving a student into a dormitory
- Moving a student from room to room
- Student swapping
- Student eviction
- Updating student data
- Writing reprimands/requests

## 5. Functional requirements

## 5.1. Use-cases for Deanery Employee

5.1.1. Use-case < Search for available rooms>
Search for available places in dormitories

Actors: Deanery Employee, Dormitory Employee.

Goals:

The list of available rooms in the selected dormitory is received

Precondition: Selected dormitory in which to search for available rooms.

Trigger condition: Need to find out how many students from those who have submitted an
application will be able to move in in the future.

Main success scenario:

```
1) An employee pressed the button to see available rooms.
2) A list of available rooms by floor is displayed.
```
5.1.2. Use-case < Determine student to be assigned to a dormitory.>
Filling in information about the student's full name, credit book number, and room number.

Actors: Deanery Employee

Goals:

Creation of a student card with data on his/her full name, his/her credit book number, room
number, group number. A corresponding record is created in the database

Precondition: The staff member has done a search for available rooms and knows the
available rooms.

Trigger condition: A list of students who have the opportunity to move into the dorms is
ready.

Main success scenario:


```
1) The employee clicks the "determine student" button
2) The employee fills in the student's full name
3) The employee fills in the student's credit book number
4) The employee fills in the student's group number
5) Employee fills in the room number
6) The staff member clicks the "Determine" button
7) The student is considered to be determined to be in the dormitory.
```
<Additional section>:

Notes:

A notification is created in the appropriate dormitory section that this student has been
assigned to that dormitory.

5.1.3. Use-case < Change student data>
Any change in student data. Updating the contract, changing the room, reprimanding,
terminating the contract, making a student demand.

Actors: Dormitory Employee, Deanery Employee

Goals:

Required student information has been updated.

Precondition: The student is checked into a dormitory.

Trigger condition: Student data needs to be changed.

Main success scenario:

```
1) Staff member opens selects the appropriate dormitory. Staff member opens student
card by searching student by room.
2) Employee updates the required data.
3) The student's data is changed.
```
5.1.4. Use-case < Switching students>
Replacement of 2 students by rooms.

Actors: Dormitory Employee, Deanery Employee

Goals:

The student rooms have been updated

Precondition: Both students are housed in a dormitory.

Trigger condition: One student coordinated with a staff member to substitute with another
student

Main success scenario:

```
1) The staff member opens the appropriate dormitory.
```

```
2) The staff member opens the student's card by searching for the student's full name
or the staff member opens the card by searching for the room by the student's full
name.
3) The staff member clicks the "Swap with ..." button.
4) The student swap window opens.
5) The staff member enters the Name of the student to swap with.
6) The employee clicks the "Accept" button
7) The students are swapped.
```
Alternative scenario < A student with that name does not exist>

```
1) A message is displayed that no such student exists.
2) The employee enters the correct full name.
```
5.1.5. Use-case < Deleting student information >
Eviction of a student from a dormitory.

Actors: Deanery Employee.

Goals:

Deleting information about a student who has graduated or withdrawn from the university

Precondition: Employee selected student and chosen a student is evicted from
dormitories.

Trigger condition: The employee selected student with search and clicked the "Delete"
button

Main success scenario:

```
1) The staff member wrote the reason for the deleting.
2) The staff member clicked the “Apply” button.
3) The student’s data deleted.
```
5.1.6. Use-case < Processing of notifications by employee>
The software periodically sends notifications to the employee, the employee processes
them and the software makes changes to the database.

Actors: Deanery Employee, Dormitory Employee

Goals:

Employee saw and processed the notification

Precondition: One of the events took place:

- A student has been assigned a room.
- There are 14 days left until the end of the student's contract.
- The student's contract has expired.
- A room has been vacated.
- Student is checked in/out


Trigger condition: The employee clicked on the notification of their choice

Main success scenario:

```
1) The employee saw the full text of the notice.
2) After completing the required actions, the employee noted that the notification had
been processed.
```
## 5.2. Use-cases for Dormitory Employee

5.2.1. Use-case < Search for available rooms>
Search for available places in dormitories

Actors: Deanery Employee, Dormitory Employee.

Goals:

The list of available rooms in the selected dormitory is received

Precondition: Selected dormitory in which to search for available rooms.

Trigger condition: Need to find out how many students from those who have submitted an
application will be able to move in in the future.

Main success scenario:

```
1) An employee pressed the button to see available rooms.
2) A list of available rooms by floor is displayed.
```
5.2.2. Use-case < Checking a student into a dormitory >
Checking the student into the dormitory after he/she has collected all the required
documents.

Actors: Dormitory Employee

Goals:

Student information has been updated. The contract has been signed, the contract data
has been entered, the student is considered to be settled. Information in the database has
been updated

Precondition: The student is determined to be in a dormitory.

Trigger condition: The student has brought all the documents necessary to draw up the
contract. The contract with the student is signed and the keys are given out.

Main success scenario:

```
1) Employee opens selects the appropriate dormitory. The employee opens the
student's information by searching for the student by room.
2) The staff member enters the student's contract number, contract start and end date,
and changes the room number if necessary.
3) The student is considered enrolled in the dormitory.
```
<Additional section>:


Notes:

A notification is created in the appropriate section of the dormitory that this student has
checked into that dormitory.

5.2.3. Use-case < Change student data>
Any change in student data. Updating the contract, changing the room, reprimanding,
terminating the contract, making a student demand.

Actors: Dormitory Employee, Deanery Employee

Goals:

Required student information has been updated.

Precondition: The student is checked into a dormitory.

Trigger condition: Student data needs to be changed.

Main success scenario:

```
1) Staff member opens selects the appropriate dormitory. Staff member opens student
card by searching student by room.
2) Employee updates the required data.
3) The student's data is changed.
```
5.2.4. Use-case < Switch students>
Student swapping.

Actors: Dormitory Employee, Deanery Employee

Goals:

The student rooms have been updated

Precondition: Both students are housed in a dormitory.

Trigger condition: One student coordinated with a staff member to substitute with another
student

Main success scenario:

```
1) The staff member opens the appropriate dormitory.
2) The staff member opens the student's card by searching for the student's full name
or the staff member opens the card by searching for the room by the student's full
name.
3) The staff member clicks the "Swap with ..." button.
4) The student swap window opens.
5) The staff member enters the Name of the student to swap with.
6) The employee clicks the "Accept" button
```

```
7) The students are swapped.
```
5.2.5. Use-case < Eviction from the dormitory >
Eviction of a student from a dormitory.

Actors: Dormitory Employee.

Goals:

The employee wrote the reason for the selected student's eviction. The student is
considered to be evicted

Precondition: Employee selected a dormitory and chosen a student is currently living in
selected dormitory.

Trigger condition: The employee selected student with search and clicked the "Evict"
button

Main success scenario:

```
1) The staff member wrote the reason for the eviction.
2) The staff member clicked the “Evict” button.
3) The student is considered to be evicted
```
## 6. Non-functional requirements

## 6.1. Environment

Desktop application on Windows operating system with a resolution of 1920 by 1080.

## 6.2. Performance

- Sending notifications to the system immediately after one of the employees has
    performed an action leading to sending, so that all employees see the notification.
- Correct updating of contract terms.
- Providing results when an employee searches within 1 second or less


