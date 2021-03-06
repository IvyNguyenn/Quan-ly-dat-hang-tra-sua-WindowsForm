
DROP TABLE GIOHANG;
DROP TABLE CHITIETTHEM;
DROP TABLE CHITIETHOADON;
DROP TABLE ORDERS;
DROP TABLE HOADON;
DROP TABLE KHACHHANG;
DROP TABLE THEM;
DROP TABLE THUCUONG;
DROP TABLE LOAITHUCUONG;

---------- CREATE TABLE -------------------------------------------------------------------
CREATE TABLE LOAITHUCUONG(
  id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1) PRIMARY KEY NOT NULL,
  tenLThucUong NVARCHAR2(50),
  ghichu NVARCHAR2(50)
  
);

CREATE TABLE THUCUONG(
  id int GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1) PRIMARY KEY NOT NULL,
  tenThucUong NVARCHAR2(50),
  idLThucUong int,
  donGia int,
  ghiChu NVARCHAR2(50),
  FOREIGN KEY (idLThucUong) REFERENCES LOAITHUCUONG(id)

);

CREATE TABLE THEM(
  id INT GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1) PRIMARY KEY NOT NULL,
  TENHAT NVARCHAR2(50),
  DONGIA INT,
  GHICHU NVARCHAR2(50)
);

CREATE TABLE KHACHHANG(
  ID INT GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1) PRIMARY KEY NOT NULL,
  USERNAME NVARCHAR2(50) NOT NULL,
  PASSWORD VARCHAR2(50) NOT NULL,
  HOTEN NVARCHAR2(50),
  NGSINH DATE ,
  SDT VARCHAR2(11),
  DIACHI NVARCHAR2(50),
  ROLE INT
);

CREATE TABLE HOADON(
  ID INT GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1) PRIMARY KEY NOT NULL,
  IDUSER INT ,
  NGAY DATE,
  TONGTIEN INT, 
  TINHTRANG NVARCHAR2(50)
);

CREATE TABLE ORDERS(
  ID INT GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1) PRIMARY KEY NOT NULL,
  IDTHUCUONG INT NOT NULL,
  TONGTIEN INT NOT NULL,
  GHICHU NVARCHAR2(50),
  FOREIGN KEY (IDTHUCUONG) REFERENCES THUCUONG(id)
);

CREATE TABLE CHITIETTHEM(
  IDORDER INT NOT NULL,
  IDTHEM INT NOT NULL,
  SOLUONG INT,
  PRIMARY KEY (IDORDER,IDTHEM),
  FOREIGN KEY (IDTHEM) REFERENCES THEM(ID),
  FOREIGN KEY (IDORDER) REFERENCES ORDERS(ID)
);

CREATE TABLE GIOHANG(
  IDUSER INT NOT NULL,
  IDORDER INT NOT NULL,
  SOLUONG INT NOT NULL,
  GHICHU NVARCHAR2(50),
  PRIMARY KEY (IDUSER,IDORDER),
  FOREIGN KEY (IDUSER) REFERENCES KHACHHANG(ID),
  FOREIGN KEY (IDORDER) REFERENCES ORDERS(ID)
);

CREATE TABLE CHITIETHOADON(
  IDHOADON INT NOT NULL,
  IDORDER INT NOT NULL,
  SOLUONG INT NOT NULL,
  PRIMARY KEY (IDHOADON,IDORDER),
  FOREIGN KEY (IDHOADON) REFERENCES HOADON(ID),
  FOREIGN KEY (IDORDER) REFERENCES ORDERS(ID) 
);




---------------- CREATE VIEW ------------------------------------------------------
CREATE OR REPLACE VIEW V_LOAITHUCUONG AS SELECT * FROM LOAITHUCUONG;
CREATE OR REPLACE VIEW V_THUCUONG AS SELECT * FROM THUCUONG;
CREATE OR REPLACE VIEW V_THEM AS SELECT * FROM THEM;
CREATE OR REPLACE VIEW V_KHACHHANG AS SELECT * FROM KHACHHANG;
CREATE OR REPLACE VIEW V_HOADON AS SELECT * FROM HOADON;
CREATE OR REPLACE VIEW V_ORDERS AS SELECT * FROM ORDERS;
CREATE OR REPLACE VIEW V_CHITIETHOADON AS SELECT * FROM CHITIETHOADON;
CREATE OR REPLACE VIEW V_CHITIETTHEM AS SELECT * FROM CHITIETTHEM;
CREATE OR REPLACE VIEW V_GIOHANG AS SELECT * FROM GIOHANG;

----------------------------------------------------------------------------------
--TH�M D? LI?U
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
INSERT INTO KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES 
('hoangvy','12345','Nguy?n Ng?c Ho�ng Vy','05-MAR-98','0906333444','482 L� V?n Vi?t',1);

INSERT INTO KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES 
('Nguyen Van An','12345','Nguy?n V?n An','25-MAR-97','0958741114','89 L� V?n Vi?t',1);

INSERT INTO KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES
('Nguyen Thi Mai','123','Nguy?n Th? Mai','14-MAY-95','0905411475','203 Tr?n H?ng ??o',1);

INSERT INTO KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES
('Le Van Nam','123123','L� V?n Nam','07-OCT-98','0123745412','53/4 An D??ng V??ng',2);

