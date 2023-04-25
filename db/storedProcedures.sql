/*
sp_CONFIGURE 'show advanced', 1
GO
RECONFIGURE
GO
sp_CONFIGURE 'Database Mail XPs', 1
GO
RECONFIGURE
GO
*/


--v pripade smazani db vlozit tento zaznam
/*
INSERT INTO Info (before_closing_date_days, borrowing_duration_days, queues_per_user,
	reservation_duration_days, reservation_penalty_days)
VALUES (3, 30, 5, 7, 30);
*/

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Mock_email (
	email_addr VARCHAR(255),
	subject VARCHAR(255),
	body VARCHAR(MAX)
);
GO

CREATE OR ALTER PROCEDURE sendEmail
(@email_addr VARCHAR(255), @subject VARCHAR(255), @body VARCHAR(MAX))
AS
BEGIN
	INSERT INTO Mock_email (email_addr, subject, body)
	VALUES (@email_addr, @subject, @body)
END
GO


--Pomocná funkce 2
CREATE OR ALTER PROCEDURE sendAddedToQueueEmail
(@book_copy_id INTEGER, @email_addr VARCHAR(255), @end_date DATE)
AS
BEGIN
	DECLARE @info VARCHAR(MAX);
	SET @info = dbo.bookCopyInfo(@book_copy_id);
	DECLARE @subject VARCHAR(255), @body VARCHAR(MAX)
	SET @subject = 'Aktivovala se Vám jedna z Vašich rezervací';
	SET @body = 'Zapoèala rezervace knihy ' + @info + ' a skonèí ' +
		CONVERT(VARCHAR, @end_date, 104) + '.';
	
	exec sendEmail @email_addr, @subject, @body;
END
GO

--2.5
/*efektivnejsi by bylo poslat zde vsechny hodnoty (title, ...), a volat tuto
funkci primo v selectu*/
CREATE OR ALTER FUNCTION bookCopyInfo
( @book_copy_id INTEGER )
RETURNS VARCHAR(MAX)
BEGIN
	DECLARE @info VARCHAR(MAX);
	SELECT @info = Book.title + ' (' + CAST(Book_copy.release_year AS VARCHAR) + 
		', ' + Language.name + ') od ' + Author.first_name + ' ' + Author.last_name
	FROM Book
	JOIN Author ON Book.author_id = Author.author_id
	JOIN Book_copy ON Book_copy.book_id = Book.book_id
	JOIN Language ON Language.language_id = Book_copy.language_id
	WHERE Book_copy.book_copy_id = @book_copy_id

	RETURN @info;
END
GO

CREATE OR ALTER FUNCTION bookCopyInfoV2
( @title VARCHAR(100), @release_year INT, @language_name VARCHAR(60),
	@author_first_name VARCHAR(60), @author_last_name VARCHAR(60))
RETURNS VARCHAR(MAX)
BEGIN
	DECLARE @info VARCHAR(MAX);
	SELECT @info = @title + ' (' + CAST(@release_year AS VARCHAR) + 
		', ' + @language_name + ') od ' + @author_first_name + ' ' + @author_last_name;

	RETURN @info;
END
GO


