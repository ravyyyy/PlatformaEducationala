CREATE TABLE Elev (
	id_elev INT IDENTITY(1, 1) PRIMARY KEY,
	nume VARCHAR(50) NOT NULL,
	prenume VARCHAR(50) NOT NULL,
	data_nastere DATETIME NOT NULL,
	adresa VARCHAR(100) NOT NULL,
	numar_telefon VARCHAR(20) NOT NULL,
	email VARCHAR(50) NOT NULL,
	id_clasa INT NOT NULL
);

CREATE TABLE Medie (
	id_medie INT IDENTITY(1, 1) PRIMARY KEY,
	id_elev INT,
	id_materie INT,
	nota DECIMAL
);

CREATE TABLE Profesor (
	id_profesor INT IDENTITY(1, 1) PRIMARY KEY,
	nume VARCHAR(50) NOT NULL,
	prenume VARCHAR(50) NOT NULL,
	data_nastere DATETIME NOT NULL,
	adresa VARCHAR(100) NOT NULL,
	numar_telefon VARCHAR(20) NOT NULL,
	email VARCHAR(50) NOT NULL,
	este_diriginte BIT NOT NULL DEFAULT 0
);

CREATE TABLE Clasa (
	id_clasa INT IDENTITY(1, 1) PRIMARY KEY,
	id_specializare INT NOT NULL,
	id_diriginte INT NOT NULL,
	an_studiu INT NOT NULL,
	grupa VARCHAR(1) NOT NULL
);

CREATE TABLE Specializare (
	id_specializare INT IDENTITY(1, 1) PRIMARY KEY,
	denumire VARCHAR(50) NOT NULL
);

CREATE TABLE Materie (
	id_materie INT IDENTITY(1, 1) PRIMARY KEY,
	nume VARCHAR(50) NOT NULL,
	id_profesor INT NOT NULL,
	an_studiu INT NOT NULL,
	are_teza BIT NOT NULL DEFAULT 0
);

CREATE TABLE Nota (
	id_nota INT IDENTITY(1, 1) PRIMARY KEY,
	id_materie INT NOT NULL,
	valoare INT NOT NULL,
	este_teza BIT NOT NULL DEFAULT 0,
	semestru INT NOT NULL CHECK (semestru IN (1, 2)),
	medie_incheiata BIT NOT NULL DEFAULT 0,
	id_elev INT NOT NULL
);

CREATE TABLE Absenta (
	id_absenta INT IDENTITY(1, 1) PRIMARY KEY,
	id_materie INT NOT NULL,
	id_elev INT NOT NULL,
	data_absenta DATE NOT NULL,
	este_motivata BIT NOT NULL DEFAULT 0
);

CREATE TABLE Material (
	id_material INT IDENTITY(1, 1) PRIMARY KEY,
	id_materie INT NOT NULL,
	fisier VARBINARY(MAX) NOT NULL
);

ALTER TABLE Elev ADD CONSTRAINT FK_Elev_Clasa FOREIGN KEY (id_clasa) REFERENCES Clasa (id_clasa);
ALTER TABLE Clasa ADD CONSTRAINT FK_Clasa_Profesor FOREIGN KEY (id_diriginte) REFERENCES Profesor (id_profesor);
ALTER TABLE Clasa ADD CONSTRAINT FK_Clasa_Specializare FOREIGN KEY (id_specializare) REFERENCES Specializare (id_specializare);
ALTER TABLE Materie ADD CONSTRAINT FK_Materie_Profesor FOREIGN KEY (id_profesor) REFERENCES Profesor (id_profesor);
ALTER TABLE Nota ADD CONSTRAINT FK_Nota_Materie FOREIGN KEY (id_materie) REFERENCES Materie (id_materie);
ALTER TABLE Absenta ADD CONSTRAINT FK_Absenta_Materie FOREIGN KEY (id_materie) REFERENCES Materie (id_materie);
ALTER TABLE Absenta ADD CONSTRAINT FK_Absenta_Elev FOREIGN KEY (id_elev) REFERENCES Elev (id_elev);
ALTER TABLE Medie ADD CONSTRAINT FK_Medie_Elev FOREIGN KEY (id_elev) REFERENCES Elev (id_elev);
ALTER TABLE Medie ADD CONSTRAINT FK_Medie_Materie FOREIGN KEY (id_materie) REFERENCES Materie (id_materie);
ALTER TABLE Material ADD CONSTRAINT FK_Material_Materie FOREIGN KEY (id_materie) REFERENCES Materie (id_materie);
ALTER TABLE Nota ADD CONSTRAINT FK_Nota_Elev FOREIGN KEY (id_elev) REFERENCES Elev (id_elev);