INSERT INTO KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES
('Bui Thi Dao','1234','B�i Th? ?�o','29-NOV-98','09023588744','144/34 V� V?n Ng�n',2);

commit; 

----------------------------------------------------------------------------------
INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('Tr� S?a',null);		--1
INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('Th?c u?ng ??c bi?t',null);--2	
INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('Tr� Nguy�n Ch?t',null);	--3
INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('Th?c U?ng S�ng T?o',null);--4
INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('?� Xay',null);		--5
INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('Coffee',null);		--6
commit;

----------------------------------------------------------------------------------
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Kem s?a',11000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Pudding',5000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('B�nh Flan',5000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Th?ch d?a',6000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Th?ch Ai-Yu',5000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Th?ch Tr�i C�y',7000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Th?ch C� Ph�',6000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Th?ch N�u',5000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('S??ng S�o',3000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Tr�n Ch�u Tr?ng',5000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Tr�n Ch�u ?en',5000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('H?t �',3000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Nha ?am',6000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Combo 2 lo?i h?t',12000,NULL);
INSERT INTO THEM (TENHAT,DONGIA,GHICHU) VALUES ('Combo 3 lo?i h?t',20000,NULL);

commit;
----------------------------------------------------------------------------------
-----------------
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Tr� Xanh',1,22000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Tr� ?en',1,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Earl Grey',1,25000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a � long',1,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a S??ng S�o',1,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Coffee',1,24000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Tr�n Ch�u ?en',1,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Chocolate',1,27000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Pudding ??u ??',1,27000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Khoai M�n',1,26000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a �long 3J',1,33000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Matcha ??u ??',1,34000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Hokkaido',1,26000,NULL);
----------------------
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Xanh',2,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� ?en',2,22000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Earl Grey',2,27000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Alisan',2,27000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� �long',2,28000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� B� ?ao',2,26000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� ?�o',2,29000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� G?ng',2,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� M?t Ong',2,27000,NULL);
-----------------
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Xanh',3,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� ?en',3,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Earl Grey',3,27000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Alisan',3,27000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� � long',3,16000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� B� ?ao',3,16000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� B� ?ao Alisan',3,17000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('H?ng Tr�',3,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� D�u',3,20000,NULL);

-----------------
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('?�o H?ng M?n v� H?t �',4,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Alisan Chanh D�y',4,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Xanh M?n',4,21000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Xanh ?�o',4,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� ?en ?�o',4,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Xanh Chanh D�y',4,20000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('M?t Ong H?t �',4,22000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Alisan Xo�i',4,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� Alisan V?i',4,23000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� � long V?i',4,22000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Chanh Ai-Yu v� Tr�n Ch�u Tr?ng',4,25000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('QQ Chanh D�y Tr� Xanh',4,27000,NULL);
-----------------
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a �long ?� Xay',5,34000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Xo�i ?� Xay',5,34000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Yakult ?�o ?� Xay',5,39000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Matcha ?� Xay',5,39000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Khoai M�n ?� Xay',5,37000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('S�c�la ?� Xay',5,38000,NULL);
-----------------
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Coffee',6,34000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Coffee Kem S?a',6,44000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Coffee ?en',6,12000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Coffee S?a',6,16000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Coffee Moka',6,35000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('B?c x?u',6,22000,NULL);
INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('B?c x?u Kem S?a',6,35000,NULL);

commit;
--------------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------

--- TRIGGER INSERT LOAI THUC UONG TREN VIEW--------------------------
DROP TRIGGER tg_addLoaiThucUong;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_addLoaiThucUong
INSTEAD OF INSERT ON v_LOAITHUCUONG 
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  select  COUNT(*) into count$ from LOAITHUCUONG L where L.tenLThucUong=:new.TENLTHUCUONG;
  IF(count$>0) THEN
    BEGIN
      raise_application_error(-20022,'T�N LO?I TH?C U?NG ?� T?N T?I');
      ROLLBACK;
      RETURN;
    END;
  END IF;
  INSERT INTO LOAITHUCUONG(tenLThucUong,ghichu) VALUES (:NEW.tenLThucUong,:new.ghichu);	
END;
----------

SELECT * FROM v_LOAITHUCUONG;

select * from LOAITHUCUONG;

INSERT INTO v_LOAITHUCUONG(tenLThucUong,ghichu) VALUES ('Coffee 33',null);	

commit;
--- TRIGGER UPDATE LOAI THUC UONG TREN VIEW--------------------------

DROP TRIGGER tg_updateLoaiThucUong;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_updateLoaiThucUong
INSTEAD OF UPDATE ON v_LOAITHUCUONG 
FOR EACH ROW
DECLARE 
count$ int;
BEGIN
  select  COUNT(*) into count$ from LOAITHUCUONG L where L.tenLThucUong=:new.TENLTHUCUONG;
  IF(count$>0 AND :new.TENLTHUCUONG<>:old.TENLTHUCUONG) THEN
    BEGIN
      raise_application_error(-20022,'T�N LO?I TH?C U?NG ?� T?N T?I');
      ROLLBACK;
      RETURN;
    END;
  END IF;
  UPDATE LOAITHUCUONG SET tenLThucUong=:new.TENLTHUCUONG,GHICHU=:NEW.GHICHU WHERE ID=:new.ID;
END;
--- TEST --------------------

SELECT * FROM v_LOAITHUCUONG;

select * from LOAITHUCUONG;

update v_LOAITHUCUONG set tenLThucUong='Coffee 444' WHERE id=41;

commit;

--- TRIGGER INSERT THUC UONG TREN VIEW--------------------------
DROP TRIGGER tg_addThucUong;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_addThucUong
INSTEAD OF INSERT ON v_THUCUONG 
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  select  COUNT(*) into count$ from THUCUONG T where T.tenThucUong=:new.TENTHUCUONG;
  IF(count$>0) THEN
    BEGIN
      raise_application_error(-20022,'T�N TH?C U?NG ?� T?N T?I');
      ROLLBACK;
      RETURN;
    END;
  END IF;
  INSERT INTO THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) 
  VALUES (:new.TENTHUCUONG,:new.IDLTHUCUONG,:new.DONGIA,:new.GHICHU);
