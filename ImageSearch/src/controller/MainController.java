package controller;

import model.SqlDAO;
import view.frame.MainFrame;
import view.panel.RootPanel;

public class MainController {

    public void start(){
        RootPanel rootPanel = new RootPanel();
        MainFrame mainFrame = new MainFrame(rootPanel);
    }
}
