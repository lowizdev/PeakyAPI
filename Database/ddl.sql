CREATE TABLE Horse (

	id SERIAL NOT NULL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	age INTEGER NOT NULL
	
);

/**/

CREATE TABLE Operator (

	id SERIAL NOT NULL PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL,
	password VARCHAR(100) NOT NULL

);

CREATE TABLE Race (
	
	id SERIAL NOT NULL PRIMARY KEY,
	race_date DATE,
	description TEXT NOT NULL,
	winner_id INT,
	CONSTRAINT fk_winner_id FOREIGN KEY (winner_id) REFERENCES Horse (id)

);

CREATE TABLE RaceHorse (

	race_id INT REFERENCES Race (id) ON UPDATE CASCADE,
	horse_id INT REFERENCES Horse (id) ON UPDATE CASCADE,
	CONSTRAINT race_horse_pkey PRIMARY KEY (race_id, horse_id)

);