END;
----------
SELECT * FROM v_THUCUONG;

select * from THUCUONG;

INSERT INTO V_THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Tr� Xanh',1,42000,NULL);

commit;
--- TRIGGER UPDATE THUC UONG TREN VIEW--------------------------

DROP TRIGGER tg_updateThucUong;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_updateThucUong
INSTEAD OF UPDATE ON v_THUCUONG 
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  IF(:NEW.DONGIA < :OLD.DONGIA) THEN
    BEGIN 
      raise_application_error(-20022,'??N GI� PH?I L?N H?N HAY B?NG ??N GI� C?');
      ROLLBACK;RETURN;
    END;
  END IF;
  select  COUNT(*) into count$ from THUCUONG T where T.tenThucUong=:new.TENTHUCUONG;
  IF(count$>0 AND :new.TENTHUCUONG<>:old.TENTHUCUONG) THEN
    BEGIN 
      raise_application_error(-20022,'T�N TH?C U?NG ?� T?N T?I');
      ROLLBACK;RETURN;
    END;
  END IF;
  UPDATE THUCUONG SET tenThucUong=:new.TENTHUCUONG,
                      IDLTHUCUONG=:new.IDLTHUCUONG,
                      dongia=:new.dongia,
                      ghichu=:new.ghichu
                      WHERE ID=:new.ID;
END;
--- TEST --------------------

SELECT * FROM v_THUCUONG;

select * from THUCUONG;

UPDATE v_THUCUONG set tenThucUong='B?c x?u Kem S?a',DONGIA=32000 WHERE id=61;
update v_THUCUONG set DONGIA=52000 WHERE id=61;

commit;

----------
SELECT * FROM v_THUCUONG;

select * from THUCUONG;

INSERT INTO V_THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES ('Tr� S?a Tr� Xanh',1,42000,NULL);

commit;
--- TRIGGER INSERT THEM TREN VIEW--------------------------
DROP TRIGGER tg_addTHEM;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_addTHEM
INSTEAD OF INSERT ON v_THEM
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  select  COUNT(*) into count$ from THEM T where T.tenHAT=:new.TENHAT;
  IF(count$>0) THEN
    BEGIN
      raise_application_error(-20022,'T�N TOPPING ?� T?N T?I');
      ROLLBACK;
      RETURN;
    END;
  END IF;
  INSERT INTO THEM (TENHAT,DONGIA,GHICHU)
  VALUES (:new.TENHAT,:new.DONGIA,:new.GHICHU);
END;
----------
SELECT * FROM V_THEM;

select * from THEM;

INSERT INTO V_THEM (TENHAT,DONGIA,GHICHU) VALUES ('Kem s?a222',16000,NULL);

commit;
--- TRIGGER UPDATE THEM TREN VIEW--------------------------

DROP TRIGGER tg_updateTHEM;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_updateTHEM
INSTEAD OF UPDATE ON v_THEM 
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  IF(:NEW.DONGIA < :OLD.DONGIA) THEN
    BEGIN 
      raise_application_error(-20022,'??N GI� PH?I L?N H?N HAY B?NG ??N GI� C?');
      ROLLBACK;RETURN;
    END;
  END IF;
  select  COUNT(*) into count$ from THEM T where T.tenHAT=:new.TENHAT;
  IF(count$>0 AND :new.TENHAT<>:old.TENHAT) THEN
    BEGIN 
      raise_application_error(-20022,'T�N TOPPING ?� T?N T?I');
      ROLLBACK;RETURN;
    END;
  END IF;
  UPDATE THEM SET tenHAT=:new.TENHAT,
                      dongia=:new.dongia,
                      ghichu=:new.ghichu
                    WHERE ID=:new.ID;
END;
--- TEST --------------------

SELECT * FROM v_THEM;

select * from THEM;

UPDATE v_THEM SET TENHAT='Kem s?a222',DONGIA=17000,GHICHU='' WHERE id=22;
update v_THEM set DONGIA=17000 WHERE id=22;

DELETE FROM V_THEM WHERE ID = 17;
commit;
--------------III
--- TRIGGER INSERT KHACHHANG TREN VIEW--------------------------
DROP TRIGGER tg_addKHACHHANG;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_addKHACHHANG
INSTEAD OF INSERT ON v_KHACHHANG
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  select  COUNT(*) into count$ from KHACHHANG K where K.USERNAME=:new.USERNAME;
  IF(count$>0) THEN
    BEGIN
      raise_application_error(-20022,'USERNAME ?� T?N T?I');
      ROLLBACK;
      RETURN;
    END;
  END IF;
  INSERT INTO KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES 
  (:NEW.USERNAME,:NEW.PASSWORD,:NEW.HOTEN,:NEW.NGSINH,:NEW.SDT,:NEW.DIACHI,:NEW.ROLE);
