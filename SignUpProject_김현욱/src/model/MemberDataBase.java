package model;

import java.sql.*;

public class MemberDataBase {
	private Constants constants;
	public Connection connection; 
	public Statement statement; 
	public ResultSet resultset;
	
	public MemberDataBase() {
		this.constants = new Constants();
		this.connection = null; 
		this.statement = null; 
		this.resultset = null;
		
		try {
			Class.forName(constants.JDBC_DRIVER);
			connection = DriverManager.getConnection(constants.DB_URL,constants.USERNAME,constants.PASSWORD);
		} catch (ClassNotFoundException e) { 
			e.printStackTrace(); 
		} catch (SQLException e) { 
			System.out.println("SQL Exception : " + e.getMessage()); 
			e.printStackTrace(); 
		}
	}
}
