package view;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

import model.Constants;

public class ResignView extends JFrame{
	
	private Constants constants; 
	
	public JPasswordField password;
	public JPasswordField passwordCheck;
	public JButton okayButton;
	public JButton cansleButton; 
	public JLabel noFind;
	
	public ResignView() {
		this.constants = new Constants();
		setResizable(false);
		
		JPanel contentPanel = new JPanel();
		contentPanel.setBackground(constants.BLUE);
		setSize(400,300);
		contentPanel.setLayout(null);
		
		okayButton = new JButton("확인");
		okayButton.setBounds(83, 230, 91, 23);
		decorateButton(okayButton);
		contentPanel.add(okayButton);
		
		JButton btnNewButton_1 = new JButton("취소");
		btnNewButton_1.setBounds(210, 230, 91, 23);
		decorateButton(btnNewButton_1);
		btnNewButton_1.addActionListener(new CansleButtonListener());
		contentPanel.add(btnNewButton_1);
		
		JLabel lblNewLabel = new JLabel("비밀번호");
		lblNewLabel.setBounds(13, 68, 110, 30);
		decorateTextBox(lblNewLabel);
		contentPanel.add(lblNewLabel);
		
		JLabel lblNewLabel_1 = new JLabel("비밀번호확인");
		lblNewLabel_1.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_1.setBounds(13, 155, 110, 30);
		decorateTextBox(lblNewLabel_1);
		contentPanel.add(lblNewLabel_1);
		
		password = new JPasswordField();
		password.setBounds(135, 155, 216, 30);
		decorateUserInfo(password);
		contentPanel.add(password);
		
		passwordCheck = new JPasswordField();
		passwordCheck.setBounds(135, 70, 216, 30);
		decorateUserInfo(passwordCheck);
		contentPanel.add(passwordCheck);

		getContentPane().add(contentPanel);
		
		noFind = new JLabel();
		noFind.setBounds(83, 195, 218, 25);
		noFind.setForeground(Color.WHITE);
		contentPanel.add(noFind);
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
	
	private class CansleButtonListener implements ActionListener{

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			setVisible(false);
		}
		
	}
}