END;
----------
SELECT * FROM V_KHACHHANG;

select * from KHACHHANG;

INSERT INTO V_KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES 
('Tran Thanh Huy','121212','Tr?n Th�nh Huy','12-DEC-93','0125557888','09 Nguy?n Tri Ph??ng',1);

commit;
--- TRIGGER UPDATE KHACH HANG TREN VIEW--------------------------

DROP TRIGGER tg_updateKHACHHANG;
-----------------------------------
CREATE OR REPLACE TRIGGER tg_updateKHACHHANG
INSTEAD OF UPDATE ON v_KHACHHANG 
FOR EACH ROW
DECLARE 
count$ int;
BEGIN 
  select  COUNT(*) into count$ from KHACHHANG T where T.USERNAME=:new.USERNAME;
  IF(count$>0 AND :new.USERNAME<>:old.USERNAME) THEN
    BEGIN 
      raise_application_error(-20022,'USERNAME ?� T?N T?I');
      ROLLBACK;RETURN;
    END;
  END IF;
  UPDATE KHACHHANG SET USERNAME=:new.USERNAME,
                      PASSWORD=:new.PASSWORD,
                      HOTEN=:new.HOTEN,
                      NGSINH=:new.NGSINH,SDT=:new.SDT,
                      DIACHI=:new.DIACHI,ROLE=:new.ROLE
                      WHERE ID=:new.ID;
END;


--- TEST --------------------

SELECT * FROM v_KHACHHANG;

select * from KHACHHANG;

UPDATE V_KHACHHANG SET USERNAME='Tran Thanh Huy12' WHERE ID=22;

UPDATE V_KHACHHANG SET USERNAME='Nguyen Van An',NGSINH='',SDT='',DIACHI='',ROLE=1 WHERE ID=22;
commit;
-------------- PROCEDURE --------------------------  
-------- THEM XOA SUA LOAI THUC UONG --------------

CREATE OR REPLACE PROCEDURE sp_insertLoaiThucUong( TenLThucUong$ NVARCHAR2, GHICHU$ NVARCHAR2)
AS 
BEGIN
  INSERT INTO v_LOAITHUCUONG(tenLThucUong,ghichu) VALUES (TenLThucUong$,GHICHU$);
END;
----------------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_deleteLoaiThucuong( ID$ int)
AS
IDTHUCUONG$ INT;
CURSOR cus IS SELECT ID FROM THUCUONG WHERE idLThucUong=ID$;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO IDTHUCUONG$;
      EXIT WHEN cus%NOTFOUND;
      DELETE FROM GIOHANG WHERE IDORDER IN (SELECT ID FROM ORDERS WHERE IDTHUCUONG=IDTHUCUONG$);
      DELETE FROM CHITIETTHEM WHERE IDORDER IN (SELECT ID FROM ORDERS WHERE IDTHUCUONG=IDTHUCUONG$);
      DELETE FROM CHITIETHOADON WHERE IDORDER IN (SELECT ID FROM ORDERS WHERE IDTHUCUONG=IDTHUCUONG$);
      DELETE FROM ORDERS WHERE IDTHUCUONG=IDTHUCUONG$;
      DELETE FROM V_THUCUONG WHERE ID = IDTHUCUONG$;
    END LOOP;
  CLOSE  cus;
  DELETE FROM V_LoaiThucuong WHERE ID = ID$;
END;
----------------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_updateLoaiThucUong(TenLThucUong$ NVARCHAR2,GHICHU$ NVARCHAR2, ID$ int )
AS 
BEGIN
  UPDATE v_LOAITHUCUONG set tenLThucUong=TenLThucUong$,GhiChu=GHICHU$ WHERE id=ID$;
END;

------ THEM XOA SUA THUC UONG -------------
CREATE OR REPLACE PROCEDURE sp_insertThucUong(tenThucUong$ NVARCHAR2,IDLTHUCUONG$ INT,
                                              DONGIA$ INT, GHICHU$ NVARCHAR2 )
AS 
BEGIN
  INSERT INTO V_THUCUONG (tenThucUong,IDLTHUCUONG,DONGIA,GHICHU) VALUES (tenThucUong$,IDLTHUCUONG$,DONGIA$,GHICHU$);
END;
----------------------------------------------
CREATE OR REPLACE PROCEDURE sp_deleteThucUong(ID$ INT )
AS 
BEGIN
  DELETE FROM GIOHANG WHERE IDORDER IN (SELECT ID FROM ORDERS WHERE IDTHUCUONG=ID$);
  DELETE FROM CHITIETTHEM WHERE IDORDER IN (SELECT ID FROM ORDERS WHERE IDTHUCUONG=ID$);
  DELETE FROM CHITIETHOADON WHERE IDORDER IN (SELECT ID FROM ORDERS WHERE IDTHUCUONG=ID$);
  DELETE FROM ORDERS WHERE IDTHUCUONG=ID$;
  DELETE FROM V_THUCUONG WHERE ID = ID$;
