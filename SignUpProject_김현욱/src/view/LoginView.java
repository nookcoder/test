package view;


import java.awt.event.*;

import javax.swing.*;

import model.Constants;

import javax.swing.JTextField;
import java.awt.*;
import javax.swing.JLabel;
import java.awt.geom.Area;
import java.awt.geom.*;

import javax.swing.SwingConstants;
import javax.swing.border.*;
import javax.swing.*;

public class LoginView extends JFrame{

	private Constants constants;
	
	// 가장 큰 패널 
	private JPanel contentPanel;
	
	// 버튼 패널 
	private JPanel buttonPanel; 
	private JButton newIdButton;
	private JButton okButton; 
	private JButton exitButton; 
	
	
	public LoginView(){
		setUndecorated(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(800,597);
		setLocationRelativeTo(null);

		this.constants = new Constants();

		// 배경 이미지 넣기 
		contentPanel = new JPanel() {
			public void paintComponent(Graphics g) {
				Dimension demension = getSize();
				Image background = constants.LOGIN_BACKGROUND.getImage();
				g.drawImage(background, 0, 0,demension.width,demension.height,null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		contentPanel.setLayout(new BorderLayout());

		// 버튼 패널 
		buttonPanel = new JPanel(); 
		
		// 버튼 생성 
		newIdButton = new JButton("회원가입");
		okButton = new JButton("로그인");
		exitButton = new JButton("종 료");
		decorateButton(newIdButton);
		decorateButton(okButton);
		decorateButton(exitButton);
//		newIdButton.addMouseListener(new ButtonDecorate()); 
		
		buttonPanel.add(newIdButton);
		buttonPanel.add(okButton);
		buttonPanel.add(exitButton);
		buttonPanel.setLayout(new FlowLayout(FlowLayout.CENTER));
		
		contentPanel.add(buttonPanel, BorderLayout.SOUTH);
		add(contentPanel);
		setVisible(true);
	}
	
	public void decorateButton(JButton btn)
	{
		
		btn.setBackground(constants.LIGHE_BLUE);
		btn.setForeground(Color.WHITE);
		btn.setFont(constants.LOGIN_FONT);
		//btn.setContentAreaFilled(false);
		btn.setBorder(BorderFactory.createCompoundBorder(
				BorderFactory.createLineBorder(constants.BLUE, 3, true),
				BorderFactory.createEmptyBorder(2, 20, 2, 20)
				));
		btn.setMargin(new Insets(5,15,5,15));
		btn.setFocusPainted(false);
		
	}
	
	private class ButtonDecorate implements MouseListener{
		
		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO Auto-generated method stub

		}

		@Override
		public void mousePressed(MouseEvent e) {
			// TODO Auto-generated method stub

		}

		@Override
		public void mouseReleased(MouseEvent e) {
			// TODO Auto-generated method stub

		}

		@Override
		public void mouseEntered(MouseEvent e) {
			// TODO Auto-generated method stub
			e.getComponent().setBackground(e.getComponent().getBackground().darker());
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO Auto-generated method stub
			e.getComponent().setBackground(getBackground());
		}
	}
	
}

