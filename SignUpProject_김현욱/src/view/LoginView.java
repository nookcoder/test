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
	
	// 로그인 패널 
	private JPanel loginPanel; 
	private JPanel checkboxPanel;
	private JLabel serverLabel;
	private JButton player1; 
	private JButton player2; 
	private Checkbox happyServer; 
	private Checkbox dreamServer;
	private JButton findButton;
	private JPanel InputPanel;
	private JLabel id; 
	private JLabel password; 
	private JTextField idField; 
	private JPasswordField passwordField; 
	private JTextField textField;
	
	
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

		// 로그인 영역 
		loginPanel = new JPanel();
		loginPanel.setBounds(274, 369, 252, 169);
		loginPanel.setBorder(new LineBorder(new Color(0, 0, 0)));
		checkboxPanel = new JPanel();
		checkboxPanel.setBounds(28, 35, 199, 32);
		serverLabel = new JLabel("멀티서버 선택");
		serverLabel.setHorizontalAlignment(SwingConstants.CENTER);
		serverLabel.setBounds(74, 0, 114, 29);
		player1= new JButton(constants.PLAYER1);
		player2 = new JButton(constants.PLATER2);
		happyServer = new Checkbox(" HAPPY");
		happyServer.setBounds(103, 5, 96, 22);
		dreamServer = new Checkbox(" DREAM");
		dreamServer.setBounds(10, 5, 96, 22);
		InputPanel = new JPanel();
		InputPanel.setBounds(12, 94, 228, 65);
		findButton = new JButton("ID/PW 찾기");
		findButton.setBounds(48, 71, 166, 23);
		id = new JLabel("I             D");
		id.setBounds(12, 8, 62, 15);
		password = new JLabel("PASSWORD");
		password.setBounds(12, 40, 68, 15);
		idField = new JTextField();
		idField.setBounds(86, 5, 130, 21);
		passwordField = new JPasswordField();
		passwordField.setBounds(0, 20, 52, -20);
		contentPanel.setLayout(null);
		checkboxPanel.setLayout(null);
		
		// 서버 component 추가
		serverLabel.setForeground(Color.WHITE);
		serverLabel.setFont(constants.LOGIN_FONT);
		checkboxPanel.add(dreamServer);
		checkboxPanel.add(happyServer);
		checkboxPanel.setFont(constants.LOGIN_FONT);
		InputPanel.setLayout(null);
		
		decorateButton(findButton);
		findButton.setBackground(constants.YELLOW);
		findButton.setBorder(BorderFactory.createLineBorder(Color.ORANGE, 3, true));
		
		InputPanel.add(id);
		InputPanel.add(idField);
		InputPanel.add(password);
		InputPanel.add(passwordField);
		loginPanel.setLayout(null);
		loginPanel.add(serverLabel);
		loginPanel.add(checkboxPanel);
		loginPanel.add(findButton);
		loginPanel.add(InputPanel);
		loginPanel.add(player1);
		loginPanel.add(player2);
		
		textField = new JPasswordField();
		textField.setBounds(86, 37, 130, 21);
		InputPanel.add(textField);
		textField.setColumns(10);
		loginPanel.setBackground(constants.YELLOW);
		
		contentPanel.add(loginPanel);
		
		// 버튼 패널 
		buttonPanel = new JPanel(); 
		buttonPanel.setBounds(238, 548, 329, 39);
		
		// 버튼 생성 
		newIdButton = new JButton("회원가입");
		okButton = new JButton("로그인");
		exitButton = new JButton("종 료");
		decorateButton(newIdButton);
		decorateButton(okButton);
		decorateButton(exitButton);
		newIdButton.addMouseListener(new ButtonDecorate()); 
		okButton.addMouseListener(new ButtonDecorate());
		exitButton.addMouseListener(new ButtonDecorate());
		
		buttonPanel.add(newIdButton);
		buttonPanel.add(okButton);
		buttonPanel.add(exitButton);
		buttonPanel.setLayout(new FlowLayout(FlowLayout.CENTER));
		
		contentPanel.add(buttonPanel);
		getContentPane().add(contentPanel);
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
	
	public void setEventListener(JButton btn,MouseListener listener)
	{
		btn.addMouseListener(listener);
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
			e.getComponent().setBackground(e.getComponent().getBackground().brighter());
		}
	}
}

