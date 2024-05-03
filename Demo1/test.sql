CREATE TABLE Client(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	first_name VARCHAR(80) NOT NULL, 
	last_name VARCHAR(80) NOT NULL, 
	second_name VARCHAR(80) NOT NULL, 
	phone VARCHAR(80) NOT NULL
);

CREATE TABLE Status(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	name VARCHAR(80) NOT NULL
);

CREATE TABLE DeviceType(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	name VARCHAR(80) NOT NULL
);

CREATE TABLE Positions(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	name VARCHAR(80) NOT NULL
);

CREATE TABLE Employee(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	first_name VARCHAR(80) NOT NULL, 
	last_name VARCHAR(80) NOT NULL, 
	second_name VARCHAR(80) NOT NULL, 
	position_id INT NOT NULL, 
	login VARCHAR(80) NOT NULL, 
	password VARCHAR(80) NOT NULL, 
	FOREIGN KEY (position_id) REFERENCES Positions(id)
);

CREATE TABLE Material(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	name VARCHAR(80) NOT NULL 
);

CREATE TABLE Application(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
	client_id INT NOT NULL,
    employee_id INT NOT NULL, 
	name VARCHAR(80) NOT NULL,
	device_type INT NOT NULL,
	priority INT NOT NULL DEFAULT 1,
	started_time DATETIME NOT NULL, 
	ended_time DATETIME NOT NULL,
	price INT NOT NULL DEFAULT 0,
	status INT NOT NULL,
	description TEXT, 
	FOREIGN KEY (device_type) REFERENCES DeviceType(id),
	FOREIGN KEY (status) REFERENCES Status(id),
	FOREIGN KEY (client_id) REFERENCES Client(id),
	FOREIGN KEY (employee_id) REFERENCES Employee(id)
);



CREATE TABLE ApplicationMaterial(
	application_id INT NOT NULL,
	material_id INT NOT NULL,
	FOREIGN KEY (application_id) REFERENCES Application(id),
	FOREIGN KEY (material_id) REFERENCES Material(id),
    PRIMARY KEY (application_id, material_id)
);

CREATE TABLE Comments(
	id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	comment_text TEXT NOT NULL
);

CREATE TABLE CommentApplication(
	comment_id INT NOT NULL,
	application_id INT NOT NULL,
	FOREIGN KEY (application_id) REFERENCES Application(id),
	FOREIGN KEY (comment_id) REFERENCES Comments(id),
	PRIMARY KEY (application_id, comment_id)
);





CREATE ROLE "employee", "manager";

GRANT SELECT, INSERT ON demo1.* TO "employee";
GRANT SELECT, INSERT, UPDATE, DELETE ON demo1.* TO "manager";