END;
----------------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_updateThucUong( tenThucUong$ NVARCHAR2, IDLTHUCUONG$ INT, DONGIA$ INT, GhiChu$ NVARCHAR2, ID$ INT)
AS 
BEGIN
  UPDATE V_THUCUONG set tenThucUong=tenThucUong$,IDLTHUCUONG=IDLTHUCUONG$,DONGIA=DONGIA$,GhiChu=GhiChu$ WHERE id=ID$;
END;

---------- THEM XOA SUA TOPPING ------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_insertThem( TENHAT$ NVARCHAR2, DONGIA$ INT, GHICHU$ NVARCHAR2)
AS 
BEGIN
  INSERT INTO V_THEM (TENHAT,DONGIA,GHICHU) VALUES (TENHAT$,DONGIA$,GHICHU$);
END;
------------------------------------
CREATE OR REPLACE PROCEDURE sp_deleteThem( ID$ int)
AS 
BEGIN
  DELETE FROM CHITIETTHEM WHERE IDTHEM = ID$;
  DELETE FROM V_THEM WHERE ID = ID$;
END;
------------------------------------
CREATE OR REPLACE PROCEDURE sp_updateThem (TENHAT$ NVARCHAR2, DONGIA$ INT, GHICHU$ NVARCHAR2, ID$ INT)
AS 
BEGIN
  UPDATE v_THEM SET TENHAT=TENHAT$,DONGIA=DONGIA$,GHICHU=GHICHU$ WHERE ID=ID$;
END;

---------- THEM XOA SUA KHACH HANG ------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_insertKhachHang (USERNAME$ NVARCHAR2, PASSWORD$ NVARCHAR2, HOTEN$ NVARCHAR2,
                                                NGSINH$ DATE, SDT$ VARCHAR2, DIACHI$ NVARCHAR2, ROLE$ INT)
AS 
BEGIN
  INSERT INTO V_KHACHHANG (USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE) VALUES (USERNAME$,PASSWORD$,HOTEN$,NGSINH$,SDT$,DIACHI$,ROLE$);
  
END;
------------------------------
CREATE OR REPLACE PROCEDURE sp_deleteKhachHang (ID$ INT )
AS
USERNAME$ NVARCHAR2(50);
BEGIN
  
  SELECT USERNAME INTO USERNAME$ FROM KHACHHANG WHERE ID=ID$;
  DELETE FROM GIOHANG WHERE IDUSER = ID$;
  DELETE FROM HOADON WHERE IDUSER = ID$;
  DELETE FROM V_KHACHHANG WHERE ID = ID$;
  
END;

------------------------------
CREATE OR REPLACE PROCEDURE sp_updateKhachHang (NGSINH$ DATE,SDT$ VARCHAR2,
                                                DIACHI$ NVARCHAR2,ROLE$ INT,ID$ INT)
AS 
BEGIN
  UPDATE V_KHACHHANG SET NGSINH=NGSINH$,SDT=SDT$,DIACHI=DIACHI$,ROLE=ROLE$ WHERE ID=ID$;
END;
---------------------

---------------- DAT HANG -----------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_resetPassword(USERNAME$ NVARCHAR2,PASS$ NVARCHAR2,HOTEN$ NVARCHAR2,NGAYSINH$ DATE, 
                                              SDT$ VARCHAR2, DIACHI$ NVARCHAR2, ID$ INT)
AS 
BEGIN
  UPDATE V_KHACHHANG SET USERNAME=USERNAME$,PASSWORD=PASS$,HOTEN=HOTEN$,NGSINH=NGAYSINH$,SDT=SDT$,DIACHI=DIACHI$ WHERE ID=ID$;
  COMMIT;
END;
----------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_insertBill(IDUSER$ INT,NGAY$ DATE,TONGTIEN$ INT)
AS 
IDBILL$ INT;
IDORDER$ INT;
COUNT$ INT;
CURSOR cus IS SELECT IDORDER,SOLUONG FROM GIOHANG WHERE IDUSER = IDUSER$;
BEGIN
  INSERT INTO HOADON (IDUSER,NGAY,TONGTIEN,TINHTRANG) VALUES (IDUSER$,NGAY$,TONGTIEN$,'?� ??t');
  SELECT ID INTO IDBILL$ FROM (SELECT * FROM HOADON ORDER BY ID DESC) WHERE  IDUSER = 1  AND ROWNUM <= 1;
  OPEN cus;
    LOOP  
      FETCH cus INTO IDORDER$,COUNT$;
      EXIT WHEN cus%NOTFOUND;
      INSERT INTO CHITIETHOADON (IDHOADON,IDORDER,SOLUONG) VALUES (IDBILL$,IDORDER$,COUNT$);
    END LOOP;
  CLOSE  cus;
  DELETE GIOHANG WHERE IDUSER = IDUSER$;
END;
--------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_cancelBill(IDBILL$ IN HOADON.ID%TYPE)
AS 
TINHTRANG$ NVARCHAR2(50);
BEGIN
  SELECT TINHTRANG INTO TINHTRANG$ FROM HOADON WHERE ID = IDBILL$;
  IF(TINHTRANG$ = '?� ??t') THEN
    UPDATE HOADON SET TINHTRANG = '?� h?y'  WHERE ID = IDBILL$;
  ELSIF(TINHTRANG$ = '?� h?y' ) THEN
    raise_application_error(-20022,'??n h�ng ?� h?y r?i !');
  ELSE 
    raise_application_error(-20022,'??n h�ng ?� thanh to�n r?i !');
  END IF;
