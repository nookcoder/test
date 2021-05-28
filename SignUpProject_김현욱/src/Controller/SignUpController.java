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
		this.signup.setIdListener(new IdListener());
	}
	
	private class IdListener implements ActionListener{
		
		String inputId = signup.getId();
		
		public void actionPerformed(ActionEvent e)
		{
			try {
				if(member.checkIsHaving("id",inputId))
				{
					signup.idField.setText("");
					// 안내문구 
					signup.idField.requestFocus();
					return;
				}
				signup.addressField.setText("되나?");
				signup.passwordField.requestFocus();
				
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		}
	}
	
}
