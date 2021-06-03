package Controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.SQLException;

import model.*;
import model.Exception;
import view.*;

public class RevisingController {
	
	private boolean isError = false;
	private Exception exception;
	private MemberDataBase member;
	private RevisingInfoView revising;
	private String id; 
	
	public RevisingController(String _id,MemberDataBase _member, RevisingInfoView _revising) throws SQLException {
		this.member = _member;
		this.revising = _revising;
		this.id = _id; 
		this.exception = new Exception();
		
		revising.idField.setText(id);
		revising.nameField.setText(member.getInfoText("name", id));
		revising.birthField.setText(member.getInfoText("birth", id));
		revising.textField.setText(member.getInfoText("phoneNumber", id));
		revising.emailField.setText(member.getInfoText("email", id));
		revising.addressField.setText(member.getInfoText("address", id));
	}
	
	private class OkButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			
		}
		
	}
	
	private class PhoneNumberListenr implements ActionListener{

		String phoneNumber;
		@Override
		public void actionPerformed(ActionEvent e) {
			phoneNumber = revising.textField.getText();
			// TODO Auto-generated method stub
			if(exception.checkPhoneNumberInput(phoneNumber))
			{
				try {
					if(member.checkIsHaving("phoneNumber",phoneNumber))
					{
						isError = true;
						revising.phoneNumberExplanation.setText("중복된 번호입니다");
						revising.phoneNumberField.setText("");
						return;
					}
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				isError = false;
				revising.phoneNumberExplanation.setText("확인됐습니다");
			}
			
			else {
				isError = true;
				revising.phoneNumberField.setText("");
				revising.phoneNumberExplanation.setText("잘못된 형식입니다");	
			}
		}
		
	}
	
	private class EmailListenr implements ActionListener{

		String email;
		@Override
		public void actionPerformed(ActionEvent e) {
			email = revising.emailField.getText();
			// TODO Auto-generated method stub
			if(exception.checkEmailInput(email))
			{
				try {
					if(member.checkIsHaving("email", email))
					{
						isError = true;
						revising.emailExplanation.setText("중복된 이메일입니다");
						revising.emailField.setText("");
						return;
					}
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				isError = false;
				revising.emailExplanation.setText("확인됐습니다");
			}
			
			else {
				isError = true;
				revising.emailField.setText("");
				revising.emailExplanation.setText("잘못된 형식입니다");	
			}
		}
		
	}
	
	
}
