package api;

import java.sql.*;

public class MysqlDatabase {
    private static Connection mysqlDatabase;

    public MysqlDatabase(){}

    public static Connection getConnection(){
        try {
            mysqlDatabase = DriverManager.getConnection("jdbc:mysql://localhost:3306/image_search", "root", "00000000");
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return mysqlDatabase;
    }
}
