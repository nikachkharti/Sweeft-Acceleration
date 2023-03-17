--6.გვაქვს Teacher ცხრილი, რომელსაც აქვს შემდეგი მახასიათებლები: სახელი, გვარი, სქესი, საგანი. გვაქვს Pupil ცხრილი, რომელსაც აქვს შემდეგი მახასიათებლები:
--სახელი, გვარი, სქესი, კლასი. ააგეთ ნებისმიერ რელაციურ ბაზაში ისეთი დამოკიდებულება, რომელიც საშუალებას მოგვცემს,
--რომ მასწავლებელმა ასწავლოს რამოდენიმე მოსწავლეს და ამავდროულად მოსწავლეს ჰყავდეს რამდენიმე მასწავლებელი (როგორც რეალურ ცხოვრებაში).


--1. დაწერეთ sql რომელიც ააგებს შესაბამის table-ებს.
CREATE DATABASE School
GO

USE School
GO

CREATE TABLE Teacher(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(40) NOT NULL,
	Gender CHAR(1) CONSTRAINT CorrectTeacherGender CHECK(Gender = 'M' OR Gender = 'F' OR Gender = 'O') NOT NULL,
	[Subject] NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Pupil(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(40) NOT NULL,
	Gender CHAR(1) CONSTRAINT CorrectPupilGender CHECK(Gender = 'M' OR Gender = 'F' OR Gender = 'O') NOT NULL,
	Class NVARCHAR(40) NOT NULL
)
GO

CREATE TABLE TeacherPupil
(
	TeacherId INT FOREIGN KEY REFERENCES Teacher(Id),
	PupilId INT FOREIGN KEY REFERENCES Pupil(Id),
)
GO

--2.დაწერეთ sql რომელიც დააბრუნებს ყველა მასწავლებელს, რომელიც ასწავლის მოსწავლეს, რომელის სახელია: „გიორგი“.
SELECT DISTINCT t.*
FROM Teacher t
INNER JOIN TeacherPupil tp ON t.Id = tp.TeacherID
INNER JOIN Pupil p ON tp.PupilID = p.Id
WHERE p.FirstName LIKE N'%გიორგი%'