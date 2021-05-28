package Controller;

import java.awt.event.*;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.mysql.jdbc.*;

import model.Constants;
import model.MemberDataBase;
import view.SignUp;

public class SignUpController {

	private MemberDataBase member;
	private SignUp signup;
	private Constants constants;
	
	public SignUpController(MemberDataBase member, SignUp signup)
	{
		this.constants = new Constants();
		this.member = member;
		this.signup = signup;
	}
	
	// 데베에 정보 넣기 
	public void insertData(String id,String password,String name,String birth,String email,String phoneNumber,String address) throws SQLException
	{
		String insertQuery = constants.INSERTQUERY;
		PreparedStatement statement = (PreparedStatement) member.connection.prepareStatement(insertQuery);
		statement.setString(1, id);
		statement.setString(2, password);
		statement.setString(3, name);
		statement.setString(4, birth);
		statement.setString(5, email);
		statement.setString(6, phoneNumber);
		statement.setString(7, address);
		statement.executeUpdate();
	}
	
	public boolean checkIsHaving(String data,String check) throws SQLException
	{
		boolean isHaving = false;
		String selecQuery = constants.SELECTQUERY;
		Statement statement = (Statement) member.connection.createStatement();
		ResultSet resultset = statement.executeQuery(selecQuery);
	
		while(resultset.next())
		{
			if(check == resultset.getString("\"" + data + "\""))
			{
				isHaving = true;
			}
		}
		
		return isHaving; 
	}
	
//	private class InsertListener implements ActionListener{
//		
//	}
}
