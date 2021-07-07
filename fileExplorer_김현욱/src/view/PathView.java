package view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.border.EmptyBorder;

import images.ImageSource;

public class PathView extends JPanel {

	private JPanel buttonPanel; 
	public JButton backButton; 
	public JButton forwardButton; 
	public JTextField pathField; 
	public JTextField searchField; 
	
	
	private ImageSource img; 
	
	public PathView()
	{
		img = new ImageSource();
		
		// 버튼 관리할 패널 생성 
		buttonPanel = new JPanel(); 
		backButton = new JButton(img.backButton); 
		backButton.addMouseListener(new ButtonMouseListener());
		forwardButton = new JButton(img.forwardButton); 
		forwardButton.addMouseListener(new ButtonMouseListener());
		setButton(backButton);
		setButton(forwardButton);
		buttonPanel.add(backButton);
		buttonPanel.add(forwardButton);
		buttonPanel.setBackground(Color.WHITE);
		buttonPanel.setPreferredSize(new Dimension(90,30));
		
		pathField = new JTextField(20);
		searchField = new JTextField(10);
		searchField.setMinimumSize(new Dimension(100,30));
		pathField.setPreferredSize(new Dimension(600,30));
		pathField.setMinimumSize(new Dimension(100,30));
		setLayout(new BorderLayout()); 
		setBorder(new EmptyBorder(2,0,0,0));
		
		add(buttonPanel, BorderLayout.WEST);
		add(pathField, BorderLayout.CENTER);
		add(searchField, BorderLayout.EAST);
	}
	
	
	public void setButton(JButton btn)
	{
		btn.setBorderPainted(false);
		btn.setContentAreaFilled(false);
		btn.setFocusPainted(false);
		btn.setPreferredSize(new Dimension(30,15));
	}
	
	private class ButtonMouseListener implements MouseListener{
		@Override
		public void mouseClicked(MouseEvent e) {
		}
		
		@Override
		public void mouseEntered(MouseEvent e) {
			JButton btn = (JButton) e.getComponent();
			btn.setContentAreaFilled(true);
			btn.setBackground(new Color(195,226,247));
		}
		
		@Override
		public void mouseExited(MouseEvent e) {
			JButton btn = (JButton) e.getSource();
			btn.setContentAreaFilled(false);
		}
		
		@Override
		public void mousePressed(MouseEvent e) {
		}
		@Override
		public void mouseReleased(MouseEvent e) {
			
		}
	}
}
