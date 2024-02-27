drop table if exists Dormitory,
Floor,
Room,
Student,
Resident,
Notification
cascade;

create table Dormitory (
	dormitory_id SERIAL primary key,
	name VARCHAR(100),
	address VARCHAR(255),
	floor_count INT not null,
	contact_info VARCHAR(255)
);

create table Floor (
	floor_id SERIAL primary key,
	dormitory_id INT references Dormitory(dormitory_id),
	number INT,
	image_path VARCHAR(255) -- future feature
);

create table Room (
	room_id SERIAL primary key,
    floor_id INT references Floor(floor_id),
    name VARCHAR(100),
    capacity INT
);

create table Student (
	student_id INT primary key not null,
	last_name VARCHAR(100) not null,
	first_name VARCHAR(100) not null,
	patronymic VARCHAR(100),
	faculty VARCHAR(100),
	study_group VARCHAR(100),
	email VARCHAR(100)
);

create table Resident (
	note_id SERIAL primary key,
	student_id INT references Student(student_id),
	room_id INT references Room(room_id),
	contract_number VARCHAR(50),
	contract_start_date DATE,
	contract_expire_date DATE
);
-- there will also be at least one additional table
-- that will contain specific information about the student

CREATE TABLE Notification (
    notification_id SERIAL PRIMARY KEY,
    message TEXT,
    time VARCHAR(20) DEFAULT TO_CHAR(CURRENT_TIMESTAMP, 'DD-MM-YYYY HH24:MI:SS')
);

