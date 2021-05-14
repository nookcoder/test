package panel;

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
	
	public JPanel02(ChangingJPanel change) { // 이미지 검색 패널 
		this.kakao = new KakaoCrawler();
		this.urlList = new ArrayList<String>();
		this.searchLog = new SearchLog();
		
		setLayout(null);
		
		searchButton = new JButton("검색");
		searchButton.setSize(100,60);
		searchButton.setLocation(600,90);
		
		backButton = new JButton("홈으로");
		backButton.setSize(100,60);
		backButton.setLocation(600,450);
		
		backButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel01");;
			} 
		});

		jTextPane = new JTextPane();
		jTextPane.setEditable(false);
		jscrolPane = new JScrollPane(jTextPane);
		jscrolPane.setBounds(100,150,600,300);
		
		jTextField2 = new JTextField("");
		jTextField2.setSize(500,60);
		jTextField2.setLocation(100,90);

		jTextField2.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				PushImage(); 
				try {
					searchLog.InsertSearchLog(jTextField2.getText());
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		
		});
		
		
		add(searchButton);add(jscrolPane);add(jTextField2);add(backButton);
	}
	
	public void PushImage() {
		try {
			urlList = kakao.GetImageUrlArray(jTextField2.getText());
			for(int index = 0; index < urlList.size(); index++)
			{
				URL url = new URL(urlList.get(index).toString());
				jTextPane.insertIcon(new ImageIcon(url));
			}
					
		} catch (ParseException e1){
		e1.printStackTrace();
		} catch (IOException e1) {
		e1.printStackTrace();}
	}
	
}
