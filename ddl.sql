-- Generated by Oracle SQL Developer Data Modeler 20.2.0.167.1538
--   at:        2021-04-12 19:34:01 CEST
--   site:      SQL Server 2012
--   type:      SQL Server 2012



CREATE TABLE Author 
    (
     author_id INTEGER IDENTITY NOT NULL , 
     last_name VARCHAR (60) NOT NULL , 
     first_name VARCHAR (60) NOT NULL , 
     birth_date DATE , 
     biography VARCHAR (255) 
    )
GO

ALTER TABLE Author ADD CONSTRAINT Author_PK PRIMARY KEY CLUSTERED (author_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Book 
    (
     book_id INTEGER IDENTITY NOT NULL , 
     title VARCHAR (100) NOT NULL , 
     title_lower VARCHAR (100) NOT NULL , 
     release_year INTEGER , 
     description VARCHAR (MAX) , 
     author_id INTEGER NOT NULL , 
     language_id INTEGER NOT NULL 
    )
GO

ALTER TABLE Book ADD CONSTRAINT Book_PK PRIMARY KEY CLUSTERED (book_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Book_copy 
    (
     book_copy_id INTEGER IDENTITY NOT NULL , 
     release_year INTEGER , 
     book_id INTEGER NOT NULL , 
     creation_date DATE NOT NULL , 
     translator_id INTEGER , 
     language_id INTEGER NOT NULL 
    )
GO

ALTER TABLE Book_copy ADD CONSTRAINT Book_copy_PK PRIMARY KEY CLUSTERED (book_copy_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Book_genre 
    (
     book_id INTEGER NOT NULL , 
     genre_id INTEGER NOT NULL 
    )
GO

ALTER TABLE Book_genre ADD CONSTRAINT Book_genre_PK PRIMARY KEY CLUSTERED (genre_id, book_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Borrowing 
    (
     borrowing_id INTEGER IDENTITY NOT NULL , 
     borrow_date DATE NOT NULL , 
     return_date DATE , 
     closing_date DATE NOT NULL , 
     book_copy_id INTEGER NOT NULL , 
     user_id INTEGER NOT NULL 
    )
GO

ALTER TABLE Borrowing ADD CONSTRAINT Borrowing_PK PRIMARY KEY CLUSTERED (borrowing_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Genre 
    (
     genre_id INTEGER IDENTITY NOT NULL , 
     name VARCHAR (60) NOT NULL 
    )
GO

ALTER TABLE Genre ADD CONSTRAINT Genre_PK PRIMARY KEY CLUSTERED (genre_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Info 
    (
     reservation_duration_days INTEGER NOT NULL , 
     reservation_penalty_days INTEGER NOT NULL , 
     borrowing_duration_days INTEGER NOT NULL , 
     before_closing_date_days INTEGER NOT NULL , 
     queues_per_user INTEGER NOT NULL 
    )
GO

CREATE TABLE Language 
    (
     language_id INTEGER IDENTITY NOT NULL , 
     name VARCHAR (60) NOT NULL 
    )
GO

ALTER TABLE Language ADD CONSTRAINT Language_PK PRIMARY KEY CLUSTERED (language_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Reservation_queue 
    (
     queue_position INTEGER NOT NULL , 
     end_date DATE , 
     user_id INTEGER NOT NULL , 
     book_copy_id INTEGER NOT NULL 
    )
GO

ALTER TABLE Reservation_queue ADD CONSTRAINT Reservation_queue_PK PRIMARY KEY CLUSTERED (book_copy_id, user_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Translator 
    (
     translator_id INTEGER IDENTITY NOT NULL , 
     last_name VARCHAR (60) NOT NULL , 
     first_name VARCHAR (60) NOT NULL , 
     birth_date DATE , 
     biography VARCHAR (255) 
    )
GO

ALTER TABLE Translator ADD CONSTRAINT Translator_PK PRIMARY KEY CLUSTERED (translator_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE "User" 
    (
     user_id INTEGER IDENTITY NOT NULL , 
     last_name VARCHAR (60) NOT NULL , 
     first_name VARCHAR (60) NOT NULL , 
     national_id_num VARCHAR (60) NOT NULL , 
     home_addr VARCHAR (255) NOT NULL , 
     email_addr VARCHAR (255) NOT NULL , 
     super_user INTEGER NOT NULL , 
     last_login_datetime DATETIME , 
     cannot_reserve_until_date DATE , 
     password VARCHAR (60) NOT NULL 
    )
GO

ALTER TABLE "User" ADD CONSTRAINT User_PK PRIMARY KEY CLUSTERED (user_id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

ALTER TABLE Book 
    ADD CONSTRAINT Book_Author_FK FOREIGN KEY 
    ( 
     author_id
    ) 
    REFERENCES Author 
    ( 
     author_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Book_copy 
    ADD CONSTRAINT Book_copy_Book_FK FOREIGN KEY 
    ( 
     book_id
    ) 
    REFERENCES Book 
    ( 
     book_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Book_copy 
    ADD CONSTRAINT Book_copy_Language_FK FOREIGN KEY 
    ( 
     language_id
    ) 
    REFERENCES Language 
    ( 
     language_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Book_copy 
    ADD CONSTRAINT Book_copy_Translator_FK FOREIGN KEY 
    ( 
     translator_id
    ) 
    REFERENCES Translator 
    ( 
     translator_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Book_genre 
    ADD CONSTRAINT Book_genre_Book_FK FOREIGN KEY 
    ( 
     book_id
    ) 
    REFERENCES Book 
    ( 
     book_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Book_genre 
    ADD CONSTRAINT Book_genre_Genre_FK FOREIGN KEY 
    ( 
     genre_id
    ) 
    REFERENCES Genre 
    ( 
     genre_id 
    ) 
    ON DELETE CASCADE 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Book 
    ADD CONSTRAINT Book_Language_FK FOREIGN KEY 
    ( 
     language_id
    ) 
    REFERENCES Language 
    ( 
     language_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Borrowing 
    ADD CONSTRAINT Borrowing_Book_copy_FK FOREIGN KEY 
    ( 
     book_copy_id
    ) 
    REFERENCES Book_copy 
    ( 
     book_copy_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Borrowing 
    ADD CONSTRAINT Borrowing_User_FK FOREIGN KEY 
    ( 
     user_id
    ) 
    REFERENCES "User" 
    ( 
     user_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Reservation_queue 
    ADD CONSTRAINT Reservation_queue_Book_copy_FK FOREIGN KEY 
    ( 
     book_copy_id
    ) 
    REFERENCES Book_copy 
    ( 
     book_copy_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE Reservation_queue 
    ADD CONSTRAINT Reservation_queue_User_FK FOREIGN KEY 
    ( 
     user_id
    ) 
    REFERENCES "User" 
    ( 
     user_id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



ALTER TABLE "User"
ADD CONSTRAINT CHK_super_user CHECK (super_user IN (0,1))

ALTER TABLE Borrowing
ADD CONSTRAINT CHK_borrow_date_return_date CHECK (return_date IS NULL OR borrow_date <= return_date)

ALTER TABLE Borrowing
ADD CONSTRAINT CHK_borrow_date_closing_date CHECK (borrow_date <= closing_date)

ALTER TABLE Reservation_queue
ADD CONSTRAINT CHK_queue_position CHECK (queue_position >= 0)

/*
DROP TABLE Book_genre
DROP TABLE Borrowing
DROP TABLE Reservation_queue
DROP TABLE Book_copy
DROP TABLE Book
DROP TABLE Author
DROP TABLE Translator
DROP TABLE Genre
DROP TABLE "User"
DROP TABLE Language
DROP TABLE Info
GO*/