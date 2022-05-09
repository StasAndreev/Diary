CREATE TABLE "User" (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	"login" char(20) NOT NULL,
	"password" char(20) NOT NULL
);

CREATE TABLE TaskType (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	userId int NOT NULL,
	"name" nchar(50) NOT NULL,
	color char(8) NOT NULL

	CONSTRAINT FK_TaskType_User FOREIGN KEY (userId)
	REFERENCES dbo."User" (id)
);


CREATE TABLE RepeatRate (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name nchar(50) NOT NULL
);

CREATE TABLE Task (
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	userId int NOT NULL,
	"name" nchar(50) NOT NULL,
	startTime datetime NOT NULL,
	endTime datetime NOT NULL,
	note nchar(250) NOT NULL,
	typeId int,
	repeatRateId int NOT NULL,
	isDone bit NOT NULL

	CONSTRAINT FK_Task_UserId FOREIGN KEY (userId)
	REFERENCES dbo."User" (id),

	CONSTRAINT FK_Task_TypeId FOREIGN KEY (typeId)
	REFERENCES dbo.TaskType (id),

	CONSTRAINT FK_Task_RepeatRateId FOREIGN KEY (repeatRateId)
	REFERENCES dbo.RepeatRate (id)
);