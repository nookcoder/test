package view;

import java.awt.event.ActionListener;

import javax.swing.border.AbstractBorder;
import javax.swing.border.EmptyBorder;

import model.Constants;

import java.awt.*;
import java.awt.geom.Area;
import java.awt.geom.*;

import javax.swing.*;

public class SignUp extends JFrame {

	private Constants constants = new Constants();
	private JPanel contentPane;
	private JLabel topLabel;
	public JTextField idField;
	public JTextField passwordField;
	public JTextField passwordCheckField;
	public JTextField nameField;
	public JTextField birthField;
	public JTextField phoneNumberField;
	public JTextField emailField;
	public JTextField addressField;

	public SignUp() {
		setSize(400,600);
		setResizable(false);
		setLocationRelativeTo(null);
		
		contentPane = new JPanel();
		contentPane.setBackground(constants.LIGHE_BLUE);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel topLabel = new JLabel("크아 게임아이디 만들기");
		topLabel.setLocation(0, 0);
		topLabel.setSize(396, 36);
		topLabel.setHorizontalAlignment(SwingConstants.LEFT);
		contentPane.add(topLabel);
		
		// 아이디 입력 부분
		JPanel idPanel = new JPanel(); 
		idPanel.setLocation(10, 31);
		idPanel.setSize(364, 51);
		
		JLabel idLabel = new JLabel("게임아이디");
		JLabel idExplanation = new JLabel("4~12자의 영어 소문자,숫자만 사용가능합니다");
		JButton idCheckButton = new JButton("중복확인");
		idCheckButton.setHorizontalAlignment(SwingConstants.LEFT);
		idCheckButton.setLocation(257, 7);
		idCheckButton.setSize(104, 23);
		
		idExplanation.setHorizontalAlignment(SwingConstants.CENTER);
		idExplanation.setBounds(22, 36, 330, 15);
		idLabel.setHorizontalAlignment(SwingConstants.CENTER);
		idLabel.setBounds(12, 7, 88, 23);
		
		decorateIdCheckButton(idCheckButton);
		decorateTextBox(idLabel);
		
		idField = new JTextField();
		idField.setBounds(101, 7, 157, 23);
		idField.setColumns(10);
		idField.setFont(constants.SIGNUP_FONT);
		idPanel.setLayout(null);
		
		idPanel.add(idCheckButton);
		idPanel.add(idLabel);
		idPanel.add(idField);
		idPanel.add(idExplanation);
		
		contentPane.add(idPanel);
		
		// 비밀번호 입력 부분 
		JPanel passwordPanel = new JPanel();
		passwordPanel.setLocation(12, 92);
		passwordPanel.setSize(362, 116);
		
		JLabel passwordLabel = new JLabel("비밀번호");
		JLabel passwordExplanation = new JLabel("8~16자 영문 대 소문자, 숫자를 사용하세요");
		passwordExplanation.setLocation(96, 28);
		passwordExplanation.setSize(234, 34);
		passwordLabel.setFont(new Font("한컴 고딕", Font.PLAIN, 12));
		passwordLabel.setHorizontalAlignment(SwingConstants.CENTER);
		passwordLabel.setBounds(12, 12, 88, 23);
		
		JLabel passwordCheckLabel = new JLabel("비밀번호 확인");
		JLabel passwordCheckExplanation = new JLabel("");
		passwordCheckExplanation.setLocation(96, 83);
		passwordCheckExplanation.setSize(199, 23);
		passwordCheckLabel.setFont(new Font("한컴 고딕", Font.PLAIN, 10));
		passwordCheckLabel.setHorizontalAlignment(SwingConstants.CENTER);
		passwordCheckLabel.setBounds(12, 61, 88, 23);
		
		passwordField = new JPasswordField();
		passwordField.setColumns(10);
		passwordField.setBounds(96, 12, 234, 23);
		
		passwordCheckField = new JPasswordField();
		passwordCheckField.setColumns(10);
		passwordCheckField.setBounds(96, 61, 234, 23);
		passwordPanel.setLayout(null);
		
		decorateTextBox(passwordLabel);
		decorateTextBox(passwordCheckLabel);
		passwordCheckLabel.setFont(new Font("한컴 고딕",Font.BOLD,11));
	
		passwordPanel.add(passwordLabel);
		passwordPanel.add(passwordField);
		passwordPanel.add(passwordLabel);
		passwordPanel.add(passwordExplanation);
		passwordPanel.add(passwordCheckExplanation);
		
		passwordPanel.add(passwordCheckLabel);
		passwordPanel.add(passwordCheckField);
		
		contentPane.add(passwordPanel);
		
		JLabel nameLabel = new JLabel("이름");
		nameLabel.setHorizontalAlignment(SwingConstants.CENTER);
		nameLabel.setFont(constants.SIGNUP_FONT);
		nameLabel.setBounds(31, 206, 71, 51);
		nameLabel.setForeground(constants.YELLOW);
		contentPane.add(nameLabel);
		
		JLabel birthLabel = new JLabel("생년월일");
		birthLabel.setHorizontalAlignment(SwingConstants.CENTER);
		birthLabel.setFont(constants.SIGNUP_FONT);
		birthLabel.setBounds(31, 267, 71, 51);
		birthLabel.setForeground(constants.YELLOW);
		contentPane.add(birthLabel);
		
		JLabel phoneNumberLabel = new JLabel("전화번호");
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.CENTER);
		phoneNumberLabel.setFont(constants.SIGNUP_FONT);
		phoneNumberLabel.setBounds(31, 328, 71, 51);
		phoneNumberLabel.setForeground(constants.YELLOW);
		contentPane.add(phoneNumberLabel);
		 
