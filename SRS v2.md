# Software requirements specification for project Effective Communication with Dormitory Settlement
1. ## Authors
- Zhitnik Elizabeth Vladimirovna
- Kozoliy Mikhail Mikhailovich
- Vlasenko Ivan Alexievich
- Kozorez Nikita Fedorovich

Mentor: Mokin Konstantin Yuryevich
1. ## Introduction
### Importance of the project
At the moment, there is no unified system for communication between departments responsible for settling students in dormitories, all work has to be done manually. There is a need to create and implement the necessary system for tracking the residence of students.
### Main Concept
We are going to solve the task of creating a component for simplifying the work of tracking the residents in the dormitory. The information is going to be presented in a visual way as a plan of the floor with rooms and occupied places. The data is going to be automatically updated when the status of the rooms changes and provide current information on available places.
### Основной сценарий
Основным сценарией будем считать работу сотрудника с программой с момента подачи студентом заявления на комнату в общежитие до момента окончания обучения студента в университете.
#### *Подача заявления*
Начальным этапом является подача заявления. Сотрудник с помощью функционала может посмотреть свободные комнаты в общежитиях. После составления списка студентов, которые могут быть заселены общежитии, сотрудник создает карту студента с его ФИО, номером зачетной книжки, номером группы, номером комнаты после чего эти данные сохраняются в базе данных. 
#### *Заселение в общежитие*
После определения в общежитие студенту необходимо принести набор справок, до этого момента студент не считается заселенным. После сбора всех необходимых документов студент обращается к сотруднику соответствующего общежития для заключения договора. Сотрудник заключает договор со студентом заполняет в карточке студента номер его договора, дату окончания и начала договора. После внесения номера договора, студент считается заселенным в общежитие.
#### *Обновление данных студента*
Во время обучения студента в университете может произойти одно из событий:

1. Студентов необходимо поменять местами.
1. У студента закончился договор. Студента необходимо выселить.
1. Необходимо вынести студенту выговор после нарушения правил проживания в общежитии.
1. Необходимо изменить данные карточки студента.
1. Студент заканчивает свое проживание в общежитии.

Все эти события могут быть обработаны сотрудником с использованием функционала приложения. Также каждое событие сопровождается уведомлением в соответствии с общежитием. 
#### *Окончание обучения студента в общежитии*
После окончания обучения студента в общежитии будь то отчисление или окончание обучения, сотрудник общежития удаляет карточку студента с его данными.
##
1. ## Glossary
- **Dormitory** – building for students to live in while studying at the university. Students live in groups in rooms, the number of people per room varies.
- **Employee** – person responsible for check-in, check-out, maintaining the database of contracts, control of student accommodation.
- **Dormitory accommodation** – conclusion of a dormitory accommodation agreement with the student, entering it into the database of dormitories.
- **Eviction from the dormitory** – cancellation of the contract with the student for his/her residence in the dormitory.
- **Student Contract** – a specific document with a specific number, validity period. It is necessary to control the student's residence in the hostel, it is concluded when the student moves into the hostel.

1. ## Actors
### 4\.1 Name: Employee
#### *Description:*
The main user of the software who can use all functions of the system. 
#### *Main goals:*
- Определение студента в общежитие
- Заселение студента в общежитие
- Переселение студента из комнаты в комнату
- Замена студентов местами
- Выселение студентов
- Обновление данных студента 
- Написание выговоров/требований
- Удаление студента из базы данных
1. ## Functional requirements
   1. ### Use-cases for Employee
      1. #### *Use-case <Поиск свободных комнат>* 
*Поиск свободных мест в общежитиях*

**Actors:** *Employee*

**Goals:*** 

Получен список свободных комнат в выбранном общежитии

**Precondition:** *Необходимо узнать сколько студентов из тех, кто подал заявление смогут в будущем заселиться.* 

**Trigger condition:** *Выбрано общежитие в которым необходимо провести поиск.*

**Main success scenario:** 

1) Сотрудник нажал кнопку посмотреть свободные комнаты.
1) Выведен список свободных комнат по этажам.
   1. #### *Use-case <Определить студента в общежитие >* 
*Заполнение информации о ФИО студента, номере его зачетной книжки, номера комнаты.*

**Actors:** *Employee*

**Goals:*** 

Создании карточки студента с данными о его ФИО, номере его зачетной книжки, номера комнаты, номер группы. В базе данных создана соответствующая запись

**Precondition:** *Сотрудник выполнил поиск свободных комнат и знает свободные комнаты.* 

**Trigger condition:** *Готов список студентов, которые имеют возможность заселиться в общежитие.*

