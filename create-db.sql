CREATE DATABASE chm;
USE chm;

CREATE TABLE chmuromaniacy (id serial PRIMARY KEY, firstname NVARCHAR(50), lastname NVARCHAR(50)); 

INSERT INTO chmuromaniacy (firstname, lastname) values ('Mirek', 'Burnejko');
INSERT INTO chmuromaniacy (firstname, lastname) values ('Damian', 'Mazurek');
INSERT INTO chmuromaniacy (firstname, lastname) values ('Michał', 'Furmankiewicz');

select * from chmuromaniacy