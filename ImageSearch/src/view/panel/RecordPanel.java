package view.panel;

import model.RecordVO;
import model.SqlDAO;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

public class RecordPanel extends JPanel {
    private final RootPanel rootPanel;
    private final SqlDAO sqlDAO;

    private JPanel recordArea;
    private JScrollPane scrollPane;
    private JTextField wordTitle;
    private JTextField timeTitle;
    private JLabel label;
    private JButton backButton;
    private JButton deleteButton;
    private JTextField searchedWord;
    private JTextField searchedTime;
    private Box container;
    private Box titleBox;
    private Box footer;

    private ArrayList<RecordVO> recordVOArrayList;

    public RecordPanel(RootPanel rootPanel, SqlDAO sqlDAO){
        this.rootPanel = rootPanel;
        this.sqlDAO = sqlDAO;

        init();
        openRecord();
    }
    private void init(){
        recordArea = new JPanel();
        footer = Box.createHorizontalBox();
        footer.setBorder(BorderFactory.createEmptyBorder(0,130,0,0));
        label = new JLabel("검색 기록");
        label.setFont(new Font("", Font.BOLD, 30));
        label.setBorder(BorderFactory.createEmptyBorder(0,0,10,100));
        deleteButton = new JButton("←");
        deleteButton.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent e) {
                super.mouseClicked(e);
                if(e.getClickCount() == 1){
                    rootPanel.convertToHomePanel(RecordPanel.this);
                }
            }
        });
        Box layoutBox = Box.createVerticalBox();
        layoutBox.add(label);
        scrollPane = new JScrollPane(recordArea);
        layoutBox.add(scrollPane);
        backButton = new JButton("삭제");
        backButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                delete();
                reset();
                openRecord();
            }
        });
        recordArea.setPreferredSize(new Dimension(400,450));
        scrollPane.setPreferredSize(new Dimension(450,450));
        wordTitle = new JTextField("검색한 단어");
        timeTitle = new JTextField("검색한 시간");
        wordTitle.setPreferredSize(new Dimension(50,30));
        wordTitle.setOpaque(false);
        wordTitle.setBackground(null);
        wordTitle.setBorder(null);
        wordTitle.setEditable(false);
        timeTitle.setOpaque(false);
        timeTitle.setBackground(null);
        timeTitle.setBorder(null);
        timeTitle.setEditable(false);

        titleBox = Box.createHorizontalBox();
        titleBox.setOpaque(true);
        titleBox.setBackground(Color.white);
        titleBox.setPreferredSize(new Dimension(450,30));
        titleBox.setBorder(BorderFactory.createEmptyBorder(0,80,0,0));
        container = Box.createVerticalBox();

        footer.add(deleteButton);
        footer.add(backButton);
        layoutBox.add(footer);
        add(layoutBox);
    }

    public void openRecord(){
        titleBox.removeAll();
        container.removeAll();
        titleBox.add(wordTitle);
        titleBox.add(timeTitle);
        container.add(titleBox);
        recordVOArrayList = sqlDAO.inquireRecord();
        for (int i =0; i < recordVOArrayList.size(); i++){
            JTextField time = new JTextField(recordVOArrayList.get(i).getTime());
            JTextField word = new JTextField(recordVOArrayList.get(i).getWord());
            word.setPreferredSize(new Dimension(210,30));
            word.setOpaque(false);
            word.setBackground(null);
            word.setBorder(null);
            word.setEditable(false);
            word.setBorder(BorderFactory.createEmptyBorder(0,80,0,0));
            time.setOpaque(false);
            time.setBackground(null);
            time.setBorder(null);
            time.setEditable(false);
            time.setBorder(BorderFactory.createEmptyBorder(0,0,0,80));

            Box box = Box.createHorizontalBox();

            box.add(word);
            box.add(time);
            container.add(box);
        }
        recordArea.add(container);
        titleBox.revalidate();
        titleBox.repaint();
        container.revalidate();
        container.repaint();
    }
    private void delete(){
        sqlDAO.deleteAllRecord();
    }

    private void reset(){
        titleBox.removeAll();
        container.removeAll();
    }

    @Override
    public void setVisible(boolean aFlag) {
        super.setVisible(aFlag);
    }
}
