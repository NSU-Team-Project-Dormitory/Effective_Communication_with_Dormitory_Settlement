insert into Dormitory (name, address, floor_count, contact_info)
values
	('5', 'Пирогова, 14', 5, 'none'),
	('4', 'Пирогова, 12', 5, 'none'),
	('6', 'Пирогова, 16', 5, 'none'),
	('7', 'Пирогова, 18', 5, 'none'),
	('1A', 'Ляпунова', 9, 'none'),
	('1B', 'Ляпунова', 9, 'none');

insert into Floor (dormitory_id, number, image_path)
values
	(1, 1, 'none'),
	(1, 2, 'none'),
	(1, 3, 'none'),
	(1, 4, 'none'),
	(1, 5, 'none'),
	(2, 1, 'none'),
	(2, 2, 'none'),
	(2, 3, 'none'),
	(2, 4, 'none'),
	(2, 5, 'none'),
	(3, 1, 'none'),
	(3, 2, 'none'),
	(3, 3, 'none'),
	(3, 4, 'none'),
	(3, 5, 'none'),
	(4, 1, 'none'),
	(4, 2, 'none'),
	(4, 3, 'none'),
	(4, 4, 'none'),
	(4, 5, 'none'),
	(5, 1, 'none'),
	(5, 2, 'none'),
	(5, 3, 'none'),
	(5, 4, 'none'),
	(5, 5, 'none'),
	(5, 6, 'none'),
	(5, 7, 'none'),
	(5, 8, 'none'),
	(5, 9, 'none'),
	(6, 1, 'none'),
	(6, 2, 'none'),
	(6, 3, 'none'),
	(6, 4, 'none'),
	(6, 5, 'none'),
	(6, 6, 'none'),
	(6, 7, 'none'),
	(6, 8, 'none'),
	(6, 9, 'none');

insert into Room (floor_id, name, capacity)
values
	(1, '101B', 3),
	(2, '201B', 3),
	(3, '301B', 3),
	(1, '102M', 1),
	(2, '202M', 1),
	(3, '302B', 3),
	(1, '103M', 1),
	(2, '203B', 3),
	(2, '303B', 3),
	(1, '104M', 1),
	(2, '204B', 3),
	(3, '304B', 3),
	(1, '105B', 3);


INSERT INTO Student (student_id, last_name, first_name, patronymic, faculty, study_group, email)
VALUES
  (1, 'Иванов', 'Иван', 'Иванович', 'ФИТ', '22101', 'email'),
  (2, 'Петров', 'Петр', 'Петрович', 'ФИТ', '22203', 'email'),
  (3, 'Сидорова', 'Анна', 'Игоревна', 'ФИТ', '22205', 'email'),
  (4, 'Козлов', 'Дмитрий', 'Александрович', 'ФИТ', '22203', 'email'),
  (5, 'Смирнов', 'Алексей', 'Николаевич', 'ФИТ', '22212', 'email'),
  (6, 'Новикова', 'Мария', 'Дмитриевна', 'ФИТ', '22210', 'email'),
  (7, 'Лебедев', 'Артем', 'Сергеевич', 'ФИТ', '22201', 'email'),
  (8, 'Васнецов', 'Александр', 'Игоревич', 'ФИТ', '20202', 'email'),
  (9, 'Тимофеев', 'Арсений', 'Владимирович', 'ФИТ', '21201', 'email'),
  (10, 'Кузнецов', 'Олег', 'Васильевич', 'ФИТ', '21201', 'email'),
  (11, 'Белова', 'Татьяна', 'Денисовна', 'ФИТ', '21201', 'email'),
  (12, 'Шевченко', 'Екатерина', 'Сергеевна', 'ФИТ', '21201', 'email'),
  (13, 'Морозов', 'Владислав', 'Александрович', 'ФИТ', '21201', 'email'),
  (14, 'Калинина', 'Людмила', 'Павловна', 'ФИТ', '21201', 'email'),
  (15, 'Романов', 'Андрей', 'Андреевич', 'ФИТ', '21201', 'email'),
  (16, 'Королева', 'Ольга', 'Сергеевна', 'ФИТ', '21201', 'email'),
  (17, 'Воронов', 'Игорь', 'Николаевич', 'ФИТ', '21201', 'email');



INSERT INTO Resident (student_id, room_id, contract_number, contract_start_date, contract_expire_date)
VALUES
  (1, 1, '1234', '2023-01-01', '2023-12-31'),
  (2, 2, '5678', '2023-01-15', '2023-12-15'),
  (3, 2, '9876', '2023-02-01', '2023-11-30'),
  (4, 4, '3456', '2023-03-01', '2023-10-31'),
  (5, 5, '7890', '2023-03-15', '2023-10-15'),
  (6, 6, '2345', '2023-04-01', '2023-09-30'),
  (7, 7, '6789', '2023-05-01', '2023-08-31'),
  (8, 9, '4321', '2023-05-15', '2023-08-15'),
  (9, 8, '5678', '2023-06-01', '2023-07-31'),
  (10, 13, '9012', '2023-07-01', '2023-12-01'),
  (11, 1, '1234', '2023-08-15', '2023-12-15'),
  (12, 7, '5678', '2023-09-01', '2023-11-30'),
  (13, 10, '9012', '2023-10-01', '2023-12-31'),
  (14, 11, '1234', '2023-11-15', '2023-12-15'),
  (15, 11, '5678', '2023-12-01', '2023-12-31'),
  (16, 1, '9012', '2024-01-01', '2024-06-01'),
  (17, 11, '1234', '2024-01-15', '2024-06-15');