-- 8.1
CREATE OR ALTER PROCEDURE addToQueue
( @user_id INTEGER, @book_copy_id INTEGER )
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	DECLARE @cannot_reserve_until_date DATE;
	DECLARE @email_addr VARCHAR(255);
	DECLARE @msg VARCHAR(255);
	SELECT @cannot_reserve_until_date = cannot_reserve_until_date,
		@email_addr = email_addr
	FROM "User"
	WHERE user_id = @user_id;

	IF @cannot_reserve_until_date > CURRENT_TIMESTAMP
	BEGIN
		--ROLLBACK;
		-- z nejakeho duvodu nejdou ty varchary spojit uvnitr RAISERROR
		SET @msg =  'Uživatel se nemùže do fronty rezervací do ' +
			convert(varchar, @cannot_reserve_until_date, 1);
		RAISERROR(@msg, 20, 1);
	END

	DECLARE @reservation_count INT
	SELECT @reservation_count = COUNT(*)
	FROM Reservation_queue
	WHERE user_id = @user_id;

	DECLARE @queues_per_user INT
	SELECT @queues_per_user = queues_per_user
	FROM Info;

	IF @reservation_count >= @queues_per_user
	BEGIN
		--ROLLBACK;
		SET @msg =  CONCAT('Uživatel nemùže mít více než ',
			@queues_per_user, ' rezervací zároveò');
		RAISERROR(@msg, 20, 1);
	END

	DECLARE @reservation_count_for_copy INT
	SELECT @reservation_count_for_copy = COUNT(*)
	FROM Reservation_queue
	WHERE user_id = @user_id AND book_copy_id = @book_copy_id;

	IF @reservation_count_for_copy != 0
	BEGIN
		--ROLLBACK;
		SET @msg = 'Uživatel už je ve frontì na tuto kopii';
		RAISERROR(@msg, 20, 1);
	END

	DECLARE @reservation_duration_days INT;
	SELECT @reservation_duration_days = reservation_duration_days
	FROM Info;

	DECLARE @queue_position INT;
	SELECT @queue_position = COALESCE(MAX(queue_position) + 1, 0)
	FROM Reservation_queue
	WHERE book_copy_id = @book_copy_id;

	
	DECLARE @end_date DATE
	IF @queue_position = 0
	BEGIN
		SET @end_date = 
			DATEADD(day, @reservation_duration_days, CURRENT_TIMESTAMP);
	END
	

	INSERT INTO Reservation_queue (user_id, book_copy_id, end_date, queue_position)
	VALUES(@user_id , @book_copy_id , @end_date , @queue_position );

	IF @queue_position = 0
	BEGIN
		exec sendAddedToQueueEmail @book_copy_id, @email_addr, @end_date;
	END

	COMMIT;


END TRY
BEGIN CATCH
	ROLLBACK;
END CATCH
END;
GO

--Pomocna funkce 1 (neni to transakce, protoze se vola uvnitr transakci)
CREATE OR ALTER PROCEDURE shiftQueue
( @book_copy_id INTEGER, @queue_position INTEGER)
AS
BEGIN;
	DELETE FROM Reservation_queue
	WHERE queue_position = @queue_position AND book_copy_id = @book_copy_id;

	UPDATE Reservation_queue
	SET queue_position = queue_position - 1
	WHERE book_copy_id = @book_copy_id AND queue_position > @queue_position;

	IF @queue_position > 0
	BEGIN
		RETURN;
	END

	--default var value is NULL and if select returns no rows, the variables retain their values
	DECLARE @user_id INT;
	DECLARE @email_addr VARCHAR(255);
	SELECT @user_id = "User".user_id, @email_addr = "User".email_addr
	FROM Reservation_queue
	JOIN "User" ON Reservation_queue.user_id = "User".user_id
	WHERE queue_position = 0 AND book_copy_id = @book_copy_id;

	IF @user_id IS NULL
	BEGIN
		RETURN;
	END

	DECLARE @reservation_duration_days INT
	SELECT @reservation_duration_days = reservation_duration_days
	FROM Info;

	DECLARE @end_date DATE;
	SET @end_date = 
		DATEADD(day, @reservation_duration_days, CURRENT_TIMESTAMP);

	UPDATE Reservation_queue
	SET end_date = @end_date
	WHERE user_id = @user_id AND book_copy_id = @book_copy_id

	BEGIN
		exec sendAddedToQueueEmail @book_copy_id, @email_addr, @end_date;
	END
	
END;
GO

