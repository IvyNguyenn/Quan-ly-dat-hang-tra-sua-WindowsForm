
DROP ROLE Adminitrator;
DROP ROLE Customer;
------------------------------------------
---- create new row ----------------------
CREATE ROLE Adminitrator;
CREATE ROLE Customer;

------------------------------------------
GRANT CONNECT, RESOURCE TO Adminitrator;
GRANT CREATE USER TO Adminitrator;
GRANT DROP USER TO Adminitrator;
GRANT ALTER USER TO Adminitrator;
GRANT CREATE ROLE TO  Adminitrator;
----- TABLE (9)-------------------------------------
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.LOAITHUCUONG TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.THUCUONG TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.THEM TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.KHACHHANG TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.ORDERS TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.HOADON TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.GIOHANG TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.CHITIETTHEM TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.CHITIETHOADON TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.V_LOAITHUCUONG TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.V_THUCUONG TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.V_THEM TO Adminitrator;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.V_KHACHHANG TO Adminitrator;
----------------------------------------------
------ STORE PROCEDURE (17) -------------------------------------
GRANT EXECUTE ON NGOCHOANG2.sp_insertLoaiThucUong TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_DeleteLoaiThucuong TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_updateLoaiThucUong TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_insertThucUong TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_deleteThucUong TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_updateThucUong TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_insertThem TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_deleteThem TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_updateThem TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_insertKhachHang TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_deleteKhachHang TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_updateKhachHang TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_resetPassword TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_insertBill TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_cancelBill TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_payedBill TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_checkAllBill TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_resetPassword TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.sp_isAdmin TO Adminitrator;
------ FUNCTION (6) -----------------------------------------------
GRANT EXECUTE ON NGOCHOANG2.fn_Login TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.fn_ThongKeHoaDon TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.fn_getOrderByUserId TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.fn_getListDrink TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.fn_getListBillOrdering TO Adminitrator;
GRANT EXECUTE ON NGOCHOANG2.fn_getListBillCanceled TO Adminitrator;

--------------------------------------------------------------------------------
GRANT CONNECT, RESOURCE TO Customer;
GRANT ALTER USER TO Customer;
-------------------------------------------------------------------
GRANT SELECT ON NGOCHOANG2.LOAITHUCUONG TO Customer;
GRANT SELECT ON NGOCHOANG2.THUCUONG TO Customer;
GRANT SELECT ON NGOCHOANG2.THEM TO Customer;
GRANT SELECT ON NGOCHOANG2.KHACHHANG TO Customer;
GRANT SELECT,INSERT ON NGOCHOANG2.ORDERS TO Customer;
GRANT SELECT,INSERT,UPDATE ON NGOCHOANG2.HOADON TO Customer;
GRANT SELECT,INSERT,DELETE,UPDATE ON NGOCHOANG2.GIOHANG TO Customer;
GRANT SELECT,INSERT ON NGOCHOANG2.CHITIETTHEM TO Customer;
GRANT SELECT,INSERT ON NGOCHOANG2.CHITIETHOADON TO Customer;
----------------------------------------------
GRANT EXECUTE ON NGOCHOANG2.sp_resetPassword TO Customer;
GRANT EXECUTE ON NGOCHOANG2.sp_insertBill TO Customer;
GRANT EXECUTE ON NGOCHOANG2.sp_cancelBill TO Customer;
GRANT EXECUTE ON NGOCHOANG2.sp_payedBill TO Customer;
GRANT EXECUTE ON NGOCHOANG2.sp_checkAllBill TO Customer;
GRANT EXECUTE ON NGOCHOANG2.sp_resetPassword TO Customer;

GRANT EXECUTE ON NGOCHOANG2.fn_Login TO Customer;
GRANT EXECUTE ON NGOCHOANG2.fn_getListDrink TO Customer;
GRANT EXECUTE ON NGOCHOANG2.fn_getOrderByUserId TO Customer;
--- tao user ADMIN ------------------------------------
CREATE USER tshoangvy IDENTIFIED BY 12345;

--- tao user CUSTOMER ---------------------------------
DROP USER 
CREATE USER tsannguyen IDENTIFIED BY 12345;
CREATE USER tsmainguyen IDENTIFIED BY 123;
CREATE USER tsnamle IDENTIFIED BY 123123;
CREATE USER tsdaobui IDENTIFIED BY 1234;
--------------------------------------------------------------------------------
------ Gan quyen ---------------------------------------------------------------
GRANT Adminitrator TO tshoangvy;
--------------
GRANT Customer TO tsannguyen;
GRANT Customer TO tsmainguyen;
GRANT Customer TO tsnamle;
GRANT Customer TO tsdaobui;

--------------------------------------------------------------------------------
--------------------------------------------------------------------------------




