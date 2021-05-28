package view;

import java.awt.*;

import javax.swing.*;

public class SignUp extends JFrame{

	private JPanel signUpPanel; 
	private JPanel idPanel;
	private JPanel passwordPanel;
	private JPanel passwordCheckPanel;
	private JPanel namePanel;
	private JPanel birthPanel;
	private JPanel phoneNumberPanel;
	private JPanel emailPanel;
	private JPanel addressPanel;
	
	private JTextField idField;
	private JTextField passwordField;
	private JTextField passwordCheckField;
	private JTextField nameField;
	private JTextField birthField;
	private JTextField phoneNumberField;
	private JTextField emailField;
	private JTextField addressField;
	
	private JLabel idLabel; 
	private JLabel passwordLabel; 
	private JLabel passwordCheckLabel; 
	private JLabel nameLabel; 
	private JLabel birthLabel; 
	private JLabel phoneNumberLabel; 
	private JLabel emailLabel; 
	private JLabel addressLabel; 
	
	
	public SignUp() {
		
		this.signUpPanel = new JPanel();
		
		this.idPanel = new JPanel();
		this.passwordPanel = new JPanel();
		this.passwordCheckPanel = new JPanel();
		this.namePanel = new JPanel();
		this.birthPanel = new JPanel();
		this.phoneNumberPanel = new JPanel();
		this.emailPanel = new JPanel();
		this.addressPanel = new JPanel();
		
		this.idField = new JTextField();
		this.passwordField = new JTextField();
		this.passwordCheckField = new JTextField();
		this.nameField = new JTextField();
		this.birthField = new JTextField();
		this.phoneNumberField = new JTextField();
		this.emailField = new JTextField();
		this.addressField = new JTextField();

		this.idLabel = new JLabel("아이디:");
		this.passwordLabel = new JLabel("비밀번호:");
		this.passwordCheckLabel = new JLabel("비밀번호 확인:");
		this.nameLabel = new JLabel("이름:");
		this.birthLabel = new JLabel("생년월일:");
		this.phoneNumberLabel = new JLabel("전화번호:");
		this.emailLabel = new JLabel("이메일:");
		this.addressLabel = new JLabel("주소:");
		
		setPanelLayout(idPanel,idField,idLabel);
		setPanelLayout(passwordPanel,passwordField,passwordLabel);
		setPanelLayout(passwordCheckPanel,passwordCheckField,passwordCheckLabel);
		setPanelLayout(namePanel,nameField,nameLabel);
		setPanelLayout(birthPanel,birthField,birthLabel);
		setPanelLayout(phoneNumberPanel,phoneNumberField,phoneNumberLabel);
		setPanelLayout(emailPanel,emailField,emailLabel);
		setPanelLayout(addressPanel,addressField,addressLabel);
		
		signUpPanel.setLayout(new GridLayout(8,0));
		
		add(signUpPanel);
		
		setTitle("회원 가입");
		setSize(600,600);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		setVisible(true);
	}
	
	public void setPanelLayout(JPanel panel, JTextField textfield, JLabel label)
	{
		panel.setLayout(new BorderLayout());
		panel.add(textfield,BorderLayout.CENTER);
		panel.add(label,BorderLayout.WEST);
		signUpPanel.add(panel);
	}
}