-- 8.2
CREATE OR ALTER PROCEDURE checkReservations
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	
	DECLARE c CURSOR FOR 
		SELECT user_id, book_copy_id, end_date
		FROM Reservation_queue
		WHERE queue_position = 0;
	DECLARE @user_id INT;
	DECLARE @book_copy_id INT;
	DECLARE @end_date DATE;

	OPEN c;
	FETCH FROM c INTO @user_id, @book_copy_id, @end_date;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @end_date < CAST(CURRENT_TIMESTAMP AS DATE)
		BEGIN
			EXEC shiftQueue @book_copy_id, 0;

			DECLARE @reservation_penalty_days INT;
			SELECT @reservation_penalty_days = reservation_penalty_days
			FROM Info;

			DECLARE @cannot_reserve_until_date DATE;
			SET @cannot_reserve_until_date = 
				DATEADD(day, @reservation_penalty_days, CURRENT_TIMESTAMP);

			UPDATE "User"
			SET cannot_reserve_until_date = @cannot_reserve_until_date
			WHERE user_id = @user_id;
		END

		FETCH FROM c INTO @user_id, @book_copy_id, @end_date;
	END
	CLOSE c;
	DEALLOCATE c;

	COMMIT;
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	ROLLBACK;
	IF CURSOR_STATUS('global','c') >= -1
	BEGIN
		IF CURSOR_STATUS('global','c') > -1
		BEGIN
			CLOSE c;
		END
		DEALLOCATE c;
	END
END CATCH
END;
GO

--8.3
CREATE OR ALTER PROCEDURE cancelReservation
( @user_id INTEGER, @book_copy_id INTEGER )
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
	
	DECLARE @msg VARCHAR(255);
	DECLARE @queue_position INT;
	SELECT @queue_position = queue_position
	FROM Reservation_queue
	WHERE user_id = @user_id AND book_copy_id = @book_copy_id

	IF @queue_position IS NULL
	BEGIN
		--ROLLBACK;
		SET @msg = 'Rezervace neexistuje';
		RAISERROR(@msg, 20, 1);
	END

	IF @queue_position = 0
	BEGIN
		--ROLLBACK;
		SET @msg = 'Rezervaci nelze zrušit, protože je aktivní,
					nebo reprezentuje aktivní výpùjèku';
		RAISERROR(@msg, 20, 1);
	END

	EXEC shiftQueue @book_copy_id, @queue_position;

	COMMIT;


END TRY
BEGIN CATCH
	ROLLBACK;
END CATCH
END;
GO


--9.1
CREATE OR ALTER PROCEDURE newBorrowing
( @user_id INTEGER, @book_copy_id INTEGER ) AS
BEGIN
	
	BEGIN TRY
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

		DECLARE @first_user_id INT;
		DECLARE @end_date DATE;
		SELECT @first_user_id = user_id, @end_date = end_date
		FROM Reservation_queue
		WHERE queue_position = 0 AND book_copy_id = @book_copy_id;

		IF @first_user_id != @user_id
		BEGIN
			--ROLLBACK;
			RAISERROR('Kopii má již rezervovanou jiný uživatel', 20, 1);
		END

		DECLARE @borrowing_duration_days INT; 
		SELECT @borrowing_duration_days = borrowing_duration_days
		FROM Info;

		DECLARE @closing_date DATE;
		SET @closing_date = DATEADD(day, @borrowing_duration_days, CURRENT_TIMESTAMP);

		IF @first_user_id IS NULL
		BEGIN
			INSERT INTO Reservation_queue 
			(queue_position, user_id, book_copy_id,end_date)
			VALUES (0, @user_id, @book_copy_id, NULL );
		END
		ELSE
		BEGIN
			UPDATE Reservation_queue
			SET end_date = NULL
			WHERE user_id = @user_id AND book_copy_id = @book_copy_id;
		END

		INSERT INTO Borrowing (book_copy_id, user_id, closing_date, borrow_date)
		VALUES (@book_copy_id , @user_id , @closing_date , CURRENT_TIMESTAMP);

		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
	END CATCH
END
GO

