package Controller;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.*;
import java.sql.SQLException;

import javax.swing.*;

import model.*;
import view.*;

public class UserController {

	private Constants constants;
	private String id; 
	private MemberDataBase data; 
	private UserInfoView view;
	private LoginView loginView;
	
	public UserController(String _id,MemberDataBase _data,UserInfoView _view, LoginView _loginView) throws SQLException
	{
		this.constants = new Constants();
		
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
		view.revisingButton.addActionListener(new RevisingButtonListener());
		view.resignButton.addActionListener(new ResignButtonListener());
	}
	
	public void loadLoginView()
	{
		loginView.getContentPane().removeAll();
		loginView.getContentPane().add(loginView.contentPanel);
		loginView.idField.setText("");
		loginView.textField.setText("");
		loginView.okButton.setBackground(constants.BLUE);
		loginView.okButton.setEnabled(false);
		loginView.revalidate();
		loginView.repaint();

	}
	
	private class ExitButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			
			loadLoginView();
		}
	}
	
	private class RevisingButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			RevisingInfoView revise = new RevisingInfoView();
			try {
				RevisingController reviseController = new RevisingController(id,data,revise);
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		}
		
	}
	
	private class ResignButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			ResignView resign = new ResignView();
			ResignController resignController = new ResignController(id,data,resign);
		}
		
	}
}
