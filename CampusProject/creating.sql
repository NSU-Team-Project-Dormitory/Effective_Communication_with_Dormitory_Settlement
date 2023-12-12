DROP TABLE IF EXISTS students, students_accommodation, dormitories, floors, rooms CASCADE;

CREATE TABLE dormitories (
	dorm_id TEXT PRIMARY KEY NOT NULL,
	floor_count INT NOT NULL,
	contact_info TEXT
);

create table floors (
	id serial PRIMARY KEY,
	floor_id INT,
	dorm_id TEXT REFERENCES dormitories(dorm_id),
	picture BYTEA  -- future feature
);


CREATE TABLE rooms (
	id serial primary key,
    room_id text,
    dorm_id TEXT REFERENCES dormitories(dorm_id),
    floor_n INT,
    capacity INT
);

CREATE TABLE students(
	student_id INT PRIMARY KEY NOT NULL,
	last_name TEXT NOT NULL,
	first_name TEXT NOT NULL,
	patronymic TEXT,
	faculty TEXT,
	study_group TEXT	-- TEXT, cause group number may contain addition symbols ('/')
);

CREATE TABLE students_accommodation(
	student_id INT REFERENCES students(student_id), -- связывает с прошлой таблицей по номеру зачётки
	dorm_n text references dormitories(dorm_id),
	room_n text,
	contract_number INT,
	contract_start_date DATE,
	contract_expire_date DATE
);


-- there will also be at least one additional table
-- that will contain specific information about the student
