CREATE TABLE PC (
	id INTEGER NOT NULL IDENTITY (0, 1) PRIMARY KEY,
	cpu	INTEGER NOT NULL,
	memory	INTEGER NOT NULL,
	hdd	INTEGER NOT NULL,
);

INSERT INTO PC (cpu, memory, hdd)
VALUES 
	(1600, 2000, 500),
	(2400, 3000, 800),
	(3200, 3000, 1200),
	(2400, 2000, 500);

--1.1

SELECT id, cpu, memory FROM PC
WHERE memory = 3000;

--1.2

SELECT MIN(hdd) AS hdd FROM PC;

--1.3

SELECT COUNT(id) id_count, hdd FROM PC 
WHERE hdd = (SELECT MIN(hdd) FROM PC)
GROUP BY hdd;

--2

CREATE TABLE track_downloads (
	id_download	INTEGER NOT NULL IDENTITY(0, 1) PRIMARY KEY,
	id_track INTEGER NOT NULL,
	id_user	INTEGER NOT NULL,
	download_time DATETIME NOT NULL,
);

INSERT INTO track_downloads (id_track, id_user, download_time)
VALUES 
	(1, 1, '2010-10-19'),
	(2, 1, '2010-11-19'),
	(3, 2, '2010-01-20'),
	(4, 2, '2010-10-19'),
	(5, 3, '2010-11-12'),
	(6, 3, '2010-01-19'),
	(7, 1, '2010-11-19');

SELECT download_count, COUNT(*) AS user_count FROM ( 
    SELECT COUNT(*) AS download_count FROM track_downloads WHERE download_time = '2010-11-19' 
	GROUP BY id_user) AS download_count
GROUP BY download_count; 

--3.
/*
DATETIME x����� ����� � ���� ������ ����� ���� YYYYMMDDHHMMSS, ��������� ��� ����� 8 ������. ��� ����� �� ������� �� ��������� ����. 
��� ������ ������������ ��� ������� ����� ��� ��, ��� ���� ���������, ���������� �� ���� ����� ������� ����.
TIMESTAMP x����� 4-������� ����� �����, ������ ���������� ������, ��������� � �������� 1 ������ 1970 ���� 
�� ����������� ������� ��������. ��� ��������� �� ���� ������������ � ������ �������� �����.
� SQLite ��� ���� ������ ��� �������� ���� ��� �������. �������������� ������� ���� � ����� ���� � ��������� ����, ���� � ���� �����. 
� SQLite ������� datetime() ���������� ������ � ������� "YYYY-MM-DD HH:MM:SS".*/

--4. 

CREATE TABLE student (
	id_student	INTEGER NOT NULL IDENTITY (0,1) PRIMARY KEY,
	name TEXT NOT NULL,
)

INSERT INTO student (name)
VALUES
	('���� XVI'),
	('��������� �������������'),
	('���� ����'),
	('�������� �����'),
	('������� ���'),
	('��� �����'),
	('�������� �������');

CREATE TABLE course (
	id_course INTEGER NOT NULL IDENTITY (0,1) PRIMARY KEY,
	name TEXT NOT NULL,
)


INSERT INTO course (name)
VALUES
	('���������� �������'),
	('���������� ������� ����������'),
	('����� ����������'),
	('�������� � ������ � ���');

CREATE TABLE student_on_course (
	id_student_on_course INTEGER NOT NULL IDENTITY (0,1) PRIMARY KEY,
	id_student INTEGER,
	id_course INTEGER,
	FOREIGN KEY (id_student) REFERENCES student(id_student),
	FOREIGN KEY (id_course) REFERENCES course(id_course),
)


INSERT INTO student_on_course (id_student, id_course)
VALUES
	(0, 0),
	(0, 2),
	(1, 0),
	(1, 2),
	(2, 2),
	(3, 0),
	(3, 1),
	(4, 0),
	(4, 2),
	(4, 3),
	(5, 0),
	(5, 3),
	(6, 0);

--4.1

SELECT COUNT(amount) AS course_amount
FROM (
	SELECT COUNT(*) as amount
	FROM student_on_course 
	GROUP BY id_course
	HAVING COUNT(*) > 5) AS amount;

--4.2

SELECT  student.id_student,  student.name , GROUP_CONCAT(course.name) FROM student_on_course
	INNER JOIN student ON student.id_student = student_on_course.id_student
	INNER JOIN course ON student_on_course.id_course = course.id_course
	WHERE student.name = '������� ���'
GROUP BY student.id_student;