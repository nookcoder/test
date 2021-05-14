package data;

import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.ArrayList;


public class SearchLogWithMySql { // mysql 에서 활동내역을 관리할 클래스 
	
	private Constants constant;
	private Connection conn;
	private PreparedStatement pstmt;
	private SimpleDateFormat dateFormat = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss");
	
	public SearchLogWithMySql() {
		
		this.constant = new Constants();
		
		// mysql 에 연결하기 
		try {
			Class.forName(constant.JDBC_DRIVER);
			conn = DriverManager.getConnection(constant.DB_URL,constant.USERNAME,constant.PASSWORD);
			
		} catch (ClassNotFoundException e) { 
			e.printStackTrace(); 
		} catch (SQLException e) { 
			e.printStackTrace();
		}
	}
	
	// 활동 내역 DB 에 저장하기 
	public void InsertSearchLog(String text) throws SQLException {
		String InsertQuery = constant.INSERTQUERY; 
		pstmt = conn.prepareStatement(InsertQuery);
		pstmt.setString(1,text);
		pstmt.setString(2,dateFormat.format(System.currentTimeMillis()).toString());
		pstmt.executeUpdate();
	}
	
	// 활동 내역 초기화 
	public void DeleteAll() throws SQLException {
		String deleteQuery = constant.DELETEQUERY;
		pstmt = conn.prepareStatement(deleteQuery);
		pstmt.executeUpdate();
	}
	
	// 활동 내역 출력하기 
	public String GetSearchLogString() throws SQLException {
		String selectQuery = constant.SELECTQUERY;
		String searchLogStr ="";
		pstmt = conn.prepareStatement(selectQuery);
		ResultSet rs = pstmt.executeQuery(selectQuery);
		
		int count = 0;
		
		while(rs.next()) {
			searchLogStr += "검색 시간 : "+rs.getString("date") + "   검색어 : "+rs.getString("text") +"\n";
		}
		
		return searchLogStr;
	}
}