GO
CREATE PROCEDURE InserareMaterial
	@id_materie INT,
	@fisier VARBINARY(MAX),
	@material_id INT OUTPUT
AS
BEGIN
	INSERT INTO Material (id_materie, fisier)
	VALUES (@id_materie, @fisier);
	SELECT @material_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareMedie
	@id_elev INT,
	@id_materie INT,
	@nota DECIMAL,
	@medie_id INT OUTPUT
AS
BEGIN
	INSERT INTO Medie (id_elev, id_materie, nota)
	VALUES (@id_elev, @id_materie, @nota);
	SELECT @medie_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareElev
	@nume VARCHAR(50),
	@prenume VARCHAR(50),
	@data_nastere DATETIME,
	@adresa VARCHAR(100),
	@numar_telefon VARCHAR(20),
	@email VARCHAR(50),
	@id_clasa INT,
	@elev_id INT OUTPUT
AS
BEGIN
	INSERT INTO Elev (nume, prenume, data_nastere, adresa, numar_telefon, email, id_clasa)
	VALUES (@nume, @prenume, @data_nastere, @adresa, @numar_telefon, @email, @id_clasa);
	SELECT @elev_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareProfesor
	@nume VARCHAR(50),
	@prenume VARCHAR(50),
	@data_nastere DATETIME,
	@adresa VARCHAR(100),
	@numar_telefon VARCHAR(20),
	@email VARCHAR(50),
	@este_diriginte BIT,
	@profesor_id INT OUTPUT
AS
BEGIN
	INSERT INTO Profesor(nume, prenume, data_nastere, adresa, numar_telefon, email, este_diriginte)
	VALUES (@nume, @prenume, @data_nastere, @adresa, @numar_telefon, @email, @este_diriginte);
	SELECT @profesor_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareClasa
	@id_specializare INT,
	@id_diriginte INT,
	@an_studiu INT,
	@grupa VARCHAR(1),
	@clasa_id INT OUTPUT
AS
BEGIN
	INSERT INTO Clasa(id_specializare, id_diriginte, an_studiu, grupa)
	VALUES (@id_specializare, @id_diriginte, @an_studiu, @grupa);
	SELECT @clasa_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareSpecializare
	@denumire VARCHAR(50),
	@specializare_id INT OUTPUT
AS
BEGIN
	INSERT INTO Specializare(denumire)
	VALUES (@denumire);
	SELECT @specializare_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareMaterie
	@nume VARCHAR(50),
	@id_profesor INT,
	@are_teza BIT,
	@an_studiu INT,
	@materie_id INT OUTPUT
AS
BEGIN
	INSERT INTO Materie(nume, id_profesor, are_teza, an_studiu)
	VALUES (@nume, @id_profesor, @are_teza, @an_studiu);
	SELECT @materie_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareNota
	@id_materie INT,
	@valoare INT,
	@este_teza BIT,
	@semestru INT,
	@medie_incheiata BIT,
	@nota_id INT OUTPUT,
	@id_elev INT
AS
BEGIN
	INSERT INTO Nota(id_materie, valoare, este_teza, semestru, medie_incheiata, id_elev)
	VALUES (@id_materie, @valoare, @este_teza, @semestru, @medie_incheiata, @id_elev);
	SELECT @nota_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE InserareAbsenta
	@id_materie INT,
	@id_elev INT,
	@data_absenta DATE,
	@este_motiva BIT,
	@absenta_id INT OUTPUT
AS
BEGIN
	INSERT INTO Absenta(id_materie, id_elev, data_absenta, este_motivata)
	VALUES (@id_materie, @id_elev, @data_absenta, @este_motiva);
	SELECT @absenta_id = SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE ActualizareMaterial
	@material_id INT,
	@id_materie INT,
	@fisier VARBINARY(MAX)
AS
BEGIN
	UPDATE Material
	SET id_materie = @id_materie,
		fisier = @fisier
	WHERE id_material = @material_id
END

GO
CREATE PROCEDURE ActualizareMedie
	@medie_id INT,
	@id_elev INT,
	@id_materie INT,
	@nota DECIMAL
AS
BEGIN
	UPDATE Medie
	SET id_elev = @id_elev,
		id_materie = @id_materie,
		nota = @nota
	WHERE id_medie = @medie_id
