package Controller;

import java.awt.BorderLayout;
import java.awt.event.*;
import java.sql.SQLException;

import javax.swing.*;

import com.mysql.jdbc.DatabaseMetaData;

import model.*;
import view.*;

public class LoginController {

	private MemberDataBase data; 
	private LoginView login;
	
	public LoginController(MemberDataBase _data, LoginView _login)
	{
		this.data = _data; 
		this.login = _login;
		login.newIdButton.addActionListener(new ButtonListener());
		login.okButton.addActionListener(new ButtonListener());
		login.exitButton.addActionListener(new ButtonListener());
		
	}
	
	private class ButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			JButton btn = (JButton)e.getSource();
			if(btn.getText().equals("회원가입"))
			{
				SignUp signup = new SignUp();
				SignUpController signUpController = new SignUpController(data,signup);
				signup.setVisible(true);
			}
			
			else if(btn.getText().equals("로그인"))
			{
				String id;
				String password;
				try {
					id =  login.idField.getText();
					password = login.textField.getText();
					if(data.isCorrectId(id, password))
					{
						UserInfoView userInfoView = new UserInfoView();
						UserController userController = new UserController(id,data,userInfoView,login);
						login.getContentPane().removeAll();
						login.getContentPane().add(userInfoView);
						login.revalidate();
						login.repaint();
					}
					
					else {
						login.idField.setText("");
						login.textField.setText("");
					}
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
			
			else if(btn.getText().equals("종 료"))
			{
				System.exit(0);
			}
		}
		
	}
}
