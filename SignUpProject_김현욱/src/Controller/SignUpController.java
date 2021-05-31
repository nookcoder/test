package Controller;

import java.awt.Color;
import java.awt.event.*;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.swing.JPasswordField;

import com.mysql.jdbc.*;

import model.Constants;
import model.MemberDataBase;
import model.Exception;
import view.SignUp;

public class SignUpController {

	private MemberDataBase member;
	private SignUp signup;
	private Constants constants;
	private Exception exception;
	private boolean isIdCheck = false;
	private boolean isPasswordCheck = false;
	
	public SignUpController(MemberDataBase member, SignUp signup)
	{
		this.exception= new Exception();
		this.constants = new Constants();
		this.member = member;
		this.signup = signup;
		
		signup.idCheckButton.addActionListener(new IdCheckButtonListener ());
		signup.idField.addKeyListener(new IdFieldListener());
		signup.passwordField.addKeyListener(new PasswordFieldListener());
		signup.passwordCheckField.addActionListener(new PasswordCheckListener());
	}
	
	public void setError(String explanation) {
		signup.idField.setText("");
		signup.idExplanation.setForeground(Color.RED);
		signup.idExplanation.setText(explanation);
		signup.idExplanation.setForeground(Color.BLACK);
	}
	
	private class IdCheckButtonListener implements ActionListener{

		String IdCheck; 
		
		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			IdCheck = signup.idField.getText();
			if(exception.checkIdInput(IdCheck))
			{
				try {
					if(member.checkIsHaving("id",IdCheck))
					{
						setError("중복된 아이디입니다");
						isIdCheck = false;
						return; 
					}
					
					signup.idExplanation.setText("멋진 아이디네요!");
					signup.passwordField.requestFocus();
					isIdCheck = true;
					return;
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
			isIdCheck = false;
			setError("허용되지않는 형식입니다");
		}
	}
	
	private class IdFieldListener implements KeyListener{

		@Override
		public void keyTyped(KeyEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void keyPressed(KeyEvent e) {
			// TODO Auto-generated method stub
			isIdCheck = false; 
			signup.idExplanation.setText("4~12자의 영어 소문자,숫자만 사용가능합니다");
			if((e.getKeyCode() == KeyEvent.VK_TAB||e.getKeyCode() == KeyEvent.VK_ENTER) && !isIdCheck)
			{
				signup.idExplanation.setText("중복 확인을 해주세요!");	
			}
		}

		@Override
		public void keyReleased(KeyEvent e) {
			// TODO Auto-generated method stub
			
		}
	}
	
	private class PasswordFieldListener implements KeyListener{

		@Override
		public void keyTyped(KeyEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void keyPressed(KeyEvent e) {
			// TODO Auto-generated method stub
			String password = signup.getPassword();
			
			if(e.getKeyCode() == KeyEvent.VK_TAB ||e.getKeyCode() == KeyEvent.VK_ENTER)
			{
				if(exception.checkPasswordInput(password))
				{
					signup.passwordCheckField.requestFocus();
					signup.passwordExplanation.setText("사용가능합니다");
					isPasswordCheck = true;
					return;
				}
				isPasswordCheck = false;
				signup.passwordField.setText("");
				signup.passwordExplanation.setText("허용되지않는 형식입니다");
				return;
			}
			
			checkPassword(password);
			
		}

		@Override
		public void keyReleased(KeyEvent e) {
			// TODO Auto-generated method stub
			
		}
		
		public void checkPassword(String password) {
			if(exception.checkPasswordInput(password))
			{
				isPasswordCheck = true;
				signup.passwordExplanation.setText("사용가능합니다");
			}
			
			else
			{
				isPasswordCheck = false;
				signup.passwordExplanation.setText("8~16자 영문 대 소문자, 숫자를 사용하세요");
			}
		}
	}

	private class PasswordCheckListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			String passwordCheck = signup.getPasswordCheck();
			String password = signup.getPassword();
			if(passwordCheck.equals(password))
			{
				isPasswordCheck = true;
				signup.nameField.requestFocus();
				signup.passwordCheckExplanation.setText("일치합니다");
			}
			
			else
			{
				isPasswordCheck = false;
				signup.passwordCheckField.setText("");
				signup.passwordCheckExplanation.setText("비밀번호를 확인해주세요");
			}
		}
		

		
	}
}
