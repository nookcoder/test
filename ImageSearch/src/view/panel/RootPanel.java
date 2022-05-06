package view.panel;

import model.SqlDAO;
import org.json.simple.parser.ParseException;
import utils.Utils;

import javax.swing.*;
import java.io.IOException;

public class RootPanel extends JPanel {
    private final HomePanel homePanel;
    private final MainPanel mainPanel;
    private final RecordPanel recordPanel;
    private final Utils utils;

    private SqlDAO sqlDAO;

    public RootPanel(){
        this.utils = new Utils();
        sqlDAO = new SqlDAO();
        homePanel = new HomePanel(this,sqlDAO);
        mainPanel = new MainPanel(this,utils,sqlDAO);
        recordPanel = new RecordPanel(this,sqlDAO);
        add(homePanel);
        homePanel.setVisible(true);
        add(mainPanel);
        mainPanel.setVisible(false);
        add(recordPanel);
        recordPanel.setVisible(false);
    }

    public void convertToMainPanel(String searchingText) throws IOException, ParseException {
        homePanel.setVisible(false);
        mainPanel.setVisible(true);
        mainPanel.setTextOfSearchText(searchingText);
        mainPanel.setImageArea(searchingText,10);
    }

    public void convertToRecordPanel(){
        homePanel.setVisible(false);
        recordPanel.openRecord();
        recordPanel.setVisible(true);
    }

    public void convertToHomePanel(JPanel currentPanel){
        currentPanel.setVisible(false);
        homePanel.setVisible(true);
    }

}
