package Controller;

import java.awt.event.*;
import java.sql.SQLException;

import model.MemberDataBase;
import view.LoginView;
import view.UserInfoView;

public class UserController {

	private String id; 
	private MemberDataBase data; 
	private UserInfoView view;
	private LoginView loginView;
	public UserController(String _id,MemberDataBase _data,UserInfoView _view, LoginView _loginView) throws SQLException
	{
		this.id = _id;
		this.data = _data;
		this.view = _view;
		this.loginView = _loginView;
		
		String name = data.getInfoText("name", id);
		String birth = data.getInfoText("birth", id);
		String phoneNumber = data.getInfoText("phoneNumber", id);
		String email = data.getInfoText("email", id);
		String address = data.getInfoText("address", id);
		
		view.userId.setText(id);
		view.userName.setText(name);
		view.userBirth.setText(birth);
		view.userPhoneNumber.setText(phoneNumber);
		view.userEmail.setText(email);
		view.userAddress.setText(address);
		view.exitButton.addActionListener(new ExitButtonListener());
	}
	
	private class ExitButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			
			loginView.getContentPane().removeAll();
			loginView.getContentPane().add(loginView.contentPanel);
			loginView.repaint();
		}
		
	}
}
