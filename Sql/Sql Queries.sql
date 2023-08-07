
------------------------------------------------             Tables  ------------------------------------------------------------------
Create table AstitvaStudents508(
	StudentId int identity(1,1) Primary Key,
	StudentName Varchar(50) Not Null
)



Create table AstitvaSubjects508(
	Id int identity(1,1) Primary key,
	StudentId int Not Null,
	SubjectName Varchar(50) Not Null,
	Marks int Not Null,
	FOREIGN KEY (StudentId) REFERENCES AstitvaStudents508(StudentId)
)



-------------------------------------------------------------------------- Inserting --------------------------------------------------

INSERT INTO AstitvaStudents508(StudentName) VALUES ('Astitva');


INSERT INTO AstitvaSubjects508 (StudentId, SubjectName, Marks)
VALUES (1, 'Mathematics', 95);

INSERT INTO AstitvaSubjects508 (StudentId, SubjectName, Marks)
VALUES (1, 'Science', 88);

select * from AstitvaStudents508
Select * from AstitvaSubjects508



