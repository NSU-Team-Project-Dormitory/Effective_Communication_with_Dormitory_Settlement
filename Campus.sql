DROP TABLE IF EXISTS campus CASCADE;

CREATE TABLE campus(domitory_number text);

INSERT INTO campus(domitory_number)
VALUES('1A'), ('1B'), ('4'), ('5'), ('6'), ('7'), ('8/1'), ('8/2'), ('9'), ('10');

SELECT * FROM campus;