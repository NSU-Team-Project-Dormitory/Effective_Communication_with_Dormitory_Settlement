DROP TABLE IF EXISTS students, students_accommodation, dormitories, floors, rooms CASCADE;

CREATE TABLE dormitories (
	dorm_id TEXT PRIMARY KEY NOT NULL,
	floor_count INT NOT NULL,
	contact_info TEXT
);

create table floors (
	floor_id INT PRIMARY KEY,
	dorm_id TEXT REFERENCES dormitories(dorm_id),
	picture BYTEA  -- future feature
);

CREATE TABLE rooms (
    room_id text PRIMARY KEY,
    dorm_id TEXT REFERENCES dormitories(dorm_id),
    floor_n INT REFERENCES floors(floor_id),
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
	room_n text references rooms(room_id),
	contract_number INT,
	contract_start_date DATE,
	contract_expire_date DATE
);


-- there will also be at least one additional table
-- that will contain specific information about the student

insert into dormitories (dorm_id, floor_count)
values
	('5', 5);

insert into floors (floor_id, dorm_id)
values
	(1, '5'),
	(2, '5'),
	(3, '5'),
	(4, '5'),
	(5, '5');

insert into rooms (room_id, dorm_id, floor_n, capacity)
values
	('101B', '5', 1, 3),
	('201B', '5', 2, 3),
	('301B', '5', 3, 3),
	('102M', '5', 1, 1),
	('202M', '5', 2, 1),
	('302B', '5', 3, 3),
	('103M', '5', 1, 1),
	('203B', '5', 2, 3),
	('303B', '5', 3, 3),
	('104M', '5', 1, 1),
	('204B', '5', 2, 3),
	('304B', '5', 3, 3),
	('105B', '5', 1, 3),
	('205B', '5', 2, 3),
	('305B', '5', 3, 3),
	('106M', '5', 1, 1),
	('206M', '5', 2, 1),
	('306B', '5', 3, 3),
	('107B', '5', 1, 3),
	('207B', '5', 2, 3);


INSERT INTO students (student_id, last_name, first_name, patronymic, faculty, study_group)
VALUES
  (1, 'Иванов', 'Иван', 'Иванович', 'ФИТ', 22101),
  (2, 'Петров', 'Петр', 'Петрович', 'ФИТ', 22201),
  (3, 'Сидорова', 'Анна', 'Игоревна', 'ФИТ', 22301),
  (4, 'Козлов', 'Дмитрий', 'Александрович', 'ФИТ', 22401),
  (5, 'Смирнов', 'Алексей', 'Николаевич', 'ФИТ', 22501),
  (6, 'Новикова', 'Мария', 'Дмитриевна', 'ФИТ', 22601),
  (7, 'Лебедев', 'Артем', 'Сергеевич', 'ФИТ', 22701),
  (8, 'Васнецов', 'Александр', 'Игоревич', 'ФИТ', 2801),
  (9, 'Тимофеев', 'Арсений', 'Владимирович', 'ФИТ', 2901),
  (10, 'Кузнецов', 'Олег', 'Васильевич', 'ФИТ', 21001),
  (11, 'Белова', 'Татьяна', 'Денисовна', 'ФИТ', 21101),
  (12, 'Шевченко', 'Екатерина', 'Сергеевна', 'ФИТ', 21201),
  (13, 'Морозов', 'Владислав', 'Александрович', 'ФИТ', 21301),
  (14, 'Калинина', 'Людмила', 'Павловна', 'ФИТ', 21401),
  (15, 'Романов', 'Андрей', 'Андреевич', 'ФИТ', 21501),
  (16, 'Королева', 'Ольга', 'Сергеевна', 'ФИТ', 21601),
  (17, 'Воронов', 'Игорь', 'Николаевич', 'ФИТ', 21701),
  (18, 'Поляков', 'Станислав', 'Викторович', 'ФИТ', 21801),
  (19, 'Кудряшова', 'Виктория', 'Анатольевна', 'ФИТ', 21901),
  (20, 'Соловьев', 'Артур', 'Александрович', 'ФИТ', 22001);


INSERT INTO students_accommodation (student_id, dorm_n, room_n, contract_number, contract_start_date, contract_expire_date)
VALUES
  (1, '5', '101B', 1234, '2023-01-01', '2023-12-31'),
  (2, '5', '201B', 5678, '2023-01-15', '2023-12-15'),
  (3, '5', '201B', 9876, '2023-02-01', '2023-11-30'),
  (4, '5', '102M', 3456, '2023-03-01', '2023-10-31'),
  (5, '5', '202M', 7890, '2023-03-15', '2023-10-15'),
  (6, '5', '302B', 2345, '2023-04-01', '2023-09-30'),
  (7, '5', '302B', 6789, '2023-05-01', '2023-08-31'),
  (8, '5', '203B', 4321, '2023-05-15', '2023-08-15'),
  (9, '5', '203B', 5678, '2023-06-01', '2023-07-31'),
  (10, '5', '105B', 9012, '2023-07-01', '2023-12-01'),
  (11, '5', '101B', 1234, '2023-08-15', '2023-12-15'),
  (12, '5', '203B', 5678, '2023-09-01', '2023-11-30'),
  (13, '5', '105B', 9012, '2023-10-01', '2023-12-31'),
  (14, '5', '205B', 1234, '2023-11-15', '2023-12-15'),
  (15, '5', '305B', 5678, '2023-12-01', '2023-12-31'),
  (16, '5', '101B', 9012, '2024-01-01', '2024-06-01'),
  (17, '5', '107B', 1234, '2024-01-15', '2024-06-15'),
  (18, '5', '306B', 5678, '2024-02-01', '2024-05-31'),
  (19, '5', '107B', 9012, '2024-03-01', '2024-05-31'),
  (20, '5', '201B', 1234, '2024-04-15', '2024-05-15');