--9.3
/*Stacil by jeden kurzor nad dotazem 
SELECT "User".user_id, "User".email_addr, Borrowing.book_copy_id, Borrowing.closing_date
		FROM Borrowing
		JOIN "User" ON Borrowing.user_id = "User".user_id
		WHERE DATEADD(day, - @before_closing_date_days, Borrowing.closing_date) =
			CAST (CURRENT_TIMESTAMP AS DATE);
za vyuziti pomocne promenne prev_user_id, ale budu se drzet puvodni implementace.
*/
CREATE OR ALTER PROCEDURE checkBorrowings
AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	DECLARE @before_closing_date_days INT;
	SELECT before_closing_date_days
	FROM Info

	DECLARE @current_date DATE;
	SET @current_date = CAST (CURRENT_TIMESTAMP AS DATE);
	
	DECLARE c CURSOR FOR 
		SELECT DISTINCT "User".user_id, "User".email_addr
		FROM Borrowing
		JOIN "User" ON Borrowing.user_id = "User".user_id
		WHERE DATEADD(day, - @before_closing_date_days, Borrowing.closing_date) =
			@current_date
			
	DECLARE @user_id INT;
	DECLARE @email_addr VARCHAR(255);
	DECLARE @books VARCHAR(MAX);
	DECLARE @book_copy_id INT;
	DECLARE @closing_date DATE;
	DECLARE @info VARCHAR(MAX);

	OPEN c;
	FETCH FROM c INTO @user_id, @email_addr;
	WHILE @@FETCH_STATUS = 0
	BEGIN

		DECLARE copiesCursor CURSOR FOR 
			SELECT Borrowing.book_copy_id, Borrowing.closing_date
			FROM Borrowing
			WHERE DATEADD(day, - @before_closing_date_days, Borrowing.closing_date) =
				@current_date AND Borrowing.user_id = @user_id;

		SET @books = '';
		FETCH FROM copiesCursor INTO @book_copy_id, @closing_date;
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @info = dbo.bookCopyInfo(@book_copy_id);
			SET @books = @books + @info + CHAR(13) + CHAR(10);

			FETCH FROM copiesCursor INTO @book_copy_id, @closing_date;
		END
		CLOSE copiesCursor;
		DEALLOCATE copiesCursor;

		DECLARE @subject VARCHAR(255), @body VARCHAR(MAX);
		SET @subject = 'Brzy Vám konèí doba výpùjèení jedné nebo více výpùjèek';
		SET @body = CONVERT(VARCHAR, @closing_date, 104) + ' skonèí doba výpùjèky knih:' +
			CHAR(13) + CHAR(10) + @books;

		exec sendEmail @email_addr, @subject, @body;

		FETCH FROM c INTO @user_id, @email_addr;
	END
	CLOSE c;
	DEALLOCATE c;

	COMMIT;
END TRY
BEGIN CATCH
	SELECT ERROR_MESSAGE() AS ErrorMessage;
	IF CURSOR_STATUS('global','c') >= -1
	BEGIN
		IF CURSOR_STATUS('global','c') > -1
		BEGIN
			CLOSE c;
		END
		DEALLOCATE c;
	END

	IF CURSOR_STATUS('global','copiesCursor') >= -1
	BEGIN
		IF CURSOR_STATUS('global','copiesCursor') > -1
		BEGIN
			CLOSE copiesCursor;
		END
		DEALLOCATE copiesCursor;
	END

	ROLLBACK;
END CATCH
END;
GO

--9.4
CREATE OR ALTER PROCEDURE closeBorrowing
( @borrowing_id INTEGER ) AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	DECLARE @book_copy_id INT;
	DECLARE @return_date DATE;
	SELECT @book_copy_id = book_copy_id, @return_date = return_date
	FROM Borrowing
	WHERE borrowing_id = @borrowing_id

	IF @return_date IS NOT NULL
	BEGIN
		--ROLLBACK;
		RAISERROR('Výpùjèka již byla ukonèena', 21, 1);
	END

	UPDATE Borrowing
	SET return_date = CURRENT_TIMESTAMP
	WHERE borrowing_id = @borrowing_id;

	EXEC shiftQueue @book_copy_id, 0;

	COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;
END CATCH
END;
GO


--z ohledu bezpecnosti to podle vseho neni idealni zpusob
CREATE OR ALTER PROCEDURE generatePassword (@pwd VARCHAR(60) OUT) -- funkce nemuze volat nedeterministicke funkce, ale procedura ano
AS
BEGIN
	SET @pwd = '';
	DECLARE @pwd_len INT;
	SET @pwd_len = 20 + ROUND(RAND() * 5,0);
	DECLARE @random_symbol CHAR(1);
	DECLARE @i INT;
	SET @i = 0;

	WHILE @i < @pwd_len
	BEGIN
		SET @random_symbol = CHAR(33 + ROUND(RAND() * (126-33),0));
		SET @pwd = @pwd + @random_symbol;

		SET @i = @i + 1;
	END
