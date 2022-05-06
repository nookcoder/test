package model;

import api.MysqlDatabase;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class SqlDAO {
    PreparedStatement preparedStatement;

    public void executeUpdateDBWithWord(String word){
        System.out.println(word);
        if(isDuplicatedWord(word)){
            updateSearchingWord(word);
            return;
        }
        insertSearchingWord(word);
    }

    private void insertSearchingWord(String word) {
        try {
            String sql = "INSERT INTO new_table(word) VALUES(?)";
            preparedStatement = MysqlDatabase.getConnection().prepareStatement(sql);
            preparedStatement.setString(1, word);

            preparedStatement.executeUpdate();

        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            try {
                if (preparedStatement != null) {
                    preparedStatement.close();
                }
                if (MysqlDatabase.getConnection() != null) {
                    MysqlDatabase.getConnection().close();
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    private void updateSearchingWord(String word) {
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        Date date = new Date();
        String currentTime = format.format(date);
        String query = String.format("UPDATE new_table SET updated_at='%s' WHERE word='%s';", currentTime, word);

        try {
            preparedStatement = MysqlDatabase.getConnection().prepareStatement(query);
            preparedStatement.executeUpdate(query);
        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            try {
                if (preparedStatement != null) {
                    preparedStatement.close();
                }
                if (MysqlDatabase.getConnection() != null) {
                    MysqlDatabase.getConnection().close();
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    private boolean isDuplicatedWord(String word) {
        try {
            String query = "SELECT word FROM new_table WHERE word = '" + word + "'";
            preparedStatement = MysqlDatabase.getConnection().prepareStatement(query);
            ResultSet resultSet = preparedStatement.executeQuery();
            return resultSet.next();
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    public ArrayList<RecordVO> inquireRecord(){
        ArrayList<RecordVO> recordVOArrayList = new ArrayList<>();
        String query = "SELECT word, updated_at FROM new_table ORDER BY updated_at desc";
        try {
            preparedStatement = MysqlDatabase.getConnection().prepareStatement(query);
            ResultSet resultSet = preparedStatement.executeQuery();
            while (resultSet.next()) {
                RecordVO recordVO = new RecordVO(resultSet.getString("word"), resultSet.getString("updated_at"));
                recordVOArrayList.add(recordVO);
            }
            return recordVOArrayList;
        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            try {
                if(preparedStatement != null){
                    preparedStatement.close();
                }
                if(MysqlDatabase.getConnection() != null){
                    MysqlDatabase.getConnection().close();
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }

        return recordVOArrayList;
    }

    public void deleteAllRecord(){
        String query = "DELETE FROM new_table";
        try {
            preparedStatement = MysqlDatabase.getConnection().prepareStatement(query);
            preparedStatement.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }finally {
            try {
                if(preparedStatement != null){
                    preparedStatement.close();
                }
                if(MysqlDatabase.getConnection() != null){
                    MysqlDatabase.getConnection().close();
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }


    }
}

