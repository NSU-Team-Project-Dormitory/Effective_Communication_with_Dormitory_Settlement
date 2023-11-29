DROP TABLE IF EXISTS students, campus, dormitory5 CASCADE;
CREATE TABLE students(
	id int,
	last_name text,
	first_name text,
	patronimic text,
	faculty text,
	study_group text
	);

CREATE TABLE students_acamodation(
	id int,
	domitory_number text,
	room_number text,
	contract_number int,
	contract_start_date date,
	contract_expire_date date
);





--INSERT INTO students(id, last_name, first_name, patronimic, dormitory_number, room, contract_number, contract_expire_date, faculty, study_group)
--VALUES (1,'Truneva', 'Alina', 'Dmitrievna', '5', '110S',0029011, 31.08.2024, 'FIT', 23216),
--	   (2,'Ivanova', 'Elena', 'Petrovna', '5', '110B', 0029012, 30.08.2025, 'FIT', 23217),
--       (3, 'Petrov', 'Sergei', 'Alexandrovich', '5', '110B', 0029013, 29.08.2023, 'FIT', 23218);

	   
CREATE TABLE campus(domitory_number text);

--INSERT INTO campus(domitory_number)
--VALUES('1A'), ('1B'), ('4'), ('5'), ('6'), ('7'), ('8/1'), ('8/2'), ('9'), ('10');


CREATE TABLE dormitory5 (
	floor int,
	room_number text,
	capacity int,
	id1 int,
	id2 int,
	id3 int,
	id4 int,
	id5 int
);
--INSERT INTO dormitory5(floor, room_number, capacity, id1, id2, id3, id4))
--VALUES(1, '110B', 3, 2, 3), ('110S', 1, 1), ('111B', 3), ('111S',1), ('112S',1), ('112B',3);