END
GO


--10.1
CREATE OR ALTER PROCEDURE newUser
( @first_name VARCHAR(60), @last_name VARCHAR(60),
  @national_id_num VARCHAR(60), @home_addr VARCHAR(255),
  @email_addr VARCHAR(255), @super_user INT,
  @user_id INT OUTPUT, @password VARCHAR(60) OUTPUT) AS
BEGIN
BEGIN TRY
	BEGIN TRANSACTION;
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

	DECLARE @user_count INT;
	SELECT @user_count = COUNT(*)
	FROM "User"
	WHERE national_id_num = @national_id_num

	IF @user_count > 0
	BEGIN
		RAISERROR('Uživatel s daným rodným èíslem již existuje', 20, 1)
	END

	SELECT @user_count = COUNT(*)
	FROM "User"
	WHERE email_addr = @email_addr

	IF @user_count > 0
	BEGIN
		RAISERROR('Uživatel s danou emailovou adresou již existuje', 20, 1);
	END

	DECLARE @pwd VARCHAR(60);
	EXEC generatePassword @pwd OUT;

	INSERT INTO "User" (first_name, last_name, national_id_num, home_addr, email_addr,
		super_user, password)
	VALUES (@first_name, @last_name, @national_id_num, @home_addr, @email_addr,
		@super_user , @pwd );

	/*DECLARE @msg_body VARCHAR(MAX);
	SET @msg_body = 'Pro pøihlášení do systému knihovny použijte email ' +
		@email_addr + ' a heslo ' + @pwd;

	EXEC msdb.dbo.sp_send_dbmail
	@recipients='user@yourdomain.com',
	@subject='Úspìšná registrace do systému knihovny',
	@body= @msg_body,
	--@body_format='HTML',
	@from_address='knihovnaXXX@gmail.com' -- vs @user_profile */

	DECLARE @subject VARCHAR(255), @body VARCHAR(MAX);
	SET @subject = 'Úspìšná registrace do systému knihovny'
	SET @body = 'Pro pøihlášení do systému knihovny použijte následující údaje:' +
		CHAR(13) + CHAR(10) + 'email: ' + @email_addr + CHAR(13) + CHAR(10) +
		 'heslo: ' + @pwd + CHAR(13) + CHAR(10);
	EXEC sendEmail @email_addr, @subject, @body;
	
	--SELECT SCOPE_IDENTITY()

	SET @user_id = SCOPE_IDENTITY();
	SET @password = @pwd;

	COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;
END CATCH
END;
GO


--1.4 - Hledání knih
CREATE OR ALTER PROCEDURE searchBooks
	(@title VARCHAR(100), @author_id INT, @language_id INT, @genre_id_list VARCHAR(MAX),
	 @release_year_from INT, @release_year_to INT)
AS
BEGIN

--CREATE A TEMP TABLE AND FILL IT WITH THE SPLITTED INPUT STRING
CREATE TABLE #Genre_ids (
	genre_id INT
);
INSERT INTO #Genre_ids (genre_id)
SELECT value FROM STRING_SPLIT(@genre_id_list,',');


SELECT DISTINCT Book.book_id, Book.title, Book.release_year,
Author.author_id, Author.first_name, Author.last_name
FROM Book
JOIN Author ON Book.author_id = Author.author_id
LEFT JOIN Book_copy ON Book_copy.book_id = Book.book_id
WHERE (@title IS NULL OR Book.title_lower LIKE ('%' + LOWER(@title ) + '%')) AND
	(@author_id IS NULL OR Book.author_id = @author_id ) AND
	(@release_year_from IS NULL OR Book.release_year >= @release_year_from ) AND
	(@release_year_to IS NULL OR Book.release_year <= @release_year_to ) AND
	(@language_id IS NULL OR Book_copy.language_id = @language_id ) AND
	NOT EXISTS (
		SELECT *
		FROM #Genre_ids
		WHERE NOT EXISTS (
			SELECT *
			FROM Book_genre
			WHERE Book_genre.book_id = Book.book_id AND
			Book_genre.genre_id = #Genre_ids.genre_id
		)
	)
END
GO