END;
--------------------------------------------------------------------
CREATE OR REPLACE PROCEDURE sp_payedBill(IDBILL$ IN HOADON.ID%TYPE)
AS 
TINHTRANG$ NVARCHAR2(50);
BEGIN
  SELECT TINHTRANG INTO TINHTRANG$ FROM HOADON WHERE ID = IDBILL$;
  IF(TINHTRANG$ = '?� ??t') THEN
    UPDATE HOADON SET TINHTRANG = '?� thanh to�n'  WHERE ID = IDBILL$; 
  ELSIF(TINHTRANG$ = '?� thanh to�n' ) THEN
    raise_application_error(-20022,'??n h�ng ?� thanh to�n r?i!');
  ELSE 
    raise_application_error(-20022,'??N H�NG ?� B? H?Y !');
  END IF;
END;
----------------------------------------------------------------
ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MON-YY HH24:MI:SS';

CREATE OR REPLACE PROCEDURE sp_checkAllBill
AS 
H1$ INT;M1$ INT;
H2$ INT;M2$ INT;
ID$ INT;
NGAY$ DATE;
CURSOR cus IS SELECT ID,NGAY FROM HOADON WHERE TINHTRANG='?� ??t';
BEGIN
  select to_CHAR(to_date(SYSDATE,'dd-MON-yy HH24:MI:SS'),'HH24') hour INTO H1$ from dual;
  select to_CHAR(to_date(SYSDATE,'dd-MON-yy HH24:MI:SS'),'MI') MI INTO M1$  from dual;
  OPEN cus;
    LOOP 
      FETCH cus INTO ID$,NGAY$;
      EXIT WHEN cus%NOTFOUND;
      select to_CHAR(to_date(NGAY$,'dd-MON-yy HH24:MI:SS'),'HH24') hour INTO H2$ from dual;
      select to_CHAR(to_date(NGAY$,'dd-MON-yy HH24:MI:SS'),'MI') MI INTO M2$ from dual;
      
      IF (((H1$-H2$)*60 + M1$+60-M2$) >= 60 OR NGAY$+1<SYSDATE) THEN 
        UPDATE HOADON SET TINHTRANG='?� h?y' WHERE ID=ID$;
      END IF;
    END LOOP;
  CLOSE  cus;
END;

------------------------------------------------------------------
------------------ kieem tra la Admin ---------
CREATE OR REPLACE PROCEDURE sp_isAdmin(a$ nvarchar2)
AS 
BEGIN
  DBMS_OUTPUT.PUT_LINE(a$);
END;
execute ngochoang2.sp_isAdmin('hello');

-----------------------------------------------

---------- FUCTION -----------------------------------
------- FUCTION LOGIN -----------------------------------------------------------------
------------------------------------------------
DROP TYPE table_tab;
DROP TYPE table_row;

CREATE TYPE table_row AS OBJECT (
  ID INT,
  USERNAME NVARCHAR2(50),
  PASSWORD VARCHAR2(50),
  HOTEN NVARCHAR2(50),
  NGSINH DATE ,
  SDT VARCHAR2(11),
  DIACHI NVARCHAR2(50),
  ROLE INT  
);

CREATE TYPE table_tab IS TABLE OF table_row;
-- Build the table function

CREATE OR REPLACE FUNCTION fn_Login(name_ in KHACHHANG.USERNAME%TYPE, 
                                      pass_ in KHACHHANG.PASSWORD%TYPE )
RETURN table_tab AS
l_tab  table_tab := table_tab();

ID_ INT;
USERNAME_ NVARCHAR2(50);
PASSWORD_ VARCHAR2(50);
HOTEN_ NVARCHAR2(50);
NGSINH_ DATE;
SDT_ VARCHAR2(11);
DIACHI_ NVARCHAR2(50);
ROLE_ INT;

CURSOR cus IS SELECT ID,USERNAME,PASSWORD,HOTEN,NGSINH,SDT,DIACHI,ROLE 
              FROM KHACHHANG KH where KH.USERNAME=name_ and KH.PASSWORD=pass_;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO ID_,USERNAME_,PASSWORD_,HOTEN_,NGSINH_,SDT_,DIACHI_,ROLE_;
      EXIT WHEN cus%NOTFOUND;
      l_tab.extend;
      l_tab(l_tab.last) := table_row(ID_,USERNAME_,PASSWORD_,HOTEN_,NGSINH_,SDT_,DIACHI_,ROLE_);
    END LOOP;
  CLOSE  cus;
  RETURN l_tab;
END;

commit;
-------------
-- Thi hanh.--------
SET SERVEROUTPUT ON
SELECT * FROM TABLE( fn_Login('Nguyen Van An','12345'));

commit;

------- FUCTION THONG KE  -----------------------------------------------------------------
------------------------------------------------
DROP TYPE table_tab1;
DROP TYPE table_row1;

CREATE TYPE table_row1 AS OBJECT (
  ID INT,
  NGAY DATE,
  TONGTIEN INT, 
  TINHTRANG NVARCHAR2(50),
  KHACHHANG NVARCHAR2(50)
);

CREATE TYPE table_tab1 IS TABLE OF table_row1;
-- Build the table function

CREATE OR REPLACE FUNCTION fn_ThongKeHoaDon(DATE1$ DATE, DATE2$ DATE)
RETURN table_tab1 AS
l_tab  table_tab1 := table_tab1();

