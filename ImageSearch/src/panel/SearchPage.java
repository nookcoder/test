package panel;

import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.Image;
import java.awt.event.*;
import java.io.IOException;
import java.net.URL;
import java.sql.SQLException;
import java.util.ArrayList;

import javax.swing.*;
import javax.swing.text.BadLocationException;
import javax.swing.text.PlainDocument;

import org.json.simple.parser.ParseException;

import data.Constants;
import data.KakaoCrawler;
import data.SearchLogWithMySql;
public class SearchPage extends JPanel{

	private Constants constant = new Constants();
	private ArrayList<String> urlList;
	private JButton searchButton;
	private JButton backButton;
	private JScrollPane jscrolPane;
	private JTextPane jTextPane; 
	private JTextField jTextField2;
	private KakaoCrawler kakao;
	private SearchLogWithMySql searchLog;
	private GridLayout grid;
	private JLabel jLabel;
	private JButton imgButton;
	private JPanel imgPanel;
	private JComboBox<String> comboBox;
	private String count[] = {"10","20","30"};
	private int imageCount = 10; 
	
	public SearchPage(ChangingJPanel change) throws SQLException { // 이미지 검색 패널 
		this.kakao = new KakaoCrawler();
		this.urlList = new ArrayList<String>();
		this.searchLog = new SearchLogWithMySql();
		this.grid = new GridLayout(5,2);
		this.jLabel = new JLabel();
		this.imgPanel = new JPanel();
		
		setLayout(null);
		
		MakeSearchButton(change);
		MakeBackButton(change);

		comboBox = new JComboBox(count);
		
		comboBox.setBounds(320, 40, 50, 30);
		
		comboBox.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e) {
				int index = comboBox.getSelectedIndex();
				switch(index) {
					case 0:
						grid = new GridLayout(5,2);
						imageCount = 10;
						break;
					case 1 : 
						grid = new GridLayout(10,2);
						imageCount = 20;
						break;
					case 2 : 
						grid = new GridLayout(15,2);
						imageCount = 30;
						break;	
				}
			}
		});
		
		jTextPane = new JTextPane();
		jTextPane.setEditable(false);
		
		jTextField2 = new JTextField("");
		jTextField2.setSize(300,30);
		jTextField2.setLocation(20,10);

		jTextField2.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				// 이미지 넣기 
				try {
					PushImage(imageCount);
				} catch (BadLocationException e2) {
					// TODO Auto-generated catch block
					e2.printStackTrace();
				} 
				
				// 활동 내역 기록하기
				try {
					String text = jTextField2.getText();
					
					// 중복된 단어면 갱신해주고, 처음 입력한 단어면 기록하기
					if(!searchLog.IsRecorded(text))
					{
						searchLog.UpdateRecordedText(text);
					}
					else { searchLog.InsertSearchLog(text); }
					
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		
		});
		

		jscrolPane = new JScrollPane(jTextPane);
		jscrolPane.setBounds(17,90,350,430);
		
		add(jscrolPane);add(jTextField2); add(comboBox);
	}
	
	public void MakeSearchButton(ChangingJPanel change) {
		searchButton = new JButton("검색");
		searchButton.setSize(50,30);
		searchButton.setLocation(320,10);
		constant.DecorateButtonJpanel02(searchButton);
		
		searchButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{	
				// 이미지 넣기 
				try {
					PushImage(imageCount);
				} catch (BadLocationException e2) {
					// TODO Auto-generated catch block
					e2.printStackTrace();
				} 
				
				// 활동 내역 기록하기
				try {
					searchLog.InsertSearchLog(jTextField2.getText());
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		
		add(searchButton);
	}
	
	public void MakeBackButton(ChangingJPanel change) {
		
		backButton = new JButton("홈으로");
		backButton.setSize(100,20);
		backButton.setLocation(265,520);
		constant.DecorateButtonJpanel02(backButton);
		
		backButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel01");;
			} 
		});
		
		add(backButton);
	}
	
	public void PushImage(int imageCount) throws BadLocationException {
	
		try {
			urlList = kakao.GetImageUrlArray(jTextField2.getText(), imageCount);

			for(int index = 0; index < urlList.size(); index++)
			{
				URL url = new URL(urlList.get(index).toString());
				ImageIcon img = new ImageIcon(url);
				Image changedImg= img.getImage().getScaledInstance(200, 150, Image.SCALE_SMOOTH );
				ImageIcon Icon = new ImageIcon(changedImg);
				imgButton = new JButton(Icon);
				imgPanel.add(imgButton);
			}
			imgPanel.setLayout(grid);
			jTextPane.insertComponent(imgPanel);
					
		} catch (ParseException e1){
		e1.printStackTrace();
		} catch (IOException e1) {
		e1.printStackTrace();}
	}
	
	
}