END

GO
CREATE PROCEDURE ActualizareElev
	@elev_id INT,
	@nume VARCHAR(50),
	@prenume VARCHAR(50),
	@data_nastere DATETIME,
	@adresa VARCHAR(100),
	@numar_telefon VARCHAR(20),
	@email VARCHAR(50),
	@id_clasa INT
AS
BEGIN
	UPDATE Elev
	SET nume = @nume,
		prenume = @prenume,
		data_nastere = @data_nastere,
		adresa = @adresa,
		numar_telefon = @numar_telefon,
		email = @email,
		id_clasa = @id_clasa
	WHERE id_elev = @elev_id
END

GO
CREATE PROCEDURE ActualizareProfesor
	@profesor_id INT,
	@nume VARCHAR(50),
	@prenume VARCHAR(50),
	@data_nastere DATETIME,
	@adresa VARCHAR(100),
	@numar_telefon VARCHAR(20),
	@email VARCHAR(50),
	@este_diriginte BIT
AS
BEGIN
	UPDATE Profesor
	SET nume = @nume,
		prenume = @prenume,
		data_nastere = @data_nastere,
		adresa = @adresa,
		numar_telefon = @numar_telefon,
		email = @email,
		este_diriginte = @este_diriginte
	WHERE id_profesor = @profesor_id
END

GO
CREATE PROCEDURE ActualizareClasa
	@clasa_id INT,
	@id_specializare INT,
	@id_diriginte INT,
	@an_studiu INT,
	@grupa VARCHAR(1)
AS
BEGIN
	UPDATE Clasa
	SET id_specializare = @id_specializare,
		id_diriginte = @id_diriginte,
		an_studiu = @an_studiu,
		grupa = @grupa
	WHERE id_clasa = @clasa_id
END

GO
CREATE PROCEDURE ActualizareSpecializare
	@specializare_id INT,
	@denumire VARCHAR(50)
AS
BEGIN
	UPDATE Specializare
	SET denumire = @denumire
	WHERE id_specializare = @specializare_id
END

GO
CREATE PROCEDURE ActualizareMaterie
	@materie_id INT,
	@nume VARCHAR(50),
	@id_profesor INT,
	@an_studiu INT,
	@are_teza BIT
AS
BEGIN
	UPDATE Materie
	SET	nume = @nume,
		id_profesor = @id_profesor,
		are_teza = @are_teza,
		an_studiu = @an_studiu
	WHERE id_materie = @materie_id
END

GO
CREATE PROCEDURE ActualizareNota
	@nota_id INT,
	@id_materie INT,
	@valoare INT,
	@este_teza BIT,
	@medie_incheiata BIT,
	@semestru INT,
	@id_elev INT
AS
BEGIN
	UPDATE Nota
	SET id_materie = @id_materie,
		valoare = @valoare,
		este_teza = @este_teza,
		semestru = @semestru,
		medie_incheiata = @medie_incheiata,
		id_elev = @id_elev
	WHERE id_nota = @nota_id
END

GO
CREATE PROCEDURE ActualizareAbsenta
	@absenta_id INT,
	@id_materie INT,
	@id_elev INT,
	@data_absenta DATE,
	@este_motivata BIT
AS
BEGIN
	UPDATE Absenta
	SET id_materie = @id_materie,
		id_elev = @id_elev,
		data_absenta = @data_absenta,
		este_motivata = @este_motivata
	WHERE id_absenta = @absenta_id
END

--GO
--CREATE PROCEDURE SelectareElev
--	@elev_id INT
--AS
--BEGIN
--	SELECT *
--	FROM Elev
--	WHERE id_elev = @elev_id
--END

--GO
--CREATE PROCEDURE SelectareProfesor
--	@profesor_id INT
--AS
--BEGIN
--	 SELECT *
--	 FROM Profesor
--	 WHERE id_profesor = @profesor_id
--END

--GO
--CREATE PROCEDURE SelectareClasa
--	@clasa_id INT
--AS
--BEGIN
--	SELECT *
--	FROM Clasa
--	WHERE id_clasa = @clasa_id
--END

--GO
--CREATE PROCEDURE SelectareSpecializare
--	@specializare_id INT
--AS
--BEGIN
--	SELECT *
--	FROM Specializare
--	WHERE id_specializare = @specializare_id
--END

--GO
--CREATE PROCEDURE SelectareMaterie
--	@materie_id INT
--AS
--BEGIN
--	SELECT *
--	FROM Materie
--	WHERE id_materie = @materie_id
--END

