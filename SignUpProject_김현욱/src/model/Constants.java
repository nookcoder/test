package model;

import java.awt.*;

import javax.swing.ImageIcon;

public class Constants {
	
	// ������ ���̽� ���� Constants
	public String JDBC_DRIVER = "com.mysql.jdbc.Driver"; 
	public String DB_URL = "jdbc:mysql://localhost:3306/signup?serverTimezone=Asia/Seoul&useSSL=false";
	public String USERNAME = "root";
	public String PASSWORD = "0000";
	public String INSERTQUERY = "insert into member_info(id,password,name,birth,email,phoneNumber,address) values(?,?,?,?,?,?,?)";
	public String DELETEQUERY = "delete from member_info";
	public String SELECTQUERY = "select * from member_info";
	
	public Color YELLOW = new Color(255,185,0);
	public Color LIGHE_BLUE = new Color(60,212,254);
	public Color BLUE = new Color(33,91,190);
	
	public Font SIGNUP_FONT = new Font("휴먼매직체", Font.BOLD, 15); 
	public Font LOGIN_FONT = new Font("한컴 고딕",Font.BOLD,14);
	
	public String TEXT_NUMBER = "^[a-z0-9]{5,12}$";
	
	public ImageIcon SIGNUP_BACKGROUND = new ImageIcon("src/images/signupBackground.jpg");
	public ImageIcon LOGIN_BACKGROUND = new ImageIcon("src/images/background.jpg");
	public ImageIcon OK_BUTTON = new ImageIcon("src/images/okbtn.png");
	public ImageIcon LOGIN_BUTTON = new ImageIcon("src/images/loginbtn.png");
	public ImageIcon SIGNUP_BUTTN = new ImageIcon("src/images/signUpbtn.png");
	public ImageIcon EXIT_BUTTON = new ImageIcon("src/images/exitbtn.png");
}
