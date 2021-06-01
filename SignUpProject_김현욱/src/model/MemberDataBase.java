package model;

import java.sql.*;

import com.mysql.jdbc.PreparedStatement;
import com.mysql.jdbc.Statement;

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
	
	// 데베에 정보 넣기 
	public void insertData(String id,String password,String name,String birth,String email,String phoneNumber,String address) throws SQLException
	{
		String insertQuery = constants.INSERTQUERY;
		PreparedStatement statement = (PreparedStatement) connection.prepareStatement(insertQuery);
		statement.setString(1, id);
		statement.setString(2, password);
		statement.setString(3, name);
		statement.setString(4, birth);
		statement.setString(5, email);
		statement.setString(6, phoneNumber);
		statement.setString(7, address);
		statement.executeUpdate();
	}
	
	public void deleteData(String id) throws SQLException
	{
		String deleteQuery = constants.DELETEQUERY+" "+ "where id='"+id+"';";
		Statement statement = (Statement)connection.createStatement();
		statement.executeUpdate(deleteQuery);
	}
	
	public boolean checkIsHaving(String data,String check) throws SQLException
	{
		boolean isHaving = false;
		String selecQuery = constants.SELECTQUERY;
		Statement statement = (Statement)connection.createStatement();
		ResultSet resultset = statement.executeQuery(selecQuery);
	
		while(resultset.next())
		{
			if(check.equals(resultset.getString(data)))
			{
				isHaving = true;
			}
		}
		
		return isHaving; 
	}
	
	public boolean isCorrectId(String id,String password) throws SQLException
	{
		boolean isCorrect = false; 
		String selecQuery = constants.SELECTQUERY+" "+ "where id='"+id+"';";
		Statement statement = (Statement)connection.createStatement();
		ResultSet resultSet = statement.executeQuery(selecQuery);
		
		while(resultSet.next()) {
			if(resultSet.getString("password").equals(password))
			{
				isCorrect = true;
			}
		}
		
		return isCorrect;
	}
	
	public String getInfoText(String type,String id) throws SQLException
	{
		String selecQuery = constants.SELECTQUERY+" "+ "where id='"+id+"';";
		Statement statement = (Statement)connection.createStatement();
		ResultSet resultSet = statement.executeQuery(selecQuery);
		String userInfo;
		
		resultSet.next(); 
		userInfo = resultSet.getString(type);
		
		
		return userInfo;
	}
}