--GO
--CREATE PROCEDURE SelectareNota
--	@nota_id INT
--AS
--BEGIN
--	SELECT *
--	FROM Nota
--	WHERE id_nota = @nota_id
--END

--GO
--CREATE PROCEDURE SelectareAbsenta
--	@absenta_id INT
--AS
--BEGIN
--	SELECT *
--	FROM Absenta
--	WHERE id_absenta = @absenta_id
--END

GO
CREATE PROCEDURE StergereMaterial
	@material_id INT
AS
BEGIN
	DELETE FROM Material
	WHERE id_material = @material_id
END

GO
CREATE PROCEDURE StergereMedie
	@medie_id INT
AS
BEGIN
	DELETE FROM Medie
	WHERE id_medie = @medie_id
END

GO
CREATE PROCEDURE StergereElev
	@elev_id INT
AS
BEGIN
	DELETE FROM Elev
	WHERE id_elev = @elev_id
END

GO
CREATE PROCEDURE StergereProfesor
	@profesor_id INT
AS
BEGIN
	DELETE FROM Profesor
	WHERE id_profesor = @profesor_id
END

GO
CREATE PROCEDURE StergereClasa
	@clasa_id INT
AS
BEGIN
	DELETE FROM Clasa
	WHERE id_clasa = @clasa_id
END

GO
CREATE PROCEDURE StergereSpecializare
	@specializare_id INT
AS
BEGIN
	DELETE FROM Specializare
	WHERE id_specializare = @specializare_id
END

GO
CREATE PROCEDURE StergereMaterie
	@materie_id INT
AS
BEGIN
	DELETE FROM Materie
	WHERE id_materie = @materie_id
END

GO
CREATE PROCEDURE StergereNota
	@nota_id INT
AS
BEGIN
	DELETE FROM Nota
	WHERE id_nota = @nota_id
END

GO
CREATE PROCEDURE StergereAbsenta
	@absenta_id INT
AS
BEGIN
	DELETE FROM Absenta
	WHERE id_absenta = @absenta_id
END

GO
CREATE PROCEDURE ObtineToateMaterialele
AS
BEGIN
	SELECT id_material, id_materie, fisier FROM Material
END

GO
CREATE PROCEDURE ObtineToateMediile
AS
BEGIN
	SELECT id_medie, id_elev, id_materie, nota FROM Medie
END

GO
CREATE PROCEDURE ObtineToateAbsentele
AS
BEGIN
	SELECT id_absenta, id_materie, id_elev, data_absenta, este_motivata FROM Absenta
END

GO
CREATE PROCEDURE ObtineToateClasele
AS
BEGIN
	SELECT id_clasa, id_specializare, id_diriginte, an_studiu, grupa FROM Clasa
END

GO
CREATE PROCEDURE ObtineTotiElevii
AS
BEGIN
	SELECT id_elev, nume, prenume, data_nastere, adresa, numar_telefon, email, id_clasa FROM Elev
END

GO
CREATE PROCEDURE ObtineToateMateriile
AS
BEGIN
	SELECT id_materie, nume, id_profesor, are_teza, an_studiu FROM Materie
END

GO
CREATE PROCEDURE ObtineToateNotele
AS
BEGIN
	SELECT id_nota, id_materie, valoare, este_teza, semestru, medie_incheiata, id_elev FROM Nota
END

GO
CREATE PROCEDURE ObtineTotiProfesorii
AS
BEGIN
	SELECT id_profesor, nume, prenume, data_nastere, adresa, numar_telefon, email, este_diriginte FROM Profesor
END

GO
CREATE PROCEDURE ObtineToateSpecializarile
AS
BEGIN
	SELECT id_specializare, denumire FROM Specializare
END

GO
CREATE PROCEDURE ObtineToateClaseleDupaSpecializare
	@specializare_id INT
AS
BEGIN
	SELECT id_clasa, id_specializare, id_diriginte, an_studiu, grupa FROM Clasa
	WHERE  id_specializare = @specializare_id
END

GO
CREATE PROCEDURE ObtineToateMateriileDupaProfesor
	@profesor_id INT
AS
BEGIN
	SELECT id_materie, nume, id_profesor, are_teza, an_studiu FROM Materie
	WHERE id_profesor = @profesor_id
END

GO
CREATE PROCEDURE ObtineToateClaseleDupaProfesor
	@profesor_id INT
