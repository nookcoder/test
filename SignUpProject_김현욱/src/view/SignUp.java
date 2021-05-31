package view;

import java.awt.event.ActionListener;

import javax.swing.border.AbstractBorder;
import javax.swing.border.EmptyBorder;
import javax.swing.text.AttributeSet;
import javax.swing.text.BadLocationException;
import javax.swing.text.PlainDocument;

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
	public JButton cansleButton;
	public JButton okayButton;
	public JButton idCheckButton;
	
	public JLabel idExplanation;
	public JLabel passwordExplanation;
	public JLabel passwordCheckExplanation;
	public JLabel nameExplanation;
	public JLabel birthExplanation;
	public JLabel emailExplanation;
	public JLabel addressExplanation;
	
	
	public SignUp() {
		setUndecorated(true);
		setSize(400,550);
		setResizable(false);
		setLocationRelativeTo(null);
		
		contentPane = new JPanel();
		contentPane.setBackground(constants.LIGHE_BLUE);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel topLabel = new JLabel("  크아 게임아이디 만들기");
		topLabel.setBounds(0, 0, 396, 36);
		topLabel.setHorizontalAlignment(SwingConstants.LEFT);
		topLabel.setFont(new Font("한컴 고딕",Font.BOLD,20));
		topLabel.setForeground(Color.white);
		contentPane.add(topLabel);
		
		// 아이디 입력 부분
		JPanel idPanel = new JPanel();
		idPanel.setBackground(constants.MIDDLE_BLUE);
		idPanel.setBounds(10, 35, 364, 56);
		
		JLabel idLabel = new JLabel("게임아이디");
		idExplanation = new JLabel("4~12자의 영어 소문자,숫자만 사용가능합니다");
		idCheckButton = new JButton("중복확인");
		idCheckButton.setHorizontalAlignment(SwingConstants.LEFT);
		idCheckButton.setLocation(257, 7);
		idCheckButton.setSize(104, 23);
		idExplanation.setBounds(100, 36, 255, 15);
		idExplanation.setFont(constants.EXPLANINATION_FONT);
		idLabel.setHorizontalAlignment(SwingConstants.CENTER);
		idLabel.setBounds(12, 7, 88, 23);
		
		decorateIdCheckButton(idCheckButton);
		decorateTextBox(idLabel);
		
		idField = new JTextField();
		idField.setBounds(101, 7, 157, 23);
		idField.setColumns(10);
		idField.setDocument(new JTextFieldLimit(12));
		idField.setFont(constants.EXPLANINATION_FONT);
		idPanel.setLayout(null);
		
		idPanel.add(idCheckButton);
		idPanel.add(idLabel);
		idPanel.add(idField);
		idPanel.add(idExplanation);
		
		contentPane.add(idPanel);
		
		// 비밀번호 입력 부분 
		JPanel passwordPanel = new JPanel();
		passwordPanel.setBackground(constants.MIDDLE_BLUE);
		passwordPanel.setBounds(12, 101, 362, 116);
		
		JLabel passwordLabel = new JLabel("비밀번호");
		passwordExplanation = new JLabel("8~16자 영문 대 소문자, 숫자를 사용하세요");
		passwordExplanation.setLocation(105, 32);
		passwordExplanation.setSize(234, 30);
		passwordExplanation.setFont(constants.EXPLANINATION_FONT);
		passwordLabel.setFont(new Font("한컴 고딕", Font.PLAIN, 12));
		passwordLabel.setHorizontalAlignment(SwingConstants.CENTER);
		passwordLabel.setBounds(12, 12, 88, 23);
		
		JLabel passwordCheckLabel = new JLabel("비밀번호 확인");
		passwordCheckExplanation = new JLabel("");
		passwordCheckExplanation.setLocation(105, 85);
		passwordCheckExplanation.setSize(199, 23);
		passwordCheckExplanation.setFont(constants.EXPLANINATION_FONT);
		passwordCheckLabel.setFont(new Font("한컴 고딕", Font.PLAIN, 10));
		passwordCheckLabel.setHorizontalAlignment(SwingConstants.CENTER);
		passwordCheckLabel.setBounds(12, 61, 88, 23);
		
		passwordField = new JPasswordField();
		passwordField.setColumns(10);
		passwordField.setDocument(new JTextFieldLimit(16));
		passwordField.setBounds(105, 12, 234, 23);
		passwordField.setFont(constants.SIGNUP_FONT);
		
		passwordCheckField = new JPasswordField();
		passwordCheckField.setColumns(10);
		passwordCheckField.setBounds(105, 61, 234, 23);
		passwordCheckField.setDocument(new JTextFieldLimit(16));
		passwordCheckField.setFont(constants.SIGNUP_FONT);
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
		
		JPanel userInfoPanel = new JPanel();
		userInfoPanel.setBounds(10, 227, 364, 266);
		userInfoPanel.setLayout(null);
		userInfoPanel.setBackground(constants.MIDDLE_BLUE);
		
		JLabel nameLabel = new JLabel("이름");
		JLabel nameExplanation = new JLabel("");
		nameExplanation.setBounds(105, 33, 234, 23);
		nameExplanation.setFont(constants.EXPLANINATION_FONT);
		nameLabel.setHorizontalAlignment(SwingConstants.CENTER);
		nameLabel.setBounds(12, 10, 88, 23);
		decorateTextBox(nameLabel);
		userInfoPanel.add(nameLabel);
		userInfoPanel.add(nameExplanation);
		
		JLabel birthLabel = new JLabel("생년월일");
		JLabel birthExplanation = new JLabel("주민등록번호 앞 6자리를 입력해주세요");
		birthExplanation.setLocation(105, 80);
		birthExplanation.setSize(234, 30);
		birthExplanation.setFont(constants.EXPLANINATION_FONT);
		birthLabel.setHorizontalAlignment(SwingConstants.CENTER);
		birthLabel.setBounds(12, 60, 88, 23);
		decorateTextBox(birthLabel);
		userInfoPanel.add(birthLabel);
		userInfoPanel.add(birthExplanation);
		
		JLabel phoneNumberLabel = new JLabel("전화번호");
		JLabel phoneNumberExplanation = new JLabel("\'-\' 제외한 숫자만 입력해주세요");
		phoneNumberExplanation.setLocation(105, 131);
		phoneNumberExplanation.setFont(constants.EXPLANINATION_FONT);
		phoneNumberExplanation.setSize(234, 30);
		phoneNumberLabel.setHorizontalAlignment(SwingConstants.CENTER);
		phoneNumberLabel.setBounds(12, 110, 88, 23);
		decorateTextBox(phoneNumberLabel);
		userInfoPanel.add(phoneNumberLabel);
		userInfoPanel.add(phoneNumberExplanation);
		 
		JLabel emailLabel = new JLabel("이메일");
		JLabel emailExplanation= new JLabel();
		emailExplanation.setLocation(105, 182);
		emailExplanation.setSize(234, 30);
		emailExplanation.setFont(constants.EXPLANINATION_FONT);
		emailLabel.setHorizontalAlignment(SwingConstants.CENTER);
		emailLabel.setBounds(12, 160, 88, 23);
		decorateTextBox(emailLabel);
		userInfoPanel.add(emailLabel);
		userInfoPanel.add(emailExplanation);
		
		JLabel addressLabel = new JLabel("주소");
		JLabel addressExplanation= new JLabel("");
		addressExplanation.setLocation(105, 236);
		addressExplanation.setSize(234, 30);
		addressExplanation.setFont(constants.EXPLANINATION_FONT);
		addressLabel.setHorizontalAlignment(SwingConstants.CENTER);
		addressLabel.setBounds(12, 210, 88, 23);
		decorateTextBox(addressLabel);
		userInfoPanel.add(addressLabel);
		userInfoPanel.add(addressExplanation);
		
		nameField = new JTextField();
		nameField.setColumns(10);
		nameField.setDocument(new JTextFieldLimit(4));
		nameField.setBounds(105, 10, 234, 23);
		nameField.setFont(constants.SIGNUP_FONT);
		userInfoPanel.add(nameField);
		
		birthField = new JTextField();
		birthField.setDocument(new JTextFieldLimit(6));
		birthField.setColumns(10);
		birthField.setBounds(105, 210, 234, 23);
		birthField.setFont(constants.SIGNUP_FONT);
		userInfoPanel.add(birthField);
		
		phoneNumberField = new JTextField();
		phoneNumberField.setColumns(10);
		phoneNumberField.setDocument(new JTextFieldLimit(11));
		phoneNumberField.setBounds(105, 60, 234, 23);
		phoneNumberField.setFont(constants.SIGNUP_FONT);
		userInfoPanel.add(phoneNumberField);
		
		emailField = new JTextField();
		emailField.setColumns(10);
		emailField.setBounds(105, 160, 234, 23);
		emailField.setFont(constants.SIGNUP_FONT);
		userInfoPanel.add(emailField);
		
		addressField = new JTextField();
		addressField.setColumns(10);
		addressField.setBounds(105, 110, 234, 23);
		addressField.setFont(constants.SIGNUP_FONT);
		userInfoPanel.add(addressField);
		
		contentPane.add(userInfoPanel);
		
		okayButton = new JButton("확인");
		okayButton.setBounds(98, 503, 90, 30);
		okayButton.setEnabled(false);
		contentPane.add(okayButton);
		constants.decorateButton(okayButton);
		
		cansleButton = new JButton("취소");
		cansleButton.setLocation(219, 503);
		cansleButton.setSize(90, 30);
		contentPane.add(cansleButton);
		constants.decorateButton(cansleButton);
		
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
