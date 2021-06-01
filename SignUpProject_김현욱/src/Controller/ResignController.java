package Controller;

import model.*;
import view.*;
import java.awt.*;
import java.awt.event.*;
import java.sql.SQLException;

public class ResignController {
	
	private MemberDataBase data;
	private ResignView resign;
	private String id;
	private Constants constants;
	
	public ResignController(String _id, MemberDataBase _data, ResignView _resign)
	{
		this.constants = new Constants();
		this.data = _data; 
		this.resign = _resign;
		this.id = _id;
		
		resign.okayButton.addActionListener(new OkayButtonListener());
	}
	
	private class OkayButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			String password = new String(resign.password.getPassword());
			String passwordCheck = new String(resign.passwordCheck.getPassword());
		
			try {
				if(data.isCorrectId(id,password) && password.equals(passwordCheck))
				{
					data.deleteData(id);
					resign.setVisible(false);
				}
				else
				{
					resign.noFind.setText("비밀번호가 일치하지않습니다");
					resign.password.setText("");
					resign.passwordCheck.setText("");
				}
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		}
		
	}
}