AS
BEGIN
	SELECT id_clasa, id_specializare, id_diriginte, an_studiu, grupa FROM Clasa
	WHERE id_diriginte = @profesor_id
END

GO
CREATE PROCEDURE ObtineTotiEleviiDupaClasa
	@clasa_id INT
AS
BEGIN
	SELECT id_elev, nume, prenume, data_nastere, adresa, numar_telefon, email, id_clasa FROM Elev
	WHERE id_clasa = @clasa_id
END

GO
CREATE PROCEDURE ObtineToateAbsenteleDupaElev
	@elev_id INT
AS
BEGIN
	SELECT id_absenta, id_materie, id_elev, data_absenta, este_motivata FROM Absenta
	WHERE id_elev = @elev_id
END

GO
CREATE PROCEDURE ObtineToateAbsenteleDupaMaterie
	@materie_id INT
AS
BEGIN
	SELECT id_absenta, id_materie, id_elev, data_absenta, este_motivata FROM Absenta
	WHERE id_materie = @materie_id
END

GO
CREATE PROCEDURE ObtineToateNoteleDupaMaterie
	@materie_id INT
AS
BEGIN
	SELECT id_nota, id_materie, valoare, este_teza, semestru, medie_incheiata, id_elev FROM Nota
	WHERE id_materie = @materie_id
END

GO
CREATE PROCEDURE ObtineToateMediileDupaMaterie
	@materie_id INT
AS
BEGIN
	SELECT id_medie, id_elev, id_materie, nota FROM Medie
	WHERE id_materie = @materie_id
END

GO
CREATE PROCEDURE ObtineToateMediileDupaElev
	@elev_id INT
AS
BEGIN
	SELECT id_medie, id_elev, id_materie, nota FROM Medie
	WHERE id_elev = @elev_id
END

GO
CREATE PROCEDURE ObtineToateMaterialeleDupaMaterie
	@materie_id INT
AS
BEGIN
	SELECT id_material, id_materie, fisier FROM Material
	WHERE id_materie = @materie_id
END

--GO
--CREATE PROCEDURE ObtineToateMateriileDupaNota
--	@materie_id INT
--AS
--BEGIN
--	SELECT id_materie, nume, id_profesor, are_teza, an_studiu FROM Materie
--	WHERE id_materie = @materie_id
--END

GO
CREATE PROCEDURE ObtineAnStudiuDupaClasa
	@clasa_id INT
AS
BEGIN
	SELECT an_studiu FROM Clasa
	WHERE id_clasa = @clasa_id
END

GO
CREATE PROCEDURE ObtineElevDupaId
	@elev_id INT
AS
BEGIN
	SELECT id_elev, nume, prenume, data_nastere, adresa, numar_telefon, email, id_clasa FROM Elev
	WHERE id_elev = @elev_id
END

GO
CREATE PROCEDURE ObtineSpecializareDupaSpecializare
	@specializare_id INT
AS
BEGIN
	SELECT denumire FROM Specializare
	WHERE id_specializare = @specializare_id
END

GO
CREATE PROCEDURE ObtineProfesorDupaId
	@profesor_id INT
AS
BEGIN
	SELECT id_profesor, nume, prenume, data_nastere, adresa, numar_telefon, email, este_diriginte FROM Profesor
	WHERE id_profesor = @profesor_id
END

GO
CREATE PROCEDURE ObtineToateAbsenteleDupaMaterieDupaProfesor
	@profesor_id INT
AS
BEGIN
	SELECT A.id_absenta, A.id_materie, A.id_elev, A.data_absenta, A.este_motivata
	FROM Absenta A
	INNER JOIN Materie M ON A.id_materie = M.id_materie
	WHERE M.id_profesor = @profesor_id
END

GO
CREATE PROCEDURE ObtineToateNoteleDupaMaterieDupaProfesor
	@profesor_id INT
AS
BEGIN
	SELECT N.id_nota, N.id_materie, N.valoare, N.este_teza, N.semestru, N.medie_incheiata, N.id_elev
	FROM Nota N
	INNER JOIN Materie M ON N.id_materie = M.id_materie
	WHERE M.id_profesor = @profesor_id
END

GO
CREATE PROCEDURE ObtineToateMaterialeleDupaMaterieDupaProfesor
	@profesor_id INT
AS
BEGIN
	SELECT M.id_material, M.id_materie, M.fisier
	FROM Material M
	INNER JOIN Materie Ma ON Ma.id_materie = M.id_materie
	WHERE Ma.id_profesor = @profesor_id
END