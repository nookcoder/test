package model;

import java.awt.*;

import javax.swing.BorderFactory;
import javax.swing.ImageIcon;
import javax.swing.JButton;

public class Constants {
	
	// ������ ���̽� ���� Constants
	public String JDBC_DRIVER = "com.mysql.jdbc.Driver"; 
	public String DB_URL = "jdbc:mysql://localhost:3306/signup?serverTimezone=Asia/Seoul&useSSL=false";
	public String USERNAME = "root";
	public String PASSWORD = "0000";
	public String INSERTQUERY = "insert into member_info(id,password,name,birth,email,phoneNumber,address) values(?,?,?,?,?,?,?)";
	public String DELETEQUERY = "delete from member_info";
	public String SELECTQUERY = "select * from member_info";
	
	public Color DARKER_YELLOW = new Color(255,85,30);
	public Color YELLOW = new Color(240,160,11);
	public Color LIGHE_BLUE = new Color(60,212,254);
	public Color MIDDLE_BLUE = new Color(25,157,255);
	public Color BLUE = new Color(33,91,190);
	
	public Font SERVER_FONT = new Font("한컴 고딕", Font.BOLD, 10); 
	public Font SIGNUP_FONT = new Font("한컴 고딕", Font.BOLD, 15); 
	public Font LOGIN_FONT = new Font("한컴 고딕",Font.BOLD,14);
	public Font FIELD_LABEL_FONT = new Font("한컴 고딕",Font.BOLD,16);
	public Font EXPLANINATION_FONT = new Font("한컴 고딕",Font.PLAIN,12);
	
	public String TEXT_NUMBER = "^[a-z0-9]{5,12}$";
	
	public ImageIcon SIGNUP_BACKGROUND = new ImageIcon("src/images/signupBackground.jpg");
	public ImageIcon LOGIN_BACKGROUND = new ImageIcon("src/images/background.jpg");
	public ImageIcon BLUE_BACKGROUND = new ImageIcon("src/images/bluebackground.jpg");
	public ImageIcon OK_BUTTON = new ImageIcon("src/images/okbtn.png");
	public ImageIcon LOGIN_BUTTON = new ImageIcon("src/images/loginbtn.png");
	public ImageIcon SIGNUP_BUTTN = new ImageIcon("src/images/signUpbtn.png");
	public ImageIcon EXIT_BUTTON = new ImageIcon("src/images/exitbtn.png");
	public ImageIcon PLAYER1 = new ImageIcon("src/images/1p.png");
	public ImageIcon PLATER2 = new ImageIcon("src/images/2p.png");

	public String ID_REGEX = "^[a-z0-9]{4,12}"; 
	public String PASSWORD_REGEX = "^[a-zA-Z0-9]{8,16}"; 
	public String NAME_REGEX  = "^[가-힣]{2,4}";
	public String BIRTH_REGEX = "\\d{6}";
	public String PHONENUMBER_REGEX = "^010(\\d{4})(\\d{4})$";
	public String EMAIL_REGEX = "^[0-9a-zA-Z]*@[0-9a-zA-Z]*.[a-zA-Z]{2,3}$";
	public void decorateButton(JButton btn)
	{
		
		btn.setBackground(BLUE);
		btn.setForeground(Color.WHITE);
		btn.setFont(LOGIN_FONT);
		btn.setBorder(BorderFactory.createCompoundBorder(
				BorderFactory.createRaisedBevelBorder(),
				BorderFactory.createEmptyBorder(2, 20, 2, 20)
				));
		btn.setMargin(new Insets(5,15,5,15));
		btn.setFocusPainted(false);
	}
}
