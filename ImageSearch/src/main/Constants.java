package main;

import java.awt.Color;
import java.awt.Font;

import javax.swing.JButton;

public class Constants {

	// mysql ฐüทร 
	public String JDBC_DRIVER = "com.mysql.jdbc.Driver"; 
	public String DB_URL = "jdbc:mysql://localhost:3306/search_log?serverTimezone=Asia/Seoul&useSSL=false";
	public String USERNAME = "root";
	public String PASSWORD = "0000";
	public String INSERTQUERY = "insert into searchrecord(text,date) values(?,?)";
	public String DELETEQUERY = "delete from searchrecord";
	public String SELECTQUERY = "select * from searchrecord";
	
	public void DecorateButton(JButton button) {
		Font font = new Font("SansSerif",Font.BOLD,30);
		button.setForeground(Color.yellow);
		button.setFont(font);
		button.setBorder(null);
		button.setBackground(new Color(62,34,36));
		button.setFocusPainted(false);
	}
	
	public void DecorateButtonJpanel02(JButton button) {
		Font font = new Font("SansSerif",Font.BOLD,10);
		button.setForeground(Color.yellow);
		button.setFont(font);
		button.setBorder(null);
		button.setBackground(new Color(62,34,36));
		button.setFocusPainted(false);
	}
}
