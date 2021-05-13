package main;

import java.sql.*;

public class SearchLog {

	public void SearchLogDBConnection() {
		Connection conn = null;
		
		try {
			Class.forName("com.mysql.jdbc.Driver");
			String url = "jdbc:mysql://localhost/root";
			conn = DriverManager.getConnection(url,"root","0000");
			System.out.println("연결 성공");
		}
		 catch(ClassNotFoundException e){
	            System.out.println("드라이버 로딩 실패");
	        }
	        catch(SQLException e){
	            System.out.println("에러: " + e);
	        }
	        finally{
	            try{
	                if( conn != null && !conn.isClosed()){
	                    conn.close();
	                }
	            }
	            catch( SQLException e){
	                e.printStackTrace();
	            }
	        }
	}
}
