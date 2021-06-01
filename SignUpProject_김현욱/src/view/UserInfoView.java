package view;

import java.awt.*;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.*;

import model.*;

public class UserInfoView extends JPanel{
	
	private Constants constants;

	private JPanel backgroundPanel; 
	private JPanel buttonPanel;
	
	public JButton exitButton; 
	public JButton revisingButton; 
	public JButton resignButton;
	
	public JLabel userId;
	public JLabel userName;
	public JLabel userBirth;
	public JLabel userPhoneNumber;
	public JLabel userEmail;
	public JLabel userAddress;
	
	public UserInfoView() {
		constants= new Constants();
		setLayout(new BorderLayout());
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
		exitButton.setBounds(63, 540, 200, 45);
		exitButton.addMouseListener(new ButtonDecorate());
		revisingButton = new JButton("정보수정");
		revisingButton.setBounds(12, 5, 152, 37);
		revisingButton.addMouseListener(new ButtonDecorate());
		resignButton = new JButton("탈퇴하기");
		resignButton.setBounds(222, 5, 165, 37);
		resignButton.addMouseListener(new ButtonDecorate());
		decorateButton(exitButton);
		decorateButton(revisingButton);
		decorateButton(resignButton);
		buttonPanel.setLayout(null);
		
		buttonPanel.add(revisingButton);
		buttonPanel.add(resignButton);
		buttonPanel.setOpaque(true);
		buttonPanel.setBackground(constants.BLUE);
		backgroundPanel.setLayout(null);
		backgroundPanel.add(exitButton);
		backgroundPanel.add(buttonPanel);
		
		
		JPanel infoPanel = new JPanel();
		infoPanel.setBounds(300, 80, 476, 505);
		infoPanel.setBackground(constants.BLUE);
		backgroundPanel.add(infoPanel);
		infoPanel.setLayout(null);
		
		JLabel idLabel = new JLabel("아이디");
		idLabel.setHorizontalAlignment(SwingConstants.CENTER);
		idLabel.setBounds(40, 30, 90, 35);
		decorateTextBox(idLabel);
		infoPanel.add(idLabel);
		
		JLabel nameLabel = new JLabel("이름");
		nameLabel.setHorizontalAlignment(SwingConstants.CENTER);
		nameLabel.setBounds(40, 90, 90, 35);
		decorateTextBox(nameLabel);
		infoPanel.add(nameLabel);
		
		JLabel phoneNumberLabel = new JLabel("전화번호");
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.CENTER);
		phoneNumberLabel.setBounds(40, 210, 90, 35);
		decorateTextBox(phoneNumberLabel);
		infoPanel.add(phoneNumberLabel);
		
		JLabel emailLabel = new JLabel("이메일");
		emailLabel.setHorizontalAlignment(SwingConstants.CENTER);
		emailLabel.setBounds(40, 270, 90, 35);
		decorateTextBox(emailLabel);
		infoPanel.add(emailLabel);
		
		JLabel addressLabel = new JLabel("주소");
		addressLabel.setHorizontalAlignment(SwingConstants.CENTER);
		addressLabel.setBounds(40, 330, 90, 35);
		decorateTextBox(addressLabel);
		infoPanel.add(addressLabel);
		
		JLabel birthLabel = new JLabel("생년월일");
		birthLabel.setHorizontalAlignment(SwingConstants.CENTER);
		birthLabel.setBounds(40, 150, 90, 35);
		decorateTextBox(birthLabel);
		infoPanel.add(birthLabel);
		
		userId = new JLabel();
		userId.setBounds(145, 30, 300, 35);
		decorateUserInfo(userId);
		infoPanel.add(userId);
		
		userName = new JLabel();
		userName.setBounds(145, 90, 300, 35);
		decorateUserInfo(userName);
		infoPanel.add(userName);
		
		userBirth= new JLabel();
		userBirth.setBounds(145, 150, 300, 35);
		decorateUserInfo(userBirth);
		infoPanel.add(userBirth);
		
		userPhoneNumber = new JLabel();
		userPhoneNumber.setBounds(145, 210, 300, 35);
		decorateUserInfo(userPhoneNumber);
		infoPanel.add(userPhoneNumber);
		
		userEmail = new JLabel();
		userEmail.setBounds(145, 270, 300, 35);
		decorateUserInfo(userEmail);
		infoPanel.add(userEmail);
		
		userAddress = new JLabel();
		userAddress.setBounds(145, 330, 300, 35);
		decorateUserInfo(userAddress);
		infoPanel.add(userAddress);
		
		backgroundPanel.add(infoPanel);
		add(backgroundPanel,BorderLayout.CENTER);
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
	
	public void decorateTextBox(JLabel label) {
		label.setBackground(constants.USER_LABEL_BLUE);
		label.setForeground(constants.LIGHE_BLUE);
		label.setFont(constants.LOGIN_FONT);
		label.setHorizontalAlignment(SwingConstants.CENTER);
		label.setOpaque(true);
		label.setBorder(BorderFactory.createEmptyBorder(0, 10, 0, 10));
	}
	
	public void decorateUserInfo(JLabel label) {
		label.setBackground(constants.USER_INFO_BLUE);
		label.setForeground(Color.WHITE);
		label.setFont(constants.LOGIN_FONT);
		label.setOpaque(true);
		label.setBorder(BorderFactory.createEmptyBorder(0, 10, 0, 10));
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
			if(e.getComponent().isEnabled())
			{
				e.getComponent().setBackground(e.getComponent().getBackground().darker());
			}
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO Auto-generated method stub
			if(e.getComponent().isEnabled())
			{
				e.getComponent().setBackground(e.getComponent().getBackground().brighter());
			}
		}
	}
}
