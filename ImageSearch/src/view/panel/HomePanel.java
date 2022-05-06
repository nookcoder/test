package view.panel;

import model.SqlDAO;
import org.json.simple.parser.ParseException;
import view.components.AppButton;
import view.components.RoundedJTextField;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;
import java.util.Objects;

public class HomePanel extends JPanel {
    private final RootPanel rootPanel;
    private final SqlDAO sqlDAO;
    public HomePanel(RootPanel rootPanel,SqlDAO sqlDAO){
        this.rootPanel = rootPanel;
        this.sqlDAO = sqlDAO;
        init();
    }

    public void init(){
        JLabel imageLabel = new JLabel();
        ImageIcon icon = new ImageIcon(
                Objects.requireNonNull(HomePanel.class.getResource("../../static/images/googlelogo_color_160x56dp.png"))
        );
        imageLabel.setIcon(icon);
        imageLabel.setHorizontalAlignment(JLabel.CENTER);

        RoundedJTextField searchTextField = new RoundedJTextField(20);
        searchTextField.addActionListener(e -> {
            try {
                String word = searchTextField.getText();
                sqlDAO.executeUpdateDBWithWord(word);
                System.out.println("SQL");
                rootPanel.convertToMainPanel(word);
                searchTextField.setText("");
            } catch (IOException | ParseException ex) {
                ex.printStackTrace();
            }
        });
        AppButton startButton = new AppButton("검색하기");
        startButton.addActionListener(e -> {
            try {
                String word = searchTextField.getText();
                sqlDAO.executeUpdateDBWithWord(word);
                rootPanel.convertToMainPanel(word);
                searchTextField.setText("");
            } catch (IOException | ParseException ex) {
                ex.printStackTrace();
            }
        });
        AppButton logButton = new AppButton("기록보기");
        logButton.addActionListener(e -> rootPanel.convertToRecordPanel());
        setLayout(new GridLayout());

        Box box = Box.createVerticalBox();
        Box box2 = Box.createHorizontalBox();
        imageLabel.setAlignmentX(CENTER_ALIGNMENT);
        box.add(imageLabel);
        searchTextField.setAlignmentX(CENTER_ALIGNMENT);
        searchTextField.setBorder(BorderFactory.createEmptyBorder(10,10,10,10));
        box.add(searchTextField);
        box2.add(startButton);
        box2.add(logButton);
        box2.setBorder(BorderFactory.createEmptyBorder(10,0,0,0));
        box.add(box2);
        box.setBorder(BorderFactory.createEmptyBorder(150,10,10,10));
        add(box);

    }

    @Override
    public void setVisible(boolean aFlag) {
        super.setVisible(aFlag);
    }

}

