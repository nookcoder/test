package view.panel;

import api.Kakao;
import model.Documents;
import model.SearchResult;
import model.SqlDAO;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.ParseException;
import utils.Utils;
import view.components.AppButton;
import view.components.ImageButton;
import view.components.RoundedJTextField;
import view.frame.ImageFrame;

import javax.imageio.ImageIO;
import javax.net.ssl.HttpsURLConnection;
import javax.print.Doc;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import java.awt.image.ImageObserver;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

import static java.awt.image.ImageObserver.WIDTH;

public class MainPanel extends JPanel {
    private final RootPanel rootPanel;
    private final Utils utils;
    private final SqlDAO sqlDAO;

    private List<String> imageUrlList;
    private Kakao kakao;

    private Box container;
    private Box topBox;
    private RoundedJTextField searchTextField;
    private AppButton searchButton;
    private AppButton backButton;
    private JPanel imageArea;
    private JScrollPane scrollFrame;
    private JComboBox comboBox;

    private URL imageUrl;
    private Image changeImage;
    private int comboBoxValue;

    public MainPanel(RootPanel rootPanel, Utils utils, SqlDAO sqlDAO){
        this.rootPanel = rootPanel;
        this.utils = utils;
        this.sqlDAO = sqlDAO;
        kakao = new Kakao();
        init();
    }
    private void init(){
        container = Box.createVerticalBox();
        topBox = Box.createHorizontalBox();
        searchTextField = new RoundedJTextField(20);
        searchTextField.addActionListener(e -> {
            try {
                String word = searchTextField.getText();
                sqlDAO.executeUpdateDBWithWord(word);
                setImageArea(word,comboBoxValue);
            } catch (IOException | ParseException ex) {
                ex.printStackTrace();
            }

        });
        searchButton = new AppButton("검색하기");
        searchButton.addActionListener(e -> {
            try {
                String word = searchTextField.getText();
                sqlDAO.executeUpdateDBWithWord(word);
                setImageArea(word,comboBoxValue);
            } catch (IOException | ParseException ex) {
                ex.printStackTrace();
            }
        });
        backButton = new AppButton("뒤로가기");
        backButton.addActionListener(e -> rootPanel.convertToHomePanel(MainPanel.this));
        imageArea = new JPanel();

        String[] comboBoxValues = {"10","20","30"};
        comboBoxValue = 10;
        comboBox = new JComboBox<>(comboBoxValues);
        comboBox.addItemListener(e -> {
            if(e.getStateChange() == ItemEvent.SELECTED){
                Object selected = e.getItem();
                comboBoxValue = Integer.parseInt(selected.toString());
                try {
                    setImageArea(searchTextField.getText(),comboBoxValue);
                } catch (IOException | ParseException ex) {
                    ex.printStackTrace();
                }
            }

        });

        imageArea.setPreferredSize(new Dimension(700,400));
        scrollFrame = new JScrollPane(imageArea);
        imageArea.setAutoscrolls(true);
        scrollFrame.setPreferredSize(new Dimension(700,400));
        topBox.add(searchTextField);
        topBox.add(searchButton);
        topBox.add(backButton);
        topBox.add(comboBox);

        container.add(topBox);
        container.add(scrollFrame);
        add(container);
    }

    @Override
    public void setVisible(boolean aFlag) {
        super.setVisible(aFlag);
    }

    public void setTextOfSearchText(String text){
        searchTextField.setText(text);
    }

    public void setImageArea(String text, int comboBoxValue) throws IOException, ParseException {
        String returnData = "";
        returnData = kakao.getSearchingResponse(text);
        imageUrlList = new ArrayList<>();
        imageUrlList = kakao.getImageUrlList(returnData);
        pushImages(imageUrlList,comboBoxValue);
        imageArea.setLayout(new FlowLayout(FlowLayout.LEFT,10,10));
        imageArea.revalidate();
        imageArea.repaint();
    }

    public void pushImages(List<String> imageUrlList, int comboBoxValue) throws IOException {
        int width = utils.setWidthFromComboBoxValue(comboBoxValue);
        int height = utils.setHeightFromComboBoxValue(comboBoxValue);

        imageArea.removeAll();
        for(int index =0; index<comboBoxValue; index++){
            imageUrl = new URL(imageUrlList.get(index));
            ImageIcon image = new ImageIcon(imageUrl);
            changeImage = image.getImage().getScaledInstance(width,height,Image.SCALE_SMOOTH);
            JButton button = new JButton(new ImageIcon(changeImage));
            ImageFrame imageFrame = new ImageFrame(image.getIconWidth(), image.getIconWidth(),image.getImage());
            button.addMouseListener(new MouseAdapter(){
                @Override
                public void mouseClicked(MouseEvent e){
                    if(e.getClickCount() == 2){
                        imageFrame.open();
                    }
                }
            });
            button.setBorder(BorderFactory.createEmptyBorder());
            button.setContentAreaFilled(false);
            button.setPreferredSize(new Dimension(width,height));
            imageArea.add(button);
        }
    }
}
