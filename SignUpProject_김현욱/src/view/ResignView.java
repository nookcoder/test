package view;

import java.awt.*;

import javax.swing.*;

import model.Constants;

public class ResignView extends JFrame{
	
	private Constants constants; 
	
	public JPasswordField password;
	public JPasswordField passwordCheck;
	public JButton okayButton;
	public JButton cansleButton;
	private JPasswordField passwordField;
	private JPasswordField passwordField_1;
	
	public ResignView() {
		this.constants = new Constants();
		
		getContentPane().setBackground(constants.BLUE);
		setSize(400,300);
		getContentPane().setLayout(null);
		
		JButton btnNewButton = new JButton("확인");
		btnNewButton.setBounds(83, 230, 91, 23);
		decorateButton(btnNewButton);
		getContentPane().add(btnNewButton);
		
		JButton btnNewButton_1 = new JButton("취소");
		btnNewButton_1.setBounds(210, 230, 91, 23);
		decorateButton(btnNewButton_1);
		getContentPane().add(btnNewButton_1);
		
		JLabel lblNewLabel = new JLabel("비밀번호");
		lblNewLabel.setBounds(23, 68, 100, 30);
		decorateTextBox(lblNewLabel);
		getContentPane().add(lblNewLabel);
		
		JLabel lblNewLabel_1 = new JLabel("비밀번호 확인");
		lblNewLabel_1.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_1.setBounds(23, 155, 100, 30);
		decorateTextBox(lblNewLabel_1);
		getContentPane().add(lblNewLabel_1);
		
		passwordField = new JPasswordField();
		passwordField.setBounds(135, 155, 216, 30);
		decorateUserInfo(passwordField);
		getContentPane().add(passwordField);
		
		passwordField_1 = new JPasswordField();
		passwordField_1.setBounds(135, 70, 216, 30);
		decorateUserInfo(passwordField_1);
		getContentPane().add(passwordField_1);

		
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
	
	public void decorateUserInfo(JPasswordField label) {
		label.setBackground(constants.USER_INFO_BLUE);
		label.setForeground(Color.WHITE);
		label.setFont(constants.LOGIN_FONT);
		label.setOpaque(true);
		label.setBorder(BorderFactory.createEmptyBorder(0, 10, 0, 10));
	}
}
