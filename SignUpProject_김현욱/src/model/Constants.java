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
	public Color LIGHE_BLUE = new Color(8,190,255);
	
	public Font SIGNUP_FONT = new Font("휴먼매직체", Font.BOLD, 15); 
	
	public String REGEX_TEXT_NUMBER = "^[0-9a-z]$";
	
	public ImageIcon SIGNUP_BACKGROUND = new ImageIcon("src/images/signupBackground.jpg");
}
