package main;

import java.awt.event.*;
import javax.swing.*;

public class JPanel02 extends JPanel{

	private JButton searchButton;
	private JButton backButton;
	private JScrollPane jscrolPane;
	private JTextArea jTextArea2; 
	private JTextField jTextField2;
	private ChangingJPanel change;
	
	public JPanel02(ChangingJPanel change) {
		this.change = change;
		setLayout(null);
		
		searchButton = new JButton("두번째");
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
		
		jTextArea2 = new JTextArea();
		jscrolPane = new JScrollPane(jTextArea2);
		jscrolPane.setBounds(100,150,600,300);
		
		jTextField2 = new JTextField("");
		jTextField2.setSize(500,60);
		jTextField2.setLocation(100,90);
		
		add(searchButton);add(jscrolPane);add(jTextField2);add(backButton);
	}
}
