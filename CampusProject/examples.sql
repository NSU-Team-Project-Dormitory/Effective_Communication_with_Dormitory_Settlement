select 
	student_id as "Номер", 
	last_name as "Фамилия",
	first_name as "Имя",
	patronymic as "Отчество",
	faculty as "Факультет",
	study_group "Группа"
from students;

select 
	student_id as "Номер студента",
	dorm_n as "Общежитие",
	room_n as "Комната",
	contract_number as "Номер договора",
	contract_start_date as "Начало",
	contract_expire_date as "Окончание"
from students_accommodation;

select * from students_accommodation;

SELECT * FROM rooms WHERE dorm_id = '5' AND floor_n = 1;

select floor_count from dormitories where dorm_id = '5'

select dorm_id from dormitories order by dorm_id 

select floor_id from floors where dorm_id = '5'

select room_id, capacity from rooms where dorm_id = '5' and floor_n = 1 