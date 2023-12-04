
-- вывести все комнаты в формате (номер, количество проживающих в ней, список id проживающих в ней студентов, вместимость комнаты)
select 
	room_id, 
	count(student_id) as count_of_residers, 
	string_agg(cast(student_id as varchar), ',') as student_ids,
	capacity
from 
	rooms_in_5_dormitory
left join 
	students_accommodation 
on 
	rooms_in_5_dormitory.room_id = students_accommodation.room_number
group by 
	room_id
order by 
	count_of_residers desc;




-- Вывести список комнат в пятом общежитии, в которых есть хотя бы одно свободное место, а также количество занятых в этой комнате мест.
select 
	room_id,
	count(students_accommodation.student_id)
from 
	rooms_in_5_dormitory
left join 
	students_accommodation 
on 
	rooms_in_5_dormitory.room_id = students_accommodation.room_number
group by 
	room_id
having
	count(students_accommodation.student_id) < rooms_in_5_dormitory.capacity
order by 
	count(students_accommodation.student_id) desc;