ID$ INT;
NGAY$ DATE;
TONGTIEN$ INT;
TINHTRANG$ NVARCHAR2(50);
KHACHHANG$ NVARCHAR2(50);

CURSOR cus IS SELECT H.ID,H.NGAY,H.TONGTIEN,H.TINHTRANG,K.HOTEN  
              FROM HOADON H,KHACHHANG K
              WHERE H.IDUSER=K.ID
              AND NGAY >= DATE1$
              AND NGAY <= DATE2$+1;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO ID$,NGAY$,TONGTIEN$,TINHTRANG$,KHACHHANG$;
      EXIT WHEN cus%NOTFOUND;
      l_tab.extend;
      l_tab(l_tab.last) := table_row1(ID$,NGAY$,TONGTIEN$,TINHTRANG$,KHACHHANG$);
    END LOOP;
  CLOSE  cus;
  RETURN l_tab;
END;

commit;
-------------
-- Thi hanh.--------
SET SERVEROUTPUT ON
SELECT * FROM TABLE( fn_ThongKeHoaDon('25-APR-18','26-APR-18')) ORDER BY ID DESC;
commit;
------- FUCTION LOAD LIST ORDER THEO USER ID -----------------------------------------------------------------
------------------------------------------------
DROP TYPE table_tab4;
DROP TYPE table_row4;

CREATE TYPE table_row4 AS OBJECT (
  ID INT,
  IDTHUCUONG NVARCHAR2(50),
  TONGTIEN INT,
  GHICHU NVARCHAR2(50)
);

CREATE TYPE table_tab4 IS TABLE OF table_row4;
-- Build the table function

CREATE OR REPLACE FUNCTION fn_getOrderByUserId(USERID$ INT)
RETURN table_tab4 AS
l_tab  table_tab4 := table_tab4();

  ID$ INT;
  IDTHUCUONG$ NVARCHAR2(50);
  TONGTIEN$ INT;
  GHICHU$ NVARCHAR2(50);

CURSOR cus IS SELECT O.ID,O.IDTHUCUONG,O.TONGTIEN,O.GHICHU 
              FROM NGOCHOANG2.ORDERS O, NGOCHOANG2.GIOHANG G 
              WHERE O.ID=G.IDORDER AND G.IDUSER =USERID$
              ORDER BY ID ASC;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO ID$,IDTHUCUONG$,TONGTIEN$,GHICHU$;
      EXIT WHEN cus%NOTFOUND;
      l_tab.extend;
      l_tab(l_tab.last) := table_row4(ID$,IDTHUCUONG$,TONGTIEN$,GHICHU$);
    END LOOP;
  CLOSE  cus;
  RETURN l_tab;
END;

commit;
-------------
-- Thi hanh.--------
SET SERVEROUTPUT ON
SELECT * FROM TABLE( NGOCHOANG2.fn_getOrderByUserId(10));
------- FUCTION LOAD LIST THUC UONG THEO TEN LOAI THUC UONG -----------------------------------------------------------------
------------------------------------------------
DROP TYPE table_tab2;
DROP TYPE table_row2;

CREATE TYPE table_row2 AS OBJECT (
  ID INT,
  TENTHUCUONG NVARCHAR2(50),
  TENLTHUCUONG NVARCHAR2(50),
  DONGIA INT,
  GHICHU NVARCHAR2(50)
);

CREATE TYPE table_tab2 IS TABLE OF table_row2;
-- Build the table function

CREATE OR REPLACE FUNCTION fn_getListDrink
RETURN table_tab2 AS
l_tab  table_tab2 := table_tab2();

ID$ INT;
TENTHUCUONG$ NVARCHAR2(50);
TENLTHUCUONG$ NVARCHAR2(50);
DONGIA$ INT;
GHICHU$ NVARCHAR2(50);

CURSOR cus IS SELECT T.ID, T.TENTHUCUONG,L.TENLTHUCUONG,T.DONGIA,T.GHICHU
              FROM ThucUong T,LoaiThucUong L 
              WHERE T.idLThucUong=L.ID
              ORDER BY L.ID ASC;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO ID$,TENTHUCUONG$,TENLTHUCUONG$,DONGIA$,GHICHU$;
      EXIT WHEN cus%NOTFOUND;
      l_tab.extend;
      l_tab(l_tab.last) := table_row2(ID$,TENTHUCUONG$,TENLTHUCUONG$,DONGIA$,GHICHU$);
    END LOOP;
  CLOSE  cus;
  RETURN l_tab;
END;

commit;
-------------
-- Thi hanh.--------
SET SERVEROUTPUT ON
SELECT * FROM TABLE( fn_getListDrink);

----------------------------------------------------------------------------------------
-- FUNCTION THONG KE NHUNG DON HANG DANG CO TINH TRANG = 'DA DAT'
DROP TYPE table_tab3;
DROP TYPE table_row3;

CREATE TYPE table_row3 AS OBJECT (
  ID INT,
  NGAY DATE,
  TONGTIEN INT,
  TINHTRANG NVARCHAR2(50),
  KHACHHANG NVARCHAR2(50)
);

CREATE TYPE table_tab3 IS TABLE OF table_row3;
-- Build the table function

CREATE OR REPLACE FUNCTION fn_getListBillOrdering(DATE1$ DATE, DATE2$ DATE)
RETURN table_tab3 AS
l_tab  table_tab3 := table_tab3();

