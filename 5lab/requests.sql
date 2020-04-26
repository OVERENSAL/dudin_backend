INSERT INTO dvd(title, production_year)
VALUES ('Interstellar', 2014),
('Inception', 2010),
('The Shawshank Redemption', 1994),
('The Green Mile', 1999),
('Let Me In', 2010)

INSERT INTO customer(first_name, last_name, password_code, registration_date)
VALUES ('Vasya', 'Pupkin', '1488AABB', 1587391252),
('Petya', 'Zatupkin', '228334BE', 1421762452),
('Love', 'Backend', 'K435BE12', 1074607252),
('Never', 'Sleep', 'B454AC12', 1214607252)

INSERT INTO offer(id_dvd, id_customer, offer_date, return_date)
VALUES (1, 1, 1587291252, 1588391252),
(2, 2, 1421762452, 1422762452),
(3, 3, 1074607252, 1084607252),
(4, 4, 1214607252, 1224607252)

SELECT *
FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

SELECT *
FROM dvd
INNER JOIN offer ON dvd.id_dvd = offer.id_dvd
WHERE 
	offer.offer_date <= strftime('%s','now') AND strftime('%s','now') < offer.return_date;
