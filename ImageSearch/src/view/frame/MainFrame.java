package view.frame;

import model.SqlDAO;
import utils.Utils;
import view.panel.RootPanel;

import javax.swing.*;
import java.awt.*;

public class MainFrame extends JFrame {
    private final RootPanel rootPanel;
    public MainFrame(RootPanel rootPanel) throws HeadlessException {
        this.rootPanel = rootPanel;
        init();
    }

    public void init(){
        setSize(800,600);
        setResizable(false);
        add(rootPanel,BorderLayout.CENTER);
        setLocationRelativeTo(null);
        setVisible(true);
        setTitle("En# 이미지 서치");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
}
