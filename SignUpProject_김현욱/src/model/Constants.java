package model;

import java.awt.*;

import javax.swing.ImageIcon;

public class Constants {
	
	// ������ ���̽� ���� Constants
	public String JDBC_DRIVER = "com.mysql.jdbc.Driver"; 
	public String DB_URL = "jdbc:mysql://localhost:3306/search_log?serverTimezone=Asia/Seoul&useSSL=false";
	public String USERNAME = "root";
	public String PASSWORD = "0000";
	public String INSERTQUERY = "insert into searchrecord(text,date) values(?,?)";
	public String DELETEQUERY = "delete from searchrecord";
	public String SELECTQUERY = "select * from searchrecord";
	
	public Color YELLOW = new Color(255,185,0);
	public Color LIGHE_BLUE = new Color(8,190,255);
	
	public Font SIGNUP_FONT = new Font("휴먼매직체", Font.BOLD, 15); 
	
	public ImageIcon SIGNUP_BACKGROUND = new ImageIcon("src/images/signupBackground.jpg");
}
