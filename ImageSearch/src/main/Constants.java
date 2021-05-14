package main;

public class Constants {

	// mysql ฐüทร 
	public String JDBC_DRIVER = "com.mysql.jdbc.Driver"; 
	public String DB_URL = "jdbc:mysql://localhost:3306/search_log?serverTimezone=Asia/Seoul&useSSL=false";
	public String USERNAME = "root";
	public String PASSWORD = "0000";
	public String INSERTQUERY = "insert into searchrecord(text,date) values(?,?)";
	public String DELETEQUERY = "delete from searchrecord";
	public String SELECTQUERY = "select * from searchrecord";
}
