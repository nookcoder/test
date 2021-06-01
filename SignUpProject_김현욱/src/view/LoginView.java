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
import javax.swing.text.AttributeSet;
import javax.swing.text.BadLocationException;
import javax.swing.text.PlainDocument;
import javax.swing.*;

public class LoginView extends JFrame{

	private Constants constants;
	
	// 가장 큰 패널 
	public JPanel contentPanel;
	
	// 버튼 패널 
	private JPanel buttonPanel; 
	public JButton newIdButton;
	public JButton okButton; 
	public JButton exitButton; 
	
	// 로그인 패널 
	private JPanel loginPanel; 
	private JPanel checkboxPanel;
	private JLabel serverLabel;
	private JButton player1; 
	private JButton player2; 
	private Checkbox happyServer; 
	private Checkbox dreamServer;
	public JButton findButton;
	private JPanel InputPanel;
	private JLabel id; 
	private JLabel password; 
	public JTextField idField; 
	private JPasswordField passwordField; 
	public JTextField textField;
	
	
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
		loginPanel = new JPanel() {
			@Override
			public void paintComponent(Graphics g) {
				Graphics2D g2 = (Graphics2D)g.create();
				RenderingHints qualityHints = new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
				qualityHints.put(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
				g2.setRenderingHints(qualityHints);

				g2.setPaint(new GradientPaint(new Point(0, 0), Color.orange, new Point(0, getHeight()),
						constants.DARKER_YELLOW));
				g2.fillRoundRect(0, 0, getWidth(), getHeight(), 40, 40);
				g2.dispose();
			}
		};
		loginPanel.setBounds(274, 390, 252, 148);
		
		// 서버 선택 관련 
		checkboxPanel = new JPanel() {
			@Override
			public void paintComponent(Graphics g) {
				Graphics2D g2 = (Graphics2D)g.create();
				RenderingHints qualityHints = new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
				qualityHints.put(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
				g2.setRenderingHints(qualityHints);

				g2.setPaint(new GradientPaint(new Point(0, 0), Color.GRAY, new Point(0, getHeight()),
						Color.GRAY));
				g2.fillRoundRect(0, 0, getWidth(), getHeight(), 10, 10);
				g2.dispose();
			}
		};
		checkboxPanel.setBounds(12, 10, 228, 32);
		serverLabel = new JLabel("서버 선택");
		serverLabel.setBounds(0, 5, 61, 22);
		serverLabel.setHorizontalAlignment(SwingConstants.CENTER);
		happyServer = new Checkbox("HAPPY");
		happyServer.setBounds(147, 5, 71, 22);
		dreamServer = new Checkbox("DREAM");
		dreamServer.setBounds(67, 5, 71, 22);
		happyServer.setBackground(constants.BLUE);
		dreamServer.setBackground(constants.BLUE);
		
		// 아이디 비밀번호 찾기 버튼 
		findButton = new JButton("ID/PW 찾기");
		findButton.addMouseListener(new ButtonDecorate());
		findButton.setBounds(12, 51, 228, 23);

		// 입력창 관련 
		InputPanel = new JPanel() {
			@Override
			public void paintComponent(Graphics g) {
				Graphics2D g2 = (Graphics2D)g.create();
				RenderingHints qualityHints = new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
				qualityHints.put(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
				g2.setRenderingHints(qualityHints);

				g2.setPaint(new GradientPaint(new Point(0, 0), Color.GRAY, new Point(0, getHeight()),
						Color.GRAY));
				g2.fillRoundRect(0, 0, getWidth(), getHeight(), 10, 10);
				g2.dispose();
			}
		};
		InputPanel.setBounds(12, 73, 228, 65);
		InputPanel.setLayout(null);
		InputPanel.setBackground(Color.GRAY);
		id = new JLabel("아이디");
		decorateFieldLabel(id);
		id.setBounds(10, 5, 70, 24);
		password = new JLabel("비밀번호");
		password.setHorizontalAlignment(SwingConstants.CENTER);
		decorateFieldLabel(password);
		password.setBounds(10, 34, 70, 24);
		idField = new JTextField();
		idField.setBounds(86, 5, 130, 24);
		idField.setBorder(null);
		idField.setDocument(new JTextFieldLimit(16));
		idField.addKeyListener(new FieldKeyListener());
	
		textField = new JPasswordField();
		textField.setBounds(86, 34, 130, 24);
		textField.setDocument(new JTextFieldLimit(16));
		textField.setBorder(null);
		textField.addKeyListener(new FieldKeyListener());
		
		InputPanel.add(textField);
		textField.setColumns(10);
		InputPanel.add(id);
		InputPanel.add(idField);
		InputPanel.add(password);
		loginPanel.setLayout(null);
		loginPanel.add(checkboxPanel);
		loginPanel.add(findButton);
		loginPanel.add(InputPanel);
		
		contentPanel.setLayout(null);
		checkboxPanel.setLayout(null);
		
		// 서버 component 추가
		serverLabel.setForeground(Color.WHITE);
		checkboxPanel.add(serverLabel);
		checkboxPanel.add(dreamServer);
		checkboxPanel.add(happyServer);
		checkboxPanel.setFont(constants.SERVER_FONT);
		decorateCheckBox(dreamServer);
		decorateCheckBox(happyServer);
		
		decorateButton(findButton);
		findButton.setBackground(constants.YELLOW);
		findButton.setBorder(BorderFactory.createLineBorder(Color.ORANGE, 3, true));
	
		loginPanel.setBackground(constants.YELLOW);
		
		contentPanel.add(loginPanel);
		
		// 버튼 패널 
		buttonPanel = new JPanel(); 
		buttonPanel.setBounds(238, 548, 329, 39);
		
		// 버튼 생성 
		newIdButton = new JButton("회원가입");
		okButton = new JButton("로그인");
		okButton.setEnabled(false);
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
		buttonPanel.setBackground(new Color(255,0,0,0));
		
		contentPanel.add(buttonPanel);
		getContentPane().add(contentPanel);
		player1 = new JButton();
		player2 = new JButton();
		player2.setSize(106, 129);
		player2.setLocation(526, 400);
		player1.setBounds(170, 400, 106, 129);
		player1.setIcon(constants.PLAYER1); 
		player2.setIcon(constants.PLATER2);
		player1.setBorderPainted(false);
		player2.setBorderPainted(false);

		contentPanel.add(player1);
		contentPanel.add(player2);
		setVisible(true);
	}
	
	public void decorateCheckBox(Checkbox box)
	{
		box.setFont(constants.LOGIN_FONT);
		box.setForeground(Color.WHITE);
	}
	public void decorateFieldLabel(JLabel label)
	{
		label.setHorizontalAlignment(SwingConstants.CENTER);
		label.setOpaque(true);
		label.setBackground(constants.BLUE);
		label.setForeground(Color.WHITE);
		label.setFont(constants.FIELD_LABEL_FONT);
	}
	
	public void decorateButton(JButton btn)
	{
		
		btn.setBackground(constants.BLUE);
		btn.setForeground(Color.WHITE);
		btn.setFont(constants.LOGIN_FONT);
		btn.setBorder(BorderFactory.createCompoundBorder(
				BorderFactory.createRaisedBevelBorder(),
				BorderFactory.createEmptyBorder(2, 20, 2, 20)
				));
		btn.setMargin(new Insets(5,15,5,15));
		btn.setFocusPainted(false);
	}
	
	public void setButtonListener(JButton btn,ActionListener listener)
	{
		btn.addActionListener(listener);
	}
	
	private class FieldKeyListener implements KeyListener{

		@Override
		public void keyTyped(KeyEvent e) {
			// TODO Auto-generated method stub
			
		}

		@Override
		public void keyPressed(KeyEvent e) {
			// TODO Auto-generated method stub
			int textLength;
			int idLength;
			
			textLength = textField.getText().length();
			idLength = idField.getText().length(); 
			
			if(textLength >= 4 && idLength >=4)
			{
				okButton.setEnabled(true);
			}
			
			else {
				okButton.setEnabled(false);
			}
		}

		@Override
		public void keyReleased(KeyEvent e) {
			// TODO Auto-generated method stub
			
		}
		
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
	
	public class JTextFieldLimit extends PlainDocument {
		private int limit;

		JTextFieldLimit(int limit) {
			super();
			this.limit = limit;
		}

		public void insertString( int offset, String  str, AttributeSet attr ) throws BadLocationException {
			if (str == null) return;

			if ((getLength() + str.length()) <= limit) {
				super.insertString(offset, str, attr);
			}
		}
	}
}

