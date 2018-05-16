# Quan-ly-dat-hang-tra-sua-WindowsForm
Database management system: Oracle 12c
Khi cài đặt:
1. Thêm các file .dll để kết nối được với Oracle. Cụ thể tên 11 file là:
- oci.dll                 1,270KB
- Oracle.DataAccess.dll   2100KB
- oramts.dll              10KB
- oramts12.dll            199KB
- oramtsus.dll            58KB
- orannzsbb12.dll         4,329KB
- oraocci12.dll           1,006KB
- oraocci12d.dll          1,200KB
- oraociei12.dll          186,014KB
- oraons.dll              198KB
- OraOps12.dll            433KB

2. chỉnh properties là Copy ifever
3. Thêm file Oracle.DataAccess.dll vào References
4. Chạy file QuanLyQuanTraSua3.sql để: tạo bảng, thêm data, trigger, procedure, function 
5. Chạy file QuanLyQuanTraSuaPhanQuyen.sql để phân quyền 
- Lưu ý là mỗi user trong file phân quyền là mỗi user trong oracle luôn 
- Cần tạo một admin có username = ngochoang2, password = 12345 làm admin gốc
