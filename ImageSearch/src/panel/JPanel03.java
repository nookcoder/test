package panel;

import java.awt.Graphics;
import java.awt.event.*;
import java.sql.SQLException;

import javax.swing.*;

import main.SearchLog;

public class JPanel03 extends JPanel { // 활동내역조회 패널
	
	private SearchLog log;
	private ChangingJPanel change;

	private JButton deletButton;
	private JButton backButton;
	private JButton showLogButton;
	private JTextArea logArea; 
	private JScrollPane jscroll;
	
	public JPanel03(ChangingJPanel change) {
		this.change = change;
		this.log = new SearchLog();
		
		setLayout(null);
		
		backButton = new JButton("홈으로");
		backButton.setSize(100,60);
		backButton.setLocation(600,90);
	
		backButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				change.ChangePanel("panel01");
			}
		});
		
		deletButton = new JButton("활동내역 삭제");
		deletButton.setSize(100,60);
		deletButton.setLocation(400,90);
		
		deletButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				try {
					log.DeleteAll();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		
		logArea= new JTextArea();
		logArea.setEditable(false);

		jscroll = new JScrollPane(logArea);
		jscroll.setBounds(100,150,600,300);

		showLogButton = new JButton("활동내역 조회");
		showLogButton.setSize(100,60);
		showLogButton.setLocation(200,90);
		
		showLogButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e)
			{
				try {
					String str;
					str = log.GetSearchLogString();
					logArea.append(str);
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		
		
		add(backButton); add(deletButton); add(showLogButton); add(jscroll);
	}
}