		JLabel emailLabel = new JLabel("이메일");
		emailLabel.setHorizontalAlignment(SwingConstants.CENTER);
		emailLabel.setFont(constants.SIGNUP_FONT);
		emailLabel.setForeground(constants.YELLOW);
		emailLabel.setBounds(43, 389, 59, 51);
		contentPane.add(emailLabel);
		
		JLabel addressLabel = new JLabel("주소");
		addressLabel.setHorizontalAlignment(SwingConstants.CENTER);
		addressLabel.setFont(constants.SIGNUP_FONT);
		addressLabel.setBounds(43, 450, 59, 53);
		addressLabel.setForeground(constants.YELLOW);
		contentPane.add(addressLabel);
		
		nameField = new JTextField();
		nameField.setColumns(10);
		nameField.setBounds(114, 221, 225, 36);
		nameField.setFont(constants.SIGNUP_FONT);
		contentPane.add(nameField);
		
		birthField = new JTextField();
		birthField.setColumns(10);
		birthField.setBounds(114, 274, 225, 36);
		birthField.setFont(constants.SIGNUP_FONT);
		contentPane.add(birthField);
		
		phoneNumberField = new JTextField();
		phoneNumberField.setColumns(10);
		phoneNumberField.setBounds(114, 335, 225, 36);
		phoneNumberField.setFont(constants.SIGNUP_FONT);
		contentPane.add(phoneNumberField);
		
		emailField = new JTextField();
		emailField.setColumns(10);
		emailField.setBounds(114, 396, 225, 36);
		emailField.setFont(constants.SIGNUP_FONT);
		contentPane.add(emailField);
		
		addressField = new JTextField();
		addressField.setColumns(10);
		addressField.setBounds(114, 458, 225, 36);
		addressField.setFont(constants.SIGNUP_FONT);
		contentPane.add(addressField);
		
		JButton okayButton = new JButton("OK");
		okayButton.setBounds(161, 519, 91, 23);
		okayButton.setBackground(constants.LIGHE_BLUE);
		okayButton.setForeground(constants.YELLOW);
		contentPane.add(okayButton);
	}
	
	public void decorateIdCheckButton(JButton btn)
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
		label.setBackground(constants.BLUE);
		label.setForeground(constants.LIGHE_BLUE);
		label.setFont(constants.LOGIN_FONT);
		label.setHorizontalAlignment(SwingConstants.CENTER);
		label.setOpaque(true);
		label.setBorder(BorderFactory.createEmptyBorder(2, 10, 2, 10));
	}
	
	// 텍스트 필드 값 받아오기 
	public String getId() {
		return idField.getText();
	}
	public String getPassword() {
		return passwordField.getText();
	}
	public String getPasswordCheck() {
		return passwordCheckField.getText();
	}
	public String getName() {
		return nameField.getText();
	}
	public String getBirth() {
		return birthField.getText();
	}
	public String getPhoneNumber() {
		return phoneNumberField.getText();
	}
	public String getEmail() {
		return emailField.getText();
	}
	public String getAddress() {
		return addressField.getText();
	}

	// 이벤트 등록 
	public void setIdListener(ActionListener listener)
	{
		idField.addActionListener(listener);
	}
	public void setPasswordListener(ActionListener listener)
	{
		passwordField.addActionListener(listener);
	}
	public void setPasswordChekcListener(ActionListener listener)
	{
		passwordCheckField.addActionListener(listener);
	}
	public void setNameListener(ActionListener listener)
	{
		nameField.addActionListener(listener);
	}
	public void setBirthListener(ActionListener listener)
	{
		birthField.addActionListener(listener);
	}
	public void setPhoneNumberListener(ActionListener listener)
	{
		phoneNumberField.addActionListener(listener);
	}
	public void setEmailListener(ActionListener listener)
	{
		emailField.addActionListener(listener);
	}
	public void setAddressListener(ActionListener listener)
	{
		addressField.addActionListener(listener);
	}
	
	
	
	
	private class RoundedCornerBorder extends AbstractBorder {
		private Color ALPHA_ZERO = new Color(0x0, true);
		@Override 
		public void paintBorder(Component c, Graphics g, int x, int y, int width, int height) {
			Graphics2D g2 = (Graphics2D) g.create();
			g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
			Shape border = getBorderShape(x, y, width - 1, height - 1);
			g2.setPaint(ALPHA_ZERO);
			Area corner = new Area(new Rectangle2D.Double(x, y, width, height));
			corner.subtract(new Area(border));
			g2.fill(corner);
			g2.setPaint(Color.GRAY);
			g2.draw(border);
			g2.dispose();
		}
		public Shape getBorderShape(int x, int y, int w, int h) {
			int r = h; //h / 2;
			return new RoundRectangle2D.Double(x, y, w, h, r, r);
		}
		@Override public Insets getBorderInsets(Component c) {
			return new Insets(4, 8, 4, 8);
		}
		@Override public Insets getBorderInsets(Component c, Insets insets) {
			insets.set(4, 8, 4, 8);
			return insets;
		}
	}
	
}
