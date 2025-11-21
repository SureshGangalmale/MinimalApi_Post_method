CREATE PROCEDURE InsertStudent
    @Name NVARCHAR(100),
    @Age INT
AS
BEGIN
    INSERT INTO students(Name, Age)
    VALUES (@Name, @Age);
END
GO