**Main success scenario:** 

1) Сотрудник нажимает кнопку “определить студента”
1) Сотрудник заполняет ФИО студента
1) Сотрудник заполняет номер зачетной книжки студента
1) Сотрудник заполняет номер группы студента 
1) Сотрудник заполняет номер комнаты
1) Сотрудник нажимает кнопку “Определить”

**<Additional section>:**

**Notes:** 

*В разделе соответствующего общежития создается уведомление о том, что этот студент определен в это общежитие.*

1. #### *Use-case < Заселить студента в общежитие >* 
*Заселение студента в общежитие после того, как он собрал все необходимые документы.* 

**Actors:** *Employee*

**Goals:*** 

Обновлена информация о студенте. Заключен договор, данные договора внесены, студент считается заселенным. Обновлена информация в базе данных

**Precondition:** Студент определен в общежитие.

**Trigger condition:** *Студент принес все необходимые для составления договора документы. Подписан договор со студентом.* 

**Main success scenario:** 

1) Сотрудник открывает выбирает соответствующее общежитие. Сотрудник открывает карточку студента с помощью поиска студента по комнате.
1) Сотрудник вносит данные о номере договора студента, дате начала и окончания договора, если необходимо меняет номер комнаты.
1) Студент считается зачисленным в общежитие.
   1. #### *Use-case <Изменить данные студента>* 
*Любое изменение данных студента. Обновление договора, изменение комнаты, выговор, расторжение договора, внесение требования студента.*

**Actors:** *Employee*

**Goals:*** 

Обновлена информация о студента, заключен договор, данные договора внесены, студент считается заселенным.

**Precondition:** Студент определен в общежитие.

**Trigger condition:** *Студент принес все необходимые для составления договора документы. Подписан договор со студентом.* 

**Main success scenario:** 

1) Сотрудник открывает выбирает соответствующее общежитие. Сотрудник открывает карточку студента с помощью поиска студента по комнате.
1) Сотрудник обновляет необходимые данные.
1) Данные студента изменены.
   1. #### *Use-case <Поменять студентов местами>* 
*Замена студентов местами.*

**Actors:** *Employee*

**Goals:*** 

Комнаты студентов обновлены

**Precondition:** Оба студента заселены в общежитие.

**Trigger condition:** *Один из студентов согласовал с сотрудником замену с другим студентом*

**Main success scenario:** 

1) Сотрудник открывает соответствующее общежитие.
1) Сотрудник открывает карточку студента с помощью поиска по ФИО или сотрудник открывает карточку с помощью поиска комнаты по ФИО студента.
1) Сотрудник нажимает кнопку «Поменять с …».
1) Открылось окно замены студентов.
1) Сотрудник вводит ФИО студента, с которым необходимо выполнить замену. 
1) Сотрудник нажимает кнопку «Принять»
1) Студенты поменяны местами.

**Alternative scenario** <Студента с таким ФИО не существует>

1) Выведено сообщение, что такого студента не существует.
1) Сотрудник вводит верное ФИО.

1. #### *Use-case < Eviction from the dormitory >* 
Eviction of a student from a dormitory. Deletion of his/her personal data from the database

**Actors:** Employee.

**Goals:** 

The employee wrote the reason for the selected student's eviction. Information deleted from database.

**Precondition:** Employee selected a dormitory and chosen a student is currently living in selected dormitory.

**Trigger condition:** The employee selected student with search and clicked the "Evict" button

**Main success scenario:**

1) The staff member wrote the reason for the eviction.
1) The staff member clicked the “Evict” button.
1) Software deleted information from the database about the evicted student
   1. #### *Use-case < Processing of notifications by employee>* 
The software periodically sends notifications to the employee, the employee processes them and the software makes changes to the database.

**Actors:** Employee

**Goals:** 

Employee saw and processed the notification

**Precondition:** One of the events took place:

- Студенту определена комната.
- До окончания договора студента осталось 14 дней.
- Договор студента истек.
- Освободилось место.
- Студент заселен/выселен

**Trigger condition:** The employee clicked on the notification of their choice

**Main success scenario:**

1) The employee saw the full text of the notice.
1) After completing the required actions, the employee noted that the notification had been processed.
1. ## Non-functional requirements
   1. ### Environment
Десктоп приложение на операционной системе Windows с разрешением 1920 на 1080.
1. ### Performance
- Отправка уведомлений в систему сразу после того, как один из сотрудников совершил действие приводящие к отправке, чтобы все сотрудники видели уведомление.
- Correct updating of contract terms.
- Providing results when an employee searches within 1 second or less

