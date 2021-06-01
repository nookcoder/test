package view;

import java.awt.*;

import javax.swing.*;

import model.*;

public class UserInfoView extends JFrame{
	
	private Constants constants;

	private JPanel backgroundPanel; 
	private JPanel buttonPanel;
	
	public JButton exitButton; 
	public JButton revisingButton; 
	public JButton resignButton;
	
	
	
	public UserInfoView() {
		setSize(800,597);
		getContentPane().setLayout(new BorderLayout());
		constants= new Constants();
		
		backgroundPanel = new JPanel() {
			public void paintComponent(Graphics g) {
				Dimension demension = getSize();
				Image background = constants.MYPAGE.getImage();
				g.drawImage(background, 0, 0,demension.width,demension.height,null);
				setOpaque(false);
				super.paintComponent(g);
			}
		};
		
	
		buttonPanel = new JPanel();
		buttonPanel.setBounds(334, 503, 399, 45);
		
		exitButton = new JButton("뒤로가기");
		exitButton.setBounds(63, 503, 191, 45);
		revisingButton = new JButton("정보수정");
		revisingButton.setBounds(12, 5, 152, 37);
		resignButton = new JButton("탈퇴하기");
		resignButton.setBounds(222, 5, 165, 37);
		decorateButton(exitButton);
		decorateButton(revisingButton);
		decorateButton(resignButton);
		buttonPanel.setLayout(null);
		
		buttonPanel.add(revisingButton);
		buttonPanel.add(resignButton);
		buttonPanel.setOpaque(true);
		backgroundPanel.setLayout(null);
		backgroundPanel.add(exitButton);
		backgroundPanel.add(buttonPanel);
		
		
		getContentPane().add(backgroundPanel,BorderLayout.CENTER);
		
		JPanel infoPanel = new JPanel();
		infoPanel.setBounds(298, 75, 476, 473);
		infoPanel.setBackground(constants.BLUE);
		backgroundPanel.add(infoPanel);
		setVisible(true);
	}
	
	public void decorateButton(JButton btn)
	{
		
		btn.setBackground(constants.LIGHE_BLUE);
		btn.setForeground(Color.WHITE);
		btn.setFont(constants.LOGIN_FONT);
		btn.setBorder(BorderFactory.createCompoundBorder(
				BorderFactory.createRaisedBevelBorder(),
				BorderFactory.createEmptyBorder(2, 20, 2, 20)
				));
		btn.setMargin(new Insets(5,15,5,15));
		btn.setFocusPainted(false);
	}
}
