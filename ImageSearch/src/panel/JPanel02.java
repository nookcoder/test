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

import org.json.simple.parser.ParseException;
import main.KakaoCrawler;
import main.SearchLog;
public class JPanel02 extends JPanel{

	private ArrayList<String> urlList;
	private JButton searchButton;
	private JButton backButton;
	private JScrollPane jscrolPane;
	private JTextPane jTextPane; 
	private JTextField jTextField2;
	private KakaoCrawler kakao;
	private SearchLog searchLog;
	private GridLayout grid;
	private JLabel jLabel;
	private JPanel imgPanel;
	
	public JPanel02(ChangingJPanel change) { // 이미지 검색 패널 
		this.kakao = new KakaoCrawler();
		this.urlList = new ArrayList<String>();
		this.searchLog = new SearchLog();
		this.grid = new GridLayout(5,2);
		this.jLabel = new JLabel();
		this.imgPanel = new JPanel();
		
		setLayout(null);
		
		MakeSearchButton(change);
		MakeBackButton(change);
		
		jTextPane = new JTextPane();
		jTextPane.setEditable(false);
		
		jTextField2 = new JTextField("");
		jTextField2.setSize(400,40);
		jTextField2.setLocation(50,30);

		jTextField2.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				// 이미지 넣기 
				PushImage(); 
				
				// 활동 내역 기록하기
				try {
					searchLog.InsertSearchLog(jTextField2.getText());
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		
		});
		

		jscrolPane = new JScrollPane(jTextPane);
		jscrolPane.setBounds(50,70,500,250);
		
		add(jscrolPane);add(jTextField2); 
	}
	
	public void MakeSearchButton(ChangingJPanel change) {
		searchButton = new JButton("검색");
		searchButton.setSize(100,40);
		searchButton.setLocation(450,30);
		
		searchButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				// 이미지 넣기 
				PushImage(); 
				
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
		backButton.setSize(100,40);
		backButton.setLocation(450,320);
		
		backButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel01");;
			} 
		});
		
		add(backButton);
	}
	
	public void PushImage() {
	
		try {
			urlList = kakao.GetImageUrlArray(jTextField2.getText(), 10);
			for(int index = 0; index < urlList.size(); index++)
			{
				URL url = new URL(urlList.get(index).toString());
				ImageIcon img = new ImageIcon(url);
				Image changedImg= img.getImage().getScaledInstance(200, 150, Image.SCALE_SMOOTH );
				ImageIcon Icon = new ImageIcon(changedImg);
				jLabel = new JLabel(Icon);
				imgPanel.add(jLabel);
			}
			imgPanel.setLayout(grid);
			jTextPane.insertComponent(imgPanel);
					
		} catch (ParseException e1){
		e1.printStackTrace();
		} catch (IOException e1) {
		e1.printStackTrace();}
		
	}
	
}