ID$ INT;
NGAY$ DATE;
TONGTIEN$ INT;
TINHTRANG$ NVARCHAR2(50);
KHACHHANG$ NVARCHAR2(50);

CURSOR cus IS SELECT H.ID,H.NGAY,H.TONGTIEN,H.TINHTRANG,K.HOTEN  
              FROM HOADON H,KHACHHANG K
              WHERE H.IDUSER=K.ID
              AND TINHTRANG='?� ??t'
              AND NGAY >= DATE1$
              AND NGAY <= DATE2$+1;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO ID$,NGAY$,TONGTIEN$,TINHTRANG$,KHACHHANG$;
      EXIT WHEN cus%NOTFOUND;
      l_tab.extend;
      l_tab(l_tab.last) := table_row3(ID$,NGAY$,TONGTIEN$,TINHTRANG$,KHACHHANG$);
    END LOOP;
  CLOSE  cus;
  RETURN l_tab;
END;

commit;
-------------
-- Thi hanh.--------
SET SERVEROUTPUT ON
SELECT * FROM TABLE( fn_getListBillOrdering('25-APR-18','26-APR-18'));
--------------------------------------------------------------------------------------------
-- FUNCTION THONG KE NHUNG DON HANG DANG CO TINH TRANG = 'DA HUY'
CREATE OR REPLACE FUNCTION fn_getListBillCanceled(DATE1$ DATE, DATE2$ DATE)
RETURN table_tab3 AS
l_tab  table_tab3 := table_tab3();

ID$ INT;
IDUSER$ INT;
NGAY$ DATE;
TONGTIEN$ INT;
TINHTRANG$ NVARCHAR2(50);
KHACHHANG$ NVARCHAR2(50);

CURSOR cus IS SELECT H.ID,H.NGAY,H.TONGTIEN,H.TINHTRANG,K.HOTEN  
              FROM HOADON H,KHACHHANG K
              WHERE H.IDUSER=K.ID
              AND TINHTRANG='?� h?y'
              AND NGAY >= DATE1$
              AND NGAY <= DATE2$+1;
BEGIN
  OPEN cus;
    LOOP 
      FETCH cus INTO ID$,NGAY$,TONGTIEN$,TINHTRANG$,KHACHHANG$;
      EXIT WHEN cus%NOTFOUND;
      l_tab.extend;
      l_tab(l_tab.last) := table_row3(ID$,NGAY$,TONGTIEN$,TINHTRANG$,KHACHHANG$);
    END LOOP;
  CLOSE  cus;
  RETURN l_tab;
END;
---------------------------------------------------------------------
------------
SELECT * FROM TABLE( fn_getListBillCanceled('01-FEB-18','30-APR-18'));
--------------------------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION fn_sumBillByUserId(IDUSER$ INT)
RETURN INT AS
TONG$ INT;
BEGIN
  SELECT SUM(TONGTIEN) INTO TONG$
  FROM HOADON 
  WHERE IDUSER=IDUSER$
  AND TINHTRANG='?� thanh to�n';
  RETURN TONG$;
END;
------
SET SERVEROUTPUT ON
BEGIN
DBMS_OUTPUT.PUT_LINE('Sum Bill: '|| fn_sumBillByUserId(1));
END;
--------------------------------------------------------------------------------------------
commit;

select * from hoadon;
select * from khachhang;
SELECT * FROM THUCUONG;
SELECT * FROM lOAITHUCUONG;
select * from user_tables;

SELECT T.ID, T.TENTHUCUONG,L.TENLTHUCUONG,T.DONGIA,T.GHICHU
FROM ThucUong T,LoaiThucUong L 
WHERE T.idLThucUong=L.ID
order by L.ID asc;

-----------------------------------------------------------------
SELECT TRUNC (TO_DATE ('20140515', 'yyyymmdd'))
       - TRUNC (TO_DATE ('20140506', 'yyyymmdd'))
           AS number_of_days
  FROM DUAL;
  
  select current_timestamp from dual;
  SELECT EXTRACT(HOUR FROM DATE '2018-04-29') FROM DUAL;
  SELECT CURRENT_TIMESTAMP FROM DUAL;
  
  with t as (select to_date(CURRENT_TIMESTAMP, 'DD-MON-YY HH.MI.SSXFF PM TZH:TZM') dt from dual)
  select to_char(dt, 'hh24')
  from   t;
  SELECT  SYSTIMESTAMP FROM DUAL; 
  SELECT  CURRENT_TIMESTAMP FROM DUAL; 
  
  TO_TIMESTAMP_TZ(CURRENT_TIMESTAMP, 'DD-MON-RR HH.MI.SSXFF PM')
  
  ALTER SESSION SET TIME_ZONE = '-8:0';
SELECT SESSIONTIMEZONE, CURRENT_TIMESTAMP FROM DUAL;

ALTER SESSION SET TIME_ZONE = '-5:0';
-- Chinh sua hien thi ngay  thang nam doi voi Kieu du lieu DATE
ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MON-YY HH24:MI:SS';
-----------------------------------------------------
SELECT SESSIONTIMEZONE, CURRENT_TIMESTAMP FROM DUAL;

select to_CHAR(to_date('27-SEP-11 03:59:00','dd-MON-yy HH24:MI:SS'),'HH24') hour